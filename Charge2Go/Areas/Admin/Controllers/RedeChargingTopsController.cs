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
    public class RedeChargingTopsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RedeChargingTopsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/RedeChargingTops
        public async Task<IActionResult> Index()
        {
              return _context.RedeChargingTop != null ? 
                          View(await _context.RedeChargingTop.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RedeChargingTop'  is null.");
        }

        // GET: Admin/RedeChargingTops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RedeChargingTop == null)
            {
                return NotFound();
            }

            var redeChargingTop = await _context.RedeChargingTop
                .FirstOrDefaultAsync(m => m.ID == id);
            if (redeChargingTop == null)
            {
                return NotFound();
            }

            return View(redeChargingTop);
        }

        // GET: Admin/RedeChargingTops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RedeChargingTops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RedeChargingTop redeChargingTop, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathRedeImage = Path.Combine(wwwRootPath, @"Images/Rede");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(redeChargingTop.ImageTop))
                    {
                        var lastImage = Path.Combine(wwwRootPath, redeChargingTop.ImageTop.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImage))
                        {
                            System.IO.File.Delete(lastImage);
                        }
                    }

                    // Save the image to the server
                    using (var fileStream = new FileStream(Path.Combine(pathRedeImage, uniqueFileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Set the ImageSlider property
                    redeChargingTop.ImageTop = @"\Images\Rede\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(redeChargingTop);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(redeChargingTop);
        }

        // GET: Admin/RedeChargingTops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RedeChargingTop == null)
            {
                return NotFound();
            }

            var redeChargingTop = await _context.RedeChargingTop.FindAsync(id);
            if (redeChargingTop == null)
            {
                return NotFound();
            }
            return View(redeChargingTop);
        }

        // POST: Admin/RedeChargingTops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RedeChargingTop redeChargingTop, IFormFile file)
        {
            if (id != redeChargingTop.ID)
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
                        string pathRedeImage = Path.Combine(wwwRootPath, @"Images/Rede");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(redeChargingTop.ImageTop))
                        {
                            var lastImage = Path.Combine(wwwRootPath, redeChargingTop.ImageTop.TrimStart('\\'));

                            if (System.IO.File.Exists(lastImage))
                            {
                                System.IO.File.Delete(lastImage);
                            }
                        }

                        // Save the new image to the server
                        using (var fileStream = new FileStream(Path.Combine(pathRedeImage, uniqueFileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        // Update the ImageSlider property with the new image path
                        redeChargingTop.ImageTop = @"\Images\Rede\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(redeChargingTop);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedeChargingTopExists(redeChargingTop.ID))
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

            return View(redeChargingTop);
        }

        // GET: Admin/RedeChargingTops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RedeChargingTop == null)
            {
                return NotFound();
            }

            var redeChargingTop = await _context.RedeChargingTop
                .FirstOrDefaultAsync(m => m.ID == id);
            if (redeChargingTop == null)
            {
                return NotFound();
            }

            return View(redeChargingTop);
        }

        // POST: Admin/RedeChargingTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RedeChargingTop == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RedeChargingTop'  is null.");
            }
            var redeChargingTop = await _context.RedeChargingTop.FindAsync(id);
            if (redeChargingTop != null)
            {
                _context.RedeChargingTop.Remove(redeChargingTop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedeChargingTopExists(int id)
        {
          return (_context.RedeChargingTop?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
