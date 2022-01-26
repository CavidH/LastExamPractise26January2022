using LastExamPractise26January2022.Data.DAL;
using LastExamPractise26January2022.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LastExamPractise26January2022.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; set; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dbDoctors =await _context.doctors.Where(x => x.IsDeleted == false).Take(4).ToListAsync();
            var homeVm = new HomeVM
            {
                doctors = dbDoctors
            };

            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
