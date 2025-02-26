using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChillLancer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
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
                    { new Guid("00649120-eab8-4d0a-bdfa-1c9ef80ebe93"), "Wellness & Fitness", "Personal Growth", "Wellness", "Created" },
                    { new Guid("00b5ffdd-33e9-48a3-8789-5f8db7fdebb4"), "Fundraising", "Finance", "Investors Sourcing", "Created" },
                    { new Guid("00f050f7-2dd9-4197-a8ca-383e7ec0264e"), "Website Development", "Programming & Tech", "Build a Complete Website", "Created" },
                    { new Guid("02f9e1bf-cbee-4704-9a0b-23b647fe95f2"), "Personal Finance & Wealth Management", "Finance", "Investments Advisory", "Created" },
                    { new Guid("03e3422a-b12d-4f28-b1a5-187c02a3bc81"), "3D Design", "Graphics & Design", "3D Landscape", "Created" },
                    { new Guid("0439a364-c222-4dbf-adf3-2a0168bf608a"), "Website Platforms", "Programming & Tech", "WordPress", "Created" },
                    { new Guid("053a61f4-8ef9-4aa1-b80e-9524b22996c5"), "Art & Illustration", "Graphics & Design", "Illustration", "Created" },
                    { new Guid("05ca00ab-e101-4941-a39f-c3adbc30b217"), "Miscellaneous", "Photography", "Photography Classes", "Created" },
                    { new Guid("05f3180a-32f0-40e6-a5d7-b00eed2d55c0"), "Data Processing & Management ", "Data", "Data Governance & Protection", "Created" },
                    { new Guid("063ae873-dc7d-4a4e-b46c-c21452d6723d"), "Miscellaneous", "Programming & Tech", "Electronics Engineering", "Created" },
                    { new Guid("0818b07b-656c-4052-a9a6-7c8348ff99e5"), "Miscellaneous", "Photography", "Other", "Created" },
                    { new Guid("0862c188-142d-4508-97a7-e9d4eab653ed"), "Motion Graphics", "Video & Animation", "Lottie & Web Animation", "Created" },
                    { new Guid("098200aa-ad2c-4b59-a00c-aa178090b413"), "Product Videos ", "Video & Animation", "App & Website Previews", "Created" },
                    { new Guid("0a5fc503-5639-45cf-a4bb-2e0670d72515"), "Visual Design", "Graphics & Design", "Vector Tracing", "Created" },
                    { new Guid("0ad6f209-d52d-472d-a91c-9b717ed06694"), "Coaching & Advice", "Consulting", "Mindfulness Coaching", "Created" },
                    { new Guid("0cb52e1a-8a9a-4c65-920e-961ddbb130e3"), "Fashion & Style", "Personal Growth", "Trend Forecasting", "Created" },
                    { new Guid("0cc5f9f4-4253-4ec7-83b8-37ad26f608d1"), "Data Collection", "Data", "Data Scraping", "Created" },
                    { new Guid("0e031f2f-5308-4d8c-9043-4e168b8e7f63"), "Website Platforms", "Programming & Tech", "Custom Websites", "Created" },
                    { new Guid("0e0dd82f-7f75-405d-aab2-e20d3afe154f"), "Business Consultants", "Consulting", "E-commerce Consulting", "Created" },
                    { new Guid("0e2a8a8d-07c2-4d69-a893-d8d65060b3f2"), "Software Development", "Programming & Tech", "Scripting", "Created" },
                    { new Guid("0e8ab76a-f1f2-4971-9334-f9b6102fdbc8"), "Search", "Digital Marketing", "Local SEO", "Created" },
                    { new Guid("0ed2e238-5db7-4940-87ff-febe2a5ea5c1"), "Data Collection", "Data", "Data Cleaning", "Created" },
                    { new Guid("0f39161f-5f78-464e-8dc1-32664caadb2f"), "Tech Consulting", "Consulting", "Cybersecurity Consulting", "Created" },
                    { new Guid("0f893e34-3dbf-4cca-b7a9-2ed8686b693f"), "Business Formation & Consulting", "Business", "HR Consulting", "Created" },
                    { new Guid("0fdfbf00-8626-4166-9dbc-1d3ee0aa3d9e"), "Motion Graphics", "Video & Animation", "Text Animation", "Created" },
                    { new Guid("0fe821ea-32e6-4fb8-a47a-7fcd40c2c5ad"), "Legal Services", "Business", "Legal Research", "Created" },
                    { new Guid("108813a8-a096-4215-9dba-d715860af297"), "Fashion & Merchandise", "Graphics & Design", "T-Shirts & Merchandise", "Created" },
                    { new Guid("1088aefb-d50f-4a04-9cc8-277c677907d2"), "Editing & Critique", "Writing & Translation", "Writing Advice", "Created" },
                    { new Guid("11762819-6b1b-4af8-bc35-675b9925a977"), "Streaming & Audio", "Music & Audio", "Podcast Production", "Created" },
                    { new Guid("1205f980-0c19-4f25-aa54-b4c4dfc95de6"), "Data Science & ML", "Data", "Deep Learning", "Created" },
                    { new Guid("12220417-bbe3-40e8-bf6d-20acf2d3f910"), "Wellness & Fitness", "Personal Growth", "Nutrition ", "Created" },
                    { new Guid("1278f29c-4799-4d2a-84ce-b98d677325d0"), "Personal Finance & Wealth Management", "Finance", "Online Trading Lessons", "Created" },
                    { new Guid("12cce3ff-54a5-42bf-8564-ece8750071a5"), "Mobile App Development", "Programming & Tech", "Android App Development", "Created" },
                    { new Guid("1309764f-dc27-4687-83f1-940fa113e774"), "Industry Specific Content", "Writing & Translation", "Health & Medical ", "Created" },
                    { new Guid("13227245-c903-4436-92ce-e405568dd3c3"), "AI Development", "Programming & Tech", "AI Integrations", "Created" },
                    { new Guid("1406296c-4be0-4fe4-839e-c4c772685eb8"), "Business Formation & Consulting", "Business", "Business Consulting", "Created" },
                    { new Guid("1474c99b-1765-424c-b5b4-b686844571c0"), "Business Consultants", "Consulting", "Business Consulting", "Created" },
                    { new Guid("14914189-f871-4a27-a770-6c6cad47dba2"), "Accounting Services", "Finance", "Find a Financial Expert", "Created" },
                    { new Guid("15c9e71e-94ff-4e83-a968-2baa6a329684"), "Audio Engineering & Post Production", "Music & Audio", "Mixing & Mastering", "Created" },
                    { new Guid("15e6da6c-2555-4404-8abb-9a135d2ec5b0"), "Corporate Finance", "Finance", "Corporate Finance Strategy", "Created" },
                    { new Guid("168145eb-7d43-4916-9c81-cae9493417ab"), " Book & eBook Publishing", "Writing & Translation", "Self-Publish Your Book", "Created" },
                    { new Guid("16b5aae5-056e-4937-b535-dbc24624b649"), "Art & Illustration", "Graphics & Design", "Children's Book Illustration", "Created" },
                    { new Guid("192603e7-048b-45b5-9174-952c6adc0237"), "Web & App Design", "Graphics & Design", "Website Design", "Created" },
                    { new Guid("19e43137-32ed-481d-a34a-f53fe7f0e658"), "Social", "Digital Marketing", "Paid Social Media", "Created" },
                    { new Guid("1b5c8b37-51b2-4b6f-a484-a3c515c6ad8a"), "Personal Finance & Wealth Management", "Finance", "Personal Budget Management", "Created" },
                    { new Guid("1bfb0ac4-94e0-4355-9576-eb2eb0381837"), "Marketing Design", "Graphics & Design", "Email Design", "Created" },
                    { new Guid("1c391435-ddd8-4cc0-9424-1ad23a2179ca"), "Audio Engineering & Post Production", "Music & Audio", "Audio Editing", "Created" },
                    { new Guid("1e301434-97ad-4c5e-bdda-1527371b5d16"), "Motion Graphics", "Video & Animation", "Logo Animation", "Created" },
                    { new Guid("1eb0acd0-8981-404e-98be-92f9a99841ec"), "Industry & Purpose-Specific", "Digital Marketing", "Music Promotion", "Created" },
                    { new Guid("1f2f6952-08e8-4e27-b583-b24f8cf9fee2"), "Local Photography", "Photography", "Photographers in London", "Created" },
                    { new Guid("1fbfed99-f419-4b01-a690-4759474fa30d"), "Marketing Strategy", "Consulting", "PR Strategy", "Created" },
                    { new Guid("1fe46292-f484-4633-91d9-68cbbf476366"), "Analytics & Strategy", "Digital Marketing", "Marketing Strategy", "Created" },
                    { new Guid("1fe6e4ef-e380-4c9e-9d66-936b8044648e"), "Data", "AI Services", "Data Science & ML", "Created" },
                    { new Guid("20b44b70-d8c0-450e-8ff0-2be831c1b987"), "Marketing Strategy", "Consulting", "Influencers Strategy", "Created" },
                    { new Guid("22443b71-e7f3-4602-b192-ed2318d3b1c1"), "Software Development", "Programming & Tech", "Databases", "Created" },
                    { new Guid("2255b821-bda4-440d-9c7a-f543b6aa9245"), "Business & Marketing Copy", "Writing & Translation", "UX Writing", "Created" },
                    { new Guid("2285c6d8-c8e3-4787-bb37-3ed2708a8397"), "Game Development", "Programming & Tech", "Mobile Games", "Created" },
                    { new Guid("22c6db00-fd10-48c9-a6af-0c935b9c1d73"), "AI for Businesses", "AI Services", "AI Consulting ", "Created" },
                    { new Guid("22d11453-f447-4183-a579-77ecf42e0693"), "3D Design", "Graphics & Design", "3D Architecture", "Created" },
                    { new Guid("23109825-a121-4db1-a480-78c0986fa5f1"), "Lessons & Transcriptions", "Music & Audio", "Online Music Lessons", "Created" },
                    { new Guid("231b7810-aa39-44af-899e-a65417394d34"), "Web & App Design", "Graphics & Design", "UX Design", "Created" },
                    { new Guid("232c5179-c298-413b-9a45-67b27a8cd409"), "Website Platforms", "Programming & Tech", "Wix", "Created" },
                    { new Guid("25a1af5d-55a4-4062-a52e-5b8f85b8f019"), "Website Platforms", "Programming & Tech", "GoDaddy", "Created" },
                    { new Guid("25ec1e78-f253-4268-b341-55878eacc714"), "Data Consulting", "Consulting", "Data Analytics Consulting", "Created" },
                    { new Guid("2684d29e-d11e-4810-a13f-ccd8376d4388"), "Operations & Management", "Business", "Project Management", "Created" },
                    { new Guid("26b651b4-76e9-45de-b0c6-6805cf112b23"), "Data Collection", "Data", "Data Enrichment", "Created" },
                    { new Guid("26c167ec-9d02-46f1-9838-b16934ca594b"), "Business & Marketing Copy", "Writing & Translation", "Case Studies", "Created" },
                    { new Guid("2846c359-aa8f-4646-9bd9-84a33674fd6d"), "Channel Specific ", "Digital Marketing", "Facebook Ads Campaign", "Created" },
                    { new Guid("28a4754c-463b-4c4d-bf95-0ea276931734"), "Voice Over & Narration", "Music & Audio", "French Voice Over", "Created" },
                    { new Guid("2918e5ed-9582-4364-99a9-e6aa667d919e"), "Music Production & Writing", "Music & Audio", "Singers & Vocalists", "Created" },
                    { new Guid("2aa2204d-f187-4b8b-917c-fbd04aa9a3ab"), "Data & Business Intelligence ", "Business", "Data Visualization", "Created" },
                    { new Guid("2adaf707-369f-4cc7-b2f3-5fbc7e11c7a2"), "Data Science & ML", "Programming & Tech", "Deep Learning", "Created" },
                    { new Guid("2ae85d1b-4839-4961-8fc9-0c69878c28c1"), "Miscellaneous", "Personal Growth", "Embroidery Digitizing", "Created" },
                    { new Guid("2b3b2156-62a7-4035-b927-d1b944af3803"), "Presenter Videos", "Video & Animation", "UGC Ads", "Created" },
                    { new Guid("2cd54ce9-6888-4191-8c07-19261d92b4ef"), "Miscellaneous", "Photography", "Photo Preset Creation", "Created" },
                    { new Guid("2cdd8225-977d-4f7d-9b1e-ef5dc9b0da81"), "Career Writing", "Writing & Translation", "Job Descriptions", "Created" },
                    { new Guid("2d1fa62c-bde4-4617-96c4-c564583d986b"), "Art & Illustration", "Graphics & Design", "Storyboards", "Created" },
                    { new Guid("2d298cca-bd07-46ca-a31d-19393bdb5619"), "Fashion & Style", "Personal Growth", "Styling & Beauty", "Created" },
                    { new Guid("2dfc6a90-4258-4d60-bb2a-595e77e93138"), "Operations & Management", "Business", "Product Management", "Created" },
                    { new Guid("302f2910-b336-4f96-bce7-0b492b660155"), "Logo & Brand Identity", "Graphics & Design", "Logo Maker Tool", "Created" },
                    { new Guid("311efac4-0db9-44ad-9742-66d7051c30ff"), "Social", "Digital Marketing", "Social Media Marketing", "Created" },
                    { new Guid("317662c4-6299-432c-b9be-46162a272a33"), "Content Writing", "Writing & Translation", "Creative Writing", "Created" },
                    { new Guid("32574f9f-151b-451d-91fe-266223bcf91b"), "Business Formation & Consulting", "Business", "Business Plans", "Created" },
                    { new Guid("3345eb8d-e8e0-4855-ae28-bfb4214cee42"), "Animation", "Video & Animation", "Rigging", "Created" },
                    { new Guid("338b67c0-cf56-4304-aefc-d8c64e551275"), "Content Writing", "Writing & Translation", "Research & Summaries", "Created" },
                    { new Guid("33a5ea27-e918-449a-a0f1-d56aecf32ace"), "AI Development", "Programming & Tech", "AI Websites & Software", "Created" },
                    { new Guid("33b084fd-d679-4bb5-bbef-979486d342df"), "Social & Marketing Videos", "Video & Animation", "Slideshow Videos", "Created" },
                    { new Guid("341b0f3b-37b6-44d6-bcaa-f1acfaf44356"), "Audio Engineering & Post Production", "Music & Audio", "Vocal Tuning", "Created" },
                    { new Guid("3424753d-1448-445f-9f2a-0dfa35ef534e"), "Website Platforms", "Programming & Tech", "Shopify", "Created" },
                    { new Guid("34827136-6d8e-458d-8c6c-b91e6ce7951b"), "Tax Consulting", "Finance", "Tax Planning", "Created" },
                    { new Guid("35647d02-38c0-4d5d-a237-92d78a3ec8b1"), "Animation", "Video & Animation", "Character Animation", "Created" },
                    { new Guid("35c08aac-1209-484e-92cb-905829fdc656"), "Channel Specific ", "Digital Marketing", " Shopify Marketing", "Created" },
                    { new Guid("362f5c85-5210-4cb5-b8eb-f1faaf0e3951"), "Product Videos ", "Video & Animation", "Corporate Videos", "Created" },
                    { new Guid("368b47f2-1e12-4633-906c-99a163ef5d5f"), "Music Production & Writing", "Music & Audio", "Songwriters", "Created" },
                    { new Guid("36c01876-6cd7-4af6-8af0-ce1ebfa188b2"), "Data Analysis & Visualization", "Data", "Dashboards", "Created" },
                    { new Guid("3728c278-daf4-49d6-ac59-222e6deb544d"), "AI Content", "AI Services", "AI Content Editing", "Created" },
                    { new Guid("3738e501-2c36-4368-96c6-520cd41eccd2"), "Website Development", "Programming & Tech", "Dropshipping Websites", "Created" },
                    { new Guid("382a8291-2010-485a-93cc-31f5cfa12a7f"), "Cloud & Cybersecurity ", "Programming & Tech", "DevOps Engineering", "Created" },
                    { new Guid("3879299a-e28b-4153-a216-00575902cc84"), "Sound Design", "Music & Audio", "Custom Patches & Samples", "Created" },
                    { new Guid("38c76f97-6fe3-4701-a61b-26ca9ea179f6"), "Print Design", "Graphics & Design", "Poster Design", "Created" },
                    { new Guid("38dd2854-2e4f-4e1a-89b3-22879d54d1ca"), "Marketing Strategy", "Consulting", "Marketing Strategy", "Created" },
                    { new Guid("39fe6201-ec74-4ead-bec7-8bbd61632ace"), "Marketing Strategy", "Consulting", "Video Marketing Consulting", "Created" },
                    { new Guid("3acee6c9-31c2-49fb-9aa3-d4a62c8d50f9"), "AI Development", "Programming & Tech", "AI Fine-Tuning", "Created" },
                    { new Guid("3b174b20-eff9-46c3-a2a8-e2b19a4193ee"), "Miscellaneous", "Personal Growth", "Family & Genealogy", "Created" },
                    { new Guid("3b715d48-644d-4a19-aeca-d1536c1d6ad8"), "AI Audio", "AI Services", "Text to Speech", "Created" },
                    { new Guid("3c9d7409-39fe-415c-ad32-f481f3340c0c"), "Logo & Brand Identity", "Graphics & Design", "Fonts & Typography", "Created" },
                    { new Guid("3d4a1391-5881-45fd-be15-4c5ff98ced0f"), "Fundraising", "Finance", "Funding Pitch Presentations", "Created" },
                    { new Guid("3d546a3c-f747-49aa-a8e4-50d6864cc6cf"), "Leisure & Hobbies", "Personal Growth", "Astrology & Psychics", "Created" },
                    { new Guid("3d814742-f94b-4ec1-b9ab-cc5af0cc8109"), "Miscellaneous", "Graphics & Design", "Design Advice", "Created" },
                    { new Guid("3edfc436-e1de-4374-8702-e7747dff5ba4"), "Translation & Transcription", "Writing & Translation", "Localization", "Created" },
                    { new Guid("40426f37-f019-4980-a78a-d81895c35b4e"), "AI Video ", "Video & Animation", "AI Music Videos", "Created" },
                    { new Guid("40a38748-4234-45fd-b2ef-98b3f34f65f4"), "Methods & Techniques ", "Digital Marketing", "Email Automations", "Created" },
                    { new Guid("40ae18e6-59d7-40f9-97b1-2a7c4679ab43"), "Tax Consulting", "Finance", "Tax Exemptions", "Created" },
                    { new Guid("40c2a74a-c14f-479f-963d-16b1eb72c52a"), "Blockchain & Cryptocurrency", "Programming & Tech", "Cryptocurrencies & Tokens", "Created" },
                    { new Guid("40f72812-12bf-4b04-a04b-5adfc0d507e9"), "AI Development", "Programming & Tech", "AI Mobile Apps", "Created" },
                    { new Guid("42b51c3f-04e0-49a1-b304-1270732c9006"), "Gaming", "Personal Growth", "Game Recordings & Guides", "Created" },
                    { new Guid("430c23c8-254f-41d8-a6ac-51ce6d759b29"), "Content Writing", "Writing & Translation", "Website Content", "Created" },
                    { new Guid("433a4b2f-21d5-4297-9e5f-029a7c7b50b7"), "Fashion & Merchandise", "Graphics & Design", "Fashion Design", "Created" },
                    { new Guid("433ee901-aba0-450c-8a19-2b101632a1ea"), "Visual Design", "Graphics & Design", "Presentation Design", "Created" },
                    { new Guid("43ceefcb-4f28-47f7-9fe7-320508b5f7b3"), "Miscellaneous", "Personal Growth", "Other", "Created" },
                    { new Guid("4576a66c-0e45-4e5f-8e95-edc80911dfd5"), "Data Processing & Management ", "Data", "Data Processing", "Created" },
                    { new Guid("46c5b356-2998-4474-a849-0503c87b93f1"), "Sound Design", "Music & Audio", "Audio Plugin Development", "Created" },
                    { new Guid("4749a823-70d3-4d7c-a620-bc0f832465b7"), "Miscellaneous", "Programming & Tech", "Convert Files", "Created" },
                    { new Guid("47ba7378-3a8b-4b29-a82c-767825c00966"), "Editing & Critique", "Writing & Translation", "AI Content Editing", "Created" },
                    { new Guid("4987c4c0-bac4-4954-ae0e-a28e4f4f0905"), "Miscellaneous", "Video & Animation", "Meditation Videos", "Created" },
                    { new Guid("4b526de7-4688-4b87-beec-78f11ecb0823"), "AI Artists", "AI Services", "Stable Diffusion Artists", "Created" },
                    { new Guid("4c38c89c-6f98-42a7-9827-f1983341ccb4"), "Lessons & Transcriptions", "Music & Audio", "Music Transcription", "Created" },
                    { new Guid("4ceb7d44-e82d-4393-9f9d-8ad9acd0cc70"), "Corporate Finance", "Finance", "Mergers & Acquisitions Advisory", "Created" },
                    { new Guid("4d5b3995-7346-4b4e-ac68-b4b0d0fe03c9"), "Explainer Videos", "Video & Animation", "Crowdfunding Videos", "Created" },
                    { new Guid("4d67c92c-e429-4bb2-b133-8750bbf8a1a3"), "AI Video", "AI Services", " AI Video Avatars", "Created" },
                    { new Guid("4dac5f82-b3f8-4225-a8e5-ecf8503f3f5e"), "Logo & Brand Identity", "Graphics & Design", "Business Cards & Stationery", "Created" },
                    { new Guid("4e433214-c8a5-4063-aa16-8ba09a26f055"), "Legal Services", "Business", "Intellectual Property Management", "Created" },
                    { new Guid("4e571bd7-60b4-4d39-9484-e6740abd8292"), "Self Improvement", "Personal Growth", "Language Lessons", "Created" },
                    { new Guid("500502f2-0941-4cbe-bc2f-f51a836a3e6f"), "AI Development", "Programming & Tech", "AI Technology Consulting", "Created" },
                    { new Guid("507ee561-725c-4b52-b0c7-e61a0ddf37be"), "Content Writing", "Writing & Translation", "Find an Expert Writer", "Created" },
                    { new Guid("50804c07-0982-4eb6-8db3-e8aeaaabf404"), "Architecture & Building Design", "Graphics & Design", "Landscape Design", "Created" },
                    { new Guid("5099fc69-a2d4-4ec5-a573-0c2f95872531"), "Miscellaneous", "Business", "Sustainability Consulting", "Created" },
                    { new Guid("509c1791-cc13-4ace-851f-29f64074ddd3"), "Animation", "Video & Animation", "NFT Animation", "Created" },
                    { new Guid("51080d41-9621-41d4-bb3a-b1662d6ec6af"), "Industry Specific Content", "Writing & Translation", "Business, Finance & Law ", "Created" },
                    { new Guid("5115fddf-99f8-406c-9e56-64b3dd939e99"), "Leisure & Hobbies", "Personal Growth", "Traveling", "Created" },
                    { new Guid("51c18224-7f8c-4678-b972-ffc480da648a"), "Methods & Techniques ", "Digital Marketing", "Guest Posting", "Created" },
                    { new Guid("526a2ca2-8f4b-4deb-8874-a8999306b950"), "Social & Marketing Videos", "Video & Animation", "Social Media Videos", "Created" },
                    { new Guid("537e562d-31e2-4e75-91b8-d0c0f6e0e290"), "Filmed Video Production", "Video & Animation", "Videographers", "Created" },
                    { new Guid("53ba54b4-0f39-4e5c-bb37-4dafec86036f"), "Software Development", "Programming & Tech", "APIs & Integrations", "Created" },
                    { new Guid("54520f3d-2b66-43d2-a5ac-1c5a0ce1c39f"), "Art & Illustration", "Graphics & Design", "Cartoons & Comics", "Created" },
                    { new Guid("55025746-be59-4d59-9646-d9a8b5ab4a29"), "Business Consultants", "Consulting", "AI Consulting", "Created" },
                    { new Guid("554c621a-e501-4cfb-bd78-449d8e6b5c5d"), "Blockchain & Cryptocurrency", "Programming & Tech", "Decentralized Apps (dApps)", "Created" },
                    { new Guid("5576fc47-3c09-4ac8-af93-1f254067a94b"), "Software Development", "Programming & Tech", "QA & Review", "Created" },
                    { new Guid("56173685-a2db-4efb-bab3-ebb75c25317b"), "Miscellaneous", "Video & Animation", "Virtual & Streaming Avatars", "Created" },
                    { new Guid("56e68e02-31f8-47e7-a37a-66f431fcd0c2"), "Gaming", "Personal Growth", "Game Matchmaking", "Created" },
                    { new Guid("5743c813-931e-4bbe-9712-5ea04284eb28"), "Corporate Finance", "Finance", "Due Diligence", "Created" },
                    { new Guid("596b5e33-1609-4935-a618-7cc4f039de81"), "Explainer Videos", "Video & Animation", "Live Action Explainers", "Created" },
                    { new Guid("596ea0e9-ac4c-4cb4-89d8-ea0fac5a02bc"), "Data Collection", "Data", "Data Typing", "Created" },
                    { new Guid("59904414-7a7b-4d52-a201-c2d1c6a76eaf"), "Sales & Customer Care", "Business", "Customer Care", "Created" },
                    { new Guid("59d24636-d2c7-4d77-8b81-baaacff1f0de"), "Product & Gaming", "Graphics & Design", "Industrial & Product Design", "Created" },
                    { new Guid("59fbc873-45fa-44a5-9dae-ed524ac80571"), "Miscellaneous", "Business", "Other", "Created" },
                    { new Guid("5ab9af20-8910-488e-ae39-a4546aad4fec"), "Tech Consulting", "Consulting", "Game Development Consulting", "Created" },
                    { new Guid("5b177e83-bea6-4817-ab68-4dc5cf338e50"), "DJing", "Music & Audio", "DJ Mixing", "Created" },
                    { new Guid("5c45985b-1ec3-4510-a40f-7fb49ec2b1ee"), "Sound Design", "Music & Audio", "Audio Logo & Sonic Branding", "Created" },
                    { new Guid("5dc82be2-85c1-4f8d-a335-ec790aafc6e7"), "Product & Gaming", "Graphics & Design", "Graphics for Streamers", "Created" },
                    { new Guid("5ffae64f-a55d-42cd-abd8-d987e986c2a9"), "Methods & Techniques ", "Digital Marketing", "Video Marketing", "Created" },
                    { new Guid("601c6acb-2dff-4c95-9d60-44fa298dc2d5"), "AI Video", "AI Services", "AI Video Art", "Created" },
                    { new Guid("60cd1abe-8e0b-4eae-864f-f8ce17f1d03f"), "Business & Marketing Copy", "Writing & Translation", "Press Releases", "Created" },
                    { new Guid("61847a69-2279-4596-9fa9-f2d7a87ba04a"), "AI Mobile Development", "AI Services", "AI Integrations", "Created" },
                    { new Guid("61e60e7a-8e21-4350-8c1a-a4eb7822929e"), "Tech Consulting", "Consulting", "Software Development Consulting", "Created" },
                    { new Guid("6247017c-a6e7-4a0a-912b-7f5ee6603d44"), "Accounting Services", "Finance", "Financial Reporting", "Created" },
                    { new Guid("63222ea1-30ac-4efd-8963-1def6b688102"), "Self Improvement", "Personal Growth", "Career Counseling", "Created" },
                    { new Guid("6375587d-072b-409d-8df5-c7ac92ba52ac"), "Packaging & Covers", "Graphics & Design", "Album Cover Design", "Created" },
                    { new Guid("643925b5-57d8-466e-8e91-055a2dd07e99"), "AI Artists", "AI Services", "AI Image Editing", "Created" },
                    { new Guid("645bdd86-bf4f-4f77-a754-e7c7081a40eb"), "Data Consulting", "Consulting", "Data Visualization Consulting", "Created" },
                    { new Guid("649b7331-e885-4b81-a0f0-77003cd3668a"), "Mobile App Development", "Programming & Tech", "iOS App Development", "Created" },
                    { new Guid("64d000f7-840c-4df5-b92d-7bd4a713b2be"), "Visual Design", "Graphics & Design", "Infographic Design", "Created" },
                    { new Guid("665866ab-f106-4871-a26e-b7ac323dff97"), "Local Photography", "Photography", "All Cities", "Created" },
                    { new Guid("66c13446-d35f-452f-a337-577160a07150"), "Web & App Design", "Graphics & Design", "Landing Page Design", "Created" },
                    { new Guid("66d303b5-eeb0-4999-85b8-f66a0777ee87"), " Book & eBook Publishing", "Writing & Translation", "Book & eBook Writing", "Created" },
                    { new Guid("674becc0-3b48-44ca-9ce4-71867ec29410"), "Business & Marketing Copy", "Writing & Translation", "Business Names & Slogans", "Created" },
                    { new Guid("676009a2-bffb-493a-b021-d1469e7cdb43"), "Visual Design", "Graphics & Design", "AI Image Editing", "Created" },
                    { new Guid("67b36435-c66b-473c-aaff-4e8cc2eb0922"), "Data & Business Intelligence ", "Business", "Data Scraping", "Created" },
                    { new Guid("6a76a474-2714-4592-810d-86fe2ec56bdd"), "Mentorship", "Consulting", "Music Mentorship", "Created" },
                    { new Guid("6b9349c7-27e1-4cd7-b6d6-6a79c25cb848"), "Product Videos ", "Video & Animation", "E-Commerce Product Videos", "Created" },
                    { new Guid("6be7a643-9a18-4c8c-a807-3f66d963ae85"), "Music Production & Writing", "Music & Audio", "Jingles & Intros", "Created" },
                    { new Guid("6c662d99-c9ae-416a-9f67-8c52b1696af2"), "Print Design", "Graphics & Design", "Flyer Design", "Created" },
                    { new Guid("6d152a08-9ef6-4c79-8e93-3d47e44dbece"), "Marketing Strategy", "Consulting", "SEM Strategy", "Created" },
                    { new Guid("6f30cd61-2400-41f6-9685-0e4be2bacdac"), "Operations & Management", "Business", "Software Management", "Created" },
                    { new Guid("6f35e7f1-166e-4920-b50e-2690f8db29db"), "3D Design", "Graphics & Design", "3D Industrial Design", "Created" },
                    { new Guid("6fc7d372-c6da-47dc-9f78-a7063dd48b62"), "Cloud & Cybersecurity ", "Programming & Tech", "Cloud Computing", "Created" },
                    { new Guid("70157ee4-063a-4431-a67b-a32ebfcc32f4"), "Financial Planning & Analysis", "Finance", "Budgeting and Forecasting", "Created" },
                    { new Guid("70df3318-e06f-4683-b991-153b0fd2ffce"), "Analytics & Strategy", "Digital Marketing", "Web Analytics", "Created" },
                    { new Guid("70f1d901-b9e9-47f7-be63-541400e8a834"), "Data Analysis & Visualization", "Data", "Data Visualization", "Created" },
                    { new Guid("710dc723-05b1-4f37-a86b-c06172a22ba0"), "Miscellaneous", "Writing & Translation", "Technical Writing", "Created" },
                    { new Guid("71a40252-d722-49f9-8c0d-4976e2f5e3ee"), "Business Formation & Consulting", "Business", "AI Consulting ", "Created" },
                    { new Guid("74e244c4-ff96-45da-ad9b-3c02a4ec032e"), "Miscellaneous", "Video & Animation", "Book Trailers", "Created" },
                    { new Guid("754bf1ef-72f8-436a-9957-0fdae1de4032"), "DJing", "Music & Audio", "DJ Drops & Tags", "Created" },
                    { new Guid("75703f8a-9899-41e6-bb6e-d4b5d3c39dd2"), "Operations & Management", "Business", "Supply Chain Management", "Created" },
                    { new Guid("75cd0b76-ea09-4aff-96e9-86312fbce14a"), "Miscellaneous", "Video & Animation", "Game Recordings & Guides", "Created" },
                    { new Guid("76cad3de-e579-4e9d-9d9f-9197a4b285aa"), "3D Design", "Graphics & Design", "3D Jewelry Design", "Created" },
                    { new Guid("76f9f7d5-4758-4601-b0f4-c9233f00055a"), "Fashion & Style", "Personal Growth", "Modeling & Acting", "Created" },
                    { new Guid("7704105c-8f0e-411c-8d4b-aa504d56d22b"), " Book & eBook Publishing", "Writing & Translation", "Book Editing", "Created" },
                    { new Guid("77b065dc-e122-4044-babc-19cb6d28cccc"), "Product & Gaming", "Graphics & Design", "Character Modeling", "Created" },
                    { new Guid("77f66827-61c3-4a66-8aac-b37d54a909c4"), "Financial Planning & Analysis", "Finance", "Financial Modeling", "Created" },
                    { new Guid("7909db4b-464e-4853-85c5-bf99701b8730"), "Products & Lifestyle", "Photography", "Food Photographers", "Created" },
                    { new Guid("794a3908-baee-4ae6-a0d9-57b99503c6f5"), "Industry & Purpose-Specific", "Digital Marketing", "Mobile App Marketing", "Created" },
                    { new Guid("79a3408b-6963-4bf0-82c3-94dbf46e7a69"), "AI for Businesses", "AI Services", "AI Lessons", "Created" },
                    { new Guid("79ae8334-34de-46e0-bd17-d7b2bafe62bf"), "Financial Planning & Analysis", "Finance", "Cost Analysis", "Created" },
                    { new Guid("7a1e6e67-741a-434b-abc9-00f56b300ce8"), "Social", "Digital Marketing", "Community Management", "Created" },
                    { new Guid("7a255621-fd0c-477a-bda6-08d5560e96b3"), "Wellness & Fitness", "Personal Growth", "Fitness", "Created" },
                    { new Guid("7aad53f0-96dd-466b-bdbb-c85d77f02949"), "3D Design", "Graphics & Design", "3D Game Art", "Created" },
                    { new Guid("7acb9f1f-e609-4120-9b3d-f26b7e45fbb7"), "Products & Lifestyle", "Photography", "Lifestyle & Fashion Photographers", "Created" },
                    { new Guid("7b1a98c7-fad2-4cb4-b96e-332bc6763f3a"), "Search", "Digital Marketing", "Search Engine Marketing (SEM)", "Created" },
                    { new Guid("7b4ac588-73ab-4cb7-a68d-c7d7107ea6fa"), "Visual Design", "Graphics & Design", "Resume Design", "Created" },
                    { new Guid("7cda0e19-f350-424f-8e12-499cd522f177"), "Voice Over & Narration", "Music & Audio", "Female Voice Over", "Created" },
                    { new Guid("7d3f3c93-742f-453b-9829-b2dd69ca9259"), "Analytics & Strategy", "Digital Marketing", "Conversion Rate Optimization (CRO)", "Created" },
                    { new Guid("7d5dde11-71b8-4629-94cf-e34512c9a846"), "Marketing Strategy", "Consulting", "Content Strategy", "Created" },
                    { new Guid("7de53aea-3c30-446a-b5eb-212af0dc9d45"), "Social & Marketing Videos", "Video & Animation", "Music Videos", "Created" },
                    { new Guid("7e0a97b7-2de0-43ce-bda3-69a28b6045b1"), "Mobile App Development", "Programming & Tech", "Mobile App Maintenance", "Created" },
                    { new Guid("7e72e0f3-0757-45b4-bd2a-6f3b0eec0401"), "Coaching & Advice", "Consulting", "Styling & Beauty Advice", "Created" },
                    { new Guid("7eb64fac-fb32-4696-8d7a-641697fd35ed"), "Coaching & Advice", "Consulting", "Nutrition Coaching", "Created" },
                    { new Guid("7f2a592e-fdd5-4a97-a866-003b335dcfe1"), "People & Scenes", "Photography", "Portrait Photographers", "Created" },
                    { new Guid("7f8431ce-b956-4a72-91f3-5ef564eabfda"), "Search", "Digital Marketing", "E-Commerce SEO", "Created" },
                    { new Guid("8058866f-5ec1-4898-b1ac-d4af5b220db6"), "Editing & Post-Production", "Video & Animation", "Subtitles & Captions", "Created" },
                    { new Guid("8078f7f8-8d61-4454-9d66-03f7ad1f8896"), "AI Video ", "Video & Animation", "AI Video Art", "Created" },
                    { new Guid("80ba1630-2e91-4a56-80e1-99c65cdea26c"), "Music Production & Writing", "Music & Audio", "Session Musicians", "Created" },
                    { new Guid("815264a3-fee4-4a12-afeb-5ff6eee31c9c"), "Print Design", "Graphics & Design", "Menu Design", "Created" },
                    { new Guid("819383c1-0213-4e41-909b-ff023e00035c"), "Chatbot Development", "Programming & Tech", "AI Chatbot", "Created" },
                    { new Guid("8197e64d-b722-4a0c-be22-6ce2f1845628"), "Streaming & Audio", "Music & Audio", "Voice Synthesis & AI", "Created" },
                    { new Guid("823569f1-7472-4596-9432-0d650262c42e"), "Blockchain & Cryptocurrency", "Programming & Tech", "Exchange Platforms", "Created" },
                    { new Guid("823a42f6-ca69-406f-b62b-089432e7d806"), "Products & Lifestyle", "Photography", "Product Photographers", "Created" },
                    { new Guid("82957d11-8039-4f53-9e23-58eadb487ad9"), "Marketing Design", "Graphics & Design", "Signage Design", "Created" },
                    { new Guid("82e102c7-bdb3-44c1-89ca-c84618a29b4b"), "Methods & Techniques ", "Digital Marketing", "Text Message Marketing", "Created" },
                    { new Guid("838df422-103c-4f03-8478-44d76402c04a"), "Voice Over & Narration", "Music & Audio", "Male Voice Over", "Created" },
                    { new Guid("83cd5acd-97d8-4348-b0b3-a84899ff2f91"), "Coaching & Advice", "Consulting", "Game Coaching", "Created" },
                    { new Guid("8460f98a-2dd9-409d-9219-6241aaa859a4"), "Translation & Transcription", "Writing & Translation", "Interpretation", "Created" },
                    { new Guid("84bd05ff-6be4-4249-9454-4de7e1ecf76f"), "Coaching & Advice", "Consulting", "Career Counseling", "Created" },
                    { new Guid("84f8e95a-7e6c-4b16-b0cb-546739e36a7f"), "Industry Specific Content", "Writing & Translation", "Internet & Technology ", "Created" },
                    { new Guid("84fd0e36-dfd2-40b1-bc57-d186e8fa6d3c"), "Tax Consulting", "Finance", "Tax Compliance", "Created" },
                    { new Guid("85390142-6cfd-4971-a1c0-2898372f0490"), "Gaming", "Personal Growth", "Game Coaching", "Created" },
                    { new Guid("85826c48-105b-410f-ab55-5a162729d143"), "Music Production & Writing", "Music & Audio", "Composers", "Created" },
                    { new Guid("85997e58-8395-4b7f-b93d-52f7d51cad18"), "Mobile App Development", "Programming & Tech", "Cross-platform Development", "Created" },
                    { new Guid("85fb03ea-e0d6-4bbb-9f69-63a6fa4ff9da"), "Data", "AI Services", "Data Visualization", "Created" },
                    { new Guid("860aa029-c976-4c36-8287-ee4f0cafb166"), "Data Science & ML", "Data", "Time Series Analysis", "Created" },
                    { new Guid("886254ac-0e58-4c66-82ec-9254bb99c660"), "Fashion & Merchandise", "Graphics & Design", "Jewelry Design", "Created" },
                    { new Guid("8a10ffa0-e677-4715-8f63-345aff6d0124"), "Mentorship", "Consulting", "Design Mentorship", "Created" },
                    { new Guid("8a9fd50d-c651-417c-9835-5787e49dab8c"), "Channel Specific ", "Digital Marketing", "Instagram Marketing", "Created" },
                    { new Guid("8b222dd7-e9d6-4bb6-8231-d4b27850f4a8"), "Sound Design", "Music & Audio", "Meditation Music", "Created" },
                    { new Guid("8c01cca1-928f-4c1f-9a66-17ef963877f0"), "Miscellaneous", "Digital Marketing", "Other", "Created" },
                    { new Guid("8c7f5e92-c00f-4ac5-bfca-3a573ac4802d"), "Business Consultants", "Consulting", "Legal Consulting", "Created" },
                    { new Guid("8cb35ae8-9f01-43d6-ac0c-41b48d458202"), "Operations & Management", "Business", "Event Management", "Created" },
                    { new Guid("8dd14f38-ab73-4219-b1a8-f86ef9433c64"), "Search", "Digital Marketing", "Search Engine Optimization (SEO)", "Created" },
                    { new Guid("8e85762f-dd44-42aa-af01-d82d24df32de"), "AI Mobile Development", "AI Services", "AI Mobile Apps", "Created" },
                    { new Guid("8faee8ee-f11c-4d3c-8b7e-9fba81e9e2e3"), "Data Collection", "Data", "Data Entry", "Created" },
                    { new Guid("8fb01635-f2a0-4dc0-8a87-1291674ad44b"), "AI Artists", "AI Services", "Midjourney Artists", "Created" },
                    { new Guid("90c1d5b1-4b1c-4e4f-9762-e51888a3f03b"), "Data Science & ML", "Data", "Machine Learning", "Created" },
                    { new Guid("90c45183-4e67-4122-a793-802132c0c714"), "Channel Specific ", "Digital Marketing", "TikTok Shop", "Created" },
                    { new Guid("918e917d-2286-40be-bd42-58a0d84d2bab"), "Software Development", "Programming & Tech", "Desktop Applications", "Created" },
                    { new Guid("91a63324-3c3c-42b8-be17-b511733ddf8b"), "Data Science & ML", "Programming & Tech", "Computer Vision", "Created" },
                    { new Guid("936f0323-75f4-45b4-ad29-e598eb40f149"), "Art & Illustration", "Graphics & Design", "AI Avatar Design", "Created" },
                    { new Guid("952f00ad-0645-4c8d-ae0c-3837585fe27e"), "Packaging & Covers", "Graphics & Design", "Book Covers", "Created" },
                    { new Guid("9605442b-40d2-460d-8817-a5b01a2cc649"), "Methods & Techniques ", "Digital Marketing", "E-Commerce Marketing", "Created" },
                    { new Guid("960a1144-f76f-4231-9eb7-fc552f8c197b"), "Website Development", "Programming & Tech", "E-Commerce Development", "Created" },
                    { new Guid("96d757da-fd58-4c44-aca6-3fad3f50e2f3"), "Miscellaneous", "Programming & Tech", "Support & IT", "Created" },
                    { new Guid("9905c343-b92b-4111-aba9-f64ac00d07be"), "Data Science & ML", "Data", "Generative Models", "Created" },
                    { new Guid("99a4546a-1a0d-4650-a0bb-11b5a8080a66"), "Editing & Post-Production", "Video & Animation", "Video Editing", "Created" },
                    { new Guid("99a539e9-dd41-44b9-94b0-79417f82b3d7"), "Methods & Techniques ", "Digital Marketing", "Affiliate Marketing", "Created" },
                    { new Guid("99a86111-e271-4d57-843d-606ad33c0d38"), "Local Photography", "Photography", "Photographers in Paris", "Created" },
                    { new Guid("9aab9829-4de7-4b6a-855a-91ebb96adcb2"), "Editing & Post-Production", "Video & Animation", "Intro & Outro Videos", "Created" },
                    { new Guid("9aad3568-d5c7-4c7a-beb0-f5fd76f19f09"), "Architecture & Building Design", "Graphics & Design", "Architecture & Interior Design", "Created" },
                    { new Guid("9b3da445-6695-40be-94e8-108f34d2e655"), "Web & App Design", "Graphics & Design", "App Design", "Created" },
                    { new Guid("9b7ae5e5-1c7d-4dd7-a1c3-b9679d4ff2ef"), "Miscellaneous", "Business", "Online Investigations", "Created" },
                    { new Guid("9bad79e0-c9a3-45c5-b821-bef9328364bb"), "People & Scenes", "Photography", "Scenic Photographers", "Created" },
                    { new Guid("9cd6e314-38f4-4c48-9060-39068632fde4"), "Social & Marketing Videos", "Video & Animation", "Video Ads & Commercials ", "Created" },
                    { new Guid("9e75d904-29cb-4f7e-b0ca-7279fc4b0afd"), "Business & Marketing Copy", "Writing & Translation", "White Papers", "Created" },
                    { new Guid("9e9f130a-6c26-41b2-b9fa-c7db26a33927"), "Content Writing", "Writing & Translation", "Content Strategy", "Created" },
                    { new Guid("a039ce51-c81b-4a98-9fb9-9f8a6c5221a6"), "Leisure & Hobbies", "Personal Growth", "Collectibles", "Created" },
                    { new Guid("a09289ea-23c0-4e28-81d4-7f33d346f7f6"), "Explainer Videos", "Video & Animation", "eLearning Video Production", "Created" },
                    { new Guid("a0ba17a1-284c-44fe-a705-9a569ec990a8"), "Voice Over & Narration", "Music & Audio", "German Voice Over", "Created" },
                    { new Guid("a2524e45-4713-4b47-9ffb-7c8f0ab06637"), "AI Mobile Development", "AI Services", "AI Fine-Tuning", "Created" },
                    { new Guid("a33efb21-8d50-4269-ad42-1e1dd92de8f7"), "Art & Illustration", "Graphics & Design", "AI Artists", "Created" },
                    { new Guid("a6205a01-931c-40fc-82a3-5d65058f0b7c"), "Coaching & Advice", "Consulting", "Life Coaching", "Created" },
                    { new Guid("a6ccf085-6f32-4287-b12e-7e4001305630"), "Packaging & Covers", "Graphics & Design", "Packaging & Label Design", "Created" },
                    { new Guid("a6f94b10-5401-4454-9378-6a6eba31c5f4"), "Software Development", "Programming & Tech", "User Testing", "Created" },
                    { new Guid("a7bbe2df-d0de-46c6-886d-f8b1bdc96d32"), "Presenter Videos", "Video & Animation", "UGC Videos ", "Created" },
                    { new Guid("a91942f5-4e78-426a-ace9-4bf89d81446c"), "Miscellaneous", "Personal Growth", "Cosmetics Formulation", "Created" },
                    { new Guid("a93983a7-40e3-4272-b867-f227ff2aff24"), "Data Analysis & Visualization", "Data", "Data Annotation", "Created" },
                    { new Guid("a9437dcf-185f-423f-a750-ae210259018f"), "Data Science & ML", "Programming & Tech", "NLP", "Created" },
                    { new Guid("aa197067-3a70-4746-890d-00ca6a0ff94d"), "Print Design", "Graphics & Design", "Brochure Design", "Created" },
                    { new Guid("aa1daf2d-e7cb-4f5f-b5c0-8dd8c403ac97"), "Databases & Engineering", "Data", "Data Engineering", "Created" },
                    { new Guid("aa596ee1-9c9b-4787-a314-675098644ba7"), "Art & Illustration", "Graphics & Design", "Portraits & Caricatures", "Created" },
                    { new Guid("aaa64d71-9add-4aaa-b1c2-12a284f2d1fa"), "Miscellaneous", "Video & Animation", "Game Trailers", "Created" },
                    { new Guid("aaa6f9e4-6cbe-411c-89c4-b8085b4a8e37"), "Industry Specific Content", "Writing & Translation", "Real Estate", "Created" },
                    { new Guid("ab0c6c20-02e3-4fa7-a225-973d16e14a54"), "Chatbot Development", "Programming & Tech", "Telegram", "Created" },
                    { new Guid("ac92b0c7-9cae-4143-8956-4c95b24dc89b"), "AI Mobile Development", "AI Services", "AI Technology Consulting", "Created" },
                    { new Guid("af803536-6575-46c4-98db-65ef7ccf20a0"), "Social", "Digital Marketing", "Influencer Marketing", "Created" },
                    { new Guid("afe22223-42f7-4019-8feb-a2070d1fed12"), "Data Collection", "Data", "Data Formatting", "Created" },
                    { new Guid("aff084e7-ae0b-4459-85fe-ab685bd55ef5"), "Music Production & Writing", "Music & Audio", "Custom Songs", "Created" },
                    { new Guid("b079c8f8-9b9d-4ee5-80ff-85ac678b5021"), "Visual Design", "Graphics & Design", "Image Editing", "Created" },
                    { new Guid("b141e87d-447d-4025-90f1-166aa380ff50"), "Product Videos ", "Video & Animation", "3D Product Animation", "Created" },
                    { new Guid("b1666ef5-6777-43f3-94f5-343dce8c4ea5"), "Business Consultants", "Consulting", "HR Consulting", "Created" },
                    { new Guid("b1997871-c3c8-4a4d-ae20-23e1f4356bc7"), "Tax Consulting", "Finance", "Tax Returns", "Created" },
                    { new Guid("b2154414-dbe1-4524-ab61-6ff3dcee6f0c"), "Music Production & Writing", "Music & Audio", "Music Producers", "Created" },
                    { new Guid("b307b795-a53d-4f3b-91df-46759d79f774"), "Website Maintenance", "Programming & Tech", "Speed Optimization", "Created" },
                    { new Guid("b5b4b374-deae-4d4e-a37a-88b12746d363"), "Tech Consulting", "Consulting", "AI Technology Consulting", "Created" },
                    { new Guid("b5e20944-c756-4196-a784-eb84b78e4aab"), "Mobile App Development", "Programming & Tech", "VR & AR Development", "Created" },
                    { new Guid("b62d169a-74e3-4b79-84cb-9768093bea85"), "Search", "Digital Marketing", "Video SEO", "Created" },
                    { new Guid("b65bee5d-8051-4bf2-9d48-e1da36abbc67"), "Career Writing", "Writing & Translation", "Cover Letters", "Created" },
                    { new Guid("b7551166-333f-4807-951b-b0b4dcf06c13"), "Industry & Purpose-Specific", "Digital Marketing", "Podcast Marketing", "Created" },
                    { new Guid("b7761d05-fc5b-4ea9-a06b-80d3f0cd328d"), "Analytics & Strategy", "Digital Marketing", "Marketing Concepts & Ideation", "Created" },
                    { new Guid("b7a0e697-a269-457f-9976-16a9c1dcacd9"), "Miscellaneous", "Personal Growth", "Greeting Cards & Videos", "Created" },
                    { new Guid("b7ab15a2-5278-409a-9afb-da66aaff4747"), "AI Artists", "AI Services", "AI Avatar Design", "Created" },
                    { new Guid("b7efea40-ccfc-4654-983d-297bc7645093"), "Corporate Finance", "Finance", "Valuation", "Created" },
                    { new Guid("b86c3c34-2e50-47a4-a4bb-9225906824f5"), "Editing & Post-Production", "Video & Animation", "Video Art", "Created" },
                    { new Guid("b987f7bb-a212-4a22-9b40-682f2d667cb2"), "Coaching & Advice", "Consulting", "Travel Advice", "Created" },
                    { new Guid("b9df99f0-8e22-465e-a8f3-ba3382f11878"), "Legal Services", "Business", "General Legal Advice", "Created" },
                    { new Guid("bb1193c7-e343-4689-80da-9afb1cab26a0"), "Cloud & Cybersecurity ", "Programming & Tech", "Cybersecurity", "Created" },
                    { new Guid("bb7ce477-e73e-4931-bb9c-33ea08f9ed46"), "Content Writing", "Writing & Translation", "Speechwriting", "Created" },
                    { new Guid("bbc6f483-be2b-457d-a1e0-8c1212cef9a7"), "Gaming", "Personal Growth", "Ingame Creation", "Created" },
                    { new Guid("bbe50abc-0932-410a-b6df-35dc4c30cc74"), "Methods & Techniques ", "Digital Marketing", "Display Advertising ", "Created" },
                    { new Guid("bd054c3a-e287-44ed-8727-47a312f65651"), "Data Consulting", "Consulting", "Databases Consulting", "Created" },
                    { new Guid("be3df9ee-67fd-49d8-8ab5-9658725e5b5e"), "Self Improvement", "Personal Growth", "Online Tutoring", "Created" },
                    { new Guid("bfe29ed1-506d-469d-87ca-4ee76c1944f4"), "Website Maintenance", "Programming & Tech", "Bug Fixes", "Created" },
                    { new Guid("c17c10ec-1c20-4caf-bb60-be940893cb3a"), "Business & Marketing Copy", "Writing & Translation", "Email Copy", "Created" },
                    { new Guid("c200fc8b-e937-4ccc-8208-27891cbf50dd"), "Web & App Design", "Graphics & Design", "Icon Design", "Created" },
                    { new Guid("c21c3449-ee00-4342-956f-fe4b85ab7ba5"), "Data Analysis & Visualization", "Data", "Data Analytics", "Created" },
                    { new Guid("c21ea8aa-cbcf-4ae7-b9ba-19242a16ded9"), "Miscellaneous", "Business", "Presentations", "Created" },
                    { new Guid("c2c46fe9-13b7-4346-b74a-5584b285f84d"), "3D Design", "Graphics & Design", "3D Fashion & Garment", "Created" },
                    { new Guid("c300692a-f78a-40eb-93bf-65a1f5e202dc"), "DJing", "Music & Audio", "Remixing", "Created" },
                    { new Guid("c3b16c08-125d-4df9-9051-ddcdaa85c11d"), "Methods & Techniques ", "Digital Marketing", "Email Marketing", "Created" },
                    { new Guid("c4a26703-66a2-4cdf-a34b-b4fad07f5915"), "Self Improvement", "Personal Growth", "Generative AI Lessons", "Created" },
                    { new Guid("c4b7e2f5-5dfd-483b-b2ce-df32065bd5c9"), "Architecture & Building Design", "Graphics & Design", "Building Engineering", "Created" },
                    { new Guid("c4eed645-0993-4058-8b38-f05beb2c4f5a"), "Data", "AI Services", "Data Analytics", "Created" },
                    { new Guid("c53d2a9e-9d66-4450-844d-40d684eebe23"), "Sales & Customer Care", "Business", "Lead Generation", "Created" },
                    { new Guid("c56a5105-7ada-47da-a520-7a669eeb5748"), "AI Mobile Development", "AI Services", "AI Websites & Software", "Created" },
                    { new Guid("c599b10f-27b2-491f-9adb-7107e6f5ef07"), "People & Scenes", "Photography", "Event Photographers", "Created" },
                    { new Guid("c6501f58-d9eb-40a9-8076-34e9b9798ad9"), "Business & Marketing Copy", "Writing & Translation", "Social Media Copywriting", "Created" },
                    { new Guid("c65ef1ee-7faa-49bf-abfa-c60111e48698"), "AI Video ", "Video & Animation", " AI Video Avatars", "Created" },
                    { new Guid("c6fdfe6a-dee0-46a2-b256-c19897017103"), "Channel Specific ", "Digital Marketing", "Google SEM", "Created" },
                    { new Guid("c717c48d-2de2-4e26-b751-7168f7ab2850"), "Career Writing", "Writing & Translation", "Resume Writing", "Created" },
                    { new Guid("c7398d50-6243-4e4e-a027-8bb844454706"), "Business & Marketing Copy", "Writing & Translation", "Ad Copy", "Created" },
                    { new Guid("c77dc732-ed35-4660-821b-312847985ed2"), "Filmed Video Production", "Video & Animation", "Filmed Video Production", "Created" },
                    { new Guid("c7fd3f05-f14c-4c24-837c-bf68d42675b3"), "Business Formation & Consulting", "Business", "Business Formation & Registration", "Created" },
                    { new Guid("c8f0368f-cfc5-4124-b0dd-259c153d9883"), "Legal Services", "Business", "Legal Documents & Contracts", "Created" },
                    { new Guid("c975f189-cd3c-4ca9-a628-1cfd04be6531"), "Marketing Strategy", "Consulting", "Social Media Strategy", "Created" },
                    { new Guid("ca941e1f-42bb-49b8-904f-04724381f089"), "Logo & Brand Identity", "Graphics & Design", "Logo Design", "Created" },
                    { new Guid("cb36188b-7d97-4756-8f7b-4476d3c09000"), "Game Development", "Programming & Tech", "Gameplay Experience & Feedback", "Created" },
                    { new Guid("ccf52ad5-ba12-4292-a87f-712fcd7fa007"), "Marketing Design", "Graphics & Design", "Web Banners", "Created" },
                    { new Guid("ce8cf822-ff0d-4ede-b419-fc27ff200eb4"), "Translation & Transcription", "Writing & Translation", "Translation", "Created" },
                    { new Guid("cee04ce0-43c7-4c81-917a-acba522dc945"), "Business & Marketing Copy", "Writing & Translation", "Product Descriptions", "Created" },
                    { new Guid("cf696449-46d8-46a6-999c-d5e62850046c"), "Social", "Digital Marketing", "Social Commerce ", "Created" },
                    { new Guid("cf6ab086-f2f4-482f-afdb-f19dfeb6984a"), "Packaging & Covers", "Graphics & Design", "Book Design", "Created" },
                    { new Guid("cf7a5748-0e58-4191-8be4-e048c16b248e"), "Editing & Critique", "Writing & Translation", "Proofreading & Editing", "Created" },
                    { new Guid("cf917283-cb7b-4869-91cc-f1b76505cd52"), "Miscellaneous", "Video & Animation", "Other", "Created" },
                    { new Guid("d03a694f-2461-4ab4-b058-e69bc96d2d42"), "Editing & Post-Production", "Video & Animation", "Visual Effects", "Created" },
                    { new Guid("d24fc3a0-c3cb-4041-a593-eeeedd04fe58"), "Business Consultants", "Consulting", "Business Plans", "Created" },
                    { new Guid("d2e9d8b6-c0bb-429b-a94d-1a28aa5717ba"), "Explainer Videos", "Video & Animation", "Screencasting Videos", "Created" },
                    { new Guid("d350ea00-8ccd-4434-8d94-65a6c894378d"), "Gaming", "Personal Growth", "eSports Management & Strategy", "Created" },
                    { new Guid("d4ff26ba-9f4c-45cb-a5cc-d9c5d0c4ffe1"), "Industry & Purpose-Specific", "Digital Marketing", "Book & eBook Marketing", "Created" },
                    { new Guid("d511ef73-ff7a-4d12-b70d-77947694d4c5"), "Animation", "Video & Animation", "Animation for Kids", "Created" },
                    { new Guid("d75abc51-b6aa-4016-b5e4-713e30a4a366"), "AI for Businesses", "AI Services", "AI Strategy", "Created" },
                    { new Guid("d8a944cd-73a4-4355-8bcc-38e77aca200a"), "Software Development", "Programming & Tech", "Web Applications", "Created" },
                    { new Guid("d8b41296-7d78-4abd-b6a3-16fb0f2b4026"), "Data Science & ML", "Programming & Tech", "Machine Learning", "Created" },
                    { new Guid("d950e916-7f30-46d7-b347-7224fb4d3d8a"), "Logo & Brand Identity", "Graphics & Design", "Brand Style Guides", "Created" },
                    { new Guid("d998b1d0-e467-4156-b258-8fd56d3c0dd3"), "Data Science & ML", "Data", "Computer Vision", "Created" },
                    { new Guid("d9f1e7b0-6666-47a6-8505-27140e3f3668"), "Presenter Videos", "Video & Animation", "Spokesperson Videos", "Created" },
                    { new Guid("da0933ef-a3ef-472d-92c0-73b8bb074f12"), "Website Development", "Programming & Tech", "Landing Pages", "Created" },
                    { new Guid("da65032f-2e18-4195-a9de-93b371fd80a5"), "Game Development", "Programming & Tech", "PC Games", "Created" },
                    { new Guid("db24cd46-8b50-4afa-a90a-6176aa312ceb"), "Data & Business Intelligence ", "Business", "Data Analytics", "Created" },
                    { new Guid("db55cb96-2162-4b07-b6d6-a74492380c1e"), "Mobile App Development", "Programming & Tech", "Website to App", "Created" },
                    { new Guid("db703ff0-9b43-4cef-9478-eeafdb23f561"), "Analytics & Strategy", "Digital Marketing", "Marketing Advice", "Created" },
                    { new Guid("db8e4c38-c086-468d-9b63-4625096b6a94"), "Streaming & Audio", "Music & Audio", "Audio Ads Production", "Created" },
                    { new Guid("db8ed1e6-6fb2-493a-ba16-9670f7020ce3"), "Data Science & ML", "Data", "NLP", "Created" },
                    { new Guid("dc79a461-6b9a-4b44-b820-65607a65b04c"), "AI Content", "AI Services", "Custom Writing Prompts", "Created" },
                    { new Guid("dc9f9e5e-1f2c-4aca-8fdb-c2be6bd12973"), "Software Development", "Programming & Tech", "Automations & Workflows", "Created" },
                    { new Guid("dca0dbfe-35e7-4251-be3c-860317de1291"), "3D Design", "Graphics & Design", "3D Printing Characters", "Created" },
                    { new Guid("dcd49d83-5a0c-41ca-8df6-12c51e597567"), "AI Artists", "AI Services", "ComfyUI Workflow Creation", "Created" },
                    { new Guid("dcf34e45-ed1b-42bc-9e5f-6781a39c6be1"), "Website Maintenance", "Programming & Tech", "Website Customization", "Created" },
                    { new Guid("dd6486f9-9a07-48c8-a2ba-65ffe8a86536"), "Lessons & Transcriptions", "Music & Audio", "Music & Audio Advice", "Created" },
                    { new Guid("dd85bf20-b004-455b-b1ed-4ac53f9e84b8"), "Chatbot Development", "Programming & Tech", "Rules Based Chatbot", "Created" },
                    { new Guid("dda5e931-d680-47ea-a90f-b0006dea0ea3"), "Explainer Videos", "Video & Animation", "Animated Explainers", "Created" },
                    { new Guid("ddd81f9a-50b9-4b9e-b996-1d923e7f650d"), "Animation", "Video & Animation", "Animation for Streamers", "Created" },
                    { new Guid("de70545a-6843-43eb-ae95-c1650532020f"), "Methods & Techniques ", "Digital Marketing", "Public Relations", "Created" },
                    { new Guid("de782c28-eaff-4ce0-b36b-0b5a0496a356"), "Architecture & Building Design", "Graphics & Design", "Lighting Design", "Created" },
                    { new Guid("e06ad3b6-6ee3-479a-9a36-cfda176b7fbc"), "Chatbot Development", "Programming & Tech", "Discord", "Created" },
                    { new Guid("e08513cc-de0b-49db-87ab-17975bed6b90"), "Mentorship", "Consulting", "Writing Mentorship", "Created" },
                    { new Guid("e0e748b9-f14a-4d70-ace2-7ac6a0332823"), "Operations & Management", "Business", "E-Commerce Management ", "Created" },
                    { new Guid("e2956197-fdd9-4660-9cd1-35bc72f35bb6"), "Accounting Services", "Finance", "Payroll Management", "Created" },
                    { new Guid("e2a0ae76-bcb1-43c0-ab3c-8ad6f2361efe"), "Sales & Customer Care", "Business", "Call Center & Calling ", "Created" },
                    { new Guid("e2d30c7a-c2aa-48cb-8322-1404bee471e3"), "Presenter Videos", "Video & Animation", "TikTok UGC Videos", "Created" },
                    { new Guid("e36357df-0f0c-4019-98c0-78ef5f1ee104"), "Animation", "Video & Animation", "Animated GIFs", "Created" },
                    { new Guid("e3b6ae63-bdbd-4585-bff4-fe46eace2272"), "Accounting Services", "Finance", "Bookkeeping", "Created" },
                    { new Guid("e424e216-47e2-411f-a549-d936948d203b"), "Art & Illustration", "Graphics & Design", "Tattoo Design", "Created" },
                    { new Guid("e555cacc-943a-477d-ae67-997d090f6cf1"), "Translation & Transcription", "Writing & Translation", "Transcription", "Created" },
                    { new Guid("e56c85be-0e4d-44cb-825e-570b1e781399"), "Tech Consulting", "Consulting", "Mobile App Consulting", "Created" },
                    { new Guid("e5a977d6-a867-4534-89ec-709ba16af806"), "Content Writing", "Writing & Translation", "Scriptwriting", "Created" },
                    { new Guid("e5b02496-e520-4955-82d4-44668677a945"), "AI Video", "AI Services", "AI Music Videos", "Created" },
                    { new Guid("e5f8378f-5c0d-48c2-97f0-1049c114ac16"), "Career Writing", "Writing & Translation", "LinkedIn Profiles", "Created" },
                    { new Guid("e69da258-9b75-4bae-b4f0-19ef89ed1d3a"), "Miscellaneous", "Writing & Translation", "eLearning Content Development", "Created" },
                    { new Guid("e6c75811-d78e-48db-9e27-705c355d427d"), "Self Improvement", "Personal Growth", "Life Coaching", "Created" },
                    { new Guid("e74f0092-f2ff-451a-a367-a1305e2e1b5b"), "Visual Design", "Graphics & Design", "Background Removal", "Created" },
                    { new Guid("e790d4f6-dd6d-413f-a3d8-2742d04d4f4b"), "Voice Over & Narration", "Music & Audio", "24hr Turnaround", "Created" },
                    { new Guid("e7a8b8ba-a904-4cd0-8d25-500036cac66d"), "Art & Illustration", "Graphics & Design", "Pattern Design", "Created" },
                    { new Guid("e95f89fd-352f-4d04-9387-a7820afeebc7"), "Miscellaneous", "Video & Animation", "Video Advice", "Created" },
                    { new Guid("e9a6b991-b8d9-41a9-b4d4-afa699ca6ee8"), "Streaming & Audio", "Music & Audio", "Audiobook Production", "Created" },
                    { new Guid("e9bb48c1-d885-435d-8604-0932b53b7a73"), " Book & eBook Publishing", "Writing & Translation", "Beta Reading", "Created" },
                    { new Guid("ea015d6b-cf6f-4e64-a896-f40d496dff60"), "Databases & Engineering", "Data", "Databases", "Created" },
                    { new Guid("ea8b4418-f4d8-482b-a29f-c4743c0506f1"), "Content Writing", "Writing & Translation", "Podcast Writing", "Created" },
                    { new Guid("eab74475-1eef-4053-a3f3-0f6d1dd1a944"), "Business & Marketing Copy", "Writing & Translation", "Brand Voice & Tone", "Created" },
                    { new Guid("eb344ad4-4e73-427e-b968-713146f8c322"), "AI Development", "Programming & Tech", "AI Agents", "Created" },
                    { new Guid("eb64d693-e6bb-4050-91dc-ff66def58318"), "People & Scenes", "Photography", "Real Estate Photographers", "Created" },
                    { new Guid("eb6d95e5-6d6b-4f43-bb0a-201d0f800edc"), "Tax Consulting", "Finance", "Tax Identification Services", "Created" },
                    { new Guid("ec04b5c1-46d7-454d-9665-20cdc8e452b4"), "Business & Marketing Copy", "Writing & Translation", "Sales Copy", "Created" },
                    { new Guid("ec77acbf-146a-4bb0-993c-607e123aa034"), "Industry Specific Content", "Writing & Translation", "News & Politics", "Created" },
                    { new Guid("ec9d55c9-d12e-4ebc-8cc2-1a5aa5b1313b"), "Local Photography", "Photography", "Photographers in Los Angeles", "Created" },
                    { new Guid("eca7c4fa-3b42-455a-a060-b86f912b12bc"), "Sound Design", "Music & Audio", "Sound Design", "Created" },
                    { new Guid("ed6b71fb-440b-4085-a7e8-c948cd929c48"), "Accounting Services", "Finance", "Fractional CFO Services", "Created" },
                    { new Guid("ed6c3a52-97b3-4b02-bb9e-764f26d96855"), "AI Audio", "AI Services", "Voice Synthesis & AI", "Created" },
                    { new Guid("eebe9be6-caef-4159-9bd9-48e03eec98a4"), "Art & Illustration", "Graphics & Design", "NFT Art", "Created" },
                    { new Guid("ef0d0afa-abd5-489f-b1d6-dbc2e8b1c2a9"), "Leisure & Hobbies", "Personal Growth", "Arts & Crafts", "Created" },
                    { new Guid("ef4ae6f8-1664-4a41-acb0-d01ba7b7c7c3"), "Miscellaneous", "Programming & Tech", "Discord Server Setup", "Created" },
                    { new Guid("f008526f-2377-4ea4-86ab-cb2ec8d2301d"), "Mentorship", "Consulting", "Video Mentorship", "Created" },
                    { new Guid("f12f15fc-3538-40eb-b9fc-4696f83c0d2c"), "Website Maintenance", "Programming & Tech", "Backup & Migration", "Created" },
                    { new Guid("f133157b-6fed-4a08-a2e5-b69f18cc3a49"), "Miscellaneous", "Video & Animation", "Real Estate Promos", "Created" },
                    { new Guid("f195205a-943e-43af-957c-9d75f8e3ec21"), "Website Development", "Programming & Tech", "Business Websites", "Created" },
                    { new Guid("f231bbc4-7fdd-451f-8d6f-5e8d87372774"), "Sales & Customer Care", "Business", "Sales", "Created" },
                    { new Guid("f2325ce9-b55b-43b7-9170-d4d2fe2f0b49"), "Print Design", "Graphics & Design", "Catalog Design", "Created" },
                    { new Guid("f2caabc3-4e0e-486a-934f-69e8901262aa"), "Editing & Post-Production", "Video & Animation", "Video Templates Editing", "Created" },
                    { new Guid("f3f8ed31-60c6-406d-b579-06759fdec865"), "Industry Specific Content", "Writing & Translation", "Marketing", "Created" },
                    { new Guid("f4ed17d3-e9c2-46e6-8396-15434783461e"), "Business Formation & Consulting", "Business", "Market Research", "Created" },
                    { new Guid("f4f06a78-07b3-4566-9adf-b740e250d01a"), "Miscellaneous", "Business", "Game Concept Design", "Created" },
                    { new Guid("f51bffd1-a441-4ab8-8eab-2b09d4e53431"), "Miscellaneous", "Video & Animation", "Article to Video", "Created" },
                    { new Guid("f56bbd17-d76a-4cc0-b394-d7a3908d46ed"), "Tech Consulting", "Consulting", "Website Consulting", "Created" },
                    { new Guid("f5a86113-7eef-4763-8643-0c3ec6f63e82"), "AI Artists", "AI Services", "All AI Art Services", "Created" },
                    { new Guid("f5ff355c-11a3-4038-a2fb-a42d00cfe785"), "Product & Gaming", "Graphics & Design", "Game Art", "Created" },
                    { new Guid("f728cbb5-443a-4879-ad40-a6ee339bd8eb"), "Miscellaneous", "Digital Marketing", "Crowdfunding", "Created" },
                    { new Guid("f7f77b10-5899-4673-87ee-d4e2e6a8c35e"), "AI Mobile Development", "AI Services", "AI Chatbot", "Created" },
                    { new Guid("f8388530-012a-4dd5-af62-f9d549882c4e"), "Financial Planning & Analysis", "Finance", "Stock Analysis", "Created" },
                    { new Guid("f8d76c8c-a44d-4f59-bd91-faa27bb030dd"), "Mentorship", "Consulting", "Marketing Mentorship", "Created" },
                    { new Guid("f96eebba-e666-47a2-a743-5e42df2bf81c"), "Operations & Management", "Business", "Virtual Assistant", "Created" },
                    { new Guid("f9f15791-410f-4d50-998e-9172a4fe1cff"), "Leisure & Hobbies", "Personal Growth", "Cosplay Creation", "Created" },
                    { new Guid("fa7ea483-3719-4495-91f0-b0c654d0e109"), "Leisure & Hobbies", "Personal Growth", "Puzzle & Game Creation", "Created" },
                    { new Guid("fbff3d4a-f6df-4c56-a330-a58dd1438797"), "Marketing Design", "Graphics & Design", "Social Media Design", "Created" },
                    { new Guid("fc0f74b9-e1af-4629-a210-d586410bc210"), "Local Photography", "Photography", "Photographers in New York", "Created" },
                    { new Guid("fcd6239e-8aaa-4c09-bc2b-ecd97be9a73f"), "AI Mobile Development", "AI Services", "AI Agents", "Created" },
                    { new Guid("fd17afc5-fab9-4482-9955-32d4a483f273"), "Marketing Design", "Graphics & Design", "Social Posts & Banners", "Created" },
                    { new Guid("fe0b099c-3708-413b-91ae-b07582300202"), "Fundraising", "Finance", "Fundraising Consultation", "Created" },
                    { new Guid("fe81d252-cff2-4fcb-83aa-e94c0813475f"), "Content Writing", "Writing & Translation", "Articles & Blog Posts", "Created" },
                    { new Guid("ffc02940-836b-4c81-975b-14c166143b02"), "Gaming", "Personal Growth", "Gameplay Experience & Feedback", "Created" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("021bd58e-fa13-492a-b978-95aaa9b00ddd"), "Somali", "Created" },
                    { new Guid("060692a5-c753-4135-8682-173afd55e512"), "Cebuano", "Created" },
                    { new Guid("0b7a2e40-b0d4-4247-96a3-f256d99ffa84"), "Bengali", "Created" },
                    { new Guid("0cef6d02-45aa-49af-b64f-c4bf7ab8380d"), "Latin", "Created" },
                    { new Guid("12b38b95-1f6f-4954-9c51-9d2b26237651"), "Danish", "Created" },
                    { new Guid("15d64e6e-1ae9-45d0-be89-7f0cd57a04db"), "French", "Created" },
                    { new Guid("1854ca96-d48a-4401-9612-74093c749afe"), "Kannada", "Created" },
                    { new Guid("18edfc8d-b8a2-484d-b899-9879826b8ce9"), "Malagasy", "Created" },
                    { new Guid("19417cdc-aae7-475a-8a09-2889aebb931a"), "Malay", "Created" },
                    { new Guid("19aa791a-dcda-498f-9ebe-7c90e821bcd6"), "Xhosa", "Created" },
                    { new Guid("2060fc23-016f-48d7-b860-0ce7c053b7fd"), "Georgian", "Created" },
                    { new Guid("220dbd86-f4d1-4c29-a7a2-3fe55a751f77"), "Polish", "Created" },
                    { new Guid("29ebfee7-7a74-419f-ad72-19d2ea2cd769"), "Luxembourgish", "Created" },
                    { new Guid("2c7e4900-d02d-4f95-9f7d-3f3a5e1d98c9"), "Tamil", "Created" },
                    { new Guid("2da90834-06a3-4dea-8b6a-1bc399ba9583"), "Vietnamese", "Created" },
                    { new Guid("3042a821-e792-4d57-8ce4-50b28b7d95eb"), "Sesotho", "Created" },
                    { new Guid("30659c02-f07c-4a17-aa7c-9c4f04c7a113"), "Urdu", "Created" },
                    { new Guid("3744a3f3-185a-4b44-8094-e884024dd897"), "Sindhi", "Created" },
                    { new Guid("3f5dd107-212f-42dc-a520-83167ac8e64b"), "Esperanto", "Created" },
                    { new Guid("40f7d215-6582-4e1f-b7f6-b1980e3cc6f6"), "Serbian", "Created" },
                    { new Guid("42d30c67-5a79-4e4c-8153-07a2375bdf8e"), "Korean", "Created" },
                    { new Guid("42f0772e-148c-4c60-bf8b-b27279859790"), "Slovenian", "Created" },
                    { new Guid("43e1cdd8-f633-461f-b043-ab2bf6630986"), "Indonesian", "Created" },
                    { new Guid("4467f2a9-09b4-4cc0-8d32-e0951bf3a055"), "Dutch", "Created" },
                    { new Guid("45e9248f-4202-4634-8f1c-fa72c7db5b94"), "Hungarian", "Created" },
                    { new Guid("496bce00-c47e-4eda-9f3b-0f0c1d3be4d8"), "Kazakh", "Created" },
                    { new Guid("4ab93634-d1e2-44ff-b968-b4c323fb6fa1"), "Yiddish", "Created" },
                    { new Guid("4b3b4f84-350d-4fa4-8577-45138d377ece"), "Igbo", "Created" },
                    { new Guid("4d289246-b425-4417-89f8-732d40fc922e"), "Latvian", "Created" },
                    { new Guid("51f7f32d-3053-493c-8e19-dce264233092"), "Swedish", "Created" },
                    { new Guid("538042d7-a180-4288-be17-4df68f4d2fcb"), "Maltese", "Created" },
                    { new Guid("55973c3a-f028-481b-9739-d4d30fca3731"), "Estonian", "Created" },
                    { new Guid("5ba4f8c6-08c5-4bdb-a0de-e838b142eba9"), "Croatian", "Created" },
                    { new Guid("5fb6c0ef-35a1-4787-a554-f57bfd1c8242"), "Japanese", "Created" },
                    { new Guid("600f624f-28e2-443c-833b-82fcd079e82a"), "Sinhala", "Created" },
                    { new Guid("6016a742-9232-4ac0-9a26-769ac3c189d4"), "Turkish", "Created" },
                    { new Guid("60fa8ef1-37da-48d0-9dbb-c515a6fe5681"), "Russian", "Created" },
                    { new Guid("612940ea-d06f-4cc7-ae50-b14d92cf8a62"), "Azerbaijani", "Created" },
                    { new Guid("61ebe6a6-908d-4d6d-a572-2a274ec6407c"), "Hawaiian", "Created" },
                    { new Guid("64089e10-76b0-4acd-a8af-58d03a5c60b9"), "Persian", "Created" },
                    { new Guid("6977ca03-ec63-4cdb-badc-34a3aab6a1ce"), "English", "Created" },
                    { new Guid("6d9a6c74-2853-4072-8c97-e5ef7028a614"), "Filipino", "Created" },
                    { new Guid("6ec2e85b-be23-4e19-b0a7-dca35427f49f"), "Albanian", "Created" },
                    { new Guid("71901fb6-37ae-4973-bd36-4d63c7e12824"), "Gujarati", "Created" },
                    { new Guid("75408682-c801-46d7-a8c4-9e7810e15f21"), "Spanish", "Created" },
                    { new Guid("767c864a-b165-4b5f-937d-0e595dbc9b9d"), "Kurdish", "Created" },
                    { new Guid("7ae01f90-eb40-420c-80e0-a15e6938244e"), "Finnish", "Created" },
                    { new Guid("7b2ff27f-cf37-4b68-8115-1589174692af"), "Hindi", "Created" },
                    { new Guid("7c087b6f-7030-4e41-a7d9-40cb4a24a606"), "Malayalam", "Created" },
                    { new Guid("7ca6581f-df17-44bc-b6d9-ed8918c82427"), "Irish", "Created" },
                    { new Guid("7f14b41b-1e03-4208-ab60-0735fe948ae7"), "Tajik", "Created" },
                    { new Guid("816fd3f8-c3e8-451e-bf79-31fbad674197"), "Hebrew", "Created" },
                    { new Guid("82a7207d-f00e-4533-8baa-110476cb4157"), "Shona", "Created" },
                    { new Guid("82f310a4-c9be-4a88-a94a-c42dde844e4b"), "Pashto", "Created" },
                    { new Guid("84c1b674-d223-4c24-89a2-b0e5b9c269c2"), "Romanian", "Created" },
                    { new Guid("8545a7f4-abe0-42d7-a27d-0aadf5e8823c"), "Thai", "Created" },
                    { new Guid("85a2ad1b-171e-4b9f-888f-641905e87f45"), "Maori", "Created" },
                    { new Guid("8610b7c1-45df-4619-8c79-a59f751e25c5"), "Ukrainian", "Created" },
                    { new Guid("92206595-d5fc-48f3-a579-f2b119b58b29"), "Hmong", "Created" },
                    { new Guid("92a6df62-5943-48c8-b6d1-346d3a37c63e"), "Basque", "Created" },
                    { new Guid("937284be-a144-4d41-b7df-d75d39c1a5c9"), "Zulu", "Created" },
                    { new Guid("94eb71f0-bb96-4896-b662-79d486d9893a"), "Uyghur", "Created" },
                    { new Guid("98a999ec-7f72-49b3-9859-b22ebe45f47f"), "Samoan", "Created" },
                    { new Guid("9c26045e-7ffa-4e1f-8315-58cbf4efea24"), "Amharic", "Created" },
                    { new Guid("9e45cac0-35b6-4e4f-8484-08db12f30c00"), "Tatar", "Created" },
                    { new Guid("9f7245c1-475f-4460-b52c-144eb3cdd5d8"), "Sundanese", "Created" },
                    { new Guid("a04108bb-85d2-4350-8fb4-c0cd6279feda"), "German", "Created" },
                    { new Guid("a10ab270-12f5-4365-9e04-625216b17f86"), "Slovak", "Created" },
                    { new Guid("a23b59c1-475c-4f2e-bd52-b4cc382f2396"), "Mongolian", "Created" },
                    { new Guid("a46eb587-1057-4bf0-a007-8e0b7e41c6a2"), "Lao", "Created" },
                    { new Guid("a84200a5-5a24-4d32-b568-6f2038eebeb3"), "Javanese", "Created" },
                    { new Guid("ac4450a0-1721-4cb2-8fbb-684f51b154b9"), "Burmese", "Created" },
                    { new Guid("afb4e066-11de-4b41-8e73-535a685bf39c"), "Macedonian", "Created" },
                    { new Guid("b1a2eea4-bd28-4b08-a5f1-30b9f12e550d"), "Afrikaans", "Created" },
                    { new Guid("b323b021-5aed-420e-a7f0-e63d652e5599"), "Greek", "Created" },
                    { new Guid("b3346c5e-a993-406a-8f47-1ac37a49d427"), "Galician", "Created" },
                    { new Guid("b3367327-3cdc-42c0-8a2e-f952673dc7f5"), "Hausa", "Created" },
                    { new Guid("b61b2c24-0d68-426c-9990-2648d6e6c671"), "Uzbek", "Created" },
                    { new Guid("c0f87989-1c4b-4d6c-a7ab-71cdeb93a637"), "Khmer", "Created" },
                    { new Guid("c40866ea-8bbc-4684-909b-68b2ea8fe30e"), "Welsh", "Created" },
                    { new Guid("c654070b-a513-4202-a486-87d717edeaf1"), "Kinyarwanda", "Created" },
                    { new Guid("c658668e-af51-487b-a3d2-9eb7bbdd35de"), "Norwegian", "Created" },
                    { new Guid("c8227f49-2482-4981-bb6e-db77918262c1"), "Yoruba", "Created" },
                    { new Guid("c8950254-3438-41e2-8219-e38b4b8d153b"), "Arabic", "Created" },
                    { new Guid("c8d80922-3a3b-4898-a387-7d2259148186"), "Marathi", "Created" },
                    { new Guid("c91f0ad8-d149-4e6e-a1ed-02c2c2d06194"), "Haitian Creole", "Created" },
                    { new Guid("ccb842aa-e7de-4de8-a514-64afb180e81a"), "Scots Gaelic", "Created" },
                    { new Guid("cfd114dc-bddb-4201-a566-a2b43ca4109d"), "Armenian", "Created" },
                    { new Guid("d1baf161-95bc-4428-84f0-b158a66dee57"), "Catalan", "Created" },
                    { new Guid("d27b554b-dded-451b-b0af-0cc3bd0b9c82"), "Czech", "Created" },
                    { new Guid("d36cb2fc-b65f-4f71-b595-f88d515a7923"), "Chinese", "Created" },
                    { new Guid("d92b41e1-c7d5-4774-8755-f3ec6c93c4e4"), "Corsican", "Created" },
                    { new Guid("de47bd51-766d-403b-b736-335a2d528ec6"), "Chichewa", "Created" },
                    { new Guid("df6ce9a4-10a5-40ef-ac1e-b6e71338b3d4"), "Bosnian", "Created" },
                    { new Guid("dfaa36d5-e46f-4c71-b51d-6de841dd560a"), "Telugu", "Created" },
                    { new Guid("e45718a9-539e-4834-8ac6-44f5ed5f300f"), "Nepali", "Created" },
                    { new Guid("e5c5fe71-38ec-493c-b1be-dbe12b79b8b1"), "Turkmen", "Created" },
                    { new Guid("ea89becb-f3c3-44d2-a0b6-a346aa1bb863"), "Bulgarian", "Created" },
                    { new Guid("eb4f99e6-fcdd-40ce-8bd3-80724265c4c2"), "Italian", "Created" },
                    { new Guid("eee7a4f6-9795-4603-b151-69343c8160c7"), "Lithuanian", "Created" },
                    { new Guid("f0d43288-5e66-47ab-8cd8-80db1946eaf0"), "Icelandic", "Created" },
                    { new Guid("f5320953-52a7-4717-a14d-ecc1dc08fb5d"), "Punjabi", "Created" },
                    { new Guid("f581dc53-4aa2-4c5e-ae82-9efd78edbcab"), "Swahili", "Created" },
                    { new Guid("f5e77648-533a-4b9e-a721-53314354c1b7"), "Kyrgyz", "Created" },
                    { new Guid("fe8defa4-2a14-4294-a6b6-847d359fec48"), "Belarusian", "Created" },
                    { new Guid("fee520de-a66e-4ad8-bd64-df664c48b30d"), "Portuguese", "Created" }
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
