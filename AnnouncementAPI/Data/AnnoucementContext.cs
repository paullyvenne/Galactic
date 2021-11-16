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
            this.Database.Migrate();
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
