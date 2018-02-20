using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImageResizeWebApp.Data;
using ImageResizeWebApp.Models;

namespace ImageResizeWebApp.Controllers
{
    public class UploadHistoriesController : Controller
    {
        private readonly UploadHistoryContext _context;

        public UploadHistoriesController(UploadHistoryContext context)
        {
            _context = context;
        }

        // GET: UploadHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.UploadHistory.ToListAsync());
        }

        // GET: UploadHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadHistory = await _context.UploadHistory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (uploadHistory == null)
            {
                return NotFound();
            }

            return View(uploadHistory);
        }

        // GET: UploadHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UploadHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,URL,IP,date")] UploadHistory uploadHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uploadHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uploadHistory);
        }

        // GET: UploadHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadHistory = await _context.UploadHistory.SingleOrDefaultAsync(m => m.ID == id);
            if (uploadHistory == null)
            {
                return NotFound();
            }
            return View(uploadHistory);
        }

        // POST: UploadHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,URL,IP,date")] UploadHistory uploadHistory)
        {
            if (id != uploadHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uploadHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UploadHistoryExists(uploadHistory.ID))
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
            return View(uploadHistory);
        }

        // GET: UploadHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadHistory = await _context.UploadHistory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (uploadHistory == null)
            {
                return NotFound();
            }

            return View(uploadHistory);
        }

        // POST: UploadHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uploadHistory = await _context.UploadHistory.SingleOrDefaultAsync(m => m.ID == id);
            _context.UploadHistory.Remove(uploadHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UploadHistoryExists(int id)
        {
            return _context.UploadHistory.Any(e => e.ID == id);
        }
    }
}
