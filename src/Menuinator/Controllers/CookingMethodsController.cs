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
    public class CookingMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CookingMethodsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CookingMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.CookingMethods.ToListAsync());
        }

        // GET: CookingMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingMethod = await _context.CookingMethods.SingleOrDefaultAsync(m => m.ID == id);
            if (cookingMethod == null)
            {
                return NotFound();
            }

            return View(cookingMethod);
        }

        // GET: CookingMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CookingMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description")] CookingMethod cookingMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cookingMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cookingMethod);
        }

        // GET: CookingMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingMethod = await _context.CookingMethods.SingleOrDefaultAsync(m => m.ID == id);
            if (cookingMethod == null)
            {
                return NotFound();
            }
            return View(cookingMethod);
        }

        // POST: CookingMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description")] CookingMethod cookingMethod)
        {
            if (id != cookingMethod.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookingMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookingMethodExists(cookingMethod.ID))
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
            return View(cookingMethod);
        }

        // GET: CookingMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingMethod = await _context.CookingMethods.SingleOrDefaultAsync(m => m.ID == id);
            if (cookingMethod == null)
            {
                return NotFound();
            }

            return View(cookingMethod);
        }

        // POST: CookingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cookingMethod = await _context.CookingMethods.SingleOrDefaultAsync(m => m.ID == id);
            _context.CookingMethods.Remove(cookingMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CookingMethodExists(int id)
        {
            return _context.CookingMethods.Any(e => e.ID == id);
        }
    }
}
