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
    public class HomePageMiddlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomePageMiddlesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/HomePageMiddles
        public async Task<IActionResult> Index()
        {
              return _context.ImageMiddle != null ? 
                          View(await _context.ImageMiddle.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ImageMiddle'  is null.");
        }

        // GET: Admin/HomePageMiddles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImageMiddle == null)
            {
                return NotFound();
            }

            var homePageMiddle = await _context.ImageMiddle
                .FirstOrDefaultAsync(m => m.ID == id);
            if (homePageMiddle == null)
            {
                return NotFound();
            }

            return View(homePageMiddle);
        }

        // GET: Admin/HomePageMiddles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomePageMiddles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HomePageMiddle homePageMiddle, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathSlider = Path.Combine(wwwRootPath, @"Images/HomePageMiddle");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(homePageMiddle.ImageMiddle))
                    {
                        var lastImage = Path.Combine(wwwRootPath, homePageMiddle.ImageMiddle.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImage))
                        {
                            System.IO.File.Delete(lastImage);
                        }
                    }

                    // Save the image to the server
                    using (var fileStream = new FileStream(Path.Combine(pathSlider, uniqueFileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Set the ImageSlider property
                    homePageMiddle.ImageMiddle = @"\Images\HomePageMiddle\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(homePageMiddle);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(homePageMiddle);
        }

        // GET: Admin/HomePageMiddles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImageMiddle == null)
            {
                return NotFound();
            }

            var homePageMiddle = await _context.ImageMiddle.FindAsync(id);
            if (homePageMiddle == null)
            {
                return NotFound();
            }
            return View(homePageMiddle);
        }

        // POST: Admin/HomePageMiddles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, HomePageMiddle homePageMiddle, IFormFile file)
        {
            if (id != homePageMiddle.ID)
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
                        string pathSlider = Path.Combine(wwwRootPath, @"Images/HomePageMiddle");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(homePageMiddle.ImageMiddle))
                        {
                            var lastImage = Path.Combine(wwwRootPath, homePageMiddle.ImageMiddle.TrimStart('\\'));

                            if (System.IO.File.Exists(lastImage))
                            {
                                System.IO.File.Delete(lastImage);
                            }
                        }

                        // Save the new image to the server
                        using (var fileStream = new FileStream(Path.Combine(pathSlider, uniqueFileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        // Update the ImageSlider property with the new image path
                        homePageMiddle.ImageMiddle = @"\Images\HomePageMiddle\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(homePageMiddle);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomePageMiddleExists(homePageMiddle.ID))
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

            return View(homePageMiddle);
        }

        // GET: Admin/HomePageMiddles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImageMiddle == null)
            {
                return NotFound();
            }

            var homePageMiddle = await _context.ImageMiddle
                .FirstOrDefaultAsync(m => m.ID == id);
            if (homePageMiddle == null)
            {
                return NotFound();
            }

            return View(homePageMiddle);
        }

        // POST: Admin/HomePageMiddles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImageMiddle == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ImageMiddle'  is null.");
            }
            var homePageMiddle = await _context.ImageMiddle.FindAsync(id);
            if (homePageMiddle != null)
            {
                _context.ImageMiddle.Remove(homePageMiddle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomePageMiddleExists(int id)
        {
          return (_context.ImageMiddle?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
