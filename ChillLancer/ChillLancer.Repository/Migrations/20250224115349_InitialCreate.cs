using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChillLancer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirebaseUid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FcmToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameTag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    National = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BioSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Favorited = table.Column<int>(type: "int", nullable: false),
                    Liked = table.Column<int>(type: "int", nullable: false),
                    Dislike = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    LastDelivery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MajorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BriefName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpecializedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNum = table.Column<short>(type: "smallint", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "MONEY", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RateCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Percentage = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AchieveFrom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearAchieved = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_Accounts_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Major = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DegreeType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    YearGraduation = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Accounts_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guidelines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<decimal>(type: "MONEY", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequirementNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Accounts_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountLanguages",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLanguages", x => new { x.AccountId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_AccountLanguages_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BriefDescribe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HandleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeePrice = table.Column<decimal>(type: "MONEY", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "MONEY", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SystemFeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_RateCodes_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "RateCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_RateCodes_SystemFeeId",
                        column: x => x.SystemFeeId,
                        principalTable: "RateCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => new { x.ProjectId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreelancerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "MONEY", nullable: false),
                    HourDuration = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Accounts_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposals_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposals_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<decimal>(type: "MONEY", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Process_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposalImages",
                columns: table => new
                {
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalImages", x => new { x.ProposalId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ProposalImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposalImages_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposalSkills",
                columns: table => new
                {
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalSkills", x => new { x.ProposalId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ProposalSkills_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposalSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BriefName", "MajorName", "SpecializedName", "Status" },
                values: new object[,]
                {
                    { new Guid("01f63211-8a57-4f8f-9cdd-2f8f7c622c65"), "Industry Specific Content", "Writing & Translation", "Internet & Technology ", "Created" },
                    { new Guid("04d1ef0d-1447-479f-afb5-dbbd1d1e18f0"), "Personal Finance & Wealth Management", "Finance", "Investments Advisory", "Created" },
                    { new Guid("04ef788b-b62f-42ef-8988-9e36f1a9c32c"), "Editing & Post-Production", "Video & Animation", "Video Templates Editing", "Created" },
                    { new Guid("05005e9a-7c3e-41b4-89de-5328d12328bb"), "Logo & Brand Identity", "Graphics & Design", "Logo Maker Tool", "Created" },
                    { new Guid("05eca098-4027-4cf0-a33d-f21e7230f44c"), "Mentorship", "Consulting", "Video Mentorship", "Created" },
                    { new Guid("060e8f9c-4606-4687-87ca-f9b79ac5c784"), "Data & Business Intelligence ", "Business", "Data Analytics", "Created" },
                    { new Guid("0660446a-28bb-44dc-be9d-a68d5d6b136c"), "Miscellaneous", "Writing & Translation", "Technical Writing", "Created" },
                    { new Guid("06a1098c-0a26-4a5f-9006-b613184a80b4"), "Data Science & ML", "Data", "Computer Vision", "Created" },
                    { new Guid("07928f94-7f00-4fdd-8f90-297bd1049f87"), "Content Writing", "Writing & Translation", "Podcast Writing", "Created" },
                    { new Guid("07cb0101-b41e-4729-8cdd-cb109ae71f52"), "Methods & Techniques ", "Digital Marketing", "Email Automations", "Created" },
                    { new Guid("08384924-0b4f-43b6-b4de-4eec9e41f207"), "Analytics & Strategy", "Digital Marketing", "Marketing Concepts & Ideation", "Created" },
                    { new Guid("08ea9bc5-1d33-4342-bc04-dcb672c0d0e8"), "Web & App Design", "Graphics & Design", "App Design", "Created" },
                    { new Guid("08f80f6a-447d-4ea2-8ae2-329443d7e636"), "Self Improvement", "Personal Growth", "Online Tutoring", "Created" },
                    { new Guid("08fc2034-e22c-4bd8-a278-30e90a6b6beb"), "AI Audio", "AI Services", "Voice Synthesis & AI", "Created" },
                    { new Guid("099a03cd-9753-4b1e-aaf9-66ab2abfadd8"), "Marketing Strategy", "Consulting", "Social Media Strategy", "Created" },
                    { new Guid("09ffb84b-9e7b-4700-8f35-98818094dc39"), "AI for Businesses", "AI Services", "AI Lessons", "Created" },
                    { new Guid("0a2e37b3-be1c-4d3c-b590-673e32adbb23"), "Miscellaneous", "Video & Animation", "Other", "Created" },
                    { new Guid("0a4effb4-043d-42df-9dce-be02b98516de"), "Self Improvement", "Personal Growth", "Life Coaching", "Created" },
                    { new Guid("0a76956f-7d28-42f9-bbfc-c5bb2e1a6d9f"), "Financial Planning & Analysis", "Finance", "Cost Analysis", "Created" },
                    { new Guid("0b19bb08-7039-41c8-918a-55d4d343236d"), "Products & Lifestyle", "Photography", "Food Photographers", "Created" },
                    { new Guid("0b5fd278-d436-48de-b894-d872d1719abf"), "Art & Illustration", "Graphics & Design", "Storyboards", "Created" },
                    { new Guid("0b9a3423-96a0-454d-b692-e647494c8cbc"), "Visual Design", "Graphics & Design", "Infographic Design", "Created" },
                    { new Guid("0c69b152-a958-4dc2-afd2-4ad33d3f9cf2"), "Business Formation & Consulting", "Business", "AI Consulting ", "Created" },
                    { new Guid("0cb07a87-9799-4dbd-9c2a-95b801e722e3"), "Art & Illustration", "Graphics & Design", "Children's Book Illustration", "Created" },
                    { new Guid("0d6ab1bb-c4b0-4cf9-8c7f-74e411f4df97"), "Voice Over & Narration", "Music & Audio", "24hr Turnaround", "Created" },
                    { new Guid("0fe4d599-4273-4135-9c50-e963b478bbf9"), "Methods & Techniques ", "Digital Marketing", "Video Marketing", "Created" },
                    { new Guid("0fe70916-e94f-494f-8b89-55e5ee57171a"), "Operations & Management", "Business", "Project Management", "Created" },
                    { new Guid("10c852dc-ebca-45aa-9c8b-41aaba48c95c"), "Local Photography", "Photography", "Photographers in London", "Created" },
                    { new Guid("114879ce-de93-433b-9947-0bb2f505c55b"), " Book & eBook Publishing", "Writing & Translation", "Book Editing", "Created" },
                    { new Guid("11716924-3b00-43aa-92fe-267accec355d"), "Explainer Videos", "Video & Animation", "Animated Explainers", "Created" },
                    { new Guid("128978e0-af51-4af1-b486-ff8ae3eeea35"), "Operations & Management", "Business", "Event Management", "Created" },
                    { new Guid("128eeaf0-af42-4002-a5cb-bfacdb78e645"), "Industry & Purpose-Specific", "Digital Marketing", "Music Promotion", "Created" },
                    { new Guid("12c6ca99-b046-4f9d-9f49-b9e68149ee24"), "Gaming", "Personal Growth", "Game Matchmaking", "Created" },
                    { new Guid("13dcd9d3-e446-45b9-9eeb-460e21fd0d9f"), "Wellness & Fitness", "Personal Growth", "Nutrition ", "Created" },
                    { new Guid("13e94cf0-4e12-4710-97a8-ef7e4af76bfb"), "Gaming", "Personal Growth", "eSports Management & Strategy", "Created" },
                    { new Guid("1411f1aa-b15b-4418-8942-dce083e0abe5"), "Art & Illustration", "Graphics & Design", "Illustration", "Created" },
                    { new Guid("143ef266-dd61-4345-b70b-5486aca5ca80"), "Packaging & Covers", "Graphics & Design", "Packaging & Label Design", "Created" },
                    { new Guid("1513f504-0b07-438d-9134-d7c6555ce880"), "Marketing Design", "Graphics & Design", "Web Banners", "Created" },
                    { new Guid("15730fa3-3d06-48c3-badc-4b540b718820"), "Fundraising", "Finance", "Investors Sourcing", "Created" },
                    { new Guid("15c2fee5-500c-47db-a1ac-bce25f673bf7"), "3D Design", "Graphics & Design", "3D Industrial Design", "Created" },
                    { new Guid("16d272ff-402c-45a1-8d60-4b8aa0dca401"), "Music Production & Writing", "Music & Audio", "Singers & Vocalists", "Created" },
                    { new Guid("17ee774c-fcd5-4bdc-97be-0a75e2f01e18"), "Website Platforms", "Programming & Tech", "WordPress", "Created" },
                    { new Guid("18b390db-a0b1-4b68-8fdc-51bd8c2cf479"), "AI Development", "Programming & Tech", "AI Websites & Software", "Created" },
                    { new Guid("19430e85-a399-44ac-803f-c9d029e3b815"), "Blockchain & Cryptocurrency", "Programming & Tech", "Decentralized Apps (dApps)", "Created" },
                    { new Guid("19ae06f1-00e2-43db-b30d-ebc9bd652aaf"), "Data & Business Intelligence ", "Business", "Data Visualization", "Created" },
                    { new Guid("19b8ec92-5bff-4f9f-acb5-2140df3b872e"), "Motion Graphics", "Video & Animation", "Logo Animation", "Created" },
                    { new Guid("1a34e052-13e0-4295-956e-135f74008853"), "Business & Marketing Copy", "Writing & Translation", "Ad Copy", "Created" },
                    { new Guid("1b785b34-f8f4-4ebf-a1eb-6884587a0aec"), "Business & Marketing Copy", "Writing & Translation", "Brand Voice & Tone", "Created" },
                    { new Guid("1ba17ae2-2f9c-4444-93b6-300171defc0c"), "Music Production & Writing", "Music & Audio", "Songwriters", "Created" },
                    { new Guid("1c41fa64-da82-4050-a3c7-f1b61b2b4194"), "Lessons & Transcriptions", "Music & Audio", "Online Music Lessons", "Created" },
                    { new Guid("1c42e97a-d62b-4aaf-8039-38ae5ec3fa2e"), "Industry & Purpose-Specific", "Digital Marketing", "Mobile App Marketing", "Created" },
                    { new Guid("1d01f762-118e-49a8-8ebd-b36ec4beccc7"), "Architecture & Building Design", "Graphics & Design", "Landscape Design", "Created" },
                    { new Guid("1e122577-92b4-49b2-bc09-4e55ff3d54dd"), "Fashion & Style", "Personal Growth", "Styling & Beauty", "Created" },
                    { new Guid("1f07ce63-2a98-4eaf-a0b9-8075545f02a0"), "Miscellaneous", "Video & Animation", "Article to Video", "Created" },
                    { new Guid("1f5fff1d-58b1-454f-bbad-777dbc5c8ad3"), "Data Science & ML", "Programming & Tech", "Computer Vision", "Created" },
                    { new Guid("20742ad4-fe36-426b-887d-e81aed0eb231"), "Audio Engineering & Post Production", "Music & Audio", "Vocal Tuning", "Created" },
                    { new Guid("20989b70-7b03-4ce8-8fdd-9ac87757f6b4"), "Chatbot Development", "Programming & Tech", "AI Chatbot", "Created" },
                    { new Guid("20b71398-c6b6-4a0f-977f-1dbb936450ac"), "Career Writing", "Writing & Translation", "Job Descriptions", "Created" },
                    { new Guid("225bf86f-3218-46f9-bf43-d169e352d53c"), "Architecture & Building Design", "Graphics & Design", "Architecture & Interior Design", "Created" },
                    { new Guid("242457bb-7120-45cd-9b79-02fc52aea48f"), "Website Platforms", "Programming & Tech", "Shopify", "Created" },
                    { new Guid("245841f3-8d8a-4288-8d7f-147eb501b6dc"), "Corporate Finance", "Finance", "Due Diligence", "Created" },
                    { new Guid("24e4412f-8712-42d7-9280-497b9aefc3e1"), "Art & Illustration", "Graphics & Design", "AI Avatar Design", "Created" },
                    { new Guid("26963e19-e4b7-4058-86d1-3c9b933295fe"), "Editing & Post-Production", "Video & Animation", "Video Art", "Created" },
                    { new Guid("26a0a8ab-aaee-4dbf-bcf7-8e6c1f02e554"), "Website Development", "Programming & Tech", "Build a Complete Website", "Created" },
                    { new Guid("27cfb66f-8a09-4da8-a44d-1635fdb8c8a1"), "Marketing Design", "Graphics & Design", "Social Posts & Banners", "Created" },
                    { new Guid("27d170c7-eea2-41b7-9b62-777e2f941ce5"), "Data Analysis & Visualization", "Data", "Data Visualization", "Created" },
                    { new Guid("27da61d9-f594-4309-a2d9-0aa243ef87b2"), "3D Design", "Graphics & Design", "3D Fashion & Garment", "Created" },
                    { new Guid("27e5086b-f630-4467-a67b-7e8a53d6c758"), "Animation", "Video & Animation", "NFT Animation", "Created" },
                    { new Guid("28010bf2-1c80-4cfe-b2db-f483790e9c99"), "Streaming & Audio", "Music & Audio", "Audiobook Production", "Created" },
                    { new Guid("283d4d21-de34-4054-8081-7039fe05f288"), "Website Maintenance", "Programming & Tech", "Speed Optimization", "Created" },
                    { new Guid("28bd104c-ba09-4eab-9061-ac487c6b3cf5"), "Miscellaneous", "Graphics & Design", "Design Advice", "Created" },
                    { new Guid("28bf2119-6dd5-4b7c-8768-ecf5bb76958d"), "Miscellaneous", "Programming & Tech", "Convert Files", "Created" },
                    { new Guid("2b46e4ec-8c44-49bb-92f9-a50771e8e1fc"), "Business & Marketing Copy", "Writing & Translation", "Social Media Copywriting", "Created" },
                    { new Guid("2c2ac501-d009-4d54-8d9d-e7f2986cebee"), "Tech Consulting", "Consulting", "Software Development Consulting", "Created" },
                    { new Guid("2d56e851-d4c6-4f03-aaa5-5d16e4283046"), "AI Development", "Programming & Tech", "AI Technology Consulting", "Created" },
                    { new Guid("2e731084-4176-4990-a3e2-51040b71f9e1"), "Website Development", "Programming & Tech", "E-Commerce Development", "Created" },
                    { new Guid("2ec314fb-6d82-4d29-a8e3-341e390302b7"), "Leisure & Hobbies", "Personal Growth", "Astrology & Psychics", "Created" },
                    { new Guid("2ef080ce-097a-41fa-b282-1b91dbbf6d87"), "Miscellaneous", "Personal Growth", "Other", "Created" },
                    { new Guid("2f20c376-6526-4de1-9a36-ce112d8d4427"), "Web & App Design", "Graphics & Design", "Icon Design", "Created" },
                    { new Guid("2f43777a-ca76-41b2-ae58-cb757c8ec613"), "Miscellaneous", "Business", "Online Investigations", "Created" },
                    { new Guid("2f47a55b-129c-49da-aeb8-9ccae985ce0c"), "Wellness & Fitness", "Personal Growth", "Wellness", "Created" },
                    { new Guid("3041a661-aad0-4a3e-9c10-dab515d1fa4e"), "Leisure & Hobbies", "Personal Growth", "Cosplay Creation", "Created" },
                    { new Guid("31205925-ca1e-4323-b435-e7972277dd67"), "Sound Design", "Music & Audio", "Audio Plugin Development", "Created" },
                    { new Guid("31b31b8b-2008-4054-9ff4-f5553c44ef39"), "People & Scenes", "Photography", "Event Photographers", "Created" },
                    { new Guid("31ffa828-3588-4e21-863f-fa20f4a4a188"), "Social & Marketing Videos", "Video & Animation", "Social Media Videos", "Created" },
                    { new Guid("3364c0df-c19c-4da1-ade3-27f44276b28c"), "Methods & Techniques ", "Digital Marketing", "Affiliate Marketing", "Created" },
                    { new Guid("33a35a39-104c-4c78-a96e-7c748c6175c3"), "Data Processing & Management ", "Data", "Data Processing", "Created" },
                    { new Guid("33cd3525-4f5c-4fd3-aab7-b8ac55d60663"), "3D Design", "Graphics & Design", "3D Printing Characters", "Created" },
                    { new Guid("3412a358-e651-45a6-844b-876dcadd9a4e"), "Coaching & Advice", "Consulting", "Career Counseling", "Created" },
                    { new Guid("34c157d3-d787-47d7-8f64-525a7eae40b8"), "Explainer Videos", "Video & Animation", "Crowdfunding Videos", "Created" },
                    { new Guid("359ed165-2072-4119-92cd-2b948f261779"), "Operations & Management", "Business", "E-Commerce Management ", "Created" },
                    { new Guid("364ae1ab-b99b-4199-bf86-6e14607dddd3"), "AI Artists", "AI Services", "AI Image Editing", "Created" },
                    { new Guid("36e40e76-4f52-48b9-80a2-f50984d6f1eb"), "Data Consulting", "Consulting", "Databases Consulting", "Created" },
                    { new Guid("373fea1d-9911-4e88-91d9-2f818bec813d"), "Mobile App Development", "Programming & Tech", "iOS App Development", "Created" },
                    { new Guid("391b6cd6-7e08-48b6-ba55-4921525aa1a4"), "Mobile App Development", "Programming & Tech", "Cross-platform Development", "Created" },
                    { new Guid("392576ba-f9bf-4f4e-9006-a2eafc24cf0b"), "Content Writing", "Writing & Translation", "Speechwriting", "Created" },
                    { new Guid("3926060f-740c-42fa-aeb3-b95d1e56543b"), "Miscellaneous", "Video & Animation", "Book Trailers", "Created" },
                    { new Guid("39519637-9b9d-43cf-b519-abae54a5e02b"), "Data Science & ML", "Data", "Time Series Analysis", "Created" },
                    { new Guid("3a36ea22-e862-4fac-921e-9a9bf2bd32d1"), "Art & Illustration", "Graphics & Design", "Portraits & Caricatures", "Created" },
                    { new Guid("3ab68665-2266-4a6a-866d-3dd9d9f502ae"), "Miscellaneous", "Video & Animation", "Virtual & Streaming Avatars", "Created" },
                    { new Guid("3b25c956-173d-4f43-9664-cbea32636ff8"), "Local Photography", "Photography", "All Cities", "Created" },
                    { new Guid("3b591f92-35e0-4e91-be13-de18698cf368"), "Website Platforms", "Programming & Tech", "GoDaddy", "Created" },
                    { new Guid("3b6914ca-215e-452e-a948-a473b45c1a66"), "Packaging & Covers", "Graphics & Design", "Book Covers", "Created" },
                    { new Guid("3c387c9d-cf45-424e-baaf-1b412fd8e5f9"), "Print Design", "Graphics & Design", "Poster Design", "Created" },
                    { new Guid("3c5e48d8-0911-4e3a-81b8-d17ed68e0443"), "Filmed Video Production", "Video & Animation", "Filmed Video Production", "Created" },
                    { new Guid("3d2e30f4-8f51-4eca-ab63-503ef762945e"), "Financial Planning & Analysis", "Finance", "Budgeting and Forecasting", "Created" },
                    { new Guid("3d61cf47-342b-4c15-a2c5-a9e88a3fe888"), "AI Video", "AI Services", "AI Music Videos", "Created" },
                    { new Guid("3d9d0463-77f9-4523-844b-fbb66d4f2f5d"), "Data Science & ML", "Programming & Tech", "NLP", "Created" },
                    { new Guid("3dd0f214-0dbc-4ad5-a5ff-84d1559f43c1"), "Product & Gaming", "Graphics & Design", "Graphics for Streamers", "Created" },
                    { new Guid("3e80ae0e-3e62-47a8-b823-a7b61a7c9f0d"), "Tax Consulting", "Finance", "Tax Exemptions", "Created" },
                    { new Guid("3f18ce35-a459-4bb4-a36c-a9cfa1107262"), "Mentorship", "Consulting", "Writing Mentorship", "Created" },
                    { new Guid("3f3944ae-3be7-4d87-b414-ea36cc0a4ef6"), "Editing & Post-Production", "Video & Animation", "Visual Effects", "Created" },
                    { new Guid("3fbfc8e6-420d-4939-a32a-3bd637dc698b"), "Art & Illustration", "Graphics & Design", "Pattern Design", "Created" },
                    { new Guid("3ffe6430-2bf2-4da2-97f3-ddab77648dab"), "Accounting Services", "Finance", "Financial Reporting", "Created" },
                    { new Guid("4057c408-4dd2-4b71-b1c8-1de84e52ca6e"), " Book & eBook Publishing", "Writing & Translation", "Book & eBook Writing", "Created" },
                    { new Guid("40c19943-e380-4b62-bf51-6e0372d43c9e"), "AI Mobile Development", "AI Services", "AI Agents", "Created" },
                    { new Guid("4177abb2-c123-465d-86fb-a6d7f40239b2"), "AI Content", "AI Services", "Custom Writing Prompts", "Created" },
                    { new Guid("41882243-b670-4a7b-8674-79d0176a5049"), "Software Development", "Programming & Tech", "User Testing", "Created" },
                    { new Guid("41a0fbe8-d720-4cb3-954c-460200af1071"), "Audio Engineering & Post Production", "Music & Audio", "Mixing & Mastering", "Created" },
                    { new Guid("43e200e5-aa4e-48e1-941c-c38d6272995d"), " Book & eBook Publishing", "Writing & Translation", "Beta Reading", "Created" },
                    { new Guid("442a114e-e073-4b3f-a639-0f8af08e40c9"), "Architecture & Building Design", "Graphics & Design", "Building Engineering", "Created" },
                    { new Guid("442cda70-9a22-4269-aef7-c6d0ee58c140"), "Social", "Digital Marketing", "Social Commerce ", "Created" },
                    { new Guid("44e0faf1-ff0a-4504-9898-f160e6da254c"), "Social & Marketing Videos", "Video & Animation", "Video Ads & Commercials ", "Created" },
                    { new Guid("45a75f28-2117-4313-baa1-5a95e9f9a50e"), "Sales & Customer Care", "Business", "Lead Generation", "Created" },
                    { new Guid("4676ad6f-c8a2-4256-9717-bbae6b034870"), "Editing & Critique", "Writing & Translation", "AI Content Editing", "Created" },
                    { new Guid("46a52ea7-3ee8-4577-80ba-5e97a4a71e11"), "Web & App Design", "Graphics & Design", "Landing Page Design", "Created" },
                    { new Guid("46f8f2dc-93ee-443e-9790-9b171d6dbc6a"), "AI Artists", "AI Services", "ComfyUI Workflow Creation", "Created" },
                    { new Guid("472f887a-0a3e-4be4-9ab2-3a47f551942d"), "Data Collection", "Data", "Data Scraping", "Created" },
                    { new Guid("4a061b69-eea2-4316-a085-2539f41ef3dc"), "Website Platforms", "Programming & Tech", "Wix", "Created" },
                    { new Guid("4aeba0ac-7737-4647-a7b8-f6b18b80b48c"), "Leisure & Hobbies", "Personal Growth", "Collectibles", "Created" },
                    { new Guid("4b74a35f-6589-4184-95a2-8f309990f209"), "Business & Marketing Copy", "Writing & Translation", "Sales Copy", "Created" },
                    { new Guid("4b9a8565-8926-4888-8235-87357783c84c"), "Packaging & Covers", "Graphics & Design", "Album Cover Design", "Created" },
                    { new Guid("4cf74b33-1065-4057-af57-f3fe88c8aa4b"), "Sales & Customer Care", "Business", "Call Center & Calling ", "Created" },
                    { new Guid("4d36a4b7-1891-4128-9143-5d09d7e0922a"), "Editing & Post-Production", "Video & Animation", "Video Editing", "Created" },
                    { new Guid("4e3a3359-1c2f-489b-8ee5-6775c7f9850c"), "Operations & Management", "Business", "Software Management", "Created" },
                    { new Guid("4e463f26-61b3-4957-98e9-129eec9bff4e"), "Explainer Videos", "Video & Animation", "Screencasting Videos", "Created" },
                    { new Guid("4e526e51-6864-45a2-9c07-5f5ae43361df"), "Software Development", "Programming & Tech", "QA & Review", "Created" },
                    { new Guid("4f3f50a4-7613-425a-b24e-72134e003446"), "Data Consulting", "Consulting", "Data Analytics Consulting", "Created" },
                    { new Guid("4f55b097-1b24-4e74-8632-feffc1e4876e"), "Website Development", "Programming & Tech", "Landing Pages", "Created" },
                    { new Guid("4f7eb4e3-96bd-401c-8928-f6b7dc808a19"), "Editing & Critique", "Writing & Translation", "Writing Advice", "Created" },
                    { new Guid("4f89b3bf-0fc6-4d3d-b220-7dc02d7a6664"), "Filmed Video Production", "Video & Animation", "Videographers", "Created" },
                    { new Guid("50259b33-17c0-4406-a72b-f2ef84cf33ed"), "Operations & Management", "Business", "Product Management", "Created" },
                    { new Guid("50cd6c9a-de61-49e8-9f66-a03eefefb1c8"), "AI Video ", "Video & Animation", "AI Music Videos", "Created" },
                    { new Guid("51091059-b5c5-4b6e-9a32-acaae7993b27"), "Miscellaneous", "Video & Animation", "Game Recordings & Guides", "Created" },
                    { new Guid("52df5359-7f46-46a9-aa18-7d6785a174b0"), "Presenter Videos", "Video & Animation", "UGC Ads", "Created" },
                    { new Guid("530463fd-4b75-4221-8c8e-f0bb424a1737"), "AI Mobile Development", "AI Services", "AI Technology Consulting", "Created" },
                    { new Guid("53c86aae-d6b4-4d60-8738-02e1ad5dd910"), "Accounting Services", "Finance", "Payroll Management", "Created" },
                    { new Guid("5402589a-3725-4c32-b10d-7c4a358b3efa"), "Lessons & Transcriptions", "Music & Audio", "Music & Audio Advice", "Created" },
                    { new Guid("55d5233a-c623-4019-928a-6fc545a6bf03"), "Streaming & Audio", "Music & Audio", "Voice Synthesis & AI", "Created" },
                    { new Guid("55ec289e-3aa0-4290-9513-c7fed3f5fe8d"), "AI Video ", "Video & Animation", " AI Video Avatars", "Created" },
                    { new Guid("561d7752-a486-4c54-93ed-7df9103104fd"), "Channel Specific ", "Digital Marketing", "Instagram Marketing", "Created" },
                    { new Guid("5642a7a8-18a9-491a-aa59-118a3f779af7"), "AI Content", "AI Services", "AI Content Editing", "Created" },
                    { new Guid("564af26b-8f9f-4056-9417-9a28fe6cb2ae"), "Mobile App Development", "Programming & Tech", "VR & AR Development", "Created" },
                    { new Guid("573248b2-b20f-450f-a17d-fceacc7bb5d9"), "Analytics & Strategy", "Digital Marketing", "Marketing Advice", "Created" },
                    { new Guid("594725b2-0b18-4d33-bc33-49aba0ace685"), "Tax Consulting", "Finance", "Tax Identification Services", "Created" },
                    { new Guid("5b23445e-e1b3-41d5-8ffb-e341e182efdd"), "Logo & Brand Identity", "Graphics & Design", "Brand Style Guides", "Created" },
                    { new Guid("5b86e8ff-2716-4c7f-b27f-d8086c654f32"), "Architecture & Building Design", "Graphics & Design", "Lighting Design", "Created" },
                    { new Guid("5b9b732a-69d8-4209-bf05-b3f58024a0e9"), "Financial Planning & Analysis", "Finance", "Financial Modeling", "Created" },
                    { new Guid("5be7ca96-84d9-4d93-b678-b1f0d4673d42"), "Industry Specific Content", "Writing & Translation", "Health & Medical ", "Created" },
                    { new Guid("5ce25883-f31e-45f2-afc6-b30beaf7bf7b"), "Miscellaneous", "Personal Growth", "Family & Genealogy", "Created" },
                    { new Guid("5d662d4d-2f82-493e-8a71-213a259f1e55"), "Data Science & ML", "Programming & Tech", "Machine Learning", "Created" },
                    { new Guid("5dc242a1-d656-4a43-9ac3-d0432111ae31"), "3D Design", "Graphics & Design", "3D Game Art", "Created" },
                    { new Guid("5e89f5a3-be55-41a9-9ef5-c38b789d0443"), "Industry Specific Content", "Writing & Translation", "Real Estate", "Created" },
                    { new Guid("5ea9c037-ff53-4cfa-988f-b8e18ef789cf"), "AI Mobile Development", "AI Services", "AI Integrations", "Created" },
                    { new Guid("5f4f9051-319a-4628-9e68-c69ede1b8259"), "Miscellaneous", "Business", "Other", "Created" },
                    { new Guid("5f5a95cf-d425-40ce-af49-65dab50a0117"), "Business Formation & Consulting", "Business", "Market Research", "Created" },
                    { new Guid("5f996a00-1458-43e1-ba48-fa0696762e40"), "Software Development", "Programming & Tech", "Automations & Workflows", "Created" },
                    { new Guid("600b13ea-65a7-4bed-8971-79e451622270"), "Mentorship", "Consulting", "Design Mentorship", "Created" },
                    { new Guid("6014b3f7-d368-4d26-99ac-09b42fc6b768"), "Explainer Videos", "Video & Animation", "eLearning Video Production", "Created" },
                    { new Guid("606776c4-ba7e-4c71-a6a2-ed3cb29b32e9"), "AI for Businesses", "AI Services", "AI Consulting ", "Created" },
                    { new Guid("60834ad4-dc7d-46e2-ba07-58dee655c518"), "Miscellaneous", "Business", "Game Concept Design", "Created" },
                    { new Guid("60ad382f-e69a-4a2c-b17f-e8b17e0fb8ce"), "Miscellaneous", "Business", "Presentations", "Created" },
                    { new Guid("617ff17c-31eb-463b-a664-706cfaa49894"), "AI Development", "Programming & Tech", "AI Agents", "Created" },
                    { new Guid("626508ea-c36b-42dc-86d1-41750c494ca0"), "Methods & Techniques ", "Digital Marketing", "Text Message Marketing", "Created" },
                    { new Guid("62d51fe9-022e-4e1c-ab18-2227ce8b5bd3"), "Local Photography", "Photography", "Photographers in Los Angeles", "Created" },
                    { new Guid("63fdcdff-8cc0-4468-a53c-9ca5066fddc0"), "Miscellaneous", "Photography", "Photo Preset Creation", "Created" },
                    { new Guid("6467263d-d5f0-42e9-b22f-24dc8e49fbae"), "Miscellaneous", "Programming & Tech", "Support & IT", "Created" },
                    { new Guid("6492687e-654a-496e-9294-6cb4bbc63d3f"), "Translation & Transcription", "Writing & Translation", "Translation", "Created" },
                    { new Guid("64ad404c-e8be-4472-bbb6-5d444e74478b"), "Search", "Digital Marketing", "Video SEO", "Created" },
                    { new Guid("64c52e62-66f3-45f9-a559-fbaa04371769"), "Content Writing", "Writing & Translation", "Creative Writing", "Created" },
                    { new Guid("65684a07-1315-4a5c-8b7f-a316c26a7fae"), "Visual Design", "Graphics & Design", "Background Removal", "Created" },
                    { new Guid("6867c94e-6990-429b-9fb2-680b58e0c979"), "Mobile App Development", "Programming & Tech", "Website to App", "Created" },
                    { new Guid("68c3f8af-5e72-42f2-839c-b2d6d2ddcc04"), "Editing & Post-Production", "Video & Animation", "Intro & Outro Videos", "Created" },
                    { new Guid("68cce523-e6ac-4f27-aad4-a46bb4915643"), "Accounting Services", "Finance", "Find a Financial Expert", "Created" },
                    { new Guid("68f6fc41-1b15-4ce5-a1ff-d12f1b7dcadc"), "Self Improvement", "Personal Growth", "Language Lessons", "Created" },
                    { new Guid("69c8825f-e29a-486f-9a63-7b178febe405"), "Web & App Design", "Graphics & Design", "UX Design", "Created" },
                    { new Guid("6ac0dd05-d462-4cf7-8bb1-5d08af3a17e7"), "Social", "Digital Marketing", "Community Management", "Created" },
                    { new Guid("6b30d47d-4b51-4bce-b492-be49a5f2bca1"), "Presenter Videos", "Video & Animation", "Spokesperson Videos", "Created" },
                    { new Guid("6b58ef51-39c7-4b35-a652-e6fefdabdf5e"), "Sales & Customer Care", "Business", "Sales", "Created" },
                    { new Guid("6badf3a4-5adb-4332-8cac-ec6660aebc3b"), "Industry Specific Content", "Writing & Translation", "Marketing", "Created" },
                    { new Guid("6c0e3b14-007d-4586-8352-8825ff7639f8"), "Operations & Management", "Business", "Supply Chain Management", "Created" },
                    { new Guid("6c8c5921-49be-4892-b824-00366e13d942"), "Miscellaneous", "Digital Marketing", "Crowdfunding", "Created" },
                    { new Guid("6d42e3f1-f36c-4925-8dc0-f2e37cf45e62"), "People & Scenes", "Photography", "Real Estate Photographers", "Created" },
                    { new Guid("6e0b7ceb-c4af-4dda-ac18-ac7086c24fab"), "Leisure & Hobbies", "Personal Growth", "Puzzle & Game Creation", "Created" },
                    { new Guid("6e7005e3-be26-44ba-9c7b-2345c7cb873b"), "3D Design", "Graphics & Design", "3D Jewelry Design", "Created" },
                    { new Guid("6e8fc5b9-47e5-42fa-af6e-4c1cdae69a91"), "Animation", "Video & Animation", "Character Animation", "Created" },
                    { new Guid("6efc2547-d119-468d-a270-754e49b75cbd"), "Search", "Digital Marketing", "Search Engine Optimization (SEO)", "Created" },
                    { new Guid("6fc605be-6ddf-41f5-a402-030cddbb928e"), "Animation", "Video & Animation", "Animation for Kids", "Created" },
                    { new Guid("70eec0c5-c35c-4bbe-86ee-1e23c437f9ca"), "Editing & Critique", "Writing & Translation", "Proofreading & Editing", "Created" },
                    { new Guid("71d44b5a-3714-4a34-9907-3f5ca420a4c4"), "Industry & Purpose-Specific", "Digital Marketing", "Book & eBook Marketing", "Created" },
                    { new Guid("72cf3182-39fa-4038-bc15-169dfff402da"), "Channel Specific ", "Digital Marketing", " Shopify Marketing", "Created" },
                    { new Guid("74e2954c-80da-47b8-bba8-99616f44f899"), "Logo & Brand Identity", "Graphics & Design", "Logo Design", "Created" },
                    { new Guid("764355ea-d643-4319-b122-2bb491f13eae"), "Legal Services", "Business", "General Legal Advice", "Created" },
                    { new Guid("7650afd3-ac2e-4813-ac6a-66c630307c4a"), "Software Development", "Programming & Tech", "Web Applications", "Created" },
                    { new Guid("7681e4d3-2b45-477b-9219-5fb02ba4f7d5"), "Coaching & Advice", "Consulting", "Styling & Beauty Advice", "Created" },
                    { new Guid("76f98b47-003e-467f-805a-10ee5eb50005"), "Data Collection", "Data", "Data Entry", "Created" },
                    { new Guid("7709c802-ae2a-4b0f-a3a3-2c62d933198f"), "Chatbot Development", "Programming & Tech", "Telegram", "Created" },
                    { new Guid("79576a41-4378-48ab-9aaa-3533613b8478"), "Cloud & Cybersecurity ", "Programming & Tech", "DevOps Engineering", "Created" },
                    { new Guid("79b975b6-32a9-4351-93d7-116e2949e041"), "Data Consulting", "Consulting", "Data Visualization Consulting", "Created" },
                    { new Guid("7a1b352e-f8ca-448f-96c0-97e2f6b05983"), "Local Photography", "Photography", "Photographers in Paris", "Created" },
                    { new Guid("7ab3b0ba-8c8c-4827-95ec-0072cb311fdf"), "Tax Consulting", "Finance", "Tax Compliance", "Created" },
                    { new Guid("7ba023d2-fc31-4dd1-8e39-a2962c172398"), "Visual Design", "Graphics & Design", "Resume Design", "Created" },
                    { new Guid("7beb4d94-93b2-435f-8cb9-b013eddb39c7"), "Business & Marketing Copy", "Writing & Translation", "White Papers", "Created" },
                    { new Guid("7cb55273-ba0b-4930-bb9a-fe469621ba53"), "Business & Marketing Copy", "Writing & Translation", "UX Writing", "Created" },
                    { new Guid("7cd3789f-4a58-41e5-b7e0-7a5921649af2"), "Art & Illustration", "Graphics & Design", "AI Artists", "Created" },
                    { new Guid("7d1d2d28-16a1-46c9-92ed-2420b91d84d6"), "Marketing Strategy", "Consulting", "Influencers Strategy", "Created" },
                    { new Guid("7dea8b59-2b19-4bdc-8d7c-70f7928e93d2"), "AI Mobile Development", "AI Services", "AI Chatbot", "Created" },
                    { new Guid("7e95cefa-dc7c-4ca4-be9b-28552c29bdea"), "Career Writing", "Writing & Translation", "Resume Writing", "Created" },
                    { new Guid("7ef6a2db-5af4-4872-ad94-a245f85b2b87"), "AI Video", "AI Services", "AI Video Art", "Created" },
                    { new Guid("7f4b8761-5366-4a08-ba26-5a571e32341c"), "Data Collection", "Data", "Data Enrichment", "Created" },
                    { new Guid("7f8e1273-5e76-44f5-ab97-1972eb0bf4e0"), "Self Improvement", "Personal Growth", "Generative AI Lessons", "Created" },
                    { new Guid("7fcb57df-8244-45fc-a105-f63a253ec002"), "AI Artists", "AI Services", "Midjourney Artists", "Created" },
                    { new Guid("801516dc-d4d7-4161-8439-4d6cc455af00"), "Visual Design", "Graphics & Design", "Vector Tracing", "Created" },
                    { new Guid("83f42ba5-a1e1-4604-b852-4857b401a513"), "Channel Specific ", "Digital Marketing", "Google SEM", "Created" },
                    { new Guid("84a58a79-d580-4175-bafe-ac57c1e8a17a"), "Miscellaneous", "Business", "Sustainability Consulting", "Created" },
                    { new Guid("84ebe8d8-bba1-4006-8f0f-79eaf1a1de23"), "Software Development", "Programming & Tech", "Desktop Applications", "Created" },
                    { new Guid("85616a97-a1db-4c53-a06f-2eb9345c9acd"), "Business & Marketing Copy", "Writing & Translation", "Case Studies", "Created" },
                    { new Guid("8592caeb-a0f3-4dd3-81d0-d23a792bc57d"), "Motion Graphics", "Video & Animation", "Lottie & Web Animation", "Created" },
                    { new Guid("85f270cd-44e0-4ee0-aeb7-5cbcf9f0605f"), "Music Production & Writing", "Music & Audio", "Session Musicians", "Created" },
                    { new Guid("860d01ae-408a-4e7f-b77d-31d3d27fbce0"), "Data Collection", "Data", "Data Cleaning", "Created" },
                    { new Guid("87742dd1-05fe-400e-822d-7c540dcf835e"), "Music Production & Writing", "Music & Audio", "Custom Songs", "Created" },
                    { new Guid("8781511e-c388-4699-bcf2-b8468de1a1be"), "AI Artists", "AI Services", "Stable Diffusion Artists", "Created" },
                    { new Guid("8962eaf3-bed3-4f3f-89c5-7948999ce47a"), "DJing", "Music & Audio", "DJ Drops & Tags", "Created" },
                    { new Guid("89ec059c-1393-4d26-a223-53e06824d478"), "Product & Gaming", "Graphics & Design", "Game Art", "Created" },
                    { new Guid("8a17b4d9-313e-4cc8-b0f6-63f6519912f9"), "Methods & Techniques ", "Digital Marketing", "Public Relations", "Created" },
                    { new Guid("8ad2084b-1722-483b-99d0-a3449d90acbd"), "Leisure & Hobbies", "Personal Growth", "Traveling", "Created" },
                    { new Guid("8b2877a7-fb4f-4d36-89e3-34ee178ce406"), "Visual Design", "Graphics & Design", "Image Editing", "Created" },
                    { new Guid("8b4c2d5a-857a-4dc9-bf6c-502ef3c34051"), "Career Writing", "Writing & Translation", "Cover Letters", "Created" },
                    { new Guid("8b64a6d8-e2fe-4160-9156-e904f55c426b"), "Personal Finance & Wealth Management", "Finance", "Online Trading Lessons", "Created" },
                    { new Guid("8bf1f396-75f7-46ce-a902-820b54a1bb6b"), "Business Consultants", "Consulting", "HR Consulting", "Created" },
                    { new Guid("8c01e77d-b84c-4c17-ab95-60c3bf9b6cb7"), "Marketing Strategy", "Consulting", "Content Strategy", "Created" },
                    { new Guid("8c731c52-d855-4125-af1c-ef2ba08ae66e"), "Corporate Finance", "Finance", "Corporate Finance Strategy", "Created" },
                    { new Guid("8d6627d1-8969-4ab6-90a8-ebbf095ccc85"), "Print Design", "Graphics & Design", "Catalog Design", "Created" },
                    { new Guid("8e5cc436-daab-4de2-85be-485c68803473"), "Music Production & Writing", "Music & Audio", "Jingles & Intros", "Created" },
                    { new Guid("8e68a403-7888-408a-b035-ec12bd2a31cc"), "Mentorship", "Consulting", "Music Mentorship", "Created" },
                    { new Guid("8ece4907-9b06-4ae1-a650-051795555bf0"), "Audio Engineering & Post Production", "Music & Audio", "Audio Editing", "Created" },
                    { new Guid("8efad708-04de-42e9-a792-b36c50de94cf"), "Data", "AI Services", "Data Analytics", "Created" },
                    { new Guid("8f488d1f-94b0-4181-b31e-4c238f2f9e4f"), "AI Video", "AI Services", " AI Video Avatars", "Created" },
                    { new Guid("90cdbefb-30d2-4ddc-becc-c767118f9b44"), "Miscellaneous", "Video & Animation", "Meditation Videos", "Created" },
                    { new Guid("90ce816c-117d-4eaf-acfc-c0905645966a"), "Business Formation & Consulting", "Business", "HR Consulting", "Created" },
                    { new Guid("91093362-3944-4b7c-aad9-b3cbda3ecb9c"), "People & Scenes", "Photography", "Portrait Photographers", "Created" },
                    { new Guid("9114772e-c636-479e-8fb3-5922d3d91a48"), "Product Videos ", "Video & Animation", "Corporate Videos", "Created" },
                    { new Guid("913ca504-1151-478d-be88-58f63baa83a2"), "3D Design", "Graphics & Design", "3D Architecture", "Created" },
                    { new Guid("9178bf76-e9db-45a6-935c-3e426b6a47aa"), "Gaming", "Personal Growth", "Game Recordings & Guides", "Created" },
                    { new Guid("93aed937-565b-4b69-9f78-299ad26bceb8"), "Website Development", "Programming & Tech", "Business Websites", "Created" },
                    { new Guid("93c25529-20f6-4034-9ace-2f3b964c36a9"), "Chatbot Development", "Programming & Tech", "Rules Based Chatbot", "Created" },
                    { new Guid("94e2f925-730d-4770-b02c-54d571d547b8"), "Miscellaneous", "Photography", "Other", "Created" },
                    { new Guid("955d1a02-93dc-4d6d-bb88-a3d627722d6c"), "Website Development", "Programming & Tech", "Dropshipping Websites", "Created" },
                    { new Guid("9602fcb3-6f22-4668-9f3b-4eed6e49b828"), "Marketing Strategy", "Consulting", "Marketing Strategy", "Created" },
                    { new Guid("96e26e73-a3a9-45c0-91a1-ac202a0dabc7"), "Data Analysis & Visualization", "Data", "Data Analytics", "Created" },
                    { new Guid("9878efc0-fd87-491f-9aa2-4d20522734a2"), "Legal Services", "Business", "Legal Research", "Created" },
                    { new Guid("993fd57f-79e1-4aad-b46d-6c5d5cdc9a8c"), "Business & Marketing Copy", "Writing & Translation", "Business Names & Slogans", "Created" },
                    { new Guid("9c2ef571-717f-437b-8164-036d17701082"), "Business Consultants", "Consulting", "Business Plans", "Created" },
                    { new Guid("9e039a39-ae97-4c31-ad34-e4ceca594640"), "Explainer Videos", "Video & Animation", "Live Action Explainers", "Created" },
                    { new Guid("9e33bba5-a7dc-4f22-8523-9aa40be83c13"), "Sound Design", "Music & Audio", "Audio Logo & Sonic Branding", "Created" },
                    { new Guid("9eb09537-e549-4dd9-8a03-00bdde264fd6"), "Translation & Transcription", "Writing & Translation", "Transcription", "Created" },
                    { new Guid("9f324984-1078-44cd-a0a3-fc2b29ad3bf1"), "Coaching & Advice", "Consulting", "Mindfulness Coaching", "Created" },
                    { new Guid("9fd75258-bfae-4bf2-90f5-c1cedc6b99bb"), "Fashion & Style", "Personal Growth", "Trend Forecasting", "Created" },
                    { new Guid("a0471918-b489-439a-a746-cd97a29134cc"), "Fashion & Merchandise", "Graphics & Design", "Jewelry Design", "Created" },
                    { new Guid("a06003cc-a27c-45bd-a6f2-71ce141835ad"), "Miscellaneous", "Video & Animation", "Video Advice", "Created" },
                    { new Guid("a0fdc1ad-824c-4207-b96d-a3b7e7237e4b"), "AI Mobile Development", "AI Services", "AI Fine-Tuning", "Created" },
                    { new Guid("a11f3917-829f-4abc-8d5b-07cdcf6af10f"), "Miscellaneous", "Personal Growth", "Greeting Cards & Videos", "Created" },
                    { new Guid("a161a963-f0eb-45b5-99cb-180d26fee939"), "Website Platforms", "Programming & Tech", "Custom Websites", "Created" },
                    { new Guid("a2207417-1aaf-4edb-98ad-032105bf945d"), "Voice Over & Narration", "Music & Audio", "Male Voice Over", "Created" },
                    { new Guid("a2235aeb-b7b1-4861-91f0-41a4db893135"), "Packaging & Covers", "Graphics & Design", "Book Design", "Created" },
                    { new Guid("a320d29f-7893-4166-8363-b3138baf8107"), "Methods & Techniques ", "Digital Marketing", "E-Commerce Marketing", "Created" },
                    { new Guid("a487a1f9-0594-41a3-8ac1-6d5360da40a3"), "Cloud & Cybersecurity ", "Programming & Tech", "Cloud Computing", "Created" },
                    { new Guid("a49ef1d4-212b-4b50-9ffa-4b67beb9a6e1"), "Accounting Services", "Finance", "Bookkeeping", "Created" },
                    { new Guid("a522c547-a65d-4637-90ba-06af63b0aaf6"), "Gaming", "Personal Growth", "Game Coaching", "Created" },
                    { new Guid("a538fead-4f9b-43e5-963b-edce4c793687"), "AI Audio", "AI Services", "Text to Speech", "Created" },
                    { new Guid("a5765c34-96f1-4be0-8165-32e9669b2877"), "Local Photography", "Photography", "Photographers in New York", "Created" },
                    { new Guid("a58d1783-974b-48e0-bc54-7a93320c1972"), "Website Maintenance", "Programming & Tech", "Website Customization", "Created" },
                    { new Guid("a5b9ebf6-cf44-4050-aa17-2f058829820d"), "Data Collection", "Data", "Data Typing", "Created" },
                    { new Guid("a5d08268-d9cd-431e-b9f1-234c78351c5b"), "AI Development", "Programming & Tech", "AI Mobile Apps", "Created" },
                    { new Guid("a5e5c75d-96d3-4167-be5d-940f9f63d8ab"), "Data", "AI Services", "Data Science & ML", "Created" },
                    { new Guid("a6966f54-7eb3-4454-b427-743ab2a09f24"), "Print Design", "Graphics & Design", "Flyer Design", "Created" },
                    { new Guid("a8071486-de17-4fc8-a636-abbb3a9e1fdc"), "Coaching & Advice", "Consulting", "Game Coaching", "Created" },
                    { new Guid("a8699482-8d2e-477d-a9cd-efd58361bb1e"), "Content Writing", "Writing & Translation", "Find an Expert Writer", "Created" },
                    { new Guid("a88edc5e-c3e2-438e-9eb6-1e3e977a417f"), "Operations & Management", "Business", "Virtual Assistant", "Created" },
                    { new Guid("a8a34be8-6fc4-4089-97cd-2bc1c3eb9e06"), "Tax Consulting", "Finance", "Tax Returns", "Created" },
                    { new Guid("a9075a03-5c27-4f6c-b855-b2ec598f5433"), "Animation", "Video & Animation", "Animated GIFs", "Created" },
                    { new Guid("a974c36f-90f3-4ef5-814a-de5418450b81"), "Social & Marketing Videos", "Video & Animation", "Music Videos", "Created" },
                    { new Guid("a98adf28-0a94-476f-bebf-a9004571a551"), "Fundraising", "Finance", "Funding Pitch Presentations", "Created" },
                    { new Guid("aa1525a0-ad38-4cee-af13-da953916a692"), "Motion Graphics", "Video & Animation", "Text Animation", "Created" },
                    { new Guid("aa1a9d84-7f1b-4bd6-8bc0-7b4126eff7f3"), "Data Collection", "Data", "Data Formatting", "Created" },
                    { new Guid("aa31daa7-0460-404c-81b6-1cb3fff15e18"), "Miscellaneous", "Personal Growth", "Cosmetics Formulation", "Created" },
                    { new Guid("ad03d7de-9036-43f4-be94-179c6f1d41eb"), "Wellness & Fitness", "Personal Growth", "Fitness", "Created" },
                    { new Guid("ad3de52c-d964-405c-9bdc-f2fc7c8d8e4c"), "Software Development", "Programming & Tech", "Databases", "Created" },
                    { new Guid("addc54f8-b0c5-41a9-a58f-9d779342c91d"), "Lessons & Transcriptions", "Music & Audio", "Music Transcription", "Created" },
                    { new Guid("ae1ced23-f6ae-499c-875d-bf23b08f0ad6"), "Marketing Strategy", "Consulting", "PR Strategy", "Created" },
                    { new Guid("ae28463b-071b-4631-952b-401fb5fa67db"), "Voice Over & Narration", "Music & Audio", "Female Voice Over", "Created" },
                    { new Guid("ae6a9ccb-d83e-4454-b268-4c266ec14523"), "Fashion & Merchandise", "Graphics & Design", "T-Shirts & Merchandise", "Created" },
                    { new Guid("af0612d3-638d-4523-a206-2c83e0dd5c6a"), "Social", "Digital Marketing", "Influencer Marketing", "Created" },
                    { new Guid("afd0ccc7-bc5c-41fa-99ac-799f9262c8ce"), "Art & Illustration", "Graphics & Design", "NFT Art", "Created" },
                    { new Guid("aff95f17-07d2-4b06-8992-94285b7dbb65"), " Book & eBook Publishing", "Writing & Translation", "Self-Publish Your Book", "Created" },
                    { new Guid("b06cb3a8-a0c4-4d5c-b490-3e938877a9ec"), "Print Design", "Graphics & Design", "Brochure Design", "Created" },
                    { new Guid("b16aa0ef-b068-429e-a0cf-bc82839f651d"), "Coaching & Advice", "Consulting", "Travel Advice", "Created" },
                    { new Guid("b1a23375-6aec-4536-9123-c439e6f26127"), "Mobile App Development", "Programming & Tech", "Android App Development", "Created" },
                    { new Guid("b218eb50-6011-46d3-9937-5d63855905f5"), "Software Development", "Programming & Tech", "APIs & Integrations", "Created" },
                    { new Guid("b26b8413-9370-4f6b-9b60-bf5436437d54"), "Data Analysis & Visualization", "Data", "Data Annotation", "Created" },
                    { new Guid("b3cc5e55-7ca5-48c5-b498-5ecdab90ce9c"), "Legal Services", "Business", "Intellectual Property Management", "Created" },
                    { new Guid("b54f5f87-c9b6-4543-93ee-fa85337b361d"), "Content Writing", "Writing & Translation", "Content Strategy", "Created" },
                    { new Guid("b560eda4-5563-422e-ba08-23540ade10d3"), "AI Mobile Development", "AI Services", "AI Websites & Software", "Created" },
                    { new Guid("b5690a49-e4e6-4b3c-b180-76c1510bc870"), "Industry Specific Content", "Writing & Translation", "News & Politics", "Created" },
                    { new Guid("b578b772-7e76-40b8-8ce0-e214fe4b037d"), "Marketing Design", "Graphics & Design", "Signage Design", "Created" },
                    { new Guid("b60f16a2-4f39-4d98-9f67-aafb9e41d77d"), "Content Writing", "Writing & Translation", "Scriptwriting", "Created" },
                    { new Guid("b6b6e5be-2ad9-4c81-9a4f-ccd444a90d84"), "Search", "Digital Marketing", "Search Engine Marketing (SEM)", "Created" },
                    { new Guid("b6beacd4-b4dc-4750-8872-e155ad63673a"), "Sound Design", "Music & Audio", "Custom Patches & Samples", "Created" },
                    { new Guid("b792433c-4530-44ba-bbc0-8f82580730e5"), "Miscellaneous", "Digital Marketing", "Other", "Created" },
                    { new Guid("b7b7d8a8-bef6-4625-ad56-d93c64a29069"), "Mobile App Development", "Programming & Tech", "Mobile App Maintenance", "Created" },
                    { new Guid("b7bd4410-2c1c-494b-9dbd-dfd8d5a449c0"), "Analytics & Strategy", "Digital Marketing", "Marketing Strategy", "Created" },
                    { new Guid("b992001c-6819-4fea-887e-c14e3584eeab"), "Content Writing", "Writing & Translation", "Articles & Blog Posts", "Created" },
                    { new Guid("b9c4c69d-7f6c-4b1d-bc00-aeddf7d6e325"), "3D Design", "Graphics & Design", "3D Landscape", "Created" },
                    { new Guid("ba488ec3-2982-415c-88f8-e8d6e97ca005"), "Blockchain & Cryptocurrency", "Programming & Tech", "Cryptocurrencies & Tokens", "Created" },
                    { new Guid("ba5b9d08-cf13-4be1-975a-00fe2d532a08"), "Data Science & ML", "Data", "Machine Learning", "Created" },
                    { new Guid("ba7bed53-fcc8-4150-963b-43901dd26682"), "Data Processing & Management ", "Data", "Data Governance & Protection", "Created" },
                    { new Guid("ba8385de-809c-4f49-be84-e9d5627c2c99"), "Software Development", "Programming & Tech", "Scripting", "Created" },
                    { new Guid("bb9f2dfb-6989-4e6c-9572-9dc982b2ea34"), "Accounting Services", "Finance", "Fractional CFO Services", "Created" },
                    { new Guid("bd3a3f3e-c74b-4123-9dc3-d48055d40d0c"), "Cloud & Cybersecurity ", "Programming & Tech", "Cybersecurity", "Created" },
                    { new Guid("bdac07db-729d-4f5c-835e-26b1061d2ddc"), "AI Development", "Programming & Tech", "AI Fine-Tuning", "Created" },
                    { new Guid("bdb2f671-7d76-400d-b8c5-a3272e8f9bf0"), "Chatbot Development", "Programming & Tech", "Discord", "Created" },
                    { new Guid("c035c361-4d1b-4b2d-bccf-e83287526910"), "Translation & Transcription", "Writing & Translation", "Interpretation", "Created" },
                    { new Guid("c04e14df-e24c-4909-8ea7-ba8bfe532bb8"), "AI Artists", "AI Services", "AI Avatar Design", "Created" },
                    { new Guid("c068b800-36e8-4c00-a253-d93731a172df"), "Logo & Brand Identity", "Graphics & Design", "Fonts & Typography", "Created" },
                    { new Guid("c0795941-12c5-4c62-adb4-6ab2e966438f"), "Databases & Engineering", "Data", "Databases", "Created" },
                    { new Guid("c08041d5-08a2-4e32-b95f-e54edcee1827"), "Sound Design", "Music & Audio", "Meditation Music", "Created" },
                    { new Guid("c1d1d77c-976f-45e0-8b7d-4e1326e938c1"), "Business Consultants", "Consulting", "Business Consulting", "Created" },
                    { new Guid("c24df8ae-4c93-4b03-9669-cafaa6a168a7"), "Social", "Digital Marketing", "Paid Social Media", "Created" },
                    { new Guid("c27e75a5-9fb0-4541-ae57-a5a2a37eac18"), "Channel Specific ", "Digital Marketing", "TikTok Shop", "Created" },
                    { new Guid("c2c0e6d3-e6e3-415e-9907-f6c5b3e3dab9"), "Content Writing", "Writing & Translation", "Website Content", "Created" },
                    { new Guid("c2e2ca9d-f40d-4d6a-afc4-d14a5b1e7711"), "Personal Finance & Wealth Management", "Finance", "Personal Budget Management", "Created" },
                    { new Guid("c505bdef-304e-4075-ad51-043fbb03b199"), "Voice Over & Narration", "Music & Audio", "French Voice Over", "Created" },
                    { new Guid("c5675b57-c8fd-4494-8aa9-aa05aed8538c"), "Product & Gaming", "Graphics & Design", "Industrial & Product Design", "Created" },
                    { new Guid("c56cdaa0-f746-400c-b814-68dbe05155b4"), "Product Videos ", "Video & Animation", "E-Commerce Product Videos", "Created" },
                    { new Guid("c56d78c3-79a5-4f51-9766-2669b3a22211"), "Business Formation & Consulting", "Business", "Business Formation & Registration", "Created" },
                    { new Guid("c5da70ff-6b0e-45c4-9fd2-278443bbcd08"), "Coaching & Advice", "Consulting", "Life Coaching", "Created" },
                    { new Guid("c640112f-99ef-432a-9e93-c957432a236a"), "Mentorship", "Consulting", "Marketing Mentorship", "Created" },
                    { new Guid("c6532e7c-7286-45a2-88b5-6258167a0c3e"), "Tech Consulting", "Consulting", "Cybersecurity Consulting", "Created" },
                    { new Guid("c8120cca-8ad3-4b53-9167-70440e801d64"), "Financial Planning & Analysis", "Finance", "Stock Analysis", "Created" },
                    { new Guid("c8ab7a94-7cd3-44d2-96b2-1e18952700e0"), "Product Videos ", "Video & Animation", "App & Website Previews", "Created" },
                    { new Guid("c8b7f751-8e0a-46fa-add3-f3998312a526"), "Music Production & Writing", "Music & Audio", "Music Producers", "Created" },
                    { new Guid("c8e123f6-d0ed-40d7-974a-6c708148d52d"), "Legal Services", "Business", "Legal Documents & Contracts", "Created" },
                    { new Guid("c9a05af3-b08c-454e-b118-572e419995fc"), "Streaming & Audio", "Music & Audio", "Audio Ads Production", "Created" },
                    { new Guid("ca2ec481-3f65-407e-bd23-5d5bfe9ce7c1"), "DJing", "Music & Audio", "DJ Mixing", "Created" },
                    { new Guid("cb72b0a6-8ec0-4d3b-bec2-da94dd8c5adc"), "Data Science & ML", "Data", "NLP", "Created" },
                    { new Guid("cb9ee74b-692b-4a8b-949d-f86f81e5770b"), "Marketing Design", "Graphics & Design", "Social Media Design", "Created" },
                    { new Guid("cbaaadcf-43ea-49b8-969b-2b32d55d21cc"), "Game Development", "Programming & Tech", "Gameplay Experience & Feedback", "Created" },
                    { new Guid("cbb9492c-25c1-42ed-a0b7-77714d5b4762"), "Art & Illustration", "Graphics & Design", "Cartoons & Comics", "Created" },
                    { new Guid("cbc67ac5-3ae9-4e36-8f60-91a902c7b079"), "Voice Over & Narration", "Music & Audio", "German Voice Over", "Created" },
                    { new Guid("cbe0ebb2-77a9-4348-875f-ee04b88f03dc"), "Data Science & ML", "Data", "Generative Models", "Created" },
                    { new Guid("cc663401-da44-4c79-a4ef-5221f0cfc48c"), "Products & Lifestyle", "Photography", "Product Photographers", "Created" },
                    { new Guid("ccd27750-204e-4ce3-abe4-e91449969129"), "Tech Consulting", "Consulting", "Game Development Consulting", "Created" },
                    { new Guid("cd5a2b2a-75d9-4349-8383-fa491c902497"), "Website Maintenance", "Programming & Tech", "Bug Fixes", "Created" },
                    { new Guid("cdc51935-d28f-402e-a88b-06496f24831b"), "Data Science & ML", "Data", "Deep Learning", "Created" },
                    { new Guid("ce073c14-39ae-4b08-a6c1-25741310bbf5"), "Marketing Design", "Graphics & Design", "Email Design", "Created" },
                    { new Guid("ce615793-390f-413f-bb44-3f7c9af5ba40"), "Data Analysis & Visualization", "Data", "Dashboards", "Created" },
                    { new Guid("cf1d4d8a-217e-4603-9d1f-e5caa629972f"), "Databases & Engineering", "Data", "Data Engineering", "Created" },
                    { new Guid("cfef5c9e-2ece-438d-8768-99f502a64d59"), "Streaming & Audio", "Music & Audio", "Podcast Production", "Created" },
                    { new Guid("cffae4a5-a140-4c5f-a6d8-cd84755080a7"), "Animation", "Video & Animation", "Rigging", "Created" },
                    { new Guid("d0dccc13-a57d-48b8-836e-1c9808251df3"), "Tech Consulting", "Consulting", "Mobile App Consulting", "Created" },
                    { new Guid("d19a2bd5-b64f-4560-9648-26aba459869f"), "AI Development", "Programming & Tech", "AI Integrations", "Created" },
                    { new Guid("d19eadc4-162d-4a75-9b9f-6f835e9c2ea4"), "Tech Consulting", "Consulting", "AI Technology Consulting", "Created" },
                    { new Guid("d28497ef-c66f-447b-97e1-62342655ef32"), "Product Videos ", "Video & Animation", "3D Product Animation", "Created" },
                    { new Guid("d293aea0-fc84-4d5e-ae9b-2806499abccc"), "Presenter Videos", "Video & Animation", "TikTok UGC Videos", "Created" },
                    { new Guid("d2942f4b-1118-4167-8979-e2c60eb0bf7f"), "Miscellaneous", "Writing & Translation", "eLearning Content Development", "Created" },
                    { new Guid("d367d93e-e7a6-46b9-84b3-d9a2cbf0d96e"), "Animation", "Video & Animation", "Animation for Streamers", "Created" },
                    { new Guid("d3d1ec43-4d38-43a1-916f-179866d59e20"), "AI Artists", "AI Services", "All AI Art Services", "Created" },
                    { new Guid("d475ab12-71f1-488c-b20d-be25c0b05356"), "Blockchain & Cryptocurrency", "Programming & Tech", "Exchange Platforms", "Created" },
                    { new Guid("d483be97-8bd4-4337-b5c0-957655c1e8d2"), "Art & Illustration", "Graphics & Design", "Tattoo Design", "Created" },
                    { new Guid("d4a5b05d-4956-4daf-9ff4-b96192526bb0"), "Corporate Finance", "Finance", "Valuation", "Created" },
                    { new Guid("d4cb694e-5d91-474e-b543-a42986dc35ab"), "Gaming", "Personal Growth", "Ingame Creation", "Created" },
                    { new Guid("d4e81e3c-0379-41b8-8624-39c17065e645"), "AI for Businesses", "AI Services", "AI Strategy", "Created" },
                    { new Guid("d61d4304-4146-436f-82d6-bc70601b3327"), "Web & App Design", "Graphics & Design", "Website Design", "Created" },
                    { new Guid("d64294c7-cddd-411a-8b58-67d6b9028863"), "Tax Consulting", "Finance", "Tax Planning", "Created" },
                    { new Guid("d7186e42-3256-4c32-97d5-39eefa52ad85"), "Presenter Videos", "Video & Animation", "UGC Videos ", "Created" },
                    { new Guid("d7f43097-5dbb-4de4-aeda-3ff2b7eae30b"), "Website Maintenance", "Programming & Tech", "Backup & Migration", "Created" },
                    { new Guid("d8de6830-e788-49e2-8d95-51c3e6c91831"), "Methods & Techniques ", "Digital Marketing", "Email Marketing", "Created" },
                    { new Guid("d9a012e9-3892-460c-90bf-70c1d78d5a2c"), "Corporate Finance", "Finance", "Mergers & Acquisitions Advisory", "Created" },
                    { new Guid("d9f289a8-f8ce-4940-b3af-97175e5d9074"), "DJing", "Music & Audio", "Remixing", "Created" },
                    { new Guid("da03c31b-9308-4d48-afbe-795ab197ba98"), "Miscellaneous", "Programming & Tech", "Discord Server Setup", "Created" },
                    { new Guid("da60106e-bf70-41e6-881d-635814390e6b"), "Analytics & Strategy", "Digital Marketing", "Conversion Rate Optimization (CRO)", "Created" },
                    { new Guid("db2b507c-a24c-452e-9c46-122b6181c7d3"), "Self Improvement", "Personal Growth", "Career Counseling", "Created" },
                    { new Guid("dc2f9d3f-db3e-4330-ae6d-cf89b9443113"), "Marketing Strategy", "Consulting", "SEM Strategy", "Created" },
                    { new Guid("dc630931-9b59-4b17-b7c3-ae7e3fdce213"), "Methods & Techniques ", "Digital Marketing", "Display Advertising ", "Created" },
                    { new Guid("dc8cdf8d-bc0d-4b15-92c6-de10990ffa1c"), "Visual Design", "Graphics & Design", "Presentation Design", "Created" },
                    { new Guid("dd5b1d82-d7c0-4b49-a93f-9dcb9d1a83ee"), "Business Consultants", "Consulting", "AI Consulting", "Created" },
                    { new Guid("dec385c4-7dab-45b7-9ff8-096040be9eb0"), "Business & Marketing Copy", "Writing & Translation", "Press Releases", "Created" },
                    { new Guid("dfc3af8b-71d9-457b-b3ed-d2390195c959"), "AI Video ", "Video & Animation", "AI Video Art", "Created" },
                    { new Guid("e0f176ae-cf11-4815-9a9f-72544b6dd9ff"), "Products & Lifestyle", "Photography", "Lifestyle & Fashion Photographers", "Created" },
                    { new Guid("e1669f51-c35c-42d6-8c39-e4562bcf9df3"), "Analytics & Strategy", "Digital Marketing", "Web Analytics", "Created" },
                    { new Guid("e1721c31-7cb7-4735-95ed-22b8fb661e0a"), "Leisure & Hobbies", "Personal Growth", "Arts & Crafts", "Created" },
                    { new Guid("e2f05143-f39d-43f5-a776-0b431aff968a"), "Search", "Digital Marketing", "Local SEO", "Created" },
                    { new Guid("e382cdcf-b36e-45c2-8805-1418b8362269"), "Business Consultants", "Consulting", "E-commerce Consulting", "Created" },
                    { new Guid("e591971a-cda9-4b92-855e-8c33d5671a67"), "Logo & Brand Identity", "Graphics & Design", "Business Cards & Stationery", "Created" },
                    { new Guid("e5ded8f8-5eb3-4e45-9651-1f0a201f1dd6"), "Data & Business Intelligence ", "Business", "Data Scraping", "Created" },
                    { new Guid("e658cfc9-c72a-434b-b278-4980d0922d8a"), "Social & Marketing Videos", "Video & Animation", "Slideshow Videos", "Created" },
                    { new Guid("e6b26e33-74d1-4ed5-a658-308d68946126"), "Business & Marketing Copy", "Writing & Translation", "Email Copy", "Created" },
                    { new Guid("e7a4bda5-d663-4c68-82f0-f6c0bb0d6138"), "Miscellaneous", "Video & Animation", "Game Trailers", "Created" },
                    { new Guid("e8d93ea0-3768-459e-b8c3-46fc0da85045"), "Social", "Digital Marketing", "Social Media Marketing", "Created" },
                    { new Guid("e8f64ae4-5f0a-4cd1-b29f-f4cfdcd8e6f9"), "Fundraising", "Finance", "Fundraising Consultation", "Created" },
                    { new Guid("e9469d65-6fee-430b-bd18-1cabfe74576e"), "Sound Design", "Music & Audio", "Sound Design", "Created" },
                    { new Guid("e994829b-2cd4-4bd4-8a45-bb7c40830492"), "Music Production & Writing", "Music & Audio", "Composers", "Created" },
                    { new Guid("e9a92217-6c79-40f1-93b1-6d05129ae461"), "Miscellaneous", "Photography", "Photography Classes", "Created" },
                    { new Guid("ea5764ef-de09-4230-aa7c-2fc1d1fd49a9"), "AI Mobile Development", "AI Services", "AI Mobile Apps", "Created" },
                    { new Guid("ea7c113d-557e-4482-959d-d29800de663f"), "Miscellaneous", "Personal Growth", "Embroidery Digitizing", "Created" },
                    { new Guid("ea834ee7-17dc-40b1-b4c8-f7847f82c79a"), "Data", "AI Services", "Data Visualization", "Created" },
                    { new Guid("eaab6dba-68db-4a02-8955-12088ac53731"), "Visual Design", "Graphics & Design", "AI Image Editing", "Created" },
                    { new Guid("eaba19ad-7e54-4efc-a869-3e5bb7fd1a16"), "Coaching & Advice", "Consulting", "Nutrition Coaching", "Created" },
                    { new Guid("eb59191e-352b-4728-a634-022fee7a096e"), "Game Development", "Programming & Tech", "PC Games", "Created" },
                    { new Guid("ebf421ee-d4a5-41d2-b207-f5a6689f6971"), "Business Formation & Consulting", "Business", "Business Plans", "Created" },
                    { new Guid("ec3a1fcf-7730-4db0-a6b3-ec336d8ba66e"), "Industry Specific Content", "Writing & Translation", "Business, Finance & Law ", "Created" },
                    { new Guid("ecf763f0-0a61-4006-9bfa-d2d3bc751ff9"), "Business Formation & Consulting", "Business", "Business Consulting", "Created" },
                    { new Guid("ee24b638-2d38-4666-a3f6-004982ecacd3"), "Sales & Customer Care", "Business", "Customer Care", "Created" },
                    { new Guid("ee9c4d8c-0211-4c85-b8e9-0535c51830d1"), "Data Science & ML", "Programming & Tech", "Deep Learning", "Created" },
                    { new Guid("ef29bbfc-46f4-4094-93f5-853a1a59964f"), "Marketing Strategy", "Consulting", "Video Marketing Consulting", "Created" },
                    { new Guid("f032906a-85af-4cdd-b975-80ef080e358e"), "Miscellaneous", "Programming & Tech", "Electronics Engineering", "Created" },
                    { new Guid("f304774d-5de5-4d6b-8207-0b4c36a69226"), "Fashion & Merchandise", "Graphics & Design", "Fashion Design", "Created" },
                    { new Guid("f358725f-7a8e-4342-917b-dc28d10c1a2e"), "Fashion & Style", "Personal Growth", "Modeling & Acting", "Created" },
                    { new Guid("f3681bf1-665f-45d6-ba00-b0d78dcb1bca"), "Career Writing", "Writing & Translation", "LinkedIn Profiles", "Created" },
                    { new Guid("f44aa591-f31e-44f9-9c6c-9b5fc9965e20"), "Tech Consulting", "Consulting", "Website Consulting", "Created" },
                    { new Guid("f45a53f3-650b-4885-a7d7-36fa9a9f3642"), "Translation & Transcription", "Writing & Translation", "Localization", "Created" },
                    { new Guid("f461b059-360f-4e8a-8820-1b0d4400a044"), "Print Design", "Graphics & Design", "Menu Design", "Created" },
                    { new Guid("f4d25048-069b-4a6f-a589-7ac99ccfad9e"), "Game Development", "Programming & Tech", "Mobile Games", "Created" },
                    { new Guid("f54d5ba8-b631-4084-9d57-aff12bf39ece"), "Miscellaneous", "Video & Animation", "Real Estate Promos", "Created" },
                    { new Guid("f61301ba-1197-4237-af7f-64ba09af2ce0"), "Industry & Purpose-Specific", "Digital Marketing", "Podcast Marketing", "Created" },
                    { new Guid("f657a939-09a6-4480-9ecd-b742b3cc606f"), "Channel Specific ", "Digital Marketing", "Facebook Ads Campaign", "Created" },
                    { new Guid("f6b3af66-b395-4614-a51e-b3e237de8cb6"), "People & Scenes", "Photography", "Scenic Photographers", "Created" },
                    { new Guid("f6bdfab3-a733-4cad-9a8e-32c87d05296a"), "Editing & Post-Production", "Video & Animation", "Subtitles & Captions", "Created" },
                    { new Guid("f77a20fa-a306-441f-8900-95857518b301"), "Gaming", "Personal Growth", "Gameplay Experience & Feedback", "Created" },
                    { new Guid("f7b1757c-0a20-422e-8ce3-6a7f51a249ae"), "Search", "Digital Marketing", "E-Commerce SEO", "Created" },
                    { new Guid("faa994f2-f095-4cc6-ba02-608588d9061c"), "Business & Marketing Copy", "Writing & Translation", "Product Descriptions", "Created" },
                    { new Guid("fb6ed897-8f3b-4a13-b903-c2c369e024de"), "Methods & Techniques ", "Digital Marketing", "Guest Posting", "Created" },
                    { new Guid("fc6d7da6-8113-492c-bbe3-56b9ae88d859"), "Product & Gaming", "Graphics & Design", "Character Modeling", "Created" },
                    { new Guid("fcd7742b-71dd-4c9c-8666-cc9aea61d638"), "Content Writing", "Writing & Translation", "Research & Summaries", "Created" },
                    { new Guid("ffdb13f6-9957-4f77-b9a4-470c4e4ade16"), "Business Consultants", "Consulting", "Legal Consulting", "Created" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("0710b6dd-4d7b-4844-af6c-462f1c13f1f3"), "Galician", "Created" },
                    { new Guid("0a511e12-ae30-4091-a027-a3c6eaa0d33a"), "Slovenian", "Created" },
                    { new Guid("0abf0736-c99f-4e17-81ff-53968f0d4001"), "Sindhi", "Created" },
                    { new Guid("0afa70c8-7b7f-4ba1-8a43-8edf5b5612e4"), "Thai", "Created" },
                    { new Guid("0c8cbf6a-2eab-406c-971c-459aa5f2676c"), "Javanese", "Created" },
                    { new Guid("0cf73d81-19fb-4398-9e43-2815a04d1656"), "Kurdish", "Created" },
                    { new Guid("0d1880c3-4781-4482-84f1-be13f511b5cc"), "Georgian", "Created" },
                    { new Guid("0d456de1-44cf-48a6-b16e-a86c4ce1397c"), "Hmong", "Created" },
                    { new Guid("0d6e26a7-e3b2-418e-a105-cef4418f4dbf"), "Croatian", "Created" },
                    { new Guid("101d371b-da0a-47d9-a903-84515b16a1d0"), "Finnish", "Created" },
                    { new Guid("16af7dcd-c86b-4f21-977d-8f63d0dfc438"), "Sinhala", "Created" },
                    { new Guid("1c12726e-924f-4895-8c91-ef84bbeadcf9"), "Estonian", "Created" },
                    { new Guid("1ce9acba-440a-4b8c-b6f4-09fff1309d1a"), "Swedish", "Created" },
                    { new Guid("1d4a8981-5b92-4d68-bcaf-32d9aa695c26"), "Tajik", "Created" },
                    { new Guid("1dc71e94-e285-46bb-97b7-e5c3443248bd"), "Marathi", "Created" },
                    { new Guid("206a09a1-19ab-4a7d-8369-5fde1975af55"), "Tatar", "Created" },
                    { new Guid("211e2d63-b8b7-4157-bff6-8fe5a0c16b7a"), "Serbian", "Created" },
                    { new Guid("2211411c-f034-4bb7-83f6-c1668428a671"), "Basque", "Created" },
                    { new Guid("2beb8442-6062-4d0d-9c7f-542f8923ee79"), "Yiddish", "Created" },
                    { new Guid("2e7861fd-801d-4fd5-9b8b-326f96aa7f87"), "Tamil", "Created" },
                    { new Guid("33e2fa28-9d42-4a13-9c7e-36f7742ae822"), "Zulu", "Created" },
                    { new Guid("35777d66-0429-4acd-899b-e33c458ee740"), "Danish", "Created" },
                    { new Guid("3635f7ea-abdc-4e76-b2d3-9e0b5202bba8"), "Filipino", "Created" },
                    { new Guid("3e76dde0-21e9-410c-ad92-f0a29cd34634"), "Catalan", "Created" },
                    { new Guid("3eb531a5-ae55-46fc-a226-ac043147a63b"), "Kinyarwanda", "Created" },
                    { new Guid("3edd42a0-4ed1-4d81-b9e8-e052fc543433"), "Urdu", "Created" },
                    { new Guid("3f5d600a-1a23-4e2c-a02a-7dc39e3110e6"), "Cebuano", "Created" },
                    { new Guid("41a5a237-88ff-45a6-992a-221855696844"), "Bosnian", "Created" },
                    { new Guid("45445c4c-6e52-4a33-9e6b-3b398b3f145d"), "French", "Created" },
                    { new Guid("46012869-897e-42fe-a39f-bd772f4ba3cd"), "Latvian", "Created" },
                    { new Guid("476d7835-ae85-4f64-899d-c6c4c751f80a"), "Chinese", "Created" },
                    { new Guid("485b22b4-f7fa-4081-a03e-862a8f61d112"), "Welsh", "Created" },
                    { new Guid("49af1a38-e3e6-495b-9381-c7515e628b7c"), "Greek", "Created" },
                    { new Guid("4a6c2af4-1562-48ed-aee7-4cd8a72b7594"), "Hindi", "Created" },
                    { new Guid("4cb8f362-2fc2-4f9f-9783-009088f8b5a2"), "Korean", "Created" },
                    { new Guid("5012844b-95d5-49d8-9d12-69abbb2703a5"), "Kannada", "Created" },
                    { new Guid("52694ac3-ba40-4c94-9c46-1a4f68e11a77"), "Hebrew", "Created" },
                    { new Guid("583e5ded-2890-46ae-ac3c-26c38d283704"), "Persian", "Created" },
                    { new Guid("5a761b22-8fbb-4202-98f3-fa5936a97657"), "Hungarian", "Created" },
                    { new Guid("5b48de55-2be7-42f8-8c54-be2b0253f7ef"), "English", "Created" },
                    { new Guid("64ec9724-c966-481f-a963-8f66e8c87702"), "Malagasy", "Created" },
                    { new Guid("65b6a5f2-cf08-4752-88ad-c9f9573c24c7"), "Maori", "Created" },
                    { new Guid("6dd5950e-3866-4bce-8836-2ef3482ce0ce"), "Arabic", "Created" },
                    { new Guid("6ed27c85-9948-4d2a-a486-ff49d7f60e6b"), "Amharic", "Created" },
                    { new Guid("724a0af1-9dd6-4896-a6b9-2a3b5f5117dd"), "Italian", "Created" },
                    { new Guid("75c5271f-c7ea-4b13-aa37-c8acc837331c"), "Malayalam", "Created" },
                    { new Guid("76188c09-0154-4baf-a2df-121d8b679fe4"), "Samoan", "Created" },
                    { new Guid("78eecf09-f956-4ead-99bd-2f60cbd3f7ed"), "Vietnamese", "Created" },
                    { new Guid("79dc51d4-86bc-4972-8b30-451bdf8af3c7"), "Somali", "Created" },
                    { new Guid("7a88a8fa-9ca4-4765-a94d-081222213565"), "Czech", "Created" },
                    { new Guid("7abbabd4-d98a-4a52-b049-5df664e7faa1"), "Haitian Creole", "Created" },
                    { new Guid("7e29262a-8258-4187-82dd-3ba41160f98d"), "Norwegian", "Created" },
                    { new Guid("7e359399-feec-4cba-bf8b-d53932e0cd4e"), "Spanish", "Created" },
                    { new Guid("8079c3ee-f90d-4213-b1dd-cf4465f23977"), "Macedonian", "Created" },
                    { new Guid("80f21f1a-482b-414f-9c57-91d8f3f6f531"), "Hausa", "Created" },
                    { new Guid("82ab8e84-f097-4544-9df9-c376ca3f43c0"), "Azerbaijani", "Created" },
                    { new Guid("83de6462-2588-4f92-90cd-0df835b7e64b"), "Mongolian", "Created" },
                    { new Guid("843d2f30-0c9d-4fe6-9ff5-6fb5b6f26c48"), "Belarusian", "Created" },
                    { new Guid("86334cfd-ab7b-4ebf-a697-9dd12ce1649f"), "Afrikaans", "Created" },
                    { new Guid("863955d9-4610-49bf-a695-25e041059ef6"), "Japanese", "Created" },
                    { new Guid("870ae3e8-cdce-4350-9402-d5bab327c90d"), "Albanian", "Created" },
                    { new Guid("8a0b74f8-a32c-48e6-8656-9de3ca373fdd"), "Xhosa", "Created" },
                    { new Guid("8aa9d03e-f778-493b-b822-4f2274baeca4"), "Bulgarian", "Created" },
                    { new Guid("8c962636-0e6b-44d9-9e8f-387a97de266c"), "Yoruba", "Created" },
                    { new Guid("8e47cb7f-5e5e-449b-8a92-8df22d896afa"), "Igbo", "Created" },
                    { new Guid("90012799-4885-4ba0-99b9-9ad2c500596c"), "Polish", "Created" },
                    { new Guid("94a3ecc3-5f2b-4ad7-92c5-c7fcefe8b7bc"), "Latin", "Created" },
                    { new Guid("9547bc00-a3eb-4b56-9b7d-d700ac9a7bad"), "Russian", "Created" },
                    { new Guid("9d43c646-0201-4470-bfc9-81f55feb3062"), "Shona", "Created" },
                    { new Guid("a06afbba-4f53-4af2-9f81-bddaeb76cea9"), "German", "Created" },
                    { new Guid("a26e5ebd-59c2-444a-9893-61fa59b94ca1"), "Khmer", "Created" },
                    { new Guid("a80ee7f4-462f-440a-ad2b-9dbc98f06bfe"), "Nepali", "Created" },
                    { new Guid("ab756710-63d4-471d-99d2-a0979c054ef4"), "Turkish", "Created" },
                    { new Guid("ab8be5bc-0795-4584-8a5e-715c7ff83009"), "Ukrainian", "Created" },
                    { new Guid("ac3a0086-f0ae-4d3b-ab6e-4666997aa798"), "Dutch", "Created" },
                    { new Guid("b1d83db7-14ec-4494-ad3a-bcaf86d2b1d3"), "Burmese", "Created" },
                    { new Guid("b3043458-ef07-4edf-a91d-6faf5467a55a"), "Scots Gaelic", "Created" },
                    { new Guid("b38999bd-51e2-4b00-9502-e01091fbbdd2"), "Indonesian", "Created" },
                    { new Guid("b5063c71-9576-4304-840c-3e6cde4f2065"), "Esperanto", "Created" },
                    { new Guid("b6ce8b51-4433-4b85-9766-2d2bf3b1e0d7"), "Irish", "Created" },
                    { new Guid("b7d10974-ca5d-48f1-b9df-318a472d4321"), "Icelandic", "Created" },
                    { new Guid("b8c8087b-1b6e-4083-8639-f2866a86f415"), "Kazakh", "Created" },
                    { new Guid("b9961a58-130b-4d36-b111-8b93a39bec46"), "Armenian", "Created" },
                    { new Guid("baf4314e-667a-4fa1-b1d8-72392de1ba51"), "Uzbek", "Created" },
                    { new Guid("bb64a847-b0cf-44e1-a3f4-f0b0f4d90478"), "Pashto", "Created" },
                    { new Guid("be7bf6b4-11c2-4cdb-9f9b-a6f21721b41c"), "Lithuanian", "Created" },
                    { new Guid("c0f68b6a-73d7-4192-a086-5927e8e58125"), "Telugu", "Created" },
                    { new Guid("c131bc85-f69d-488c-a235-a9c6f76bf514"), "Malay", "Created" },
                    { new Guid("c59af8bd-21f7-4e27-90cb-b969a6073f3f"), "Turkmen", "Created" },
                    { new Guid("cdcf2353-176b-454c-b7b7-4c4b9c2cd882"), "Maltese", "Created" },
                    { new Guid("cf2c804e-8639-4fdb-b707-8056a9d251b9"), "Slovak", "Created" },
                    { new Guid("d61819e8-95a8-4c67-9cc4-211b2dbe15fc"), "Swahili", "Created" },
                    { new Guid("d66ca043-bdc6-4ce0-9c47-38f38976e4e5"), "Kyrgyz", "Created" },
                    { new Guid("d99574d9-9912-4a92-8d28-9d2767dad85c"), "Uyghur", "Created" },
                    { new Guid("dafded4c-17c1-4037-80ba-dbf6aaba6d89"), "Lao", "Created" },
                    { new Guid("dcc5e28a-f05a-40b7-b84b-0f6074d4209a"), "Portuguese", "Created" },
                    { new Guid("ddcf7ae1-6cbf-48c5-846e-7e75f89d7836"), "Corsican", "Created" },
                    { new Guid("e4035631-48c5-4122-a990-744284726c57"), "Punjabi", "Created" },
                    { new Guid("e6347f4b-b0d0-4d3a-bc2f-3ac6f5c01eb3"), "Sundanese", "Created" },
                    { new Guid("ef85ab2d-a02d-4e6d-a008-1d5054125d7f"), "Hawaiian", "Created" },
                    { new Guid("f0fb7a4f-a529-4430-ab5b-073f438afc55"), "Luxembourgish", "Created" },
                    { new Guid("f3b8b594-9f06-4951-ab34-7cf81fa6e6a6"), "Bengali", "Created" },
                    { new Guid("f513be37-aecf-4138-a257-6b107c6afaf6"), "Romanian", "Created" },
                    { new Guid("f87a6300-e95c-4f51-97a7-1cf825463d8c"), "Sesotho", "Created" },
                    { new Guid("fbc74e4d-ae68-456f-9cee-e851487ab4de"), "Gujarati", "Created" },
                    { new Guid("fe1b92de-7698-4822-ada7-712a3ca2f9f9"), "Chichewa", "Created" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountLanguages_LanguageId",
                table: "AccountLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_FreelancerId",
                table: "Certifications",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FreelancerId",
                table: "Educations",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_ProposalId",
                table: "Process",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployerId",
                table: "Projects",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_SkillId",
                table: "ProjectSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalImages_ImageId",
                table: "ProposalImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_CategoryId",
                table: "Proposals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_FreelancerId",
                table: "Proposals",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ProjectId",
                table: "Proposals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_TransactionId",
                table: "Proposals",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalSkills_SkillId",
                table: "ProposalSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployerId",
                table: "Transactions",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FreelancerId",
                table: "Transactions",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PackageId",
                table: "Transactions",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PromotionId",
                table: "Transactions",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SystemFeeId",
                table: "Transactions",
                column: "SystemFeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLanguages");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "ProposalImages");

            migrationBuilder.DropTable(
                name: "ProposalSkills");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "RateCodes");
        }
    }
}
