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
    public class FAQSQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FAQSQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FAQSQuestions
        public async Task<IActionResult> Index()
        {
              return _context.FAQsQuestions != null ? 
                          View(await _context.FAQsQuestions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.FAQsQuestions'  is null.");
        }

        // GET: Admin/FAQSQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FAQsQuestions == null)
            {
                return NotFound();
            }

            var fAQSQuestions = await _context.FAQsQuestions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fAQSQuestions == null)
            {
                return NotFound();
            }

            return View(fAQSQuestions);
        }

        // GET: Admin/FAQSQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FAQSQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,QuestionFAQ,AnswerFAQ")] FAQSQuestions fAQSQuestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fAQSQuestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fAQSQuestions);
        }

        // GET: Admin/FAQSQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FAQsQuestions == null)
            {
                return NotFound();
            }

            var fAQSQuestions = await _context.FAQsQuestions.FindAsync(id);
            if (fAQSQuestions == null)
            {
                return NotFound();
            }
            return View(fAQSQuestions);
        }

        // POST: Admin/FAQSQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,QuestionFAQ,AnswerFAQ")] FAQSQuestions fAQSQuestions)
        {
            if (id != fAQSQuestions.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fAQSQuestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQSQuestionsExists(fAQSQuestions.ID))
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
            return View(fAQSQuestions);
        }

        // GET: Admin/FAQSQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FAQsQuestions == null)
            {
                return NotFound();
            }

            var fAQSQuestions = await _context.FAQsQuestions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fAQSQuestions == null)
            {
                return NotFound();
            }

            return View(fAQSQuestions);
        }

        // POST: Admin/FAQSQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FAQsQuestions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FAQsQuestions'  is null.");
            }
            var fAQSQuestions = await _context.FAQsQuestions.FindAsync(id);
            if (fAQSQuestions != null)
            {
                _context.FAQsQuestions.Remove(fAQSQuestions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAQSQuestionsExists(int id)
        {
          return (_context.FAQsQuestions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
