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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "ProjectContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BriefName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TotalPay = table.Column<decimal>(type: "MONEY", nullable: false),
                    Paid = table.Column<decimal>(type: "MONEY", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContracts_Accounts_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectContracts_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectContracts_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<decimal>(type: "MONEY", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Process_ProjectContracts_ProjectContractId",
                        column: x => x.ProjectContractId,
                        principalTable: "ProjectContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BriefName", "MajorName", "SpecializedName", "Status" },
                values: new object[,]
                {
                    { new Guid("006700ce-b084-40c4-bfe4-83e9d4ee7acd"), "Data Science & ML", "Data", "Time Series Analysis", "Created" },
                    { new Guid("038d0706-0d45-475d-8e6f-486a07fb6dce"), "Product Videos ", "Video & Animation", "App & Website Previews", "Created" },
                    { new Guid("0398a384-d348-495b-89bd-1da072a5736b"), "AI Video ", "Video & Animation", "AI Video Art", "Created" },
                    { new Guid("03d37f4d-7f0c-49fd-8a01-6075305cb189"), "Streaming & Audio", "Music & Audio", "Podcast Production", "Created" },
                    { new Guid("04715284-ef97-4a75-a41a-1aa78bfdaa82"), "Website Development", "Programming & Tech", "Landing Pages", "Created" },
                    { new Guid("047a12e4-28f4-4164-a558-fe51b060d843"), "Social", "Digital Marketing", "Community Management", "Created" },
                    { new Guid("050368c5-17d1-4b7a-a57d-e96a6fd01f8c"), "AI Video", "AI Services", "AI Video Art", "Created" },
                    { new Guid("0506e6de-c58e-4e6e-8885-114c31410385"), "Architecture & Building Design", "Graphics & Design", "Building Engineering", "Created" },
                    { new Guid("050b3ac4-ab2a-4e27-85a6-5ef9e8fe4fb4"), "Social & Marketing Videos", "Video & Animation", "Video Ads & Commercials ", "Created" },
                    { new Guid("0513d790-42d5-429c-ad4e-fab612716def"), "Miscellaneous", "Writing & Translation", "Technical Writing", "Created" },
                    { new Guid("0648cded-0bb8-453d-9760-d5ae3a451ae4"), "Music Production & Writing", "Music & Audio", "Singers & Vocalists", "Created" },
                    { new Guid("066e7959-018c-4004-a86f-f703d5145b09"), "Legal Services", "Business", "General Legal Advice", "Created" },
                    { new Guid("06e33521-ef5c-4192-b1d6-a8f77e5f603a"), "People & Scenes", "Photography", "Real Estate Photographers", "Created" },
                    { new Guid("07c200d9-1c6a-4453-a514-fd4a293187cb"), "AI Development", "Programming & Tech", "AI Mobile Apps", "Created" },
                    { new Guid("081dddef-521d-48c7-8482-0c305e865233"), "Databases & Engineering", "Data", "Databases", "Created" },
                    { new Guid("085568fe-4afa-4de4-aaaf-d264a650993a"), "Miscellaneous", "Photography", "Other", "Created" },
                    { new Guid("08809f30-e222-4903-a2d3-6895187be5c9"), "Cloud & Cybersecurity ", "Programming & Tech", "Cloud Computing", "Created" },
                    { new Guid("08d66955-165b-4ff5-8928-4e9677610ad1"), "Content Writing", "Writing & Translation", "Creative Writing", "Created" },
                    { new Guid("08e665a5-1721-4af3-9018-ceacc9dbb4c4"), "3D Design", "Graphics & Design", "3D Fashion & Garment", "Created" },
                    { new Guid("08fcdfc7-c983-4053-8906-928930008481"), "Data Analysis & Visualization", "Data", "Data Analytics", "Created" },
                    { new Guid("09949c64-bef4-4fd8-a4ac-4ed94d787dc4"), "Motion Graphics", "Video & Animation", "Lottie & Web Animation", "Created" },
                    { new Guid("099d89c6-c59d-42ce-9661-94c75be575d0"), "Tax Consulting", "Finance", "Tax Returns", "Created" },
                    { new Guid("0e559677-d3e4-471f-9760-cea24c91a2da"), "Business Consultants", "Consulting", "Business Plans", "Created" },
                    { new Guid("0eead3e0-f603-446a-9938-aded22443b9a"), "Accounting Services", "Finance", "Find a Financial Expert", "Created" },
                    { new Guid("10a09751-9ec1-4ff5-bbee-1b42c357c1e3"), "Operations & Management", "Business", "E-Commerce Management ", "Created" },
                    { new Guid("10c44588-5854-4c0c-85bd-fa6029c89ef3"), "Explainer Videos", "Video & Animation", "Animated Explainers", "Created" },
                    { new Guid("1126ed7e-ac8d-47ec-8d19-c279235d154b"), "Data Collection", "Data", "Data Enrichment", "Created" },
                    { new Guid("11d3b61e-134b-461f-b73c-7aceae23dd5c"), "Visual Design", "Graphics & Design", "Presentation Design", "Created" },
                    { new Guid("11ff65c0-c414-491f-b337-77d9c3dca8bb"), "Analytics & Strategy", "Digital Marketing", "Marketing Strategy", "Created" },
                    { new Guid("12427d81-0478-48e5-bf9c-6d5ae70c525f"), "Content Writing", "Writing & Translation", "Articles & Blog Posts", "Created" },
                    { new Guid("12871289-171c-486a-8dda-65ffcb91e8e1"), "Motion Graphics", "Video & Animation", "Text Animation", "Created" },
                    { new Guid("12d8d28a-e99e-49b1-8a7d-445966eeda55"), "Data Collection", "Data", "Data Cleaning", "Created" },
                    { new Guid("1441d14a-2c90-4500-84f6-41822b16e3dd"), "Mobile App Development", "Programming & Tech", "Cross-platform Development", "Created" },
                    { new Guid("14710b4b-d784-4590-a6bb-2340d5402350"), "Corporate Finance", "Finance", "Due Diligence", "Created" },
                    { new Guid("15c6341e-5e5f-45a0-b0b4-19e7dd083ad9"), "Logo & Brand Identity", "Graphics & Design", "Brand Style Guides", "Created" },
                    { new Guid("166fa528-25be-45f3-b1c5-7e5fb8d5687c"), "Architecture & Building Design", "Graphics & Design", "Architecture & Interior Design", "Created" },
                    { new Guid("1769ecf4-ac70-4c2c-b986-57933fbad79e"), "Data & Business Intelligence ", "Business", "Data Scraping", "Created" },
                    { new Guid("197c9cf7-538a-4601-b717-010da68548ef"), "Coaching & Advice", "Consulting", "Game Coaching", "Created" },
                    { new Guid("19a3318d-52d8-46e3-80b1-b4970a1ca97d"), "Visual Design", "Graphics & Design", "Infographic Design", "Created" },
                    { new Guid("1acf0956-336b-488e-b3b3-cdd96990bcd4"), "Lessons & Transcriptions", "Music & Audio", "Music Transcription", "Created" },
                    { new Guid("1b4229d0-aa6c-4117-ba70-cf652d8b7a54"), "Print Design", "Graphics & Design", "Catalog Design", "Created" },
                    { new Guid("1cad3a6e-f3df-4d73-aa01-bbf1e99ae72f"), "Motion Graphics", "Video & Animation", "Logo Animation", "Created" },
                    { new Guid("1cad8fba-3a5a-46dd-9331-11e829892966"), "Product Videos ", "Video & Animation", "3D Product Animation", "Created" },
                    { new Guid("1e2ab951-343c-49f6-8f6b-0a57af911b0f"), "Marketing Strategy", "Consulting", "SEM Strategy", "Created" },
                    { new Guid("2147c76a-322a-4e71-b68d-200e7fb83f12"), "Leisure & Hobbies", "Personal Growth", "Collectibles", "Created" },
                    { new Guid("21cccd48-a397-4801-9878-cc3b529a781c"), "Audio Engineering & Post Production", "Music & Audio", "Audio Editing", "Created" },
                    { new Guid("2284c4d3-60b2-498b-8d9e-c5e1a18f4974"), "Gaming", "Personal Growth", "Game Recordings & Guides", "Created" },
                    { new Guid("22c9507a-1e47-4660-91bf-ae9c3ca3993a"), "Tax Consulting", "Finance", "Tax Exemptions", "Created" },
                    { new Guid("236414f2-a601-44b2-bdf9-bca31c3cadf0"), "Local Photography", "Photography", "Photographers in New York", "Created" },
                    { new Guid("23f9d8f8-3698-4575-986f-d809dbd4cd2b"), "Visual Design", "Graphics & Design", "Image Editing", "Created" },
                    { new Guid("246385a8-0d62-44a6-8978-c151c09c93b4"), "Data Consulting", "Consulting", "Databases Consulting", "Created" },
                    { new Guid("25b10693-ce27-4124-adac-dfbcbd2c56f6"), "Chatbot Development", "Programming & Tech", "Discord", "Created" },
                    { new Guid("266ea3d9-e373-4386-89f1-c15f0e8daab3"), "Industry Specific Content", "Writing & Translation", "Health & Medical ", "Created" },
                    { new Guid("26a2b478-d71a-4fa1-a455-888f809b1635"), "Art & Illustration", "Graphics & Design", "Tattoo Design", "Created" },
                    { new Guid("26b4904b-e800-498e-8471-666abc5f6640"), "AI Artists", "AI Services", "AI Image Editing", "Created" },
                    { new Guid("26c9162f-25ae-425b-b580-6cd81d49089b"), "Leisure & Hobbies", "Personal Growth", "Puzzle & Game Creation", "Created" },
                    { new Guid("2727379b-9d17-4919-a336-0c78be7e7065"), "Data Science & ML", "Programming & Tech", "Machine Learning", "Created" },
                    { new Guid("28277b2d-d137-4639-923b-b5f8fb74c140"), "Tech Consulting", "Consulting", "Mobile App Consulting", "Created" },
                    { new Guid("286e746a-30b2-41db-ac10-2b9d1442784f"), "Miscellaneous", "Programming & Tech", "Discord Server Setup", "Created" },
                    { new Guid("289e6b88-fb50-465a-a107-859f29fee8f9"), "Website Maintenance", "Programming & Tech", "Bug Fixes", "Created" },
                    { new Guid("294a5b26-d49e-428b-9233-9ba01aa70e28"), "Business Formation & Consulting", "Business", "Business Consulting", "Created" },
                    { new Guid("29ce6a2c-1483-4169-ac43-25854fa05e7b"), "Business & Marketing Copy", "Writing & Translation", "UX Writing", "Created" },
                    { new Guid("2ab7b964-ab89-4418-8a43-5a6b9823ef28"), "Business & Marketing Copy", "Writing & Translation", "Sales Copy", "Created" },
                    { new Guid("2af16a65-1f5d-4bed-b83a-b26d7f71d097"), "Game Development", "Programming & Tech", "Gameplay Experience & Feedback", "Created" },
                    { new Guid("2b4e9400-e337-4f2a-abcc-4521bee7f379"), "Social", "Digital Marketing", "Social Commerce ", "Created" },
                    { new Guid("2b8d2f83-a4ca-4b8e-aee8-2f9e14589791"), "Art & Illustration", "Graphics & Design", "Cartoons & Comics", "Created" },
                    { new Guid("2c1314bc-123e-4645-aaf5-ed953e1ac11b"), "Miscellaneous", "Business", "Sustainability Consulting", "Created" },
                    { new Guid("2c2687e3-6678-46b2-b416-6c1cf6028f04"), "Data Collection", "Data", "Data Formatting", "Created" },
                    { new Guid("2c3c529c-ca19-49ef-8a30-d0cff48a2d44"), " Book & eBook Publishing", "Writing & Translation", "Self-Publish Your Book", "Created" },
                    { new Guid("2c5dd2a8-ae62-47f6-ba6a-78eefe32c63d"), "Art & Illustration", "Graphics & Design", "Illustration", "Created" },
                    { new Guid("2c694e83-0922-4cca-b02b-15063a25ddbc"), "AI Mobile Development", "AI Services", "AI Chatbot", "Created" },
                    { new Guid("2c7eea65-a74f-4716-87c7-355810d73a43"), "Data Collection", "Data", "Data Typing", "Created" },
                    { new Guid("2ce2e92a-e9a3-43d6-af1b-0eed1abfd6cf"), "Marketing Strategy", "Consulting", "Influencers Strategy", "Created" },
                    { new Guid("2de1ffd2-c1be-4b9f-8529-a53ffea61f82"), "Web & App Design", "Graphics & Design", "Website Design", "Created" },
                    { new Guid("2e20e9aa-610f-458c-a2d9-7ec67265ae5b"), "Tech Consulting", "Consulting", "Cybersecurity Consulting", "Created" },
                    { new Guid("2ed32a9e-1c24-4698-871e-20038c563e1e"), "Miscellaneous", "Programming & Tech", "Support & IT", "Created" },
                    { new Guid("2f097b61-5381-4d8e-ac3e-c4a312db5c37"), "Fashion & Style", "Personal Growth", "Modeling & Acting", "Created" },
                    { new Guid("2f721f8c-2c06-4c78-a63a-ef2a2438da89"), "Analytics & Strategy", "Digital Marketing", "Conversion Rate Optimization (CRO)", "Created" },
                    { new Guid("30134941-dfc0-4855-b801-d7220cb85d21"), "Legal Services", "Business", "Legal Documents & Contracts", "Created" },
                    { new Guid("303d359c-4a6b-446b-a966-c4ae388b45e4"), "DJing", "Music & Audio", "DJ Mixing", "Created" },
                    { new Guid("3247338c-abcb-4ce9-b443-a142b97944ef"), "Visual Design", "Graphics & Design", "Vector Tracing", "Created" },
                    { new Guid("34129a7f-b3bf-4967-aa35-f6ef3142bfe4"), "Editing & Critique", "Writing & Translation", "AI Content Editing", "Created" },
                    { new Guid("3473d970-2350-41c2-94ba-8731c5a3b56c"), "Tech Consulting", "Consulting", "Game Development Consulting", "Created" },
                    { new Guid("3554b0f1-15dd-4a62-9085-ca2a8a0e7d97"), "Sound Design", "Music & Audio", "Meditation Music", "Created" },
                    { new Guid("35613d12-913f-41a1-82e4-9eba944a88c5"), "Miscellaneous", "Business", "Game Concept Design", "Created" },
                    { new Guid("35801bed-10f8-43b9-90ef-e7ce78ea9ee6"), "Fundraising", "Finance", "Investors Sourcing", "Created" },
                    { new Guid("36941c2d-01de-485c-9ca4-77c3d511ad4c"), " Book & eBook Publishing", "Writing & Translation", "Beta Reading", "Created" },
                    { new Guid("38f27f17-7eab-47a3-b729-f411939632f3"), "Miscellaneous", "Personal Growth", "Cosmetics Formulation", "Created" },
                    { new Guid("3946d1bc-fe01-44e0-b700-2d56ab23a63f"), "Miscellaneous", "Video & Animation", "Real Estate Promos", "Created" },
                    { new Guid("3962d5d6-5934-404b-a1f1-c22041da971a"), "Miscellaneous", "Personal Growth", "Embroidery Digitizing", "Created" },
                    { new Guid("39732026-22d2-4511-af4d-03ba26d67353"), "Voice Over & Narration", "Music & Audio", "Female Voice Over", "Created" },
                    { new Guid("39a40c89-7f05-416b-8ba0-dc27191ae33a"), "Accounting Services", "Finance", "Fractional CFO Services", "Created" },
                    { new Guid("39b6d562-c13a-4f5c-9649-fafb1daf8314"), "Logo & Brand Identity", "Graphics & Design", "Business Cards & Stationery", "Created" },
                    { new Guid("3bb37855-4085-441b-a4d4-dbe5779c1735"), "Business & Marketing Copy", "Writing & Translation", "Email Copy", "Created" },
                    { new Guid("3c573068-3dbf-4aa0-ba50-89376bb80459"), "Search", "Digital Marketing", "Search Engine Marketing (SEM)", "Created" },
                    { new Guid("3c652809-05b5-4916-833c-483ba5aaafa1"), "Methods & Techniques ", "Digital Marketing", "Email Automations", "Created" },
                    { new Guid("3c9be4b5-fb79-4094-b074-9113f037b8cd"), "AI Mobile Development", "AI Services", "AI Websites & Software", "Created" },
                    { new Guid("3d21bc89-cd56-4e40-9317-ec726c54537e"), "Gaming", "Personal Growth", "eSports Management & Strategy", "Created" },
                    { new Guid("3edfbe62-b9b3-4056-8ed8-6f46ad2983f9"), "Art & Illustration", "Graphics & Design", "AI Avatar Design", "Created" },
                    { new Guid("3fdff68b-e4de-4c1c-bdc4-3b2d8ffcee13"), "Mobile App Development", "Programming & Tech", "VR & AR Development", "Created" },
                    { new Guid("40680448-d7eb-499a-a12b-92853f0d5e2d"), "Print Design", "Graphics & Design", "Poster Design", "Created" },
                    { new Guid("416c1e7a-d659-4376-b3e8-9455486cffd0"), "Logo & Brand Identity", "Graphics & Design", "Logo Design", "Created" },
                    { new Guid("4320af1e-aed9-4aa0-abee-87b9553d1d4f"), "Print Design", "Graphics & Design", "Menu Design", "Created" },
                    { new Guid("4360348f-dada-4cf5-aa79-cc7d7856de6e"), "Software Development", "Programming & Tech", "Scripting", "Created" },
                    { new Guid("43768e58-9264-4c39-ac66-6f6f910a94b3"), "Operations & Management", "Business", "Software Management", "Created" },
                    { new Guid("4464dc89-ff35-469d-a6cd-57f708241d9c"), "Tech Consulting", "Consulting", "Website Consulting", "Created" },
                    { new Guid("44957108-fa88-4707-b7ce-378869d8188d"), "Search", "Digital Marketing", "Search Engine Optimization (SEO)", "Created" },
                    { new Guid("45a48a6c-5ec1-42b3-aa6c-7f31a27a31de"), "Animation", "Video & Animation", "Animation for Kids", "Created" },
                    { new Guid("45a9cb3d-fbcb-4eda-a458-2e1da15a82e4"), "Data Science & ML", "Data", "Deep Learning", "Created" },
                    { new Guid("45bbd7af-5a05-48b2-a602-7f03542a9858"), "Channel Specific ", "Digital Marketing", "Google SEM", "Created" },
                    { new Guid("46f40b01-2163-4919-a575-efccba9b4217"), "Data", "AI Services", "Data Visualization", "Created" },
                    { new Guid("4a4b2f3d-6dae-47f9-976a-80203e0d2698"), "Data Consulting", "Consulting", "Data Visualization Consulting", "Created" },
                    { new Guid("4a55c3b8-09a9-48e7-98ea-8b28ce33a98a"), "Sales & Customer Care", "Business", "Lead Generation", "Created" },
                    { new Guid("4bcb2c84-f5cd-4d94-929b-0d36e4c2d75f"), "Animation", "Video & Animation", "Rigging", "Created" },
                    { new Guid("4bf0860b-16c9-4496-8144-75d3bbb82bd4"), "Miscellaneous", "Video & Animation", "Game Trailers", "Created" },
                    { new Guid("4c2051d2-672a-4cf5-a1f8-138c0db143d1"), "Architecture & Building Design", "Graphics & Design", "Landscape Design", "Created" },
                    { new Guid("4cbae343-8b5b-4c61-ba78-0c3b60af490d"), "AI Mobile Development", "AI Services", "AI Integrations", "Created" },
                    { new Guid("4d72d6bd-439a-4caf-afb8-31ba65a2ef36"), " Book & eBook Publishing", "Writing & Translation", "Book Editing", "Created" },
                    { new Guid("4dc3737a-15e7-4575-9fdc-3013f5a80910"), "Miscellaneous", "Personal Growth", "Family & Genealogy", "Created" },
                    { new Guid("4ddeb7ba-a5f4-4f2a-b9fe-dbfc45e4540f"), "Art & Illustration", "Graphics & Design", "Children's Book Illustration", "Created" },
                    { new Guid("4e229895-261d-47cb-9685-5b9b4b779201"), "Marketing Strategy", "Consulting", "Video Marketing Consulting", "Created" },
                    { new Guid("4e35594c-6a31-49a6-b298-daa42b776fc6"), "Business Consultants", "Consulting", "AI Consulting", "Created" },
                    { new Guid("4f44e8b4-64c8-41d5-ad04-70409db38ff4"), "Accounting Services", "Finance", "Payroll Management", "Created" },
                    { new Guid("4f863482-84ff-44c0-8cae-8cec789689b2"), "Translation & Transcription", "Writing & Translation", "Localization", "Created" },
                    { new Guid("50ab6f0f-2ad6-4cd4-9547-b1345f42d490"), "3D Design", "Graphics & Design", "3D Landscape", "Created" },
                    { new Guid("50d6218b-7def-4f3b-8d35-239f002b4bb9"), "AI Video", "AI Services", "AI Music Videos", "Created" },
                    { new Guid("50eb5ba5-be56-47e2-83dc-b3254daefd74"), "Filmed Video Production", "Video & Animation", "Videographers", "Created" },
                    { new Guid("5156d340-5280-46e0-8cd8-01af9b131f0b"), "AI Mobile Development", "AI Services", "AI Agents", "Created" },
                    { new Guid("51b88495-055f-483d-a688-a458c9708970"), "AI Audio", "AI Services", "Voice Synthesis & AI", "Created" },
                    { new Guid("51f5d210-ca77-43e5-bb84-2390cfbcc113"), "Corporate Finance", "Finance", "Mergers & Acquisitions Advisory", "Created" },
                    { new Guid("54b064ce-ffdb-4e18-bfde-f2bb64fb5b6d"), "Financial Planning & Analysis", "Finance", "Budgeting and Forecasting", "Created" },
                    { new Guid("54d5ce46-8f54-40c1-827d-00cbc64ee24a"), "Miscellaneous", "Photography", "Photography Classes", "Created" },
                    { new Guid("54e1ae4f-dc2a-4f1f-9664-340b2808dbb7"), "Channel Specific ", "Digital Marketing", "TikTok Shop", "Created" },
                    { new Guid("54f8a4ab-a0e6-4e3a-8c6f-295accef3b95"), "Website Maintenance", "Programming & Tech", "Website Customization", "Created" },
                    { new Guid("55bc9ec6-67a7-48ad-a48a-16dc0ef58cdb"), "AI Content", "AI Services", "AI Content Editing", "Created" },
                    { new Guid("55c7aabd-cb02-435f-8b2a-19a9493bf8ee"), "Miscellaneous", "Video & Animation", "Game Recordings & Guides", "Created" },
                    { new Guid("55dc2fd5-e67a-4505-87cb-9e34963d99f2"), "Logo & Brand Identity", "Graphics & Design", "Logo Maker Tool", "Created" },
                    { new Guid("56404599-b73f-48e8-aa75-73000a24d4b4"), "Channel Specific ", "Digital Marketing", "Instagram Marketing", "Created" },
                    { new Guid("56d7cca8-fb95-4fe9-9fb8-5053a91e1649"), "Architecture & Building Design", "Graphics & Design", "Lighting Design", "Created" },
                    { new Guid("58912034-eefc-4908-8a71-cf9431884d7f"), "Leisure & Hobbies", "Personal Growth", "Cosplay Creation", "Created" },
                    { new Guid("58b47034-8be3-4964-a5fa-ffdfb30c8436"), "Packaging & Covers", "Graphics & Design", "Packaging & Label Design", "Created" },
                    { new Guid("592ad8bc-c640-490e-9c91-3849dacc4ca7"), "Product Videos ", "Video & Animation", "Corporate Videos", "Created" },
                    { new Guid("593a74c5-8497-444b-8212-5c7a41f45beb"), "Data Science & ML", "Programming & Tech", "Deep Learning", "Created" },
                    { new Guid("5a535760-40b0-4247-90a4-303717517963"), "Art & Illustration", "Graphics & Design", "AI Artists", "Created" },
                    { new Guid("5a83aac7-783f-483c-b7ad-da3761d9d212"), "Animation", "Video & Animation", "Animation for Streamers", "Created" },
                    { new Guid("5ae5faf4-845a-4704-bcd4-a81fdfe1b6a1"), "Blockchain & Cryptocurrency", "Programming & Tech", "Cryptocurrencies & Tokens", "Created" },
                    { new Guid("5b5cfece-d32a-461c-88bd-1feaf9ad3a06"), "Business Consultants", "Consulting", "HR Consulting", "Created" },
                    { new Guid("5b7a2064-911f-4ef0-b71c-9ba3f00e5894"), "People & Scenes", "Photography", "Event Photographers", "Created" },
                    { new Guid("5ca30021-434b-43fd-955a-ab7659342c00"), "People & Scenes", "Photography", "Portrait Photographers", "Created" },
                    { new Guid("5d3245a5-7de9-4e34-ae68-6c9c72eed8e7"), "Miscellaneous", "Business", "Other", "Created" },
                    { new Guid("5d4ac14f-b3fc-4cb5-8df4-b61e0a6e290a"), "AI Video ", "Video & Animation", " AI Video Avatars", "Created" },
                    { new Guid("5da77ce6-05ae-443b-8386-3e20d7cdbed3"), "Miscellaneous", "Personal Growth", "Greeting Cards & Videos", "Created" },
                    { new Guid("5e1c1de5-4e8b-45ac-ba8e-565b549f1e91"), "Analytics & Strategy", "Digital Marketing", "Marketing Advice", "Created" },
                    { new Guid("5feabfb9-5a65-49f1-9d0e-696f15037a0a"), "Gaming", "Personal Growth", "Gameplay Experience & Feedback", "Created" },
                    { new Guid("6149e869-10f5-4d35-9ced-7d8b3d4848b9"), "Content Writing", "Writing & Translation", "Podcast Writing", "Created" },
                    { new Guid("631dc206-f4b6-43b4-94c8-e6269593b07a"), "People & Scenes", "Photography", "Scenic Photographers", "Created" },
                    { new Guid("63628f0e-e606-4eb8-ac3e-9f352e6d47a9"), "Wellness & Fitness", "Personal Growth", "Fitness", "Created" },
                    { new Guid("63cd64d6-502d-4ef9-8fe5-5c295bed9bf8"), "Gaming", "Personal Growth", "Game Matchmaking", "Created" },
                    { new Guid("63e85be0-e4b1-4c9a-8757-f054990d33b7"), "Business Formation & Consulting", "Business", "AI Consulting ", "Created" },
                    { new Guid("6433da58-1905-46b1-97cf-69ea021aab87"), "Search", "Digital Marketing", "E-Commerce SEO", "Created" },
                    { new Guid("644f8fb2-766f-4861-b011-556584f82e6c"), "Editing & Post-Production", "Video & Animation", "Video Editing", "Created" },
                    { new Guid("6557c94e-33fc-45a1-9019-6362fc4a3216"), "Leisure & Hobbies", "Personal Growth", "Traveling", "Created" },
                    { new Guid("658d9348-a2a6-4dba-80ee-292df138423e"), "Business Formation & Consulting", "Business", "Business Plans", "Created" },
                    { new Guid("659336df-5eaa-406a-87b5-802afa7e71cd"), "Miscellaneous", "Business", "Presentations", "Created" },
                    { new Guid("65ceaef2-3e59-49e7-889a-dfc8fdcff3e6"), "Business & Marketing Copy", "Writing & Translation", "Case Studies", "Created" },
                    { new Guid("660e7600-0b43-43c2-97fe-3cef48ce32ee"), "Business & Marketing Copy", "Writing & Translation", "Ad Copy", "Created" },
                    { new Guid("6683d1c3-fac7-4d6f-b6e0-c192fd98b363"), "Sound Design", "Music & Audio", "Audio Logo & Sonic Branding", "Created" },
                    { new Guid("67855f9d-53c9-4b6a-9b0a-a481dc057968"), " Book & eBook Publishing", "Writing & Translation", "Book & eBook Writing", "Created" },
                    { new Guid("696767af-b333-4200-ab23-d0e34593d301"), "Mentorship", "Consulting", "Video Mentorship", "Created" },
                    { new Guid("698ae8a0-ed04-4b9d-a72c-068b8b6cb769"), "Editing & Post-Production", "Video & Animation", "Visual Effects", "Created" },
                    { new Guid("69c2d51d-78fc-4915-8f80-3a56e39aed71"), "Data Science & ML", "Data", "NLP", "Created" },
                    { new Guid("6a1c3cbe-1f43-43a5-bc29-8ae537af7136"), "Audio Engineering & Post Production", "Music & Audio", "Vocal Tuning", "Created" },
                    { new Guid("6a66c0eb-c1df-4b57-aac2-1e416cfa6b7b"), "Marketing Strategy", "Consulting", "PR Strategy", "Created" },
                    { new Guid("6c3f0c07-ab19-4128-bd6d-3557b19969cb"), "Filmed Video Production", "Video & Animation", "Filmed Video Production", "Created" },
                    { new Guid("6cc26db4-b363-4d59-b98c-5b2fee1300c2"), "Presenter Videos", "Video & Animation", "TikTok UGC Videos", "Created" },
                    { new Guid("6d539530-fc65-41d9-ab45-b1939b9a1f9f"), "Sound Design", "Music & Audio", "Audio Plugin Development", "Created" },
                    { new Guid("6ddb0c9d-c5c0-4251-ba92-b21f2124f944"), "Data & Business Intelligence ", "Business", "Data Visualization", "Created" },
                    { new Guid("6eb9fea8-5cea-4d47-beea-f1272415a98e"), "Mobile App Development", "Programming & Tech", "iOS App Development", "Created" },
                    { new Guid("6f6a337d-baef-43e5-94c1-66498525a264"), "Software Development", "Programming & Tech", "Databases", "Created" },
                    { new Guid("7084add2-d004-4eac-8f2b-48b6e78bc039"), "Self Improvement", "Personal Growth", "Life Coaching", "Created" },
                    { new Guid("70dcaca7-baec-420c-b952-4ab46e36f9e2"), "Social", "Digital Marketing", "Influencer Marketing", "Created" },
                    { new Guid("71504e13-7e54-42cd-9cac-a231db896cdb"), "Music Production & Writing", "Music & Audio", "Music Producers", "Created" },
                    { new Guid("7214b112-1e84-4e54-96b8-75f0b7c97ff0"), "Art & Illustration", "Graphics & Design", "NFT Art", "Created" },
                    { new Guid("722d2f15-5024-452d-b0aa-0783b576a942"), "Coaching & Advice", "Consulting", "Mindfulness Coaching", "Created" },
                    { new Guid("727b84fb-12a2-4ec3-8b03-4b3739fed464"), "Presenter Videos", "Video & Animation", "Spokesperson Videos", "Created" },
                    { new Guid("72a1a2bb-3170-448e-a224-c22ae4063aed"), "Miscellaneous", "Video & Animation", "Virtual & Streaming Avatars", "Created" },
                    { new Guid("74695e3a-2326-4123-9f6f-cc497b8549a5"), "Game Development", "Programming & Tech", "Mobile Games", "Created" },
                    { new Guid("7483f6a1-d782-4eda-9fda-3a31ec1bfe0a"), "Software Development", "Programming & Tech", "Desktop Applications", "Created" },
                    { new Guid("74adb315-a350-44d1-85a5-40be7763009c"), "Blockchain & Cryptocurrency", "Programming & Tech", "Decentralized Apps (dApps)", "Created" },
                    { new Guid("75085cc2-15c5-497d-bb3c-1de1c3f4b9d7"), "Social", "Digital Marketing", "Paid Social Media", "Created" },
                    { new Guid("755decb1-d001-491a-a0fe-f0dd5e926ff6"), "Music Production & Writing", "Music & Audio", "Songwriters", "Created" },
                    { new Guid("75fadd38-a569-4042-915c-3d6ac97b094e"), "Data Consulting", "Consulting", "Data Analytics Consulting", "Created" },
                    { new Guid("769ca435-2d87-42bb-91eb-97993969620c"), "Data", "AI Services", "Data Analytics", "Created" },
                    { new Guid("7806ed0f-8fde-4099-b364-ddd34363bb29"), "Financial Planning & Analysis", "Finance", "Cost Analysis", "Created" },
                    { new Guid("782e97da-a8a2-4bfb-8967-0070555f9936"), "Packaging & Covers", "Graphics & Design", "Book Design", "Created" },
                    { new Guid("78597f69-857d-4108-82c8-d5a2a60768c8"), "Product Videos ", "Video & Animation", "E-Commerce Product Videos", "Created" },
                    { new Guid("79197a71-aa12-4bbd-91cc-471e364c30dd"), "Web & App Design", "Graphics & Design", "App Design", "Created" },
                    { new Guid("793ebbef-4ea5-4ed4-aa18-2e233d778081"), "Fundraising", "Finance", "Funding Pitch Presentations", "Created" },
                    { new Guid("7a1e5bf2-7e16-41ef-a310-ee767aa320a0"), "AI Mobile Development", "AI Services", "AI Mobile Apps", "Created" },
                    { new Guid("7a22b239-4dfa-46ce-ac51-408fd8da6afd"), "Data Science & ML", "Data", "Generative Models", "Created" },
                    { new Guid("7a89a3ec-4f14-4ef0-9d67-87340bc9d427"), "Industry & Purpose-Specific", "Digital Marketing", "Music Promotion", "Created" },
                    { new Guid("7ace41f2-2dc2-4a0a-b19f-fee130fcb8f4"), "Explainer Videos", "Video & Animation", "Screencasting Videos", "Created" },
                    { new Guid("7b140060-2c0d-4ca0-b6b2-de7c80b65a61"), "Data Processing & Management ", "Data", "Data Governance & Protection", "Created" },
                    { new Guid("7b4a424a-4077-4b6c-a985-07e37f735e3a"), "Streaming & Audio", "Music & Audio", "Voice Synthesis & AI", "Created" },
                    { new Guid("7b9adc9b-8434-4626-b671-0c05032e0e2f"), "Career Writing", "Writing & Translation", "Cover Letters", "Created" },
                    { new Guid("7be5cace-686d-445a-ad25-716384392ac5"), "Financial Planning & Analysis", "Finance", "Stock Analysis", "Created" },
                    { new Guid("7c354761-55be-43e6-812b-8782e2478d7f"), "Operations & Management", "Business", "Project Management", "Created" },
                    { new Guid("7c7c4c38-689f-4f24-941f-3fb2d6f76cf3"), "Sales & Customer Care", "Business", "Customer Care", "Created" },
                    { new Guid("7d1c1c36-e3ff-49d6-9e97-ee26ed62c46b"), "Visual Design", "Graphics & Design", "Background Removal", "Created" },
                    { new Guid("7d3f7464-116b-4c48-8321-a6e23642f0c2"), "Business & Marketing Copy", "Writing & Translation", "White Papers", "Created" },
                    { new Guid("7d4c82d8-c730-41c6-82d4-fcfb01c59cfe"), "Search", "Digital Marketing", "Local SEO", "Created" },
                    { new Guid("7dc79c4f-7580-43a9-a19f-045adbdac461"), "Website Platforms", "Programming & Tech", "GoDaddy", "Created" },
                    { new Guid("7e2c7a93-647f-4028-9ccd-c10b6d59ff73"), "Channel Specific ", "Digital Marketing", " Shopify Marketing", "Created" },
                    { new Guid("7e74cfff-5dcb-436e-afc9-51cb982bc683"), "Website Development", "Programming & Tech", "Build a Complete Website", "Created" },
                    { new Guid("7f0a6efa-4bae-4795-b372-8f2c29d3f22c"), "Content Writing", "Writing & Translation", "Research & Summaries", "Created" },
                    { new Guid("7f642891-b8fd-45cc-85ed-f67fe16c654b"), "Website Development", "Programming & Tech", "Business Websites", "Created" },
                    { new Guid("800f3f68-030a-4f0e-aba6-cb2d1990652c"), "Business Consultants", "Consulting", "Legal Consulting", "Created" },
                    { new Guid("804a14f0-a14c-45c2-9ffd-0cd2e9eb42d9"), "Miscellaneous", "Business", "Online Investigations", "Created" },
                    { new Guid("80a4e5e2-2abc-4f9b-a782-f13ab38e57e9"), "Animation", "Video & Animation", "Animated GIFs", "Created" },
                    { new Guid("821c29b5-29bf-4e50-999f-31687de4320f"), "Sound Design", "Music & Audio", "Custom Patches & Samples", "Created" },
                    { new Guid("83297ff3-0f8c-4ae9-be18-3c2e3c7a8cda"), "Software Development", "Programming & Tech", "User Testing", "Created" },
                    { new Guid("8375cbe5-2db1-41d6-bb2d-72b9b1ce2289"), "Tax Consulting", "Finance", "Tax Planning", "Created" },
                    { new Guid("853f01e9-002c-44c8-9070-2a20ae697f0c"), "Marketing Design", "Graphics & Design", "Social Posts & Banners", "Created" },
                    { new Guid("86324ae4-c661-4331-98e3-ae4609b578fd"), "Data Science & ML", "Programming & Tech", "NLP", "Created" },
                    { new Guid("868c8f7e-a231-412f-82b9-a1c50a1cc537"), "Business Formation & Consulting", "Business", "HR Consulting", "Created" },
                    { new Guid("8863a02b-f230-42b7-9104-a747fefb83a5"), "Presenter Videos", "Video & Animation", "UGC Ads", "Created" },
                    { new Guid("893cff74-e7ff-4353-a95e-9125a76d7866"), "Industry & Purpose-Specific", "Digital Marketing", "Mobile App Marketing", "Created" },
                    { new Guid("89db274e-6bd4-497f-8dc3-a93121349e37"), "Data Collection", "Data", "Data Scraping", "Created" },
                    { new Guid("8a72201c-279a-4abc-a2af-849e4232ed80"), "Local Photography", "Photography", "Photographers in Paris", "Created" },
                    { new Guid("8b5da7d8-280c-4f2a-9154-c93a6c0db43e"), "Mobile App Development", "Programming & Tech", "Website to App", "Created" },
                    { new Guid("8b8c4481-807b-4504-9978-590159a44179"), "Miscellaneous", "Video & Animation", "Article to Video", "Created" },
                    { new Guid("8ba20b85-0ef1-4d31-83a2-66c1a096b770"), "Voice Over & Narration", "Music & Audio", "French Voice Over", "Created" },
                    { new Guid("8bcd6711-2342-4f33-9812-5bca7df57c97"), "Marketing Design", "Graphics & Design", "Signage Design", "Created" },
                    { new Guid("8c657952-70d8-40bd-adc7-d95df43757e7"), "Software Development", "Programming & Tech", "Automations & Workflows", "Created" },
                    { new Guid("8ced6cae-9512-4ef6-9dab-c1fa8d48ee24"), "Translation & Transcription", "Writing & Translation", "Interpretation", "Created" },
                    { new Guid("8cf5be58-61ae-4465-af7e-43ed3c26f09a"), "Local Photography", "Photography", "All Cities", "Created" },
                    { new Guid("8d66c0b1-4c07-4bea-8fc2-6e6ecd9b6e42"), "Sound Design", "Music & Audio", "Sound Design", "Created" },
                    { new Guid("8dab24fa-3ab8-4795-9ea0-e7c7d8c90b3f"), "Translation & Transcription", "Writing & Translation", "Translation", "Created" },
                    { new Guid("8ea46593-e473-4205-84ef-79f0046721a4"), "Legal Services", "Business", "Legal Research", "Created" },
                    { new Guid("8f00fbd0-f865-4d20-a73a-66ad1af8e986"), "Content Writing", "Writing & Translation", "Scriptwriting", "Created" },
                    { new Guid("91157248-4f02-493b-a4a2-4db60d49fb47"), "Marketing Design", "Graphics & Design", "Email Design", "Created" },
                    { new Guid("9115f5c3-aa94-4d8e-99b4-3b2b2d74b0b5"), "Packaging & Covers", "Graphics & Design", "Book Covers", "Created" },
                    { new Guid("91a4ebaa-cd50-4427-9e86-9e630e00d0f6"), "Chatbot Development", "Programming & Tech", "Rules Based Chatbot", "Created" },
                    { new Guid("91c5106b-861c-4d5e-99e9-ee959e1b4eae"), "Data Processing & Management ", "Data", "Data Processing", "Created" },
                    { new Guid("935b5f1e-a5c8-4fd9-90c3-f636851a3c29"), "Marketing Strategy", "Consulting", "Marketing Strategy", "Created" },
                    { new Guid("93ea4dea-7dad-4872-acc5-680945d1dd25"), "Business & Marketing Copy", "Writing & Translation", "Product Descriptions", "Created" },
                    { new Guid("94cda4e1-f706-4cff-b9f5-cdf20fb80759"), "Local Photography", "Photography", "Photographers in Los Angeles", "Created" },
                    { new Guid("96544b2f-2b39-4932-98a5-8eac22a830f0"), "Miscellaneous", "Programming & Tech", "Convert Files", "Created" },
                    { new Guid("96a2c12f-7355-4003-b495-7ab03f79bd95"), "Website Maintenance", "Programming & Tech", "Backup & Migration", "Created" },
                    { new Guid("976ecd94-fa7e-4173-a7aa-cfaa8e4b124c"), "Products & Lifestyle", "Photography", "Food Photographers", "Created" },
                    { new Guid("977f083c-e350-4967-a2df-b5657b0eac37"), "Print Design", "Graphics & Design", "Flyer Design", "Created" },
                    { new Guid("98ce3bd3-af8c-4928-a7dd-74ef524ecb61"), "AI Content", "AI Services", "Custom Writing Prompts", "Created" },
                    { new Guid("9959b4ba-c132-4605-a12b-4233949408d7"), "Web & App Design", "Graphics & Design", "UX Design", "Created" },
                    { new Guid("998fe13f-2f4a-42f3-ad68-7cd146f61b78"), "Coaching & Advice", "Consulting", "Life Coaching", "Created" },
                    { new Guid("99a50046-da2c-42c5-8089-9d8ffda4b7a3"), "Coaching & Advice", "Consulting", "Styling & Beauty Advice", "Created" },
                    { new Guid("9a3c6b0c-3970-483a-9653-279600267748"), "Industry & Purpose-Specific", "Digital Marketing", "Book & eBook Marketing", "Created" },
                    { new Guid("9c11bb3a-847f-40cd-b051-05b389de3630"), "Fashion & Merchandise", "Graphics & Design", "Jewelry Design", "Created" },
                    { new Guid("9d648e87-8a3a-44e0-986e-1bd12f711ea2"), "Miscellaneous", "Personal Growth", "Other", "Created" },
                    { new Guid("9e1d9731-9dfd-4f13-960a-7d0fa85777c0"), "Art & Illustration", "Graphics & Design", "Storyboards", "Created" },
                    { new Guid("9e2f9c1f-6b33-4079-b84f-cf25b6dc9375"), "Voice Over & Narration", "Music & Audio", "German Voice Over", "Created" },
                    { new Guid("9e598687-1680-4711-9d7b-9ce43a001a68"), "AI Video ", "Video & Animation", "AI Music Videos", "Created" },
                    { new Guid("9e745e6f-782f-4fd2-947c-68d470bdf5df"), "AI for Businesses", "AI Services", "AI Strategy", "Created" },
                    { new Guid("9ea9ebf9-1f46-4489-bfcc-77acbdfe3db7"), "3D Design", "Graphics & Design", "3D Jewelry Design", "Created" },
                    { new Guid("9f6fb922-02b6-40ce-b524-fd5c1f00d4ed"), "AI Audio", "AI Services", "Text to Speech", "Created" },
                    { new Guid("9fbea16d-0353-4c70-86ca-08d77a822e19"), "Presenter Videos", "Video & Animation", "UGC Videos ", "Created" },
                    { new Guid("a070768c-db66-41a4-afbd-859a5fcddb65"), "3D Design", "Graphics & Design", "3D Printing Characters", "Created" },
                    { new Guid("a082d71a-8867-4dfc-b14b-f9efa14b503d"), "Web & App Design", "Graphics & Design", "Icon Design", "Created" },
                    { new Guid("a0af3ee6-1172-44bf-9a0d-4e4f5aed4b01"), "Industry Specific Content", "Writing & Translation", "Real Estate", "Created" },
                    { new Guid("a111a8ff-06c5-4cad-b36f-829332d56933"), "Self Improvement", "Personal Growth", "Language Lessons", "Created" },
                    { new Guid("a2d8df72-9b27-4db3-8ffd-5f93b0b3a41b"), "Operations & Management", "Business", "Supply Chain Management", "Created" },
                    { new Guid("a382a8c6-0243-43d8-83f9-00d8d9a1dc5c"), "Website Maintenance", "Programming & Tech", "Speed Optimization", "Created" },
                    { new Guid("a45e2c3e-de0f-45f7-bd04-b699db213497"), "Personal Finance & Wealth Management", "Finance", "Personal Budget Management", "Created" },
                    { new Guid("a47681c3-e3cc-4389-b06d-6378b6351ade"), "Operations & Management", "Business", "Product Management", "Created" },
                    { new Guid("a4e2d023-ddf0-46ac-a44a-c04b6bd32fd0"), "Analytics & Strategy", "Digital Marketing", "Marketing Concepts & Ideation", "Created" },
                    { new Guid("a5397839-c1e5-4f38-9bd6-6871dfea4d21"), "Career Writing", "Writing & Translation", "Resume Writing", "Created" },
                    { new Guid("a5dc523c-1d47-4bfd-ae5a-2a32fd4edfaa"), "Cloud & Cybersecurity ", "Programming & Tech", "Cybersecurity", "Created" },
                    { new Guid("a724c8aa-3a62-41e7-a456-810e1d1d3229"), "Financial Planning & Analysis", "Finance", "Financial Modeling", "Created" },
                    { new Guid("a8506dbd-ed1d-4cbc-8011-5c70f71379fb"), "Software Development", "Programming & Tech", "APIs & Integrations", "Created" },
                    { new Guid("a897e971-ff37-491b-a5dd-3d5086a9e924"), "Personal Finance & Wealth Management", "Finance", "Investments Advisory", "Created" },
                    { new Guid("a8a1b6d5-1435-482f-a3e2-9462c0bae54b"), "Social & Marketing Videos", "Video & Animation", "Social Media Videos", "Created" },
                    { new Guid("a8d0f0b6-babf-48a9-9e52-71c560305c11"), "Cloud & Cybersecurity ", "Programming & Tech", "DevOps Engineering", "Created" },
                    { new Guid("a9342ddb-a36b-455d-a563-eea66ecdc073"), "Social & Marketing Videos", "Video & Animation", "Music Videos", "Created" },
                    { new Guid("a99b6fc9-11bb-4d2a-ab23-99810377aa9f"), "Methods & Techniques ", "Digital Marketing", "Guest Posting", "Created" },
                    { new Guid("a9d2d1f3-5f66-425e-b38d-b4cbcf05ec71"), "Marketing Strategy", "Consulting", "Content Strategy", "Created" },
                    { new Guid("a9f6e026-0007-4da3-afec-91042a1f0dd7"), "Print Design", "Graphics & Design", "Brochure Design", "Created" },
                    { new Guid("ac4ffd7d-3fda-4f8f-8a8a-13b6cd2e7b55"), "Data Analysis & Visualization", "Data", "Data Annotation", "Created" },
                    { new Guid("ad563a94-a5f0-405d-a089-42f919eb228f"), "Software Development", "Programming & Tech", "QA & Review", "Created" },
                    { new Guid("ad684779-2ba1-402a-a305-8f2772cbd85e"), "Website Platforms", "Programming & Tech", "Shopify", "Created" },
                    { new Guid("ae31803b-13a4-430a-84cc-92728d7f8ac3"), "Miscellaneous", "Programming & Tech", "Electronics Engineering", "Created" },
                    { new Guid("aeaeebb2-148c-4843-885e-b6dc72a34b49"), "Lessons & Transcriptions", "Music & Audio", "Online Music Lessons", "Created" },
                    { new Guid("aee0c64f-3ffc-40ac-bd1f-7968ff569bad"), "Data & Business Intelligence ", "Business", "Data Analytics", "Created" },
                    { new Guid("af207c29-a4e9-4ec5-aa82-6afe2ebc118b"), "Chatbot Development", "Programming & Tech", "Telegram", "Created" },
                    { new Guid("af526617-8c89-4be5-8b20-57ffd8f1bedd"), "Industry & Purpose-Specific", "Digital Marketing", "Podcast Marketing", "Created" },
                    { new Guid("b06ef85b-345c-4e14-94f1-7c4c8dc92cde"), "Sales & Customer Care", "Business", "Call Center & Calling ", "Created" },
                    { new Guid("b124eb45-0325-46dd-8261-96a113b518d8"), "Miscellaneous", "Photography", "Photo Preset Creation", "Created" },
                    { new Guid("b25d5547-65a8-4159-862f-50f24de7b74c"), "Methods & Techniques ", "Digital Marketing", "E-Commerce Marketing", "Created" },
                    { new Guid("b287c071-7e8f-4ef8-b8ef-65727bc3f04e"), "Career Writing", "Writing & Translation", "Job Descriptions", "Created" },
                    { new Guid("b3c1f221-f3c6-4539-b980-1e046071a476"), "Methods & Techniques ", "Digital Marketing", "Email Marketing", "Created" },
                    { new Guid("b425df52-ab20-4568-ab51-50e9c9ef5ab4"), "Tech Consulting", "Consulting", "AI Technology Consulting", "Created" },
                    { new Guid("b47870fc-fded-47f8-9b9b-501141ed708c"), "Data Collection", "Data", "Data Entry", "Created" },
                    { new Guid("b5b019e0-ea0c-4a20-b639-6ae82496086f"), "AI Artists", "AI Services", "Midjourney Artists", "Created" },
                    { new Guid("b6520ac2-e444-4733-868e-160c637f8518"), "Fashion & Merchandise", "Graphics & Design", "Fashion Design", "Created" },
                    { new Guid("b68fc700-c67b-440e-b6a8-f3e080fcab91"), "Social", "Digital Marketing", "Social Media Marketing", "Created" },
                    { new Guid("b704025a-fd34-495d-a676-20e7c1b6c64d"), "Databases & Engineering", "Data", "Data Engineering", "Created" },
                    { new Guid("b75045f1-1a4f-4e6e-8651-593eedb1eac8"), "Business & Marketing Copy", "Writing & Translation", "Social Media Copywriting", "Created" },
                    { new Guid("b759836b-3790-43bc-a241-a89d9344bc94"), "Self Improvement", "Personal Growth", "Generative AI Lessons", "Created" },
                    { new Guid("b76acbdd-ec34-4046-bb1f-eeec8c2febf0"), "Animation", "Video & Animation", "Character Animation", "Created" },
                    { new Guid("b79e8da0-4a63-41e3-a431-c5a782587673"), "Tech Consulting", "Consulting", "Software Development Consulting", "Created" },
                    { new Guid("b8076c34-f33d-4769-8eee-f00e343427ee"), "Miscellaneous", "Video & Animation", "Meditation Videos", "Created" },
                    { new Guid("b97c57ac-f5c8-48f7-959e-5df43f60f65d"), "Miscellaneous", "Video & Animation", "Book Trailers", "Created" },
                    { new Guid("b9b5fd4e-d3f5-4565-b43a-e227b442bcff"), "Explainer Videos", "Video & Animation", "Live Action Explainers", "Created" },
                    { new Guid("b9faca6d-7d8c-4e2c-aff4-6570fbdeab31"), "Editing & Critique", "Writing & Translation", "Writing Advice", "Created" },
                    { new Guid("ba0a082c-275c-4904-98d8-e7c072647532"), "AI Video", "AI Services", " AI Video Avatars", "Created" },
                    { new Guid("ba144e26-6cf4-4e63-b35f-0b64f8e6d491"), "Miscellaneous", "Video & Animation", "Video Advice", "Created" },
                    { new Guid("bb074407-58f8-4c35-a83a-c3e749e07f65"), "Wellness & Fitness", "Personal Growth", "Nutrition ", "Created" },
                    { new Guid("bb80e1f3-50dd-4668-805e-74f3128d0c6a"), "Website Platforms", "Programming & Tech", "Wix", "Created" },
                    { new Guid("bb8a9e9d-6de5-487a-95dc-7fe609c3e560"), "Data Science & ML", "Data", "Machine Learning", "Created" },
                    { new Guid("bba86c07-36bf-4ae5-b7a3-eb743dde46c8"), "Leisure & Hobbies", "Personal Growth", "Arts & Crafts", "Created" },
                    { new Guid("bc783392-b729-404b-bba5-ca67b98b304d"), "Gaming", "Personal Growth", "Game Coaching", "Created" },
                    { new Guid("bdcb008f-fe9c-4c04-845b-359d04a85e3d"), "Operations & Management", "Business", "Virtual Assistant", "Created" },
                    { new Guid("beafeb59-6652-4824-afb4-63187abf34fa"), "Local Photography", "Photography", "Photographers in London", "Created" },
                    { new Guid("befcbfc1-679b-440e-9f7b-8b04803104cb"), "Fashion & Merchandise", "Graphics & Design", "T-Shirts & Merchandise", "Created" },
                    { new Guid("bf4acb54-8fa6-4952-8923-6abe5dbb2acf"), "Website Platforms", "Programming & Tech", "WordPress", "Created" },
                    { new Guid("bfe5f250-6e71-42d8-a73a-9de925fd6025"), "Mentorship", "Consulting", "Writing Mentorship", "Created" },
                    { new Guid("c0cb09ef-1273-43ea-a57d-df3d4b7d37b2"), "Business & Marketing Copy", "Writing & Translation", "Press Releases", "Created" },
                    { new Guid("c11b6ee5-7b23-41cc-93a9-d902eae3e86d"), "Data Science & ML", "Data", "Computer Vision", "Created" },
                    { new Guid("c12b25b5-48e4-4976-a5a9-79f3cc786b41"), "AI Artists", "AI Services", "Stable Diffusion Artists", "Created" },
                    { new Guid("c1bc74c3-b185-48e4-b6d2-1e50510c7d2e"), "Explainer Videos", "Video & Animation", "eLearning Video Production", "Created" },
                    { new Guid("c24b8e9d-e1b4-4829-844d-11fa44e31764"), "Content Writing", "Writing & Translation", "Website Content", "Created" },
                    { new Guid("c25885d1-2595-4c1d-920c-99ee92d4756d"), "Methods & Techniques ", "Digital Marketing", "Text Message Marketing", "Created" },
                    { new Guid("c3810cb5-30c7-44bb-a62d-8ef8c3227acb"), "Logo & Brand Identity", "Graphics & Design", "Fonts & Typography", "Created" },
                    { new Guid("c461a2ca-48a7-4a33-96b7-efdb86846acd"), "Social & Marketing Videos", "Video & Animation", "Slideshow Videos", "Created" },
                    { new Guid("c4899600-335b-40ae-ad11-1f922001f39e"), "Music Production & Writing", "Music & Audio", "Jingles & Intros", "Created" },
                    { new Guid("c4c6212b-1485-460a-94d5-490eff79597f"), "AI for Businesses", "AI Services", "AI Lessons", "Created" },
                    { new Guid("c4fabcd2-0147-4fa9-9cf6-0e37dab9fe0c"), "Industry Specific Content", "Writing & Translation", "Business, Finance & Law ", "Created" },
                    { new Guid("c50b9bab-67aa-46bd-967d-4ed6617d3f6e"), "Product & Gaming", "Graphics & Design", "Game Art", "Created" },
                    { new Guid("c5316310-61ed-488d-9c82-18d5678bd3cc"), "Translation & Transcription", "Writing & Translation", "Transcription", "Created" },
                    { new Guid("c584b102-9c51-408d-8076-fd0e3d6f72d7"), "Gaming", "Personal Growth", "Ingame Creation", "Created" },
                    { new Guid("c6035ef2-bd51-4336-ac8b-a1cdff919c37"), "Website Platforms", "Programming & Tech", "Custom Websites", "Created" },
                    { new Guid("c6b26c5d-36a6-41c7-8d9d-d79edc4aacda"), "AI Mobile Development", "AI Services", "AI Fine-Tuning", "Created" },
                    { new Guid("c88af515-8be0-48e9-a5fa-6721620f5084"), "Accounting Services", "Finance", "Bookkeeping", "Created" },
                    { new Guid("c8b05b61-c6c0-4e36-a2f4-b249c39030cc"), "Streaming & Audio", "Music & Audio", "Audio Ads Production", "Created" },
                    { new Guid("c8cffd54-c187-40c2-a440-01fec109a2fe"), "Leisure & Hobbies", "Personal Growth", "Astrology & Psychics", "Created" },
                    { new Guid("ca13ce36-55e6-4a6d-8844-8a9b85d0cba9"), "Marketing Design", "Graphics & Design", "Web Banners", "Created" },
                    { new Guid("ca73f95d-3cb5-436e-bb2d-f3d1727e1a74"), "Industry Specific Content", "Writing & Translation", "Marketing", "Created" },
                    { new Guid("ca7f53b6-58e6-4435-96fc-d41c92a86d1b"), "Mobile App Development", "Programming & Tech", "Android App Development", "Created" },
                    { new Guid("ca85ae5c-db7a-42df-8055-4f49860e3759"), "Packaging & Covers", "Graphics & Design", "Album Cover Design", "Created" },
                    { new Guid("cab865f7-7725-4fa8-b786-f1c5d770814a"), "Wellness & Fitness", "Personal Growth", "Wellness", "Created" },
                    { new Guid("cb9c0b37-6b3d-4d33-9048-283c6c8019ff"), "Streaming & Audio", "Music & Audio", "Audiobook Production", "Created" },
                    { new Guid("cc1a550b-70e4-4204-8c5d-dca03766a266"), "Music Production & Writing", "Music & Audio", "Session Musicians", "Created" },
                    { new Guid("cc87a70e-b743-44e8-a58a-b3b476c21ddf"), "Game Development", "Programming & Tech", "PC Games", "Created" },
                    { new Guid("ccaf7167-b62e-488f-a1fa-670f2e8f2e0e"), "Methods & Techniques ", "Digital Marketing", "Video Marketing", "Created" },
                    { new Guid("cd8b98e6-2cad-43d4-bfd8-4edc3c424fe2"), "Mentorship", "Consulting", "Marketing Mentorship", "Created" },
                    { new Guid("ce7ab1d2-5479-4098-a905-1e6cd3c22f96"), "Editing & Post-Production", "Video & Animation", "Subtitles & Captions", "Created" },
                    { new Guid("cf559244-c43c-4078-b490-5a6f0e4ff7b4"), "Mobile App Development", "Programming & Tech", "Mobile App Maintenance", "Created" },
                    { new Guid("cf74e06b-79ef-4a95-82a4-31bd0744d5c5"), "Self Improvement", "Personal Growth", "Career Counseling", "Created" },
                    { new Guid("cf8d66ea-7279-430c-9b7f-2474568b5284"), "Miscellaneous", "Digital Marketing", "Crowdfunding", "Created" },
                    { new Guid("d01af2e5-7bcc-4340-b024-e43e624d79ff"), "Product & Gaming", "Graphics & Design", "Character Modeling", "Created" },
                    { new Guid("d06565a2-0267-4a41-897f-ae73545580f9"), "Miscellaneous", "Graphics & Design", "Design Advice", "Created" },
                    { new Guid("d13754e6-2235-4d72-aaf6-7817ba420ad0"), "AI Mobile Development", "AI Services", "AI Technology Consulting", "Created" },
                    { new Guid("d2082a07-1286-4833-8683-f03f7c6aa62a"), "AI Artists", "AI Services", "ComfyUI Workflow Creation", "Created" },
                    { new Guid("d2b03d50-3805-48a0-8d67-1846fe36af99"), "Marketing Strategy", "Consulting", "Social Media Strategy", "Created" },
                    { new Guid("d33a977f-f826-4f1c-8604-dfddea9f61e0"), "Product & Gaming", "Graphics & Design", "Industrial & Product Design", "Created" },
                    { new Guid("d38b3581-323b-44d1-9dde-5b68c33fa176"), "Legal Services", "Business", "Intellectual Property Management", "Created" },
                    { new Guid("d39d1b5b-5626-445f-b414-af3cf50868d9"), "Products & Lifestyle", "Photography", "Product Photographers", "Created" },
                    { new Guid("d53ab6b2-3c11-4ee1-84d7-839c46412464"), "Editing & Post-Production", "Video & Animation", "Video Templates Editing", "Created" },
                    { new Guid("d5bc4af1-26db-4dbc-a502-ebebd37b806d"), "Content Writing", "Writing & Translation", "Find an Expert Writer", "Created" },
                    { new Guid("d5c1c801-1a83-4096-8996-d4cf53e86344"), "Business & Marketing Copy", "Writing & Translation", "Brand Voice & Tone", "Created" },
                    { new Guid("d66c48d3-72d4-4f73-9871-5ccadd2bafad"), "Art & Illustration", "Graphics & Design", "Portraits & Caricatures", "Created" },
                    { new Guid("d7fab89a-f5a9-46a2-8ea1-e371646f9033"), "Methods & Techniques ", "Digital Marketing", "Affiliate Marketing", "Created" },
                    { new Guid("d9415858-6eb7-4081-b4a2-29b73d05364f"), "Business & Marketing Copy", "Writing & Translation", "Business Names & Slogans", "Created" },
                    { new Guid("d9e38369-d9e7-4ee1-a563-4a661fa9c32f"), "Music Production & Writing", "Music & Audio", "Custom Songs", "Created" },
                    { new Guid("dba0bc2e-a534-488d-b23e-1ac481188d59"), "Explainer Videos", "Video & Animation", "Crowdfunding Videos", "Created" },
                    { new Guid("dc218bd5-6d36-4a4c-9d24-9bdfa674d6ea"), "3D Design", "Graphics & Design", "3D Industrial Design", "Created" },
                    { new Guid("dc708c36-5367-419a-aa99-70afb6aea4de"), "Channel Specific ", "Digital Marketing", "Facebook Ads Campaign", "Created" },
                    { new Guid("dd63344e-c551-490e-844b-032db9872ec6"), "Audio Engineering & Post Production", "Music & Audio", "Mixing & Mastering", "Created" },
                    { new Guid("dd73801b-81f1-4e70-b65a-a197bb8bd1b8"), "3D Design", "Graphics & Design", "3D Architecture", "Created" },
                    { new Guid("de763e3a-4afc-4456-af9b-5d5092a252bc"), "Marketing Design", "Graphics & Design", "Social Media Design", "Created" },
                    { new Guid("df3054f4-6cd7-48ad-882b-a39ce274e2e0"), "Editing & Post-Production", "Video & Animation", "Intro & Outro Videos", "Created" },
                    { new Guid("dfa35302-66ee-4a2a-91f2-87b33f78feeb"), "Visual Design", "Graphics & Design", "Resume Design", "Created" },
                    { new Guid("e2028b97-9b75-4930-8d76-78ac7084cebe"), "AI Development", "Programming & Tech", "AI Integrations", "Created" },
                    { new Guid("e23c74ec-f057-4368-997f-e7834d63df12"), "Editing & Post-Production", "Video & Animation", "Video Art", "Created" },
                    { new Guid("e26428a6-f70e-4bb5-8bde-e07c0a7e1f31"), "Personal Finance & Wealth Management", "Finance", "Online Trading Lessons", "Created" },
                    { new Guid("e2e6ac4d-2b1b-4c27-b1b8-0a6a1ec4cbdd"), "Data Analysis & Visualization", "Data", "Data Visualization", "Created" },
                    { new Guid("e3094600-644a-4cf7-ab47-0e88353234af"), "Website Development", "Programming & Tech", "Dropshipping Websites", "Created" },
                    { new Guid("e3ad6e07-fba0-4682-a985-dfead944512b"), "Coaching & Advice", "Consulting", "Travel Advice", "Created" },
                    { new Guid("e4579ea5-fc30-4640-8914-2b9277b7835c"), "Data", "AI Services", "Data Science & ML", "Created" },
                    { new Guid("e494c3df-00b6-438d-8665-8684f8cb66df"), "Web & App Design", "Graphics & Design", "Landing Page Design", "Created" },
                    { new Guid("e5ced67e-0ee9-4039-92f2-d8fc7eebf989"), "Methods & Techniques ", "Digital Marketing", "Display Advertising ", "Created" },
                    { new Guid("e6daf4b7-c499-4419-be2b-e87bcc88c58d"), "AI Development", "Programming & Tech", "AI Fine-Tuning", "Created" },
                    { new Guid("e760ba59-478d-4e79-b6a6-b87032259f32"), "Tax Consulting", "Finance", "Tax Compliance", "Created" },
                    { new Guid("e7a03666-5269-411c-8f10-b4ed03fb19e1"), "Industry Specific Content", "Writing & Translation", "News & Politics", "Created" },
                    { new Guid("e7bd843e-4980-45eb-849f-cb5595cace33"), "Fundraising", "Finance", "Fundraising Consultation", "Created" },
                    { new Guid("e7faaaab-b6ac-424d-87db-c5dbb6a13745"), "AI Development", "Programming & Tech", "AI Websites & Software", "Created" },
                    { new Guid("e84ad252-a5bb-4b5f-832c-497353d1a5b7"), "Chatbot Development", "Programming & Tech", "AI Chatbot", "Created" },
                    { new Guid("e955d5d7-d50d-46e9-9749-3d58fb758492"), "Products & Lifestyle", "Photography", "Lifestyle & Fashion Photographers", "Created" },
                    { new Guid("ea1dbd49-63e3-4b1c-b096-acb9a881c648"), "3D Design", "Graphics & Design", "3D Game Art", "Created" },
                    { new Guid("ea581ef5-7c1e-4bfa-a78f-3df2fe3caa33"), "Career Writing", "Writing & Translation", "LinkedIn Profiles", "Created" },
                    { new Guid("eabf4e90-12ef-4aea-bb76-4e5160fb010e"), "Industry Specific Content", "Writing & Translation", "Internet & Technology ", "Created" },
                    { new Guid("eacdaaeb-d19f-4c65-b8bd-e358e046d4e0"), "Fashion & Style", "Personal Growth", "Styling & Beauty", "Created" },
                    { new Guid("ead0cea0-b22a-4849-afd1-1fc166aebb17"), "Music Production & Writing", "Music & Audio", "Composers", "Created" },
                    { new Guid("eaf49648-56d9-4f00-b31c-37d98ca8a43f"), "Business Formation & Consulting", "Business", "Business Formation & Registration", "Created" },
                    { new Guid("eafbfddd-852e-4649-a557-a7c627520272"), "Fashion & Style", "Personal Growth", "Trend Forecasting", "Created" },
                    { new Guid("ebe0e0fa-81bf-4716-91d5-aee01104cbed"), "Voice Over & Narration", "Music & Audio", "Male Voice Over", "Created" },
                    { new Guid("ebe73d7c-913d-4ec1-b48c-46a9c834cbdf"), "Miscellaneous", "Video & Animation", "Other", "Created" },
                    { new Guid("ed2794ef-8fa3-42f0-9d0e-bc15ad6758bb"), "Data Analysis & Visualization", "Data", "Dashboards", "Created" },
                    { new Guid("ed872b90-a24c-4033-8829-745371720285"), "AI Development", "Programming & Tech", "AI Agents", "Created" },
                    { new Guid("eda2f1fb-340d-41c2-a48b-a6c9a57dcb0c"), "Business Consultants", "Consulting", "E-commerce Consulting", "Created" },
                    { new Guid("eda66ee9-04e5-4f5b-95a2-9b13cb43939f"), "Website Development", "Programming & Tech", "E-Commerce Development", "Created" },
                    { new Guid("ede017f5-d3ca-47ca-b4dd-7673ba11f150"), "Content Writing", "Writing & Translation", "Speechwriting", "Created" },
                    { new Guid("ee7e966a-b0a7-4862-afb6-559dbacc8b58"), "Lessons & Transcriptions", "Music & Audio", "Music & Audio Advice", "Created" },
                    { new Guid("ef233aec-8b4b-499a-b0ec-f65386b05057"), "Mentorship", "Consulting", "Music Mentorship", "Created" },
                    { new Guid("ef352593-2fdb-40b7-b3a3-bcdf56017609"), "Blockchain & Cryptocurrency", "Programming & Tech", "Exchange Platforms", "Created" },
                    { new Guid("ef37b7a8-ace4-4b0d-ab94-00797cc5538a"), "Methods & Techniques ", "Digital Marketing", "Public Relations", "Created" },
                    { new Guid("ef49581f-7a35-409f-afe8-a7a6066f99dd"), "Coaching & Advice", "Consulting", "Career Counseling", "Created" },
                    { new Guid("ef54ea72-14d5-41b5-912d-85255d819ec1"), "Corporate Finance", "Finance", "Valuation", "Created" },
                    { new Guid("ef67d0de-8b90-4dfb-96ec-0cb2f8b1e12e"), "DJing", "Music & Audio", "Remixing", "Created" },
                    { new Guid("ef759aa5-6a3e-4b57-ba02-66a17582a7d0"), "Corporate Finance", "Finance", "Corporate Finance Strategy", "Created" },
                    { new Guid("ef928919-761c-4fec-b8de-0950f27b2448"), "Business Consultants", "Consulting", "Business Consulting", "Created" },
                    { new Guid("f200b912-80c9-4f49-9c67-d7576fc3aef9"), "Sales & Customer Care", "Business", "Sales", "Created" },
                    { new Guid("f206168e-13bf-4f9d-91ee-dfb7468d1498"), "Miscellaneous", "Writing & Translation", "eLearning Content Development", "Created" },
                    { new Guid("f21743fc-d81b-4b4c-882d-ded03fc106ad"), "Operations & Management", "Business", "Event Management", "Created" },
                    { new Guid("f2eb0aa7-b1e9-46da-8b9a-f9951230b501"), "Miscellaneous", "Digital Marketing", "Other", "Created" },
                    { new Guid("f344cbef-a4bd-4d04-90c9-ec9789f97508"), "Art & Illustration", "Graphics & Design", "Pattern Design", "Created" },
                    { new Guid("f34adbd5-ef27-49a0-b845-d85bbc3574e1"), "Mentorship", "Consulting", "Design Mentorship", "Created" },
                    { new Guid("f34b1c62-cc58-4671-8d1f-372c1388b9cf"), "AI Artists", "AI Services", "AI Avatar Design", "Created" },
                    { new Guid("f35aa3c2-0673-40bb-aef9-65f0966ceb84"), "Tax Consulting", "Finance", "Tax Identification Services", "Created" },
                    { new Guid("f3dca618-2fc9-4408-ac53-397c9cb404e9"), "AI Development", "Programming & Tech", "AI Technology Consulting", "Created" },
                    { new Guid("f488d8f9-ddbd-4fea-b0d8-2ea7cee6cb95"), "Visual Design", "Graphics & Design", "AI Image Editing", "Created" },
                    { new Guid("f58c761b-6d50-4ce6-88f5-ef5409d028bf"), "Editing & Critique", "Writing & Translation", "Proofreading & Editing", "Created" },
                    { new Guid("f594e3da-c14e-4b03-b906-93a1b15cf1be"), "Coaching & Advice", "Consulting", "Nutrition Coaching", "Created" },
                    { new Guid("f5bf97bb-79ae-44a4-bbb2-182147a5c5a0"), "Animation", "Video & Animation", "NFT Animation", "Created" },
                    { new Guid("f7fb9a5c-481c-4a84-ac89-69cd42f0d04b"), "Software Development", "Programming & Tech", "Web Applications", "Created" },
                    { new Guid("f8f60616-9607-46ae-bc24-596623aa97e7"), "Self Improvement", "Personal Growth", "Online Tutoring", "Created" },
                    { new Guid("f90c2d8f-a259-4255-868a-950552a6cda3"), "Data Science & ML", "Programming & Tech", "Computer Vision", "Created" },
                    { new Guid("f94bd94f-cdb5-4987-86a5-b8f420d8fc11"), "Content Writing", "Writing & Translation", "Content Strategy", "Created" },
                    { new Guid("fa1ba7d8-7076-4f81-9c14-700cd027c52e"), "Accounting Services", "Finance", "Financial Reporting", "Created" },
                    { new Guid("fa6dd736-4367-41e4-b965-3890b2e8f982"), "Voice Over & Narration", "Music & Audio", "24hr Turnaround", "Created" },
                    { new Guid("fcbec32c-9c25-4dea-96b2-d95a7376ccd1"), "DJing", "Music & Audio", "DJ Drops & Tags", "Created" },
                    { new Guid("fd02160f-02ab-4742-9a9c-6fb25853f699"), "Search", "Digital Marketing", "Video SEO", "Created" },
                    { new Guid("fd0b473d-f0d6-4bd2-93fe-401cb1564fe2"), "Product & Gaming", "Graphics & Design", "Graphics for Streamers", "Created" },
                    { new Guid("fd453370-d43d-46b4-84ca-cae1297c3055"), "Analytics & Strategy", "Digital Marketing", "Web Analytics", "Created" },
                    { new Guid("fde2025a-b199-4eb5-b202-a6420a820d99"), "AI for Businesses", "AI Services", "AI Consulting ", "Created" },
                    { new Guid("ff5e3865-6d39-41dd-8103-9b26a2f79861"), "Business Formation & Consulting", "Business", "Market Research", "Created" },
                    { new Guid("ffa6b113-3f66-4bfa-ae8c-547fed7a8255"), "AI Artists", "AI Services", "All AI Art Services", "Created" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("014b8e0a-1a62-43b1-9757-edc59841c873"), "Esperanto", "Created" },
                    { new Guid("0150ecd9-59d5-4768-8d23-5c2a4fdf699c"), "Norwegian", "Created" },
                    { new Guid("0170ea33-bf7c-4cc9-a616-d6b098821d55"), "Nepali", "Created" },
                    { new Guid("02e3a1c3-d5f7-4d66-b110-dbcf5570eb29"), "Hawaiian", "Created" },
                    { new Guid("03cce991-fdd8-4fab-94d5-98a58af8fbb9"), "Welsh", "Created" },
                    { new Guid("04d9aeda-8513-4903-ab38-1cf3b4270626"), "Spanish", "Created" },
                    { new Guid("05253f7a-7b87-4740-a180-ecf3ead613db"), "Portuguese", "Created" },
                    { new Guid("06e81a01-f34b-42c6-a41e-6acf494106c1"), "Telugu", "Created" },
                    { new Guid("0ed00b86-390c-4845-9cb4-1234d76ea849"), "Kyrgyz", "Created" },
                    { new Guid("11e1f59c-766d-4946-bbcd-6d577db5e8ed"), "Tamil", "Created" },
                    { new Guid("16d7e6ee-e9f1-4e7d-a56d-66aa484c0f2a"), "Malagasy", "Created" },
                    { new Guid("1846e690-1791-49e2-928d-069ca4567e24"), "Sesotho", "Created" },
                    { new Guid("1f79ab6a-fc48-4d84-9f28-48528eddcd28"), "Finnish", "Created" },
                    { new Guid("1fc92104-03bf-4237-89d4-44126dcd2880"), "Turkish", "Created" },
                    { new Guid("27fc562f-ad7c-4a18-9583-02f8de9908c2"), "Luxembourgish", "Created" },
                    { new Guid("2e2dbd4b-9729-412a-b91e-c63f44ea1187"), "Malay", "Created" },
                    { new Guid("2e4a6c9b-bc96-4ab5-b1a3-dc15c3f8ee85"), "Punjabi", "Created" },
                    { new Guid("2f4004c5-4caa-4263-b241-e67b39c435f4"), "Xhosa", "Created" },
                    { new Guid("33f385f5-658c-4c97-90e4-4a5ff23bf037"), "Greek", "Created" },
                    { new Guid("341e284d-6523-44a1-abee-8b60928b379c"), "Kannada", "Created" },
                    { new Guid("34697b5a-8e14-4cc9-a8fa-db67b4fcc14c"), "Mongolian", "Created" },
                    { new Guid("36155284-fd9d-4bb8-bb04-f779af8d9402"), "Macedonian", "Created" },
                    { new Guid("38749891-51cc-4d18-afee-c57372dc85c3"), "Lao", "Created" },
                    { new Guid("3c2d769a-6905-4d66-b841-c33013099677"), "Yoruba", "Created" },
                    { new Guid("3f42c9ed-ff33-46b9-a20a-a03e19bedc14"), "Thai", "Created" },
                    { new Guid("47675616-5ef5-49e3-9cd5-5c81633d8195"), "Basque", "Created" },
                    { new Guid("4a2e1b8a-d37c-4562-97e7-cdf470e4db67"), "Haitian Creole", "Created" },
                    { new Guid("4aad661d-70ca-483b-b507-92e037c0e607"), "Kazakh", "Created" },
                    { new Guid("4b33a9da-98c0-4b83-8e77-5c6bb080da21"), "Gujarati", "Created" },
                    { new Guid("4c9d0174-bbfe-49b6-a210-103e75f7d86c"), "Tajik", "Created" },
                    { new Guid("4eb05cd7-60a4-4033-9411-171fd5aabb71"), "Hungarian", "Created" },
                    { new Guid("4f0bd9c0-c30e-4401-9198-3113673340bb"), "Samoan", "Created" },
                    { new Guid("51bd64c5-d34f-4753-85b1-82aa1ba1663d"), "Catalan", "Created" },
                    { new Guid("5494d0dd-ea34-4834-a09e-3edb4b4693dc"), "Georgian", "Created" },
                    { new Guid("5585450b-0253-4d4d-a589-7044786196b5"), "Italian", "Created" },
                    { new Guid("581155dd-2411-4943-ab44-ec232c221cc7"), "Japanese", "Created" },
                    { new Guid("5ce14718-62a2-4997-9c51-a85dd902f360"), "Chichewa", "Created" },
                    { new Guid("5ebf5f4c-7455-4dec-bcb2-78de0734cf8d"), "Kinyarwanda", "Created" },
                    { new Guid("606131e2-b67c-4833-820a-0c1c85ddc53e"), "Serbian", "Created" },
                    { new Guid("6118b366-6cc8-4a90-a701-4120f9bbbabf"), "Chinese", "Created" },
                    { new Guid("63c1daba-0286-4a55-810e-273012210136"), "Icelandic", "Created" },
                    { new Guid("67781ad8-19f8-4fbe-a075-f4f63c92e5f7"), "Ukrainian", "Created" },
                    { new Guid("680f6d0a-bc6b-46ff-b136-e58afed6eb7c"), "Malayalam", "Created" },
                    { new Guid("689c03ce-826c-4320-9da3-1c3bb5a2730c"), "Javanese", "Created" },
                    { new Guid("693f5465-2787-4dcf-8257-69188e34275b"), "Latin", "Created" },
                    { new Guid("715d1938-9482-4a80-bed3-937de3358445"), "Filipino", "Created" },
                    { new Guid("7267d515-fcac-4bf9-87f3-a79c675fadff"), "Swedish", "Created" },
                    { new Guid("72e3ca1d-70e2-4eed-b890-649a517b3585"), "Persian", "Created" },
                    { new Guid("74346c20-3d23-4a51-95c1-32159c3b1de1"), "Latvian", "Created" },
                    { new Guid("74a8b2f0-7a6e-4ce8-9d19-ab5ce514f964"), "Sundanese", "Created" },
                    { new Guid("76bd6fe0-9d43-4539-b4cf-35e5c907d984"), "Slovenian", "Created" },
                    { new Guid("7a067905-893c-4e56-9982-c9cf122d8203"), "Maori", "Created" },
                    { new Guid("7ed5c9e2-626d-446c-b5b3-0c79f4d9370c"), "Uzbek", "Created" },
                    { new Guid("8064de6e-30cc-468a-b4ca-0d75673adaa7"), "Bosnian", "Created" },
                    { new Guid("86a7cd31-72c1-43bd-acd2-21a077c97f7b"), "Danish", "Created" },
                    { new Guid("86d2bbfd-d8d5-4c80-bb96-7d14f6b3218c"), "Croatian", "Created" },
                    { new Guid("88b6582b-dc47-4bce-bc2a-f3fe4b7e7105"), "Igbo", "Created" },
                    { new Guid("8af8bc9b-e652-4f31-9229-11fdde62ad46"), "Amharic", "Created" },
                    { new Guid("8c57cd9a-aa09-4aab-8bf3-f0817a17d52f"), "Uyghur", "Created" },
                    { new Guid("8fc29562-c155-4337-bf47-fd894a3d4b55"), "English", "Created" },
                    { new Guid("9082e957-a4b2-4bec-a551-824e5833d071"), "Hindi", "Created" },
                    { new Guid("90949919-96c1-4b75-bc84-4a592bd658ef"), "German", "Created" },
                    { new Guid("9622494d-f041-4af2-9c8c-982643d89d8e"), "Dutch", "Created" },
                    { new Guid("97fa62eb-2a6d-4d43-9b37-525eb48c5d55"), "Sinhala", "Created" },
                    { new Guid("9b53eb74-76ad-431a-9596-27ae59f7cc88"), "Romanian", "Created" },
                    { new Guid("9c00ca58-bb25-4a99-bc52-e091a3695b61"), "Turkmen", "Created" },
                    { new Guid("9e0e09fa-5304-49c2-9f0f-1e90b8f93e30"), "Bengali", "Created" },
                    { new Guid("a309a612-2d87-499f-9541-68939a206b56"), "Armenian", "Created" },
                    { new Guid("a7b48166-643d-4432-83aa-21c4251ea9bc"), "Albanian", "Created" },
                    { new Guid("a7d463ac-6acd-4218-af84-be69396f0df5"), "Swahili", "Created" },
                    { new Guid("a82e326c-bbac-4d74-a7e3-14f0450c946c"), "Estonian", "Created" },
                    { new Guid("aaf4edce-f656-4bdf-b412-61575cbf1f42"), "Urdu", "Created" },
                    { new Guid("acb4347f-b661-4f21-994e-d67e249c60fe"), "Lithuanian", "Created" },
                    { new Guid("addeeecc-a42c-42d7-b9a4-c650801c4e36"), "Pashto", "Created" },
                    { new Guid("adf3ade9-5ee0-446c-a0d4-3adcfe69a51a"), "Indonesian", "Created" },
                    { new Guid("af7a4629-4c34-454e-83fc-19cc87ed3d0c"), "Slovak", "Created" },
                    { new Guid("b41a374e-6570-4a7d-bffc-70eba12d6f72"), "Belarusian", "Created" },
                    { new Guid("be329894-d748-4016-ad91-e41dd21a08b1"), "Somali", "Created" },
                    { new Guid("c8b28da9-1eff-4897-88c3-8c022ea91035"), "Russian", "Created" },
                    { new Guid("ca29f937-c1fd-419c-83a2-fd909584eec9"), "Bulgarian", "Created" },
                    { new Guid("ca7a8dd5-9c40-459e-92ab-83278e6633d8"), "Czech", "Created" },
                    { new Guid("cc372a2a-8055-48c0-8630-06ccfd4aeb1f"), "Tatar", "Created" },
                    { new Guid("cc586334-a771-4728-9c96-e4975129695d"), "Khmer", "Created" },
                    { new Guid("cfde7c26-6f86-4297-ae20-2c71a9eb6fc2"), "Hebrew", "Created" },
                    { new Guid("d5d1359f-ccf9-4f1e-945a-7426a4323885"), "Burmese", "Created" },
                    { new Guid("d6f7b3a8-13ad-407d-b8ad-e9a9a276712a"), "Kurdish", "Created" },
                    { new Guid("daff77a5-799e-436f-b301-2fa755e1e266"), "Polish", "Created" },
                    { new Guid("de012677-ccc5-496b-8951-52be22245af7"), "Marathi", "Created" },
                    { new Guid("e23bbeb8-4e06-4a95-9f9d-c127b5bc5aec"), "Korean", "Created" },
                    { new Guid("e2bcd368-4e5c-49dc-bccc-62561c9415f9"), "Hausa", "Created" },
                    { new Guid("e3583f19-0774-4ae9-bfdd-c49743eaa64e"), "Galician", "Created" },
                    { new Guid("e3ba706c-a2d8-4308-8dd2-d195ed69c0ab"), "Scots Gaelic", "Created" },
                    { new Guid("e3f8d30c-7568-48bc-90af-1d58f8827999"), "Yiddish", "Created" },
                    { new Guid("e49f46c0-1150-45ad-b3ed-d2af10f52285"), "Zulu", "Created" },
                    { new Guid("e510e341-ae60-4741-a641-ca79254bc955"), "Sindhi", "Created" },
                    { new Guid("e77b8851-e242-43cb-96c8-64b88faa3b5a"), "Azerbaijani", "Created" },
                    { new Guid("e988b57d-2b08-494d-8483-4faef2d279a0"), "Hmong", "Created" },
                    { new Guid("eb3c5c35-7b60-44d6-a5f0-59ad9f67bb6d"), "Shona", "Created" },
                    { new Guid("eb3f0fde-8b66-4fe7-878c-be2242e71021"), "Corsican", "Created" },
                    { new Guid("f1e7e32a-bf80-4829-875a-1adc0c05a465"), "Arabic", "Created" },
                    { new Guid("f2d83fcb-e849-4d40-baea-220a3120cd10"), "Maltese", "Created" },
                    { new Guid("f4152fa6-31a8-494c-8b50-add99a314d5d"), "Afrikaans", "Created" },
                    { new Guid("fc44eeaa-43cf-4d16-b82a-6e5e4b429751"), "Vietnamese", "Created" },
                    { new Guid("fc96acb0-956c-4ade-9b17-d8c5d4cf8296"), "French", "Created" },
                    { new Guid("fcdabd3f-b061-4b9a-b8a7-32471e5c6946"), "Cebuano", "Created" },
                    { new Guid("fe943b7b-c68d-4e0b-8682-962f0fe11f2d"), "Irish", "Created" }
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
                name: "IX_Process_ProjectContractId",
                table: "Process",
                column: "ProjectContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContracts_FreelancerId",
                table: "ProjectContracts",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContracts_ProjectId",
                table: "ProjectContracts",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContracts_TransactionId",
                table: "ProjectContracts",
                column: "TransactionId");

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
                name: "ProjectContracts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "RateCodes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
