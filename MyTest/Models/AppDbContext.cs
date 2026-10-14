using Microsoft.EntityFrameworkCore;

    namespace MyTest.Models
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Students> Student { get; set; }
            public DbSet<School> School { get; set; }
             public DbSet<HomeTeacher> HomeTeacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Students>()
                    .HasOne(s => s.School)
                    .WithMany(sc => sc.Students)
                    .HasForeignKey(s => s.SchoolId);
            }

        }
}

