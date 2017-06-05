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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;


namespace Menuinator.Controllers
{
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Meals.Include(m => m.AltCookingMethod).Include(m => m.CookingMethod).Include(m => m.CookingTime).Include(m => m.PrepTime).Include(m => m.WeatherType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.SingleOrDefaultAsync(m => m.ID == id);
            if (meal == null)
            {
                return NotFound();
            }
            else
            {
                ViewMealViewModel viewMealViewModel = new ViewMealViewModel(
                    meal.ID,
                    meal.Name,
                    meal.Description,
                    meal.Location,
                    _context.WeatherTypes.ToList(),
                    meal.WeatherTypeID,
                    _context.CookingMethods.ToList(),
                    meal.CookingMethodID,
                    _context.CookingMethods.ToList(),
                    meal.AltCookingMethodID,
                    _context.CookingTimes.ToList(),
                    meal.CookingTimeID,
                    _context.PrepTimes.ToList(),
                    meal.PrepTimeID);
                return View(viewMealViewModel);
            }
        }
        // GET: Meals/Create
        public IActionResult Create()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            if(userId != null)
            {
                AddMealViewModel addMealViewModel = new AddMealViewModel(
                        userId,
                       _context.WeatherTypes.ToList(),
                       _context.CookingMethods.ToList(),
                       _context.CookingMethods.ToList(),
                       _context.CookingTimes.ToList(),
                       _context.PrepTimes.ToList());

                return View(addMealViewModel);
            }
            else
                return RedirectToAction("Home/Index");

        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AltCookingMethodID,CookingMethodID,CookingTimeID,Description,Location,Name,PrepTimeID,UserID,WeatherTypeID")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AltCookingMethodID"] = new SelectList(_context.CookingMethods, "ID", "ID", meal.AltCookingMethodID);
            ViewData["CookingMethodID"] = new SelectList(_context.CookingMethods, "ID", "ID", meal.CookingMethodID);
            ViewData["CookingTimeID"] = new SelectList(_context.CookingTimes, "ID", "ID", meal.CookingTimeID);
            ViewData["PrepTimeID"] = new SelectList(_context.PrepTimes, "ID", "ID", meal.PrepTimeID);
            ViewData["WeatherTypeID"] = new SelectList(_context.WeatherTypes, "ID", "ID", meal.WeatherTypeID);
            return View(meal);
        }

        // GET: Meals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.SingleOrDefaultAsync(m => m.ID == id);
            if (meal == null)
            {
                return NotFound();
            }
            EditMealViewModel editMealViewModel = new EditMealViewModel(
                       meal.ID,
                       meal.Name,
                       meal.Description,
                       _context.WeatherTypes.ToList(),
                       meal.WeatherTypeID,
                       _context.CookingMethods.ToList(),
                       meal.CookingMethodID,
                       _context.CookingMethods.ToList(),
                       meal.AltCookingMethodID,
                       _context.CookingTimes.ToList(),
                       meal.CookingTimeID,
                       _context.PrepTimes.ToList(),
                       meal.PrepTimeID);

            _context.SaveChanges();
            return View(editMealViewModel);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AltCookingMethodID,CookingMethodID,CookingTimeID,Description,Location,Name,PrepTimeID,UserID,WeatherTypeID")] Meal meal)
        {
            if (id != meal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.ID))
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
            ViewData["AltCookingMethodID"] = new SelectList(_context.CookingMethods, "ID", "ID", meal.AltCookingMethodID);
            ViewData["CookingMethodID"] = new SelectList(_context.CookingMethods, "ID", "ID", meal.CookingMethodID);
            ViewData["CookingTimeID"] = new SelectList(_context.CookingTimes, "ID", "ID", meal.CookingTimeID);
            ViewData["PrepTimeID"] = new SelectList(_context.PrepTimes, "ID", "ID", meal.PrepTimeID);
            ViewData["WeatherTypeID"] = new SelectList(_context.WeatherTypes, "ID", "ID", meal.WeatherTypeID);
            return View(meal);
        }

        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.SingleOrDefaultAsync(m => m.ID == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Meals.SingleOrDefaultAsync(m => m.ID == id);
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.ID == id);
        }
    }
}
