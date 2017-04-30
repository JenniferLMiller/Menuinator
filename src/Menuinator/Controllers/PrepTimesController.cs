using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menuinator.Data;
using Menuinator.Models;

namespace Menuinator.Controllers
{
    public class PrepTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrepTimesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PrepTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrepTimes.ToListAsync());
        }

        // GET: PrepTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prepTime = await _context.PrepTimes.SingleOrDefaultAsync(m => m.ID == id);
            if (prepTime == null)
            {
                return NotFound();
            }

            return View(prepTime);
        }

        // GET: PrepTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrepTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description")] PrepTime prepTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prepTime);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prepTime);
        }

        // GET: PrepTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prepTime = await _context.PrepTimes.SingleOrDefaultAsync(m => m.ID == id);
            if (prepTime == null)
            {
                return NotFound();
            }
            return View(prepTime);
        }

        // POST: PrepTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description")] PrepTime prepTime)
        {
            if (id != prepTime.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prepTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrepTimeExists(prepTime.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(prepTime);
        }

        // GET: PrepTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prepTime = await _context.PrepTimes.SingleOrDefaultAsync(m => m.ID == id);
            if (prepTime == null)
            {
                return NotFound();
            }

            return View(prepTime);
        }

        // POST: PrepTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prepTime = await _context.PrepTimes.SingleOrDefaultAsync(m => m.ID == id);
            _context.PrepTimes.Remove(prepTime);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PrepTimeExists(int id)
        {
            return _context.PrepTimes.Any(e => e.ID == id);
        }
    }
}
