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
    public class WeatherTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeatherTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WeatherTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherTypes.ToListAsync());
        }

        // GET: WeatherTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherType = await _context.WeatherTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (weatherType == null)
            {
                return NotFound();
            }

            return View(weatherType);
        }

        // GET: WeatherTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description")] WeatherType weatherType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(weatherType);
        }

        // GET: WeatherTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherType = await _context.WeatherTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (weatherType == null)
            {
                return NotFound();
            }
            return View(weatherType);
        }

        // POST: WeatherTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description")] WeatherType weatherType)
        {
            if (id != weatherType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherTypeExists(weatherType.ID))
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
            return View(weatherType);
        }

        // GET: WeatherTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherType = await _context.WeatherTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (weatherType == null)
            {
                return NotFound();
            }

            return View(weatherType);
        }

        // POST: WeatherTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherType = await _context.WeatherTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.WeatherTypes.Remove(weatherType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WeatherTypeExists(int id)
        {
            return _context.WeatherTypes.Any(e => e.ID == id);
        }
    }
}
