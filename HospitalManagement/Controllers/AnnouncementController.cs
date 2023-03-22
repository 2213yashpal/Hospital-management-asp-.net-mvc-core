using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class AnnouncementController : Controller
    {
        AnnouncementsModel annObj = new AnnouncementsModel();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addannouncement(AnnouncementsModel announcement)
        {
            bool res;
            annObj = new AnnouncementsModel();
            res = annObj.Addannouncement(announcement);
            if (res)
            {
                TempData["msg"] = "Announcement added successfully";
            }
            else
            {
                TempData["msg"] = "Announcement not added";
            }
            return View();
        }
        public IActionResult Addannouncement()
        {
            return View();
        }

        public IActionResult Listofannouncement()
        {

            annObj = new AnnouncementsModel();
            List<AnnouncementsModel> lst = annObj.getData();
            return View(lst);
        }

    }
}
