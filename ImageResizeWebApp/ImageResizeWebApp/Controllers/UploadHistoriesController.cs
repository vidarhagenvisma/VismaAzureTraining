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
            return View(await _context.UploadHistory.OrderByDescending(m =>m.date).ToListAsync());
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


  

        private bool UploadHistoryExists(int id)
        {
            return _context.UploadHistory.Any(e => e.ID == id);
        }
    }
}
