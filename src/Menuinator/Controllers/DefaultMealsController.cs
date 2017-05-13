using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menuinator.Data;
using Menuinator.Models;
using Menuinator.Models.SupportTables;
using Menuinator.ViewModels;

namespace Menuinator.Controllers
{
    public class DefaultMealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DefaultMealsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: DefaultMeals
        public async Task<IActionResult> Index()
        {
            return View(await _context.DefaultMeals.ToListAsync());
        }

        // GET: DefaultMeals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defaultMeal = await _context.DefaultMeals.SingleOrDefaultAsync(m => m.ID == id);
            if (defaultMeal == null)
            {
                return NotFound();
            }

            return View(defaultMeal);
        }

        // GET: DefaultMeals/Create
        public IActionResult Create()
        {
            AddDefaultMealViewModel addDefaultMealViewModel = new AddDefaultMealViewModel(
               _context.WeatherTypes.ToList(), 
               _context.CookingMethods.ToList(),
               _context.CookingMethods.ToList(),
               _context.CookingTimes.ToList(), 
               _context.PrepTimes.ToList());

            return View(addDefaultMealViewModel);
        }

        // POST: DefaultMeals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddDefaultMealViewModel addDefaultMealViewModel)
        {
            if (ModelState.IsValid)
            {
                WeatherType newWeatherType = _context.WeatherTypes.Single(w => w.ID == addDefaultMealViewModel.WeatherTypeID);
                CookingMethod newCookingMethod = _context.CookingMethods.Single(m => m.ID == addDefaultMealViewModel.CookingMethodID);
                CookingMethod newAltCookingMethod = _context.CookingMethods.Single(a => a.ID == addDefaultMealViewModel.AltCookingMethodID);
                CookingTime newCookingTime = _context.CookingTimes.Single(t => t.ID == addDefaultMealViewModel.CookingTimeID);
                PrepTime newPrepTime = _context.PrepTimes.Single(p => p.ID == addDefaultMealViewModel.PrepTimeID);

                //Add the new default meal to the default meal table
                DefaultMeal newDefaultMeal = new DefaultMeal
                {
                    Name = addDefaultMealViewModel.Name,
                    Description = addDefaultMealViewModel.Description,
                    WeatherType = newWeatherType,
                    CookingMethod = newCookingMethod,
                    AltCookingMethod = newAltCookingMethod,
                    CookingTime = newCookingTime,
                    PrepTime = newPrepTime
                };

                _context.DefaultMeals.Add(newDefaultMeal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addDefaultMealViewModel);
        }

        // GET: DefaultMeals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defaultMeal = await _context.DefaultMeals.SingleOrDefaultAsync(m => m.ID == id);
            if (defaultMeal == null)
            {
                return NotFound();
            }
            return View(defaultMeal);
        }

        // POST: DefaultMeals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Name")] DefaultMeal defaultMeal)
        {
            if (id != defaultMeal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defaultMeal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefaultMealExists(defaultMeal.ID))
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
            return View(defaultMeal);
        }

        // GET: DefaultMeals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defaultMeal = await _context.DefaultMeals.SingleOrDefaultAsync(m => m.ID == id);
            if (defaultMeal == null)
            {
                return NotFound();
            }

            return View(defaultMeal);
        }

        // POST: DefaultMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defaultMeal = await _context.DefaultMeals.SingleOrDefaultAsync(m => m.ID == id);
            _context.DefaultMeals.Remove(defaultMeal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DefaultMealExists(int id)
        {
            return _context.DefaultMeals.Any(e => e.ID == id);
        }
    }
}
