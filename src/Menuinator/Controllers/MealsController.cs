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
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            if (userId != null)
            {
                var applicationDbContext = _context.Meals
                    .Where(m => m.UserID == userId)
                    .Include(m => m.AltCookingMethod)
                    .Include(m => m.CookingMethod)
                    .Include(m => m.CookingTime)
                    .Include(m => m.PrepTime)
                    .Include(m => m.WeatherType);

                return View(await applicationDbContext.ToListAsync());
            }
            return Redirect("Home/Index");
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
        public async Task<IActionResult> Create(AddMealViewModel addMealViewModel)
        {
            if (ModelState.IsValid)
            {
                WeatherType newWeatherType = _context.WeatherTypes.Single(w => w.ID == addMealViewModel.WeatherTypeID);
                CookingMethod newCookingMethod = _context.CookingMethods.Single(m => m.ID == addMealViewModel.CookingMethodID);
                CookingMethod newAltCookingMethod = _context.CookingMethods.Single(a => a.ID == addMealViewModel.AltCookingMethodID);
                CookingTime newCookingTime = _context.CookingTimes.Single(t => t.ID == addMealViewModel.CookingTimeID);
                PrepTime newPrepTime = _context.PrepTimes.Single(p => p.ID == addMealViewModel.PrepTimeID);

                //Add the new meal to the meal table
                Meal newMeal = new Meal
                {
                    Name = addMealViewModel.Name,
                    Description = addMealViewModel.Description,
                    Location = addMealViewModel.Location,
                    UserID = addMealViewModel.UserID,
                    WeatherType = newWeatherType,
                    CookingMethod = newCookingMethod,
                    AltCookingMethod = newAltCookingMethod,
                    CookingTime = newCookingTime,
                    PrepTime = newPrepTime
                };

                _context.Meals.Add(newMeal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(addMealViewModel);
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
                       meal.UserID,
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
        public async Task<IActionResult> Edit(int id, EditMealViewModel editMealViewModel)
        {
            if (id != editMealViewModel.mealID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    WeatherType newWeatherType = _context.WeatherTypes.Single(w => w.ID == editMealViewModel.WeatherTypeID);
                    CookingMethod newCookingMethod = _context.CookingMethods.Single(m => m.ID == editMealViewModel.CookingMethodID);
                    CookingMethod newAltCookingMethod = _context.CookingMethods.Single(a => a.ID == editMealViewModel.AltCookingMethodID);
                    CookingTime newCookingTime = _context.CookingTimes.Single(t => t.ID == editMealViewModel.CookingTimeID);
                    PrepTime newPrepTime = _context.PrepTimes.Single(p => p.ID == editMealViewModel.PrepTimeID);

                    //Add the new default meal to the default meal table
                    Meal editMeal = new Meal
                    {
                        ID = editMealViewModel.mealID,
                        Name = editMealViewModel.Name,
                        Description = editMealViewModel.Description,
                        Location = editMealViewModel.Location,
                        UserID = editMealViewModel.UserID,
                        WeatherType = newWeatherType,
                        CookingMethod = newCookingMethod,
                        AltCookingMethod = newAltCookingMethod,
                        CookingTime = newCookingTime,
                        PrepTime = newPrepTime
                    };

                    _context.Update(editMeal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists((editMealViewModel.mealID)))
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

            return View(editMealViewModel);
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
