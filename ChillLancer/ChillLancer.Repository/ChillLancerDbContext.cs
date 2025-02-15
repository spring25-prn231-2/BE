using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChillLancer.Repository
{
    public class ChillLancerDbContext : DbContext
    {
        //Option
        public ChillLancerDbContext() { }
        public ChillLancerDbContext(DbContextOptions<ChillLancerDbContext> options)
        : base(options) { }

        public virtual DbSet<Account> Accounts { get; set; }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())   //Path.Combine(Directory.GetCurrentDirectory(),"ProjectName.Api")
                .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:LocalSQL"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(GetConnectionString());

        //optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=12345;Database=ChillLancer;TrustServerCertificate=True;");
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
        }
    }
}
