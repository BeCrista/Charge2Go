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
    public class RedeChargingPointsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RedeChargingPointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/RedeChargingPoints
        public async Task<IActionResult> Index()
        {
              return _context.RedeChargingPoints != null ? 
                          View(await _context.RedeChargingPoints.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RedeChargingPoints'  is null.");
        }

        // GET: Admin/RedeChargingPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RedeChargingPoints == null)
            {
                return NotFound();
            }

            var redeChargingPoint = await _context.RedeChargingPoints
                .FirstOrDefaultAsync(m => m.ID == id);
            if (redeChargingPoint == null)
            {
                return NotFound();
            }

            return View(redeChargingPoint);
        }

        // GET: Admin/RedeChargingPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RedeChargingPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NormalChargingPointTitle,NormalChargingPointDescription,QuickChargingPointTitle,QuickChargingPointDescription")] RedeChargingPoint redeChargingPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(redeChargingPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(redeChargingPoint);
        }

        // GET: Admin/RedeChargingPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RedeChargingPoints == null)
            {
                return NotFound();
            }

            var redeChargingPoint = await _context.RedeChargingPoints.FindAsync(id);
            if (redeChargingPoint == null)
            {
                return NotFound();
            }
            return View(redeChargingPoint);
        }

        // POST: Admin/RedeChargingPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NormalChargingPointTitle,NormalChargingPointDescription,QuickChargingPointTitle,QuickChargingPointDescription")] RedeChargingPoint redeChargingPoint)
        {
            if (id != redeChargingPoint.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(redeChargingPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedeChargingPointExists(redeChargingPoint.ID))
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
            return View(redeChargingPoint);
        }

        // GET: Admin/RedeChargingPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RedeChargingPoints == null)
            {
                return NotFound();
            }

            var redeChargingPoint = await _context.RedeChargingPoints
                .FirstOrDefaultAsync(m => m.ID == id);
            if (redeChargingPoint == null)
            {
                return NotFound();
            }

            return View(redeChargingPoint);
        }

        // POST: Admin/RedeChargingPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RedeChargingPoints == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RedeChargingPoints'  is null.");
            }
            var redeChargingPoint = await _context.RedeChargingPoints.FindAsync(id);
            if (redeChargingPoint != null)
            {
                _context.RedeChargingPoints.Remove(redeChargingPoint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedeChargingPointExists(int id)
        {
          return (_context.RedeChargingPoints?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
