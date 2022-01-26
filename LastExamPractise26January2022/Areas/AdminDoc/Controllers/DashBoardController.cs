using Microsoft.AspNetCore.Mvc;

namespace LastExamPractise26January2022.Areas.AdminDoc.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("AdminDoc")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
