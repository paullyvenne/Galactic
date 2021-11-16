using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using AnnouncementAPI.Data;

namespace AnnouncementAPI.Controllers
{
    [ApiController]
    [Route("[controller][action]")]
    public class AccouncementController : ControllerBase
    {
        private readonly ILogger<AccouncementController> _logger;

        public AccouncementController(ILogger<AccouncementController> logger, DbContextOptions<AnnouncementsContext> options)
        {
            _logger = logger;
            AnnouncementStorage.InitDBContext(options);
        }

        [HttpGet]
        [ActionName("List")]
        public IEnumerable<Announcement> List() //List All
        {
            return AnnouncementStorage.ListAnnouncements(0, 0);
        }

        [HttpGet]
        [ActionName("ListByPage")]
        public IEnumerable<Announcement> ListByPage(int page, int pageSize) //List By Page/Size
        {
            return AnnouncementStorage.ListAnnouncements(page, pageSize);
        }


        [HttpPost]
        [ActionName("Create")]
        public ConfirmationMsg Create(AnnouncementParams param) //Create
        {
            Announcement? announcement = AnnouncementStorage.CreateAnnouncement(param);
            return new ConfirmationMsg { IsSuccessful = (announcement!=null), Result = announcement };
        }

        [HttpGet]
        [ActionName("Details")]
        public Announcement? Details(int id) //Read
        {
            return AnnouncementStorage.ReadAnnouncement(id);
        }


        [HttpPost]
        [ActionName("Update")]
        public ConfirmationMsg Update(int id, AnnouncementParams param) //Update
        {
            Announcement? announcement = AnnouncementStorage.UpdateAnnouncement(id, param);
            return new ConfirmationMsg { IsSuccessful = (announcement != null), Result = announcement };
        }


        [HttpPost]
        [ActionName("Delete")]
        public ConfirmationMsg Delete(int id) //Delete
        {
            Announcement? announcement = AnnouncementStorage.DeleteAnnouncement(id);
            return new ConfirmationMsg { IsSuccessful = (announcement != null), Result = announcement };
        }

    }
}
