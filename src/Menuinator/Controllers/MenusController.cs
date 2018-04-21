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
using Menuinator.ViewModels.Menu_view_models;
using System.Security.Claims;
using Menuinator.ViewModels.Common_Classes;

namespace Menuinator.Controllers
{
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menus.ToListAsync());
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var description = "";
            var mealCount = 5;
     //       var weatherTypeID = 0;

            if (userId != null)
            {
                AddMenuViewModel addMenuViewModel = new AddMenuViewModel(
                        userId,
                        description,
                        mealCount,
             //           weatherTypeID,
                       _context.WeatherTypes.ToList());

                return View(addMenuViewModel);
            }
            else
                return RedirectToAction("Home/Index");

        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                WeatherType newWeatherType = _context.WeatherTypes.Single(w => w.ID == addMenuViewModel.WeatherTypeID);

                Menu newMenu = new Menu
                {
                    Description = addMenuViewModel.Description,
                    UserID = User.Identity.Name,
                    WeatherType = newWeatherType,  
                    MealCount = addMenuViewModel.MealCount,
                    DateCreated = DateTime.Now
                };

                _context.Add(newMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addMenuViewModel);
        }

        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateCreated")] Menu menu)
        {
            if (id != menu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.ID))
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
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.ID == id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.ID == id);
        }
    }
}
