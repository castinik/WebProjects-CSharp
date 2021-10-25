using Microsoft.EntityFrameworkCore;
using RistoWeb.Entity;

namespace RistoWeb.Context
{
    public class RistoWebDBContext : DbContext
    {
        public RistoWebDBContext(DbContextOptions<RistoWebDBContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DCB9SVQ\\SQLEXPRESS;Initial Catalog=RistoDB;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Course>().HasNoKey();
            //builder.Entity<User>().HasNoKey();
            //builder.Entity<Reservation>().HasNoKey();
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
