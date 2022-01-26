

using LastExamPractise26January2022.Data.Configurations;
using LastExamPractise26January2022.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LastExamPractise26January2022.Data.DAL
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Doctor> doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);
            //builder.ApplyConfiguration(new DoctorConfiguration());  

            base.OnModelCreating(builder);
        }
    }
}