using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AnnouncementAPI.Data;

namespace AnnouncementAPI.Controllers
{
    [ApiController]
    [Route("[controller][action]")]
    public class AccouncementController : ControllerBase
    {
        private readonly ILogger<AccouncementController> _logger;
        private readonly AnnoucementsContext _context;

        public AccouncementController(ILogger<AccouncementController> logger, AnnoucementsContext annoucementsContext)
        {
            _logger = logger;
            _context = annoucementsContext;
            AnnoucementStorage.InitDBContext(_context);
        }

        [HttpGet]
        [ActionName("List")]
        public IEnumerable<Annoucement> List() //List All
        {
            return AnnoucementStorage.ListAnnoucements(0, 0);
        }

        [HttpGet]
        [ActionName("ListByPage")]
        public IEnumerable<Annoucement> ListByPage(int page, int pageSize) //List By Page/Size
        {
            return AnnoucementStorage.ListAnnoucements(page, pageSize);
        }


        [HttpPost]
        [ActionName("Create")]
        public ConfirmationMsg Create(AnnoucementParams param) //Create
        {
            Annoucement? annoucement = AnnoucementStorage.CreateAnnouncement(param);
            return new ConfirmationMsg { IsSuccessful = (annoucement!=null), Result = annoucement };
        }

        [HttpPost]
        [ActionName("Details")]
        public ConfirmationMsg Details(int id) //Read
        {
            Annoucement? annoucement = AnnoucementStorage.ReadAnnouncement(id);
            return new ConfirmationMsg { IsSuccessful = (annoucement != null), Result = annoucement };
        }


        [HttpPost]
        [ActionName("Update")]
        public ConfirmationMsg Update(int id, AnnoucementParams param) //Update
        {
            Annoucement? annoucement = AnnoucementStorage.UpdateAnnoucement(id, param);
            return new ConfirmationMsg { IsSuccessful = (annoucement != null), Result = annoucement };
        }


        [HttpPost]
        [ActionName("Delete")]
        public ConfirmationMsg Delete(int id) //Delete
        {
            Annoucement? annoucement = AnnoucementStorage.DeleteAnnoucement(id);
            return new ConfirmationMsg { IsSuccessful = (annoucement != null), Result = annoucement };
        }

    }
}
