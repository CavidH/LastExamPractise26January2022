using LastExamPractise26January2022.Areas.AdminDoc.ViewModels;
using LastExamPractise26January2022.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LastExamPractise26January2022.Areas.AdminDoc.Controllers
{
    public class DoctorController : Controller
    {
        private AppDbContext _context { get; }
        public DoctorController(AppDbContext context)
        {
            _context = context;
        }
        [Area("AdminDoc")]
        public async Task<IActionResult> Index()
        {
            var dbdoctors = await _context.doctors.Where(p => p.IsDeleted == false).ToListAsync();
          
            return View(dbdoctors);
        }
    }
}
