using LastExamPractise26January2022.Areas.AdminDoc.ViewModels;
using LastExamPractise26January2022.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LastExamPractise26January2022.Areas.AdminDoc.Controllers
{
    [Area("AdminDoc")]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; }

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> Register()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //var Admin = new RegisterVM
        //        //{
        //        //    FullName = "CAvid Haciyev",
        //        //    Email = "hcavid386@gmail.com",
        //        //    Password = "@Qwerty123"
        //        //};
        //        var user = new ApplicationUser
        //        {

        //            Fullname = "CAvid Haciyev",
        //            UserName = "Admin",
        //            Email = "hcavid386@gmail.com",
        //        };

        //       var result =await  _userManager.CreateAsync(user, "@Qwerty123");
        //        //if (result.Succeeded) { }
        //    }
        //    return Content("Ok");
        //}
        public IActionResult Login()
        {
            return View();
        }

    }
}
