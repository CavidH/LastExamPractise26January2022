using LastExamPractise26January2022.Data.DAL;
using LastExamPractise26January2022.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LastExamPractise26January2022.Areas.AdminDoc.Controllers
{
    [Area("AdminDoc")]
    public class DoctorController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment webHostEnvironment { get; }

        public DoctorController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var dbdoctors = await _context.doctors.Where(p => p.IsDeleted == false).ToListAsync();

            return View(dbdoctors);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(doctor);
                var doc = new Doctor
                {
                    Name = doctor.Name,
                    SurName = doctor.SurName,
                    Position = doctor.Position,
                    Image = uniqueFileName

                };
                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);

        }
        private string ProcessUploadedFile(Doctor doctor)
        {
            string uniqueFileName = null;

            if (doctor.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "assets","img", "doctors");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + doctor.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    doctor.ImageFile.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


        public async Task<IActionResult> Delete(int id)
        {
            var dbdoctor = await _context.doctors.Where(p => p.IsDeleted == false && p.Id == id).FirstOrDefaultAsync();
            dbdoctor.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Doctor");
        }

    }
}
