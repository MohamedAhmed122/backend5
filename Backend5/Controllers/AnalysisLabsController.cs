using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend5.Data;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class AnalysisLabsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnalysisLabsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnalysisLabs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AnalysisLabs.Include(a => a.Lab);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AnalysisLabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisLab = await _context.AnalysisLabs
                .Include(a => a.Lab)
                .SingleOrDefaultAsync(m => m.AnalysisId == id);
            if (analysisLab == null)
            {
                return NotFound();
            }

            return View(analysisLab);
        }

        // GET: AnalysisLabs/Create
        public IActionResult Create()
        {
            ViewData["LabId"] = new SelectList(_context.Labs, "Id", "Name");
            return View();
        }

        // POST: AnalysisLabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnalysisId,LabId")] AnalysisLab analysisLab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analysisLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabId"] = new SelectList(_context.Labs, "Id", "Name", analysisLab.LabId);
            return View(analysisLab);
        }

        // GET: AnalysisLabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisLab = await _context.AnalysisLabs.SingleOrDefaultAsync(m => m.AnalysisId == id);
            if (analysisLab == null)
            {
                return NotFound();
            }
            ViewData["LabId"] = new SelectList(_context.Labs, "Id", "Name", analysisLab.LabId);
            return View(analysisLab);
        }

        // POST: AnalysisLabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnalysisId,LabId")] AnalysisLab analysisLab)
        {
            if (id != analysisLab.AnalysisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analysisLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalysisLabExists(analysisLab.AnalysisId))
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
            ViewData["LabId"] = new SelectList(_context.Labs, "Id", "Name", analysisLab.LabId);
            return View(analysisLab);
        }

        // GET: AnalysisLabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisLab = await _context.AnalysisLabs
                .Include(a => a.Lab)
                .SingleOrDefaultAsync(m => m.AnalysisId == id);
            if (analysisLab == null)
            {
                return NotFound();
            }

            return View(analysisLab);
        }

        // POST: AnalysisLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var analysisLab = await _context.AnalysisLabs.SingleOrDefaultAsync(m => m.AnalysisId == id);
            _context.AnalysisLabs.Remove(analysisLab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalysisLabExists(int id)
        {
            return _context.AnalysisLabs.Any(e => e.AnalysisId == id);
        }
    }
}
