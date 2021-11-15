using AnnouncementAPI.Data;

namespace AnnouncementAPI
{
    public class AnnoucementStorage 
    {

        private static AnnoucementsContext db;

        public static void InitDBContext(AnnoucementsContext annoucementsContext)
        {
            db = annoucementsContext;
        }

        public static IEnumerable<Annoucement> ListAnnoucements(int pageIndex, int pageSize = 0)
        {
            if (pageSize == 0) return db.Annoucements.AsEnumerable();
            else return db.Annoucements
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }

        public static Annoucement? CreateAnnouncement(AnnoucementParams param) //Create
        {
            Annoucement annoucement = new Annoucement().CopyParams(param);
            db.Annoucements.Add(annoucement);
            db.SaveChanges();
            return annoucement;
        }

        public static Annoucement? ReadAnnouncement(int id) //Read or Null
        {
            return db.Annoucements.SingleOrDefault(x => x.ID == id );
        }
        
        public static Annoucement? UpdateAnnoucement(int id, AnnoucementParams param) //Update
        {
            Annoucement? annoucement = ReadAnnouncement(id);
            if(annoucement != null)
            {
                annoucement.CopyParams(param);
                db.SaveChanges();
                return annoucement;
            }
            return null;
        }

        public static Annoucement? DeleteAnnoucement(int id) //Delete
        {
            Annoucement? annoucement = ReadAnnouncement(id);
            if (annoucement != null)
            {
                db.Annoucements.Remove(annoucement);
                db.SaveChanges();
                return annoucement;
            }
            return null;
        }

        //public static bool HasUserViewed(string userId, int annoucementId) //Mark user as having viewed annoucement
        //{
        //    throw new NotImplementedException();
        //}

        //public static void MarkUserAsViewed(string userId, int annoucementId) //Mark user as having viewed annoucement
        //{
        //    throw new NotImplementedException();
        //}

    }
}
