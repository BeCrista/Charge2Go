using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Charge2Go.Data;
using Charge2Go.Models;
using System.Diagnostics;

namespace Charge2Go.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TariffTopsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TariffTopsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/TariffTops
        public async Task<IActionResult> Index()
        {
              return _context.TariffTop != null ? 
                          View(await _context.TariffTop.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TariffTop'  is null.");
        }

        // GET: Admin/TariffTops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TariffTop == null)
            {
                return NotFound();
            }

            var tariffTop = await _context.TariffTop
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tariffTop == null)
            {
                return NotFound();
            }

            return View(tariffTop);
        }

        // GET: Admin/TariffTops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TariffTops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TariffTop tariffTop, IFormFile imageTopFile, IFormFile imageCardFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save ImageTop file to the wwwroot/Images/TariffTop folder
                if (imageTopFile != null)
                {
                    string pathImageTop = Path.Combine(wwwRootPath, @"Images/TariffTop");
                    string uniqueFileNameImageTop = Guid.NewGuid().ToString() + Path.GetExtension(imageTopFile.FileName);

                    if (!string.IsNullOrEmpty(tariffTop.ImageTop))
                    {
                        var lastImageTop = Path.Combine(wwwRootPath, tariffTop.ImageTop.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageTop))
                        {
                            System.IO.File.Delete(lastImageTop);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageTop, uniqueFileNameImageTop), FileMode.Create))
                    {
                        imageTopFile.CopyTo(fileStream);
                    }

                    tariffTop.ImageTop = @"\Images\TariffTop\" + uniqueFileNameImageTop;
                }

                // Save ImageCard file to the wwwroot/Images/TariffTop folder
                if (imageCardFile != null)
                {
                    string pathImageCard = Path.Combine(wwwRootPath, @"Images/TariffTop");
                    string uniqueFileNameImageCard = Guid.NewGuid().ToString() + Path.GetExtension(imageCardFile.FileName);

                    if (!string.IsNullOrEmpty(tariffTop.ImageCard))
                    {
                        var lastImageCard = Path.Combine(wwwRootPath, tariffTop.ImageCard.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageCard))
                        {
                            System.IO.File.Delete(lastImageCard);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageCard, uniqueFileNameImageCard), FileMode.Create))
                    {
                        imageCardFile.CopyTo(fileStream);
                    }

                    tariffTop.ImageCard = @"\Images\TariffTop\" + uniqueFileNameImageCard;
                }

                // Clear ModelState to avoid validation issues with ImageFile fields
                ModelState.Clear();

                // Add the entity to the context after the images have been saved
                _context.Add(tariffTop);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            foreach (var modelStateValue in ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    Debug.WriteLine("Validation Error: " + error.ErrorMessage);
                }
            }

            return View(tariffTop);
        }


        // GET: Admin/TariffTops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TariffTop == null)
            {
                return NotFound();
            }

            var tariffTop = await _context.TariffTop.FindAsync(id);
            if (tariffTop == null)
            {
                return NotFound();
            }
            return View(tariffTop);
        }

        // POST: Admin/TariffTops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TariffTop tariffTop, IFormFile imageTopFile, IFormFile imageCardFile)
        {
            if (id != tariffTop.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save ImageTop file to the wwwroot/Images/TariffTop folder
                if (imageTopFile != null)
                {
                    string pathImageTop = Path.Combine(wwwRootPath, @"Images/TariffTop");
                    string uniqueFileNameImageTop = Guid.NewGuid().ToString() + Path.GetExtension(imageTopFile.FileName);

                    if (!string.IsNullOrEmpty(tariffTop.ImageTop))
                    {
                        var lastImageTop = Path.Combine(wwwRootPath, tariffTop.ImageTop.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageTop))
                        {
                            System.IO.File.Delete(lastImageTop);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageTop, uniqueFileNameImageTop), FileMode.Create))
                    {
                        imageTopFile.CopyTo(fileStream);
                    }

                    tariffTop.ImageTop = @"\Images\TariffTop\" + uniqueFileNameImageTop;
                }

                // Save ImageCard file to the wwwroot/Images/TariffTop folder
                if (imageCardFile != null)
                {
                    string pathImageCard = Path.Combine(wwwRootPath, @"Images/TariffTop");
                    string uniqueFileNameImageCard = Guid.NewGuid().ToString() + Path.GetExtension(imageCardFile.FileName);

                    if (!string.IsNullOrEmpty(tariffTop.ImageCard))
                    {
                        var lastImageCard = Path.Combine(wwwRootPath, tariffTop.ImageCard.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImageCard))
                        {
                            System.IO.File.Delete(lastImageCard);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(pathImageCard, uniqueFileNameImageCard), FileMode.Create))
                    {
                        imageCardFile.CopyTo(fileStream);
                    }

                    tariffTop.ImageCard = @"\Images\TariffTop\" + uniqueFileNameImageCard;
                }

                // Clear ModelState to avoid validation issues with ImageFile fields
                ModelState.Clear();

                // Update the entity in the context after the images have been saved or if they are unchanged
                _context.Update(tariffTop);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            foreach (var modelStateValue in ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    Debug.WriteLine("Validation Error: " + error.ErrorMessage);
                }
            }

            return View(tariffTop);
        }

        // GET: Admin/TariffTops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TariffTop == null)
            {
                return NotFound();
            }

            var tariffTop = await _context.TariffTop
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tariffTop == null)
            {
                return NotFound();
            }

            return View(tariffTop);
        }

        // POST: Admin/TariffTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TariffTop == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TariffTop'  is null.");
            }
            var tariffTop = await _context.TariffTop.FindAsync(id);
            if (tariffTop != null)
            {
                _context.TariffTop.Remove(tariffTop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TariffTopExists(int id)
        {
          return (_context.TariffTop?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
