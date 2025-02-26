using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection.Emit;

namespace ChillLancer.Repository
{
    public class ChillLancerDbContext : DbContext
    {
        /**/
        /**/
        /*Uncomment after migration to use with Dependency Injection*/

        //============[ Constructor ]============
        public ChillLancerDbContext() { }
        public ChillLancerDbContext(DbContextOptions<ChillLancerDbContext> options) : base(options) { }


        //Declare Object
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RateCode> RateCodes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<ProjectContract> ProjectContracts { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<AccountLanguage> AccountLanguages { get; set; }
        public virtual DbSet<ProjectSkill> ProjectSkills { get; set; }
        public virtual DbSet<ProposalSkill> ProposalSkills { get; set; }
        public virtual DbSet<ProposalImage> ProposalImages { get; set; }

        private string GetConnectionString()
        {
            string root = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName ?? "";
            string apiDirectory = Path.Combine(root, "ChillLancer.API");

            // Lấy giá trị môi trường từ biến môi trường (mặc định là Development nếu không có)
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            // Tạo builder cấu hình và thêm các file appsettings tùy theo môi trường
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(apiDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true) // Tải file môi trường
                .Build();

            return configuration["ConnectionStrings:LocalSQL"]!;
        }

        /**/
        /**/
        //Comment Method OnConfiguring(...) after migration to avoid conflic in Dependency Injection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString())
                          .LogTo(Console.WriteLine, LogLevel.Information)  // Ghi log truy vấn
                          .EnableSensitiveDataLogging();  // Hiển thị tham số truy vấn
        }

        /**/
        /**/

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Account>(entity =>
            {
                entity.HasMany(a => a.Certifications)
                .WithOne(cer => cer.Freelancer)
                .HasForeignKey("FreelancerId");

                entity.HasMany(a => a.Educations)
                .WithOne(edu => edu.Freelancer)
                .HasForeignKey("FreelancerId");

                entity.HasMany(a => a.AccountLanguages)
                .WithOne(al => al.Account)
                .HasForeignKey("AccountId");

                entity.HasMany(a => a.ProjectContracts)
                .WithOne(projCon => projCon.Freelancer)
                .HasForeignKey("FreelancerId");

                entity.HasMany(a => a.Projects)
                .WithOne(proj => proj.Employer)
                .HasForeignKey("EmployerId");

                entity.HasMany(a => a.Proposals)
                .WithOne(prop => prop.Freelancer)
                .HasForeignKey("FreelancerId");
            });

            optionsBuilder.Entity<AccountLanguage>(entity =>
            {
                entity.HasKey(al => new { al.AccountId, al.LanguageId });

                entity.HasOne(al => al.Account)
                .WithMany(a => a.AccountLanguages)
                .HasForeignKey(al => al.AccountId);

                entity.HasOne(al => al.Language)
                .WithMany(lang => lang.AccountLanguages)
                .HasForeignKey(al => al.LanguageId);
            });

            optionsBuilder.Entity<RateCode>(entity =>
            {
                entity.Property(raco => raco.Percentage).HasColumnType("DECIMAL(5,2)");

                entity.HasMany(raco => raco.SystemFeeTransactions)
                .WithOne(sysfeeTran => sysfeeTran.SystemFee)
                .HasForeignKey("SystemFeeId");

                entity.HasMany(raco => raco.PromotionTransactions)
                .WithOne(promoTran => promoTran.Promotion)
                .HasForeignKey("PromotionId");
            });

            optionsBuilder.Entity<Package>(entity => {
                entity.Property(p => p.Price).HasColumnType("MONEY");

                entity.HasMany(pack => pack.Transactions)
                .WithOne(trans => trans.Package)
                .HasForeignKey("PackageId");
            });

            optionsBuilder.Entity<ProjectContract>(entity =>
            {
                entity.Property(projCon => projCon.TotalPay).HasColumnType("MONEY");
                entity.Property(projCon => projCon.Paid).HasColumnType("MONEY");

                entity.HasOne(projCon => projCon.Project)
                .WithMany(proj => proj.ProjectContracts)
                .HasForeignKey("ProjectId");

                entity.HasOne(projCon => projCon.Transaction)
                .WithMany(trans => trans.ProjectContracts)
                .HasForeignKey("TransactionId");

                entity.HasMany(projCon => projCon.Processes)
                .WithOne(proces => proces.ProjectContract)
                .HasForeignKey("ProjectContractId");
            });

            optionsBuilder.Entity<Process>().Property(proc => proc.Cost).HasColumnType("MONEY");
            optionsBuilder.Entity<Project>().Property(proj => proj.Budget).HasColumnType("MONEY");

            optionsBuilder.Entity<ProjectSkill>(entity =>
            {
                entity.HasKey(projskil => new { projskil.ProjectId, projskil.SkillId });

                entity.HasOne(projskil => projskil.Project)
                .WithMany(proj => proj.ProjectSkills)
                .HasForeignKey(proj => proj.ProjectId);

                entity.HasOne(projskil => projskil.Skill)
                .WithMany(ski => ski.ProjectSkills)
                .HasForeignKey(ski => ski.SkillId);
            });

            optionsBuilder.Entity<Proposal>(entity =>
            {
                entity.Property(prop => prop.Price).HasColumnType("MONEY");

                entity.HasOne(prop => prop.Project)
                .WithMany(proj => proj.Proposals)
                .HasForeignKey("ProjectId");

                entity.HasMany(prop => prop.ProposalSkills)
                .WithOne(propS => propS.Proposal)
                .HasForeignKey(propS => propS.ProposalId);

                entity.HasMany(cat => cat.ProposalImages)
                .WithOne(propI => propI.Proposal)
                .HasForeignKey(propI => propI.ProposalId);
            });

            optionsBuilder.Entity<ProposalSkill>(entity =>
            {
                entity.HasKey(propskil => new { propskil.ProposalId, propskil.SkillId });

                entity.HasOne(propskil => propskil.Proposal)
                .WithMany(prop => prop.ProposalSkills)
                .HasForeignKey(prop => prop.ProposalId);

                entity.HasOne(propskil => propskil.Skill)
                .WithMany(ski => ski.ProposalSkill)
                .HasForeignKey(ski => ski.SkillId);
            });

            optionsBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(cat => cat.Projects)
                .WithOne(proj => proj.Category)
                .HasForeignKey("CategoryId");

