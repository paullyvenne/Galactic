using Microsoft.EntityFrameworkCore;

namespace AnnouncementAPI.Data
{
    public class AnnoucementsContext : DbContext
    {
        public DbSet<Annoucement> Annoucements { get; set; }

        public AnnoucementsContext(DbContextOptions<AnnoucementsContext> options)
             : base(options)
        {
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = WebApplication.CreateBuilder();
            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Annoucement>(entity =>
            {
                entity.HasIndex(e => e.ID);
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).IsRequired();
            });
        }
    }

}
