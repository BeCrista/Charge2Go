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
    public class TariffBottomsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TariffBottomsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/TariffBottoms
        public async Task<IActionResult> Index()
        {
              return _context.TariffBottom != null ? 
                          View(await _context.TariffBottom.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TariffBottom'  is null.");
        }

        // GET: Admin/TariffBottoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TariffBottom == null)
            {
                return NotFound();
            }

            var tariffBottom = await _context.TariffBottom
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tariffBottom == null)
            {
                return NotFound();
            }

            return View(tariffBottom);
        }

        // GET: Admin/TariffBottoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TariffBottoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TariffBottom tariffBottom, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathImageSolution = Path.Combine(wwwRootPath, @"Images/TariffBottom");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(tariffBottom.TariffSolutionImage))
                    {
                        var lastImage = Path.Combine(wwwRootPath, tariffBottom.TariffSolutionImage.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImage))
                        {
                            System.IO.File.Delete(lastImage);
                        }
                    }

                    // Save the image to the server
                    using (var fileStream = new FileStream(Path.Combine(pathImageSolution, uniqueFileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Set the ImageSlider property
                    tariffBottom.TariffSolutionImage = @"\Images\TariffBottom\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(tariffBottom);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(tariffBottom);
        }

        // GET: Admin/TariffBottoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TariffBottom == null)
            {
                return NotFound();
            }

            var tariffBottom = await _context.TariffBottom.FindAsync(id);
            if (tariffBottom == null)
            {
                return NotFound();
            }
            return View(tariffBottom);
        }

        // POST: Admin/TariffBottoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TariffBottom tariffBottom, IFormFile file)
        {
            if (id != tariffBottom.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    // Save image file to the wwwroot/images folder and update the ImageSlider property
                    if (file != null)
                    {
                        string pathImageSolution = Path.Combine(wwwRootPath, @"Images/TariffBottom");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(tariffBottom.TariffSolutionImage))
                        {
                            var lastImage = Path.Combine(wwwRootPath, tariffBottom.TariffSolutionImage.TrimStart('\\'));

                            if (System.IO.File.Exists(lastImage))
                            {
                                System.IO.File.Delete(lastImage);
                            }
                        }

                        // Save the new image to the server
                        using (var fileStream = new FileStream(Path.Combine(pathImageSolution, uniqueFileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        // Update the ImageSlider property with the new image path
                        tariffBottom.TariffSolutionImage = @"\Images\TariffBottom\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(tariffBottom);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TariffBottomExists(tariffBottom.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(tariffBottom);
        }

        // GET: Admin/TariffBottoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TariffBottom == null)
            {
                return NotFound();
            }

            var tariffBottom = await _context.TariffBottom
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tariffBottom == null)
            {
                return NotFound();
            }

            return View(tariffBottom);
        }

        // POST: Admin/TariffBottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TariffBottom == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TariffBottom'  is null.");
            }
            var tariffBottom = await _context.TariffBottom.FindAsync(id);
            if (tariffBottom != null)
            {
                _context.TariffBottom.Remove(tariffBottom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TariffBottomExists(int id)
        {
          return (_context.TariffBottom?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