                entity.HasMany(cat => cat.Proposals)
                .WithOne(prop => prop.Category)
                .HasForeignKey("CategoryId");
            });


            optionsBuilder.Entity<ProposalImage>(entity =>
            {
                entity.HasKey(propImg => new { propImg.ProposalId, propImg.ImageId });

                entity.HasOne(propImg => propImg.Proposal)
                .WithMany(prop => prop.ProposalImages)
                .HasForeignKey(propImg => propImg.ProposalId);

                entity.HasOne(propImg => propImg.Image)
                .WithMany(img => img.ProposalImages)
                .HasForeignKey(propImg => propImg.ImageId);
            });

            optionsBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(trans => trans.FeePrice).HasColumnType("MONEY");
                entity.Property(trans => trans.TotalPrice).HasColumnType("MONEY");

                entity.HasOne(trans => trans.Freelancer)
                .WithMany(frel => frel.TransactionsAsFreelancer)
                .HasForeignKey("FreelancerId");

                entity.HasOne(trans => trans.Employer)
                .WithMany(emp => emp.TransactionsAsEmployer)
                .HasForeignKey("EmployerId");
            });

            optionsBuilder.Entity<Language>().HasData(GetLanguages());
            optionsBuilder.Entity<Category>().HasData(GetCategorys());
        }

        //=================================[ Data ]=================================
        private List<Language> GetLanguages()
        {
            return new List<Language>{
                new Language { Name = "Afrikaans" },
                new Language { Name = "Albanian" },
                new Language { Name = "Amharic" },
                new Language { Name = "Arabic" },
                new Language { Name = "Armenian" },
                new Language { Name = "Azerbaijani" },
                new Language { Name = "Basque" },
                new Language { Name = "Belarusian" },
                new Language { Name = "Bengali" },
                new Language { Name = "Bosnian" },
                new Language { Name = "Bulgarian" },
                new Language { Name = "Burmese" },
                new Language { Name = "Catalan" },
                new Language { Name = "Cebuano" },
                new Language { Name = "Chichewa" },
                new Language { Name = "Chinese" },
                new Language { Name = "Corsican" },
                new Language { Name = "Croatian" },
                new Language { Name = "Czech" },
                new Language { Name = "Danish" },
                new Language { Name = "Dutch" },
                new Language { Name = "English" },
                new Language { Name = "Esperanto" },
                new Language { Name = "Estonian" },
                new Language { Name = "Filipino" },
                new Language { Name = "Finnish" },
                new Language { Name = "French" },
                new Language { Name = "Galician" },
                new Language { Name = "Georgian" },
                new Language { Name = "German" },
                new Language { Name = "Greek" },
                new Language { Name = "Gujarati" },
                new Language { Name = "Haitian Creole" },
                new Language { Name = "Hausa" },
                new Language { Name = "Hawaiian" },
                new Language { Name = "Hebrew" },
                new Language { Name = "Hindi" },
                new Language { Name = "Hmong" },
                new Language { Name = "Hungarian" },
                new Language { Name = "Icelandic" },
                new Language { Name = "Igbo" },
                new Language { Name = "Indonesian" },
                new Language { Name = "Irish" },
                new Language { Name = "Italian" },
                new Language { Name = "Japanese" },
                new Language { Name = "Javanese" },
                new Language { Name = "Kannada" },
                new Language { Name = "Kazakh" },
                new Language { Name = "Khmer" },
                new Language { Name = "Kinyarwanda" },
                new Language { Name = "Korean" },
                new Language { Name = "Kurdish" },
                new Language { Name = "Kyrgyz" },
                new Language { Name = "Lao" },
                new Language { Name = "Latin" },
                new Language { Name = "Latvian" },
                new Language { Name = "Lithuanian" },
                new Language { Name = "Luxembourgish" },
                new Language { Name = "Macedonian" },
                new Language { Name = "Malagasy" },
                new Language { Name = "Malay" },
                new Language { Name = "Malayalam" },
                new Language { Name = "Maltese" },
                new Language { Name = "Maori" },
                new Language { Name = "Marathi" },
                new Language { Name = "Mongolian" },
                new Language { Name = "Nepali" },
                new Language { Name = "Norwegian" },
                new Language { Name = "Pashto" },
                new Language { Name = "Persian" },
                new Language { Name = "Polish" },
                new Language { Name = "Portuguese" },
                new Language { Name = "Punjabi" },
                new Language { Name = "Romanian" },
                new Language { Name = "Russian" },
                new Language { Name = "Samoan" },
                new Language { Name = "Scots Gaelic" },
                new Language { Name = "Serbian" },
                new Language { Name = "Sesotho" },
                new Language { Name = "Shona" },
                new Language { Name = "Sindhi" },
                new Language { Name = "Sinhala" },
                new Language { Name = "Slovak" },
                new Language { Name = "Slovenian" },
                new Language { Name = "Somali" },
                new Language { Name = "Spanish" },
                new Language { Name = "Sundanese" },
                new Language { Name = "Swahili" },
                new Language { Name = "Swedish" },
                new Language { Name = "Tajik" },
                new Language { Name = "Tamil" },
                new Language { Name = "Tatar" },
                new Language { Name = "Telugu" },
                new Language { Name = "Thai" },
                new Language { Name = "Turkish" },
                new Language { Name = "Turkmen" },
                new Language { Name = "Ukrainian" },
                new Language { Name = "Urdu" },
                new Language { Name = "Uyghur" },
                new Language { Name = "Uzbek" },
                new Language { Name = "Vietnamese" },
                new Language { Name = "Welsh" },
                new Language { Name = "Xhosa" },
                new Language { Name = "Yiddish" },
                new Language { Name = "Yoruba" },
                new Language { Name = "Zulu" }
            };
        }

        private List<Category> GetCategorys()
        {
            return new List<Category>
            {
                new Category { MajorName = "Graphics & Design", BriefName = "Logo & Brand Identity", SpecializedName = "Logo Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Logo & Brand Identity", SpecializedName = "Brand Style Guides"},
                new Category { MajorName = "Graphics & Design", BriefName = "Logo & Brand Identity", SpecializedName = "Business Cards & Stationery"},
                new Category { MajorName = "Graphics & Design", BriefName = "Logo & Brand Identity", SpecializedName = "Fonts & Typography"},
                new Category { MajorName = "Graphics & Design", BriefName = "Logo & Brand Identity", SpecializedName = "Logo Maker Tool"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "Illustration"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "AI Artists"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "AI Avatar Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "Children's Book Illustration"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "Portraits & Caricatures"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "Cartoons & Comics"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "Pattern Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "Tattoo Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "Storyboards"},
                new Category { MajorName = "Graphics & Design", BriefName = "Art & Illustration", SpecializedName = "NFT Art"},
                new Category { MajorName = "Graphics & Design", BriefName = "Miscellaneous", SpecializedName = "Design Advice"},
                new Category { MajorName = "Graphics & Design", BriefName = "Web & App Design", SpecializedName = "Website Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Web & App Design", SpecializedName = "App Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Web & App Design", SpecializedName = "UX Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Web & App Design", SpecializedName = "Landing Page Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Web & App Design", SpecializedName = "Icon Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Product & Gaming", SpecializedName = "Industrial & Product Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Product & Gaming", SpecializedName = "Character Modeling"},
                new Category { MajorName = "Graphics & Design", BriefName = "Product & Gaming", SpecializedName = "Game Art"},
                new Category { MajorName = "Graphics & Design", BriefName = "Product & Gaming", SpecializedName = "Graphics for Streamers"},
                new Category { MajorName = "Graphics & Design", BriefName = "Print Design", SpecializedName = "Flyer Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Print Design", SpecializedName = "Brochure Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Print Design", SpecializedName = "Poster Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Print Design", SpecializedName = "Catalog Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Print Design", SpecializedName = "Menu Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Visual Design", SpecializedName = "Image Editing"},
                new Category { MajorName = "Graphics & Design", BriefName = "Visual Design", SpecializedName = "AI Image Editing"},
                new Category { MajorName = "Graphics & Design", BriefName = "Visual Design", SpecializedName = "Presentation Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Visual Design", SpecializedName = "Background Removal"},
                new Category { MajorName = "Graphics & Design", BriefName = "Visual Design", SpecializedName = "Infographic Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Visual Design", SpecializedName = "Vector Tracing"},
                new Category { MajorName = "Graphics & Design", BriefName = "Visual Design", SpecializedName = "Resume Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Marketing Design", SpecializedName = "Social Media Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Marketing Design", SpecializedName = "Social Posts & Banners"},
                new Category { MajorName = "Graphics & Design", BriefName = "Marketing Design", SpecializedName = "Email Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Marketing Design", SpecializedName = "Web Banners"},
                new Category { MajorName = "Graphics & Design", BriefName = "Marketing Design", SpecializedName = "Signage Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Packaging & Covers", SpecializedName = "Packaging & Label Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Packaging & Covers", SpecializedName = "Book Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Packaging & Covers", SpecializedName = "Book Covers"},
                new Category { MajorName = "Graphics & Design", BriefName = "Packaging & Covers", SpecializedName = "Album Cover Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Architecture & Building Design", SpecializedName = "Architecture & Interior Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Architecture & Building Design", SpecializedName = "Landscape Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Architecture & Building Design", SpecializedName = "Building Engineering"},
                new Category { MajorName = "Graphics & Design", BriefName = "Architecture & Building Design", SpecializedName = "Lighting Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Fashion & Merchandise", SpecializedName = "T-Shirts & Merchandise"},
                new Category { MajorName = "Graphics & Design", BriefName = "Fashion & Merchandise", SpecializedName = "Fashion Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "Fashion & Merchandise", SpecializedName = "Jewelry Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "3D Design", SpecializedName = "3D Architecture"},
                new Category { MajorName = "Graphics & Design", BriefName = "3D Design", SpecializedName = "3D Industrial Design"},
                new Category { MajorName = "Graphics & Design", BriefName = "3D Design", SpecializedName = "3D Fashion & Garment"},
                new Category { MajorName = "Graphics & Design", BriefName = "3D Design", SpecializedName = "3D Printing Characters"},
                new Category { MajorName = "Graphics & Design", BriefName = "3D Design", SpecializedName = "3D Landscape"},
                new Category { MajorName = "Graphics & Design", BriefName = "3D Design", SpecializedName = "3D Game Art"},
                new Category { MajorName = "Graphics & Design", BriefName = "3D Design", SpecializedName = "3D Jewelry Design"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Development", SpecializedName = "Business Websites"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Development", SpecializedName = "E-Commerce Development"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Development", SpecializedName = "Landing Pages"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Development", SpecializedName = "Dropshipping Websites"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Development", SpecializedName = "Build a Complete Website"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Platforms", SpecializedName = "WordPress"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Platforms", SpecializedName = "Shopify"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Platforms", SpecializedName = "Wix"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Platforms", SpecializedName = "Custom Websites"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Platforms", SpecializedName = "GoDaddy"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Maintenance", SpecializedName = "Website Customization"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Maintenance", SpecializedName = "Bug Fixes"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Maintenance", SpecializedName = "Backup & Migration"},
                new Category { MajorName = "Programming & Tech", BriefName = "Website Maintenance", SpecializedName = "Speed Optimization"},
                new Category { MajorName = "Programming & Tech", BriefName = "AI Development", SpecializedName = "AI Websites & Software"},
                new Category { MajorName = "Programming & Tech", BriefName = "AI Development", SpecializedName = "AI Mobile Apps"},
                new Category { MajorName = "Programming & Tech", BriefName = "AI Development", SpecializedName = "AI Integrations"},
                new Category { MajorName = "Programming & Tech", BriefName = "AI Development", SpecializedName = "AI Agents"},
                new Category { MajorName = "Programming & Tech", BriefName = "AI Development", SpecializedName = "AI Fine-Tuning"},
                new Category { MajorName = "Programming & Tech", BriefName = "AI Development", SpecializedName = "AI Technology Consulting"},
                new Category { MajorName = "Programming & Tech", BriefName = "Chatbot Development", SpecializedName = "AI Chatbot"},
                new Category { MajorName = "Programming & Tech", BriefName = "Chatbot Development", SpecializedName = "Rules Based Chatbot"},
                new Category { MajorName = "Programming & Tech", BriefName = "Chatbot Development", SpecializedName = "Discord"},
                new Category { MajorName = "Programming & Tech", BriefName = "Chatbot Development", SpecializedName = "Telegram"},
                new Category { MajorName = "Programming & Tech", BriefName = "Game Development", SpecializedName = "Gameplay Experience & Feedback"},
                new Category { MajorName = "Programming & Tech", BriefName = "Game Development", SpecializedName = "PC Games"},
                new Category { MajorName = "Programming & Tech", BriefName = "Game Development", SpecializedName = "Mobile Games"},
                new Category { MajorName = "Programming & Tech", BriefName = "Mobile App Development", SpecializedName = "Cross-platform Development"},
                new Category { MajorName = "Programming & Tech", BriefName = "Mobile App Development", SpecializedName = "Android App Development"},
                new Category { MajorName = "Programming & Tech", BriefName = "Mobile App Development", SpecializedName = "iOS App Development"},
                new Category { MajorName = "Programming & Tech", BriefName = "Mobile App Development", SpecializedName = "Website to App"},
                new Category { MajorName = "Programming & Tech", BriefName = "Mobile App Development", SpecializedName = "Mobile App Maintenance"},
                new Category { MajorName = "Programming & Tech", BriefName = "Mobile App Development", SpecializedName = "VR & AR Development"},
                new Category { MajorName = "Programming & Tech", BriefName = "Cloud & Cybersecurity ", SpecializedName = "Cloud Computing"},
                new Category { MajorName = "Programming & Tech", BriefName = "Cloud & Cybersecurity ", SpecializedName = "DevOps Engineering"},
                new Category { MajorName = "Programming & Tech", BriefName = "Cloud & Cybersecurity ", SpecializedName = "Cybersecurity"},
                new Category { MajorName = "Programming & Tech", BriefName = "Data Science & ML", SpecializedName = "Machine Learning"},
                new Category { MajorName = "Programming & Tech", BriefName = "Data Science & ML", SpecializedName = "Computer Vision"},
                new Category { MajorName = "Programming & Tech", BriefName = "Data Science & ML", SpecializedName = "NLP"},
                new Category { MajorName = "Programming & Tech", BriefName = "Data Science & ML", SpecializedName = "Deep Learning"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "Web Applications"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "Desktop Applications"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "Automations & Workflows"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "APIs & Integrations"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "Databases"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "Scripting"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "QA & Review"},
                new Category { MajorName = "Programming & Tech", BriefName = "Software Development", SpecializedName = "User Testing"},
                new Category { MajorName = "Programming & Tech", BriefName = "Blockchain & Cryptocurrency", SpecializedName = "Decentralized Apps (dApps)"},
                new Category { MajorName = "Programming & Tech", BriefName = "Blockchain & Cryptocurrency", SpecializedName = "Cryptocurrencies & Tokens"},
                new Category { MajorName = "Programming & Tech", BriefName = "Blockchain & Cryptocurrency", SpecializedName = "Exchange Platforms"},
                new Category { MajorName = "Programming & Tech", BriefName = "Miscellaneous", SpecializedName = "Electronics Engineering"},
                new Category { MajorName = "Programming & Tech", BriefName = "Miscellaneous", SpecializedName = "Support & IT"},
                new Category { MajorName = "Programming & Tech", BriefName = "Miscellaneous", SpecializedName = "Discord Server Setup"},
                new Category { MajorName = "Programming & Tech", BriefName = "Miscellaneous", SpecializedName = "Convert Files"},
                new Category { MajorName = "Digital Marketing", BriefName = "Search", SpecializedName = "Search Engine Optimization (SEO)"},
                new Category { MajorName = "Digital Marketing", BriefName = "Search", SpecializedName = "Search Engine Marketing (SEM)"},
                new Category { MajorName = "Digital Marketing", BriefName = "Search", SpecializedName = "Local SEO"},
                new Category { MajorName = "Digital Marketing", BriefName = "Search", SpecializedName = "E-Commerce SEO"},
                new Category { MajorName = "Digital Marketing", BriefName = "Search", SpecializedName = "Video SEO"},
                new Category { MajorName = "Digital Marketing", BriefName = "Social", SpecializedName = "Social Media Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Social", SpecializedName = "Paid Social Media"},
                new Category { MajorName = "Digital Marketing", BriefName = "Social", SpecializedName = "Social Commerce "},
                new Category { MajorName = "Digital Marketing", BriefName = "Social", SpecializedName = "Influencer Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Social", SpecializedName = "Community Management"},
                new Category { MajorName = "Digital Marketing", BriefName = "Channel Specific ", SpecializedName = "TikTok Shop"},
                new Category { MajorName = "Digital Marketing", BriefName = "Channel Specific ", SpecializedName = "Facebook Ads Campaign"},
                new Category { MajorName = "Digital Marketing", BriefName = "Channel Specific ", SpecializedName = "Instagram Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Channel Specific ", SpecializedName = "Google SEM"},
                new Category { MajorName = "Digital Marketing", BriefName = "Channel Specific ", SpecializedName = " Shopify Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Industry & Purpose-Specific", SpecializedName = "Music Promotion"},
                new Category { MajorName = "Digital Marketing", BriefName = "Industry & Purpose-Specific", SpecializedName = "Podcast Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Industry & Purpose-Specific", SpecializedName = "Book & eBook Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Industry & Purpose-Specific", SpecializedName = "Mobile App Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Video Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "E-Commerce Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Email Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Email Automations"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Guest Posting"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Affiliate Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Display Advertising "},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Public Relations"},
                new Category { MajorName = "Digital Marketing", BriefName = "Methods & Techniques ", SpecializedName = "Text Message Marketing"},
                new Category { MajorName = "Digital Marketing", BriefName = "Analytics & Strategy", SpecializedName = "Marketing Strategy"},
                new Category { MajorName = "Digital Marketing", BriefName = "Analytics & Strategy", SpecializedName = "Marketing Concepts & Ideation"},
                new Category { MajorName = "Digital Marketing", BriefName = "Analytics & Strategy", SpecializedName = "Marketing Advice"},
                new Category { MajorName = "Digital Marketing", BriefName = "Analytics & Strategy", SpecializedName = "Web Analytics"},
                new Category { MajorName = "Digital Marketing", BriefName = "Analytics & Strategy", SpecializedName = "Conversion Rate Optimization (CRO)"},
                new Category { MajorName = "Digital Marketing", BriefName = "Miscellaneous", SpecializedName = "Crowdfunding"},
                new Category { MajorName = "Digital Marketing", BriefName = "Miscellaneous", SpecializedName = "Other"},
                new Category { MajorName = "Video & Animation", BriefName = "Editing & Post-Production", SpecializedName = "Video Editing"},
                new Category { MajorName = "Video & Animation", BriefName = "Editing & Post-Production", SpecializedName = "Visual Effects"},
                new Category { MajorName = "Video & Animation", BriefName = "Editing & Post-Production", SpecializedName = "Video Art"},
                new Category { MajorName = "Video & Animation", BriefName = "Editing & Post-Production", SpecializedName = "Intro & Outro Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Editing & Post-Production", SpecializedName = "Video Templates Editing"},
                new Category { MajorName = "Video & Animation", BriefName = "Editing & Post-Production", SpecializedName = "Subtitles & Captions"},
                new Category { MajorName = "Video & Animation", BriefName = "Social & Marketing Videos", SpecializedName = "Video Ads & Commercials "},
                new Category { MajorName = "Video & Animation", BriefName = "Social & Marketing Videos", SpecializedName = "Social Media Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Social & Marketing Videos", SpecializedName = "Music Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Social & Marketing Videos", SpecializedName = "Slideshow Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Motion Graphics", SpecializedName = "Logo Animation"},
                new Category { MajorName = "Video & Animation", BriefName = "Motion Graphics", SpecializedName = "Lottie & Web Animation"},
                new Category { MajorName = "Video & Animation", BriefName = "Motion Graphics", SpecializedName = "Text Animation"},
                new Category { MajorName = "Video & Animation", BriefName = "Presenter Videos", SpecializedName = "UGC Videos "},
                new Category { MajorName = "Video & Animation", BriefName = "Presenter Videos", SpecializedName = "Spokesperson Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Presenter Videos", SpecializedName = "UGC Ads"},
                new Category { MajorName = "Video & Animation", BriefName = "Presenter Videos", SpecializedName = "TikTok UGC Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Animation", SpecializedName = "Character Animation"},
                new Category { MajorName = "Video & Animation", BriefName = "Animation", SpecializedName = "Animated GIFs"},
                new Category { MajorName = "Video & Animation", BriefName = "Animation", SpecializedName = "Animation for Kids"},
                new Category { MajorName = "Video & Animation", BriefName = "Animation", SpecializedName = "Animation for Streamers"},
                new Category { MajorName = "Video & Animation", BriefName = "Animation", SpecializedName = "Rigging"},
                new Category { MajorName = "Video & Animation", BriefName = "Animation", SpecializedName = "NFT Animation"},
                new Category { MajorName = "Video & Animation", BriefName = "Filmed Video Production", SpecializedName = "Videographers"},
                new Category { MajorName = "Video & Animation", BriefName = "Filmed Video Production", SpecializedName = "Filmed Video Production"},
                new Category { MajorName = "Video & Animation", BriefName = "Explainer Videos", SpecializedName = "Animated Explainers"},
                new Category { MajorName = "Video & Animation", BriefName = "Explainer Videos", SpecializedName = "Live Action Explainers"},
                new Category { MajorName = "Video & Animation", BriefName = "Explainer Videos", SpecializedName = "Screencasting Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Explainer Videos", SpecializedName = "eLearning Video Production"},
                new Category { MajorName = "Video & Animation", BriefName = "Explainer Videos", SpecializedName = "Crowdfunding Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Product Videos ", SpecializedName = "3D Product Animation"},
                new Category { MajorName = "Video & Animation", BriefName = "Product Videos ", SpecializedName = "E-Commerce Product Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Product Videos ", SpecializedName = "Corporate Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Product Videos ", SpecializedName = "App & Website Previews"},
                new Category { MajorName = "Video & Animation", BriefName = "AI Video ", SpecializedName = "AI Video Art"},
                new Category { MajorName = "Video & Animation", BriefName = "AI Video ", SpecializedName = "AI Music Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "AI Video ", SpecializedName = " AI Video Avatars"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Virtual & Streaming Avatars"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Article to Video"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Game Trailers"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Game Recordings & Guides"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Meditation Videos"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Real Estate Promos"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Book Trailers"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Video Advice"},
                new Category { MajorName = "Video & Animation", BriefName = "Miscellaneous", SpecializedName = "Other"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Articles & Blog Posts"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Content Strategy"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Website Content"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Scriptwriting"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Creative Writing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Podcast Writing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Speechwriting"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Research & Summaries"},
                new Category { MajorName = "Writing & Translation", BriefName = "Content Writing", SpecializedName = "Find an Expert Writer"},
                new Category { MajorName = "Writing & Translation", BriefName = "Editing & Critique", SpecializedName = "Proofreading & Editing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Editing & Critique", SpecializedName = "AI Content Editing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Editing & Critique", SpecializedName = "Writing Advice"},
                new Category { MajorName = "Writing & Translation", BriefName = " Book & eBook Publishing", SpecializedName = "Book & eBook Writing"},
                new Category { MajorName = "Writing & Translation", BriefName = " Book & eBook Publishing", SpecializedName = "Book Editing"},
                new Category { MajorName = "Writing & Translation", BriefName = " Book & eBook Publishing", SpecializedName = "Beta Reading"},
                new Category { MajorName = "Writing & Translation", BriefName = " Book & eBook Publishing", SpecializedName = "Self-Publish Your Book"},
                new Category { MajorName = "Writing & Translation", BriefName = "Career Writing", SpecializedName = "Resume Writing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Career Writing", SpecializedName = "Cover Letters"},
                new Category { MajorName = "Writing & Translation", BriefName = "Career Writing", SpecializedName = "LinkedIn Profiles"},
                new Category { MajorName = "Writing & Translation", BriefName = "Career Writing", SpecializedName = "Job Descriptions"},
                new Category { MajorName = "Writing & Translation", BriefName = "Miscellaneous", SpecializedName = "eLearning Content Development"},
                new Category { MajorName = "Writing & Translation", BriefName = "Miscellaneous", SpecializedName = "Technical Writing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Brand Voice & Tone"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Business Names & Slogans"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Case Studies"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "White Papers"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Product Descriptions"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Ad Copy"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Sales Copy"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Email Copy"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Social Media Copywriting"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "Press Releases"},
                new Category { MajorName = "Writing & Translation", BriefName = "Business & Marketing Copy", SpecializedName = "UX Writing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Translation & Transcription", SpecializedName = "Translation"},
                new Category { MajorName = "Writing & Translation", BriefName = "Translation & Transcription", SpecializedName = "Localization"},
                new Category { MajorName = "Writing & Translation", BriefName = "Translation & Transcription", SpecializedName = "Transcription"},
                new Category { MajorName = "Writing & Translation", BriefName = "Translation & Transcription", SpecializedName = "Interpretation"},
                new Category { MajorName = "Writing & Translation", BriefName = "Industry Specific Content", SpecializedName = "Business, Finance & Law "},
                new Category { MajorName = "Writing & Translation", BriefName = "Industry Specific Content", SpecializedName = "Health & Medical "},
                new Category { MajorName = "Writing & Translation", BriefName = "Industry Specific Content", SpecializedName = "Internet & Technology "},
                new Category { MajorName = "Writing & Translation", BriefName = "Industry Specific Content", SpecializedName = "News & Politics"},
                new Category { MajorName = "Writing & Translation", BriefName = "Industry Specific Content", SpecializedName = "Marketing"},
                new Category { MajorName = "Writing & Translation", BriefName = "Industry Specific Content", SpecializedName = "Real Estate"},
                new Category { MajorName = "Music & Audio", BriefName = "Music Production & Writing", SpecializedName = "Music Producers"},
                new Category { MajorName = "Music & Audio", BriefName = "Music Production & Writing", SpecializedName = "Composers"},
                new Category { MajorName = "Music & Audio", BriefName = "Music Production & Writing", SpecializedName = "Singers & Vocalists"},
                new Category { MajorName = "Music & Audio", BriefName = "Music Production & Writing", SpecializedName = "Session Musicians"},
                new Category { MajorName = "Music & Audio", BriefName = "Music Production & Writing", SpecializedName = "Songwriters"},
                new Category { MajorName = "Music & Audio", BriefName = "Music Production & Writing", SpecializedName = "Jingles & Intros"},
                new Category { MajorName = "Music & Audio", BriefName = "Music Production & Writing", SpecializedName = "Custom Songs"},
                new Category { MajorName = "Music & Audio", BriefName = "Audio Engineering & Post Production", SpecializedName = "Mixing & Mastering"},
                new Category { MajorName = "Music & Audio", BriefName = "Audio Engineering & Post Production", SpecializedName = "Audio Editing"},
                new Category { MajorName = "Music & Audio", BriefName = "Audio Engineering & Post Production", SpecializedName = "Vocal Tuning"},
                new Category { MajorName = "Music & Audio", BriefName = "Voice Over & Narration", SpecializedName = "24hr Turnaround"},
                new Category { MajorName = "Music & Audio", BriefName = "Voice Over & Narration", SpecializedName = "Female Voice Over"},
                new Category { MajorName = "Music & Audio", BriefName = "Voice Over & Narration", SpecializedName = "Male Voice Over"},
                new Category { MajorName = "Music & Audio", BriefName = "Voice Over & Narration", SpecializedName = "French Voice Over"},
                new Category { MajorName = "Music & Audio", BriefName = "Voice Over & Narration", SpecializedName = "German Voice Over"},
                new Category { MajorName = "Music & Audio", BriefName = "Streaming & Audio", SpecializedName = "Podcast Production"},
                new Category { MajorName = "Music & Audio", BriefName = "Streaming & Audio", SpecializedName = "Audiobook Production"},
                new Category { MajorName = "Music & Audio", BriefName = "Streaming & Audio", SpecializedName = "Audio Ads Production"},
                new Category { MajorName = "Music & Audio", BriefName = "Streaming & Audio", SpecializedName = "Voice Synthesis & AI"},
                new Category { MajorName = "Music & Audio", BriefName = "DJing", SpecializedName = "DJ Drops & Tags"},
                new Category { MajorName = "Music & Audio", BriefName = "DJing", SpecializedName = "DJ Mixing"},
                new Category { MajorName = "Music & Audio", BriefName = "DJing", SpecializedName = "Remixing"},
                new Category { MajorName = "Music & Audio", BriefName = "Sound Design", SpecializedName = "Sound Design"},
                new Category { MajorName = "Music & Audio", BriefName = "Sound Design", SpecializedName = "Meditation Music"},
                new Category { MajorName = "Music & Audio", BriefName = "Sound Design", SpecializedName = "Audio Logo & Sonic Branding"},
                new Category { MajorName = "Music & Audio", BriefName = "Sound Design", SpecializedName = "Custom Patches & Samples"},
                new Category { MajorName = "Music & Audio", BriefName = "Sound Design", SpecializedName = "Audio Plugin Development"},
                new Category { MajorName = "Music & Audio", BriefName = "Lessons & Transcriptions", SpecializedName = "Online Music Lessons"},
                new Category { MajorName = "Music & Audio", BriefName = "Lessons & Transcriptions", SpecializedName = "Music Transcription"},
                new Category { MajorName = "Music & Audio", BriefName = "Lessons & Transcriptions", SpecializedName = "Music & Audio Advice"},
                new Category { MajorName = "Business", BriefName = "Business Formation & Consulting", SpecializedName = "Business Formation & Registration"},
                new Category { MajorName = "Business", BriefName = "Business Formation & Consulting", SpecializedName = "Market Research"},
                new Category { MajorName = "Business", BriefName = "Business Formation & Consulting", SpecializedName = "Business Plans"},
                new Category { MajorName = "Business", BriefName = "Business Formation & Consulting", SpecializedName = "Business Consulting"},
                new Category { MajorName = "Business", BriefName = "Business Formation & Consulting", SpecializedName = "HR Consulting"},
                new Category { MajorName = "Business", BriefName = "Business Formation & Consulting", SpecializedName = "AI Consulting "},
                new Category { MajorName = "Business", BriefName = "Legal Services", SpecializedName = "Intellectual Property Management"},
                new Category { MajorName = "Business", BriefName = "Legal Services", SpecializedName = "Legal Documents & Contracts"},
                new Category { MajorName = "Business", BriefName = "Legal Services", SpecializedName = "Legal Research"},
                new Category { MajorName = "Business", BriefName = "Legal Services", SpecializedName = "General Legal Advice"},
                new Category { MajorName = "Business", BriefName = "Operations & Management", SpecializedName = "Virtual Assistant"},
                new Category { MajorName = "Business", BriefName = "Operations & Management", SpecializedName = "Project Management"},
                new Category { MajorName = "Business", BriefName = "Operations & Management", SpecializedName = "Software Management"},
                new Category { MajorName = "Business", BriefName = "Operations & Management", SpecializedName = "E-Commerce Management "},
                new Category { MajorName = "Business", BriefName = "Operations & Management", SpecializedName = "Supply Chain Management"},
                new Category { MajorName = "Business", BriefName = "Operations & Management", SpecializedName = "Event Management"},
                new Category { MajorName = "Business", BriefName = "Operations & Management", SpecializedName = "Product Management"},
                new Category { MajorName = "Business", BriefName = "Data & Business Intelligence ", SpecializedName = "Data Visualization"},
                new Category { MajorName = "Business", BriefName = "Data & Business Intelligence ", SpecializedName = "Data Analytics"},
                new Category { MajorName = "Business", BriefName = "Data & Business Intelligence ", SpecializedName = "Data Scraping"},
                new Category { MajorName = "Business", BriefName = "Sales & Customer Care", SpecializedName = "Sales"},
                new Category { MajorName = "Business", BriefName = "Sales & Customer Care", SpecializedName = "Lead Generation"},
                new Category { MajorName = "Business", BriefName = "Sales & Customer Care", SpecializedName = "Call Center & Calling "},
                new Category { MajorName = "Business", BriefName = "Sales & Customer Care", SpecializedName = "Customer Care"},
                new Category { MajorName = "Business", BriefName = "Miscellaneous", SpecializedName = "Presentations"},
                new Category { MajorName = "Business", BriefName = "Miscellaneous", SpecializedName = "Online Investigations"},
                new Category { MajorName = "Business", BriefName = "Miscellaneous", SpecializedName = "Sustainability Consulting"},
                new Category { MajorName = "Business", BriefName = "Miscellaneous", SpecializedName = "Game Concept Design"},
                new Category { MajorName = "Business", BriefName = "Miscellaneous", SpecializedName = "Other"},
                new Category { MajorName = "Finance", BriefName = "Accounting Services", SpecializedName = "Fractional CFO Services"},
                new Category { MajorName = "Finance", BriefName = "Accounting Services", SpecializedName = "Financial Reporting"},
                new Category { MajorName = "Finance", BriefName = "Accounting Services", SpecializedName = "Bookkeeping"},
                new Category { MajorName = "Finance", BriefName = "Accounting Services", SpecializedName = "Payroll Management"},
                new Category { MajorName = "Finance", BriefName = "Accounting Services", SpecializedName = "Find a Financial Expert"},
                new Category { MajorName = "Finance", BriefName = "Corporate Finance", SpecializedName = "Due Diligence"},
                new Category { MajorName = "Finance", BriefName = "Corporate Finance", SpecializedName = "Valuation"},
                new Category { MajorName = "Finance", BriefName = "Corporate Finance", SpecializedName = "Mergers & Acquisitions Advisory"},
                new Category { MajorName = "Finance", BriefName = "Corporate Finance", SpecializedName = "Corporate Finance Strategy"},
                new Category { MajorName = "Finance", BriefName = "Tax Consulting", SpecializedName = "Tax Returns"},
                new Category { MajorName = "Finance", BriefName = "Tax Consulting", SpecializedName = "Tax Identification Services"},
                new Category { MajorName = "Finance", BriefName = "Tax Consulting", SpecializedName = "Tax Planning"},
                new Category { MajorName = "Finance", BriefName = "Tax Consulting", SpecializedName = "Tax Compliance"},
                new Category { MajorName = "Finance", BriefName = "Tax Consulting", SpecializedName = "Tax Exemptions"},
                new Category { MajorName = "Finance", BriefName = "Financial Planning & Analysis", SpecializedName = "Budgeting and Forecasting"},
                new Category { MajorName = "Finance", BriefName = "Financial Planning & Analysis", SpecializedName = "Financial Modeling"},
                new Category { MajorName = "Finance", BriefName = "Financial Planning & Analysis", SpecializedName = "Cost Analysis"},
                new Category { MajorName = "Finance", BriefName = "Financial Planning & Analysis", SpecializedName = "Stock Analysis"},
                new Category { MajorName = "Finance", BriefName = "Personal Finance & Wealth Management", SpecializedName = "Personal Budget Management"},
                new Category { MajorName = "Finance", BriefName = "Personal Finance & Wealth Management", SpecializedName = "Investments Advisory"},
                new Category { MajorName = "Finance", BriefName = "Personal Finance & Wealth Management", SpecializedName = "Online Trading Lessons"},
                new Category { MajorName = "Finance", BriefName = "Fundraising", SpecializedName = "Investors Sourcing"},
                new Category { MajorName = "Finance", BriefName = "Fundraising", SpecializedName = "Funding Pitch Presentations"},
                new Category { MajorName = "Finance", BriefName = "Fundraising", SpecializedName = "Fundraising Consultation"},
                new Category { MajorName = "AI Services", BriefName = "AI Mobile Development", SpecializedName = "AI Mobile Apps"},
                new Category { MajorName = "AI Services", BriefName = "AI Mobile Development", SpecializedName = "AI Websites & Software"},
                new Category { MajorName = "AI Services", BriefName = "AI Mobile Development", SpecializedName = "AI Chatbot"},
                new Category { MajorName = "AI Services", BriefName = "AI Mobile Development", SpecializedName = "AI Integrations"},
                new Category { MajorName = "AI Services", BriefName = "AI Mobile Development", SpecializedName = "AI Agents"},
                new Category { MajorName = "AI Services", BriefName = "AI Mobile Development", SpecializedName = "AI Fine-Tuning"},
                new Category { MajorName = "AI Services", BriefName = "AI Mobile Development", SpecializedName = "AI Technology Consulting"},
                new Category { MajorName = "AI Services", BriefName = "Data", SpecializedName = "Data Science & ML"},
                new Category { MajorName = "AI Services", BriefName = "Data", SpecializedName = "Data Analytics"},
                new Category { MajorName = "AI Services", BriefName = "Data", SpecializedName = "Data Visualization"},
                new Category { MajorName = "AI Services", BriefName = "AI Artists", SpecializedName = "AI Avatar Design"},
                new Category { MajorName = "AI Services", BriefName = "AI Artists", SpecializedName = "ComfyUI Workflow Creation"},
                new Category { MajorName = "AI Services", BriefName = "AI Artists", SpecializedName = "AI Image Editing"},
                new Category { MajorName = "AI Services", BriefName = "AI Artists", SpecializedName = "Midjourney Artists"},
                new Category { MajorName = "AI Services", BriefName = "AI Artists", SpecializedName = "Stable Diffusion Artists"},
                new Category { MajorName = "AI Services", BriefName = "AI Artists", SpecializedName = "All AI Art Services"},
                new Category { MajorName = "AI Services", BriefName = "AI for Businesses", SpecializedName = "AI Consulting "},
                new Category { MajorName = "AI Services", BriefName = "AI for Businesses", SpecializedName = "AI Strategy"},
                new Category { MajorName = "AI Services", BriefName = "AI for Businesses", SpecializedName = "AI Lessons"},
                new Category { MajorName = "AI Services", BriefName = "AI Video", SpecializedName = "AI Music Videos"},
                new Category { MajorName = "AI Services", BriefName = "AI Video", SpecializedName = "AI Video Art"},
                new Category { MajorName = "AI Services", BriefName = "AI Video", SpecializedName = " AI Video Avatars"},
                new Category { MajorName = "AI Services", BriefName = "AI Audio", SpecializedName = "Voice Synthesis & AI"},
                new Category { MajorName = "AI Services", BriefName = "AI Audio", SpecializedName = "Text to Speech"},
                new Category { MajorName = "AI Services", BriefName = "AI Content", SpecializedName = "AI Content Editing"},
                new Category { MajorName = "AI Services", BriefName = "AI Content", SpecializedName = "Custom Writing Prompts"},
                new Category { MajorName = "Personal Growth", BriefName = "Self Improvement", SpecializedName = "Online Tutoring"},
                new Category { MajorName = "Personal Growth", BriefName = "Self Improvement", SpecializedName = "Language Lessons"},
                new Category { MajorName = "Personal Growth", BriefName = "Self Improvement", SpecializedName = "Life Coaching"},
                new Category { MajorName = "Personal Growth", BriefName = "Self Improvement", SpecializedName = "Career Counseling"},
                new Category { MajorName = "Personal Growth", BriefName = "Self Improvement", SpecializedName = "Generative AI Lessons"},
                new Category { MajorName = "Personal Growth", BriefName = "Fashion & Style", SpecializedName = "Modeling & Acting"},
                new Category { MajorName = "Personal Growth", BriefName = "Fashion & Style", SpecializedName = "Styling & Beauty"},
                new Category { MajorName = "Personal Growth", BriefName = "Fashion & Style", SpecializedName = "Trend Forecasting"},
                new Category { MajorName = "Personal Growth", BriefName = "Wellness & Fitness", SpecializedName = "Fitness"},
                new Category { MajorName = "Personal Growth", BriefName = "Wellness & Fitness", SpecializedName = "Nutrition "},
                new Category { MajorName = "Personal Growth", BriefName = "Wellness & Fitness", SpecializedName = "Wellness"},
                new Category { MajorName = "Personal Growth", BriefName = "Gaming", SpecializedName = "Game Coaching"},
                new Category { MajorName = "Personal Growth", BriefName = "Gaming", SpecializedName = "eSports Management & Strategy"},
                new Category { MajorName = "Personal Growth", BriefName = "Gaming", SpecializedName = "Game Matchmaking"},
                new Category { MajorName = "Personal Growth", BriefName = "Gaming", SpecializedName = "Ingame Creation"},
                new Category { MajorName = "Personal Growth", BriefName = "Gaming", SpecializedName = "Gameplay Experience & Feedback"},
                new Category { MajorName = "Personal Growth", BriefName = "Gaming", SpecializedName = "Game Recordings & Guides"},
                new Category { MajorName = "Personal Growth", BriefName = "Leisure & Hobbies", SpecializedName = "Astrology & Psychics"},
                new Category { MajorName = "Personal Growth", BriefName = "Leisure & Hobbies", SpecializedName = "Arts & Crafts"},
                new Category { MajorName = "Personal Growth", BriefName = "Leisure & Hobbies", SpecializedName = "Cosplay Creation"},
                new Category { MajorName = "Personal Growth", BriefName = "Leisure & Hobbies", SpecializedName = "Puzzle & Game Creation"},
                new Category { MajorName = "Personal Growth", BriefName = "Leisure & Hobbies", SpecializedName = "Traveling"},
                new Category { MajorName = "Personal Growth", BriefName = "Leisure & Hobbies", SpecializedName = "Collectibles"},
                new Category { MajorName = "Personal Growth", BriefName = "Miscellaneous", SpecializedName = "Family & Genealogy"},
                new Category { MajorName = "Personal Growth", BriefName = "Miscellaneous", SpecializedName = "Cosmetics Formulation"},
                new Category { MajorName = "Personal Growth", BriefName = "Miscellaneous", SpecializedName = "Greeting Cards & Videos"},
                new Category { MajorName = "Personal Growth", BriefName = "Miscellaneous", SpecializedName = "Embroidery Digitizing"},
                new Category { MajorName = "Personal Growth", BriefName = "Miscellaneous", SpecializedName = "Other"},
                new Category { MajorName = "Consulting", BriefName = "Business Consultants", SpecializedName = "Legal Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Business Consultants", SpecializedName = "Business Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Business Consultants", SpecializedName = "HR Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Business Consultants", SpecializedName = "AI Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Business Consultants", SpecializedName = "Business Plans"},
                new Category { MajorName = "Consulting", BriefName = "Business Consultants", SpecializedName = "E-commerce Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Marketing Strategy", SpecializedName = "Marketing Strategy"},
                new Category { MajorName = "Consulting", BriefName = "Marketing Strategy", SpecializedName = "Content Strategy"},
                new Category { MajorName = "Consulting", BriefName = "Marketing Strategy", SpecializedName = "Social Media Strategy"},
                new Category { MajorName = "Consulting", BriefName = "Marketing Strategy", SpecializedName = "Influencers Strategy"},
                new Category { MajorName = "Consulting", BriefName = "Marketing Strategy", SpecializedName = "Video Marketing Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Marketing Strategy", SpecializedName = "SEM Strategy"},
                new Category { MajorName = "Consulting", BriefName = "Marketing Strategy", SpecializedName = "PR Strategy"},
                new Category { MajorName = "Consulting", BriefName = "Data Consulting", SpecializedName = "Data Analytics Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Data Consulting", SpecializedName = "Databases Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Data Consulting", SpecializedName = "Data Visualization Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Coaching & Advice", SpecializedName = "Career Counseling"},
                new Category { MajorName = "Consulting", BriefName = "Coaching & Advice", SpecializedName = "Life Coaching"},
                new Category { MajorName = "Consulting", BriefName = "Coaching & Advice", SpecializedName = "Game Coaching"},
                new Category { MajorName = "Consulting", BriefName = "Coaching & Advice", SpecializedName = "Styling & Beauty Advice"},
                new Category { MajorName = "Consulting", BriefName = "Coaching & Advice", SpecializedName = "Travel Advice"},
                new Category { MajorName = "Consulting", BriefName = "Coaching & Advice", SpecializedName = "Nutrition Coaching"},
                new Category { MajorName = "Consulting", BriefName = "Coaching & Advice", SpecializedName = "Mindfulness Coaching"},
                new Category { MajorName = "Consulting", BriefName = "Tech Consulting", SpecializedName = "AI Technology Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Tech Consulting", SpecializedName = "Website Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Tech Consulting", SpecializedName = "Mobile App Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Tech Consulting", SpecializedName = "Game Development Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Tech Consulting", SpecializedName = "Software Development Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Tech Consulting", SpecializedName = "Cybersecurity Consulting"},
                new Category { MajorName = "Consulting", BriefName = "Mentorship", SpecializedName = "Marketing Mentorship"},
                new Category { MajorName = "Consulting", BriefName = "Mentorship", SpecializedName = "Design Mentorship"},
                new Category { MajorName = "Consulting", BriefName = "Mentorship", SpecializedName = "Writing Mentorship"},
                new Category { MajorName = "Consulting", BriefName = "Mentorship", SpecializedName = "Video Mentorship"},
                new Category { MajorName = "Consulting", BriefName = "Mentorship", SpecializedName = "Music Mentorship"},
                new Category { MajorName = "Data", BriefName = "Data Science & ML", SpecializedName = "Machine Learning"},
                new Category { MajorName = "Data", BriefName = "Data Science & ML", SpecializedName = "Computer Vision"},
                new Category { MajorName = "Data", BriefName = "Data Science & ML", SpecializedName = "NLP"},
                new Category { MajorName = "Data", BriefName = "Data Science & ML", SpecializedName = "Deep Learning"},
                new Category { MajorName = "Data", BriefName = "Data Science & ML", SpecializedName = "Generative Models"},
                new Category { MajorName = "Data", BriefName = "Data Science & ML", SpecializedName = "Time Series Analysis"},
                new Category { MajorName = "Data", BriefName = "Data Analysis & Visualization", SpecializedName = "Data Analytics"},
                new Category { MajorName = "Data", BriefName = "Data Analysis & Visualization", SpecializedName = "Data Visualization"},
                new Category { MajorName = "Data", BriefName = "Data Analysis & Visualization", SpecializedName = "Data Annotation"},
                new Category { MajorName = "Data", BriefName = "Data Analysis & Visualization", SpecializedName = "Dashboards"},
                new Category { MajorName = "Data", BriefName = "Data Collection", SpecializedName = "Data Entry"},
                new Category { MajorName = "Data", BriefName = "Data Collection", SpecializedName = "Data Typing"},
                new Category { MajorName = "Data", BriefName = "Data Collection", SpecializedName = "Data Scraping"},
                new Category { MajorName = "Data", BriefName = "Data Collection", SpecializedName = "Data Formatting"},
                new Category { MajorName = "Data", BriefName = "Data Collection", SpecializedName = "Data Cleaning"},
                new Category { MajorName = "Data", BriefName = "Data Collection", SpecializedName = "Data Enrichment"},
                new Category { MajorName = "Data", BriefName = "Data Processing & Management ", SpecializedName = "Data Processing"},
                new Category { MajorName = "Data", BriefName = "Data Processing & Management ", SpecializedName = "Data Governance & Protection"},
                new Category { MajorName = "Data", BriefName = "Databases & Engineering", SpecializedName = "Databases"},
                new Category { MajorName = "Data", BriefName = "Databases & Engineering", SpecializedName = "Data Engineering"},
                new Category { MajorName = "Photography", BriefName = "Products & Lifestyle", SpecializedName = "Product Photographers"},
                new Category { MajorName = "Photography", BriefName = "Products & Lifestyle", SpecializedName = "Food Photographers"},
                new Category { MajorName = "Photography", BriefName = "Products & Lifestyle", SpecializedName = "Lifestyle & Fashion Photographers"},
                new Category { MajorName = "Photography", BriefName = "People & Scenes", SpecializedName = "Portrait Photographers"},
                new Category { MajorName = "Photography", BriefName = "People & Scenes", SpecializedName = "Event Photographers"},
                new Category { MajorName = "Photography", BriefName = "People & Scenes", SpecializedName = "Real Estate Photographers"},
                new Category { MajorName = "Photography", BriefName = "People & Scenes", SpecializedName = "Scenic Photographers"},
                new Category { MajorName = "Photography", BriefName = "Local Photography", SpecializedName = "Photographers in New York"},
                new Category { MajorName = "Photography", BriefName = "Local Photography", SpecializedName = "Photographers in Los Angeles"},
                new Category { MajorName = "Photography", BriefName = "Local Photography", SpecializedName = "Photographers in London"},
                new Category { MajorName = "Photography", BriefName = "Local Photography", SpecializedName = "Photographers in Paris"},
                new Category { MajorName = "Photography", BriefName = "Local Photography", SpecializedName = "All Cities"},
                new Category { MajorName = "Photography", BriefName = "Miscellaneous", SpecializedName = "Photography Classes"},
                new Category { MajorName = "Photography", BriefName = "Miscellaneous", SpecializedName = "Photo Preset Creation"},
                new Category { MajorName = "Photography", BriefName = "Miscellaneous", SpecializedName = "Other"}
            };
        }

    }//End class
}//End namespace
