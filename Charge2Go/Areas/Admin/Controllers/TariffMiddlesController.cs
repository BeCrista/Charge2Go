using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Charge2Go.Data;
using Charge2Go.Models;

namespace Charge2Go.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TariffMiddlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TariffMiddlesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/TariffMiddles
        public async Task<IActionResult> Index()
        {
              return _context.TariffMiddle != null ? 
                          View(await _context.TariffMiddle.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TariffMiddle'  is null.");
        }

        // GET: Admin/TariffMiddles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TariffMiddle == null)
            {
                return NotFound();
            }

            var tariffMiddle = await _context.TariffMiddle
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tariffMiddle == null)
            {
                return NotFound();
            }

            return View(tariffMiddle);
        }

        // GET: Admin/TariffMiddles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TariffMiddles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TariffMiddle tariffMiddle, IFormFile tariffPriceFile, IFormFile tariffScheduleFile, IFormFile tariffCampaingFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save ImageTop file to the wwwroot/Images/TariffTop folder
                if (tariffPriceFile != null)
                {
                    string pathImagePrice = Path.Combine(wwwRootPath, @"Images/TariffMiddle");
                    string uniqueFileNameImagePrice = Guid.NewGuid().ToString() + Path.GetExtension(tariffPriceFile.FileName);

                    if (!string.IsNullOrEmpty(tariffMiddle.TariffPriceImage))
                    {
                        var lastImagePrice = Path.Combine(wwwRootPath, tariffMiddle.TariffPriceImage.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImagePrice))
                        {
                            System.IO.File.Delete(lastImagePrice);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImagePrice, uniqueFileNameImagePrice), FileMode.Create))
                    {
                        tariffPriceFile.CopyTo(fileStream);
                    }

                    tariffMiddle.TariffPriceImage = @"\Images\TariffMiddle\" + uniqueFileNameImagePrice;
                }

                // Save ImageCard file to the wwwroot/Images/TariffTop folder
                if (tariffScheduleFile != null)
                {
                    string pathImageSchedule = Path.Combine(wwwRootPath, @"Images/TariffMiddle");
                    string uniqueFileNameImageSchedule = Guid.NewGuid().ToString() + Path.GetExtension(tariffScheduleFile.FileName);

                    if (!string.IsNullOrEmpty(tariffMiddle.TariffScheduleImage))
                    {
                        var lastImageSchedule = Path.Combine(wwwRootPath, tariffMiddle.TariffScheduleImage.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageSchedule))
                        {
                            System.IO.File.Delete(lastImageSchedule);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageSchedule, uniqueFileNameImageSchedule), FileMode.Create))
                    {
                        tariffScheduleFile.CopyTo(fileStream);
                    }

                    tariffMiddle.TariffScheduleImage = @"\Images\TariffMiddle\" + uniqueFileNameImageSchedule;
                }

                if (tariffCampaingFile != null)
                {
                    string pathImageCampaing = Path.Combine(wwwRootPath, @"Images/TariffMiddle");
                    string uniqueFileNameImageCampaing = Guid.NewGuid().ToString() + Path.GetExtension(tariffCampaingFile.FileName);

                    if (!string.IsNullOrEmpty(tariffMiddle.TariffCampaignImage))
                    {
                        var lastImageCampaing = Path.Combine(wwwRootPath, tariffMiddle.TariffCampaignImage.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageCampaing))
                        {
                            System.IO.File.Delete(lastImageCampaing);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageCampaing, uniqueFileNameImageCampaing), FileMode.Create))
                    {
                        tariffCampaingFile.CopyTo(fileStream);
                    }

                    tariffMiddle.TariffCampaignImage = @"\Images\TariffMiddle\" + uniqueFileNameImageCampaing;
                }

                // Clear ModelState to avoid validation issues with ImageFile fields
                ModelState.Clear();

                // Add the entity to the context after the images have been saved
                _context.Add(tariffMiddle);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(tariffMiddle);
        }

        // GET: Admin/TariffMiddles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TariffMiddle == null)
            {
                return NotFound();
            }

            var tariffMiddle = await _context.TariffMiddle.FindAsync(id);
            if (tariffMiddle == null)
            {
                return NotFound();
            }
            return View(tariffMiddle);
        }

        // POST: Admin/TariffMiddles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TariffMiddle tariffMiddle, IFormFile tariffPriceFile, IFormFile tariffScheduleFile, IFormFile tariffCampaingFile)
        {
            if (id != tariffMiddle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save ImageTop file to the wwwroot/Images/TariffTop folder
                if (tariffPriceFile != null)
                {
                    string pathImagePrice = Path.Combine(wwwRootPath, @"Images/TariffMiddle");
                    string uniqueFileNameImagePrice = Guid.NewGuid().ToString() + Path.GetExtension(tariffPriceFile.FileName);

                    if (!string.IsNullOrEmpty(tariffMiddle.TariffPriceImage))
                    {
                        var lastImagePrice = Path.Combine(wwwRootPath, tariffMiddle.TariffPriceImage.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImagePrice))
                        {
                            System.IO.File.Delete(lastImagePrice);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImagePrice, uniqueFileNameImagePrice), FileMode.Create))
                    {
                        tariffPriceFile.CopyTo(fileStream);
                    }

                    tariffMiddle.TariffPriceImage = @"\Images\TariffMiddle\" + uniqueFileNameImagePrice;
                }

                // Save ImageCard file to the wwwroot/Images/TariffTop folder
                if (tariffScheduleFile != null)
                {
                    string pathImageSchedule = Path.Combine(wwwRootPath, @"Images/TariffMiddle");
                    string uniqueFileNameImageSchedule = Guid.NewGuid().ToString() + Path.GetExtension(tariffScheduleFile.FileName);

                    if (!string.IsNullOrEmpty(tariffMiddle.TariffScheduleImage))
                    {
                        var lastImageSchedule = Path.Combine(wwwRootPath, tariffMiddle.TariffScheduleImage.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageSchedule))
                        {
                            System.IO.File.Delete(lastImageSchedule);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageSchedule, uniqueFileNameImageSchedule), FileMode.Create))
                    {
                        tariffScheduleFile.CopyTo(fileStream);
                    }

                    tariffMiddle.TariffScheduleImage = @"\Images\TariffMiddle\" + uniqueFileNameImageSchedule;
                }

                if (tariffCampaingFile != null)
                {
                    string pathImageCampaing = Path.Combine(wwwRootPath, @"Images/TariffMiddle");
                    string uniqueFileNameImageCampaing = Guid.NewGuid().ToString() + Path.GetExtension(tariffCampaingFile.FileName);

                    if (!string.IsNullOrEmpty(tariffMiddle.TariffCampaignImage))
                    {
                        var lastImageCampaing = Path.Combine(wwwRootPath, tariffMiddle.TariffCampaignImage.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageCampaing))
                        {
                            System.IO.File.Delete(lastImageCampaing);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageCampaing, uniqueFileNameImageCampaing), FileMode.Create))
                    {
                        tariffCampaingFile.CopyTo(fileStream);
                    }

                    tariffMiddle.TariffCampaignImage = @"\Images\TariffMiddle\" + uniqueFileNameImageCampaing;
                }

                // Clear ModelState to avoid validation issues with ImageFile fields
                ModelState.Clear();

                // Update the entity in the context after the images have been saved or if they are unchanged
                _context.Update(tariffMiddle);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(tariffMiddle);
        }

        // GET: Admin/TariffMiddles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TariffMiddle == null)
            {
                return NotFound();
            }

            var tariffMiddle = await _context.TariffMiddle
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tariffMiddle == null)
            {
                return NotFound();
            }

            return View(tariffMiddle);
        }

        // POST: Admin/TariffMiddles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TariffMiddle == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TariffMiddle'  is null.");
            }
            var tariffMiddle = await _context.TariffMiddle.FindAsync(id);
            if (tariffMiddle != null)
            {
                _context.TariffMiddle.Remove(tariffMiddle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TariffMiddleExists(int id)
        {
          return (_context.TariffMiddle?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
