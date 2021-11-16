using AnnouncementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementAPI
{
    public class AnnouncementStorage
    {
        private static AnnouncementsContext db;

        public static void InitDBContext(DbContextOptions<AnnouncementsContext> options)
        {
            db = new AnnouncementsContext(options);
        }

        public static void InitDBContext(string connString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnnouncementsContext>();
            optionsBuilder.UseSqlServer(connString);

            var options = optionsBuilder.Options;
            db = new AnnouncementsContext(options);
        }

        public static IEnumerable<Announcement> ListAnnouncements(int pageIndex, int pageSize = 0)
        {
            if (pageSize == 0) return db.Announcements.AsEnumerable();
            else return db.Announcements
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }

        public static Announcement? CreateAnnouncement(AnnouncementParams param) //Create
        {
            Announcement announcement = new Announcement().CopyParams(param);
            db.Announcements.Add(announcement);
            db.SaveChanges();
            return announcement;
        }

        public static Announcement? ReadAnnouncement(int id) //Read or Null
        {
            return db.Announcements.SingleOrDefault(x => x.ID == id );
        }
        
        public static Announcement? UpdateAnnouncement(int id, AnnouncementParams param) //Update
        {
            Announcement? announcement = ReadAnnouncement(id);
            if(announcement != null)
            {
                announcement.CopyParams(param);
                db.SaveChanges();
                return announcement;
            }
            return null;
        }

        public static Announcement? DeleteAnnouncement(int id) //Delete
        {
            Announcement? announcement = ReadAnnouncement(id);
            if (announcement != null)
            {
                db.Announcements.Remove(announcement);
                db.SaveChanges();
                return announcement;
            }
            return null;
        }

        //public static bool HasUserViewed(string userId, int announcementId) //Mark user as having viewed announcement
        //{
        //    throw new NotImplementedException();
        //}

        //public static void MarkUserAsViewed(string userId, int announcementId) //Mark user as having viewed announcement
        //{
        //    throw new NotImplementedException();
        //}

    }
}
