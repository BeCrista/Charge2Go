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
    public class HomePageSlidersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomePageSlidersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/HomePageSliders
        public async Task<IActionResult> Index()
        {
              return _context.SliderTop != null ? 
                          View(await _context.SliderTop.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SliderTop'  is null.");
        }

        // GET: Admin/HomePageSliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SliderTop == null)
            {
                return NotFound();
            }

            var homePageSlider = await _context.SliderTop
                .FirstOrDefaultAsync(m => m.ID == id);
            if (homePageSlider == null)
            {
                return NotFound();
            }

            return View(homePageSlider);
        }

        // GET: Admin/HomePageSliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomePageSliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HomePageSlider homePageSlider, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathSlider = Path.Combine(wwwRootPath, @"Images/HomePageSlider");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(homePageSlider.ImageSlider))
                    {
                        var lastImage = Path.Combine(wwwRootPath, homePageSlider.ImageSlider.TrimStart('\\'));

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
                    homePageSlider.ImageSlider = @"\Images\HomePageSlider\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(homePageSlider);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(homePageSlider);
        }

        // GET: Admin/HomePageSliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SliderTop == null)
            {
                return NotFound();
            }

            var homePageSlider = await _context.SliderTop.FindAsync(id);
            if (homePageSlider == null)
            {
                return NotFound();
            }
            return View(homePageSlider);
        }

        // POST: Admin/HomePageSliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, HomePageSlider homePageSlider, IFormFile file)
        {
            if (id != homePageSlider.ID)
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
                        string pathSlider = Path.Combine(wwwRootPath, @"Images/HomePageSlider");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(homePageSlider.ImageSlider))
                        {
                            var lastImage = Path.Combine(wwwRootPath, homePageSlider.ImageSlider.TrimStart('\\'));

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
                        homePageSlider.ImageSlider = @"\Images\HomePageSlider\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(homePageSlider);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomePageSliderExists(homePageSlider.ID))
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

            return View(homePageSlider);
        }

        // GET: Admin/HomePageSliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SliderTop == null)
            {
                return NotFound();
            }

            var homePageSlider = await _context.SliderTop
                .FirstOrDefaultAsync(m => m.ID == id);
            if (homePageSlider == null)
            {
                return NotFound();
            }

            return View(homePageSlider);
        }

        // POST: Admin/HomePageSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SliderTop == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SliderTop'  is null.");
            }
            var homePageSlider = await _context.SliderTop.FindAsync(id);
            if (homePageSlider != null)
            {
                _context.SliderTop.Remove(homePageSlider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomePageSliderExists(int id)
        {
          return (_context.SliderTop?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
