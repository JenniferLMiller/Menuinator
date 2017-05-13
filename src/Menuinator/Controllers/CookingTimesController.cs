using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menuinator.Data;
using Menuinator.Models.SupportTables;

namespace Menuinator.Controllers
{
    public class CookingTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CookingTimesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CookingTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CookingTimes.ToListAsync());
        }

        // GET: CookingTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingTime = await _context.CookingTimes.SingleOrDefaultAsync(m => m.ID == id);
            if (cookingTime == null)
            {
                return NotFound();
            }

            return View(cookingTime);
        }

        // GET: CookingTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CookingTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description")] CookingTime cookingTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cookingTime);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cookingTime);
        }

        // GET: CookingTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingTime = await _context.CookingTimes.SingleOrDefaultAsync(m => m.ID == id);
            if (cookingTime == null)
            {
                return NotFound();
            }
            return View(cookingTime);
        }

        // POST: CookingTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description")] CookingTime cookingTime)
        {
            if (id != cookingTime.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookingTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookingTimeExists(cookingTime.ID))
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
            return View(cookingTime);
        }

        // GET: CookingTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingTime = await _context.CookingTimes.SingleOrDefaultAsync(m => m.ID == id);
            if (cookingTime == null)
            {
                return NotFound();
            }

            return View(cookingTime);
        }

        // POST: CookingTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cookingTime = await _context.CookingTimes.SingleOrDefaultAsync(m => m.ID == id);
            _context.CookingTimes.Remove(cookingTime);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CookingTimeExists(int id)
        {
            return _context.CookingTimes.Any(e => e.ID == id);
        }
    }
}
