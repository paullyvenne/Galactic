using Microsoft.EntityFrameworkCore;

namespace AnnouncementAPI.Data
{
    public class AnnouncementsContext : DbContext
    {

        private readonly DbContextOptions<AnnouncementsContext> options;

        public DbSet<Announcement> Announcements { get; set; }

        public AnnouncementsContext(DbContextOptions<AnnouncementsContext> options)
             : base(options)
        {
            this.options = options;
            try
            {
                this.Database.Migrate();

            } catch (System.InvalidOperationException ex)
            {
                throw new InvalidDataException("Please check connectionstring in appsettings.json is pointing to a valid database!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasIndex(e => e.ID);
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).IsRequired();
            });
        }
    }

}
