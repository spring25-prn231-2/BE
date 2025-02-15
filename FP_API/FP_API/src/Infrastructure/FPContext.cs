using FP_API.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace FP_API.src.Infrastructure
{
    public class FPContext : DbContext
    {
        public FPContext()
        {
            
        }
        public FPContext(DbContextOptions<FPContext> options) : base(options)
        {
            
        }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public int MyProperty { get; set; }
    }
}
