using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Menuinator.ViewModels.Menu_view_models;
using System.Security.Claims;
using Menuinator.Data;


namespace Menuinator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult MainMenu()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var mealCount = 5;
            var description = "";
    //        var weatherTypeId = 0;

            if (userId != null)
            {
                AddMenuViewModel addMenuViewModel = new AddMenuViewModel(
                        description,
                        userId,
                        mealCount,
            //            weatherTypeId,
                       _context.WeatherTypes.ToList());
                return View(addMenuViewModel);
            }
            else
                return RedirectToAction("Home/Index");

          //  return View();
        }
    }
}
