using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menuinator.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Menuinator.ViewModels
{
    public class AddMealViewModel
    {
        public int MealID { get; set; }
        public int WeatherTypeID { get; set; }
        public int CookingTimeID { get; set; }
        public int CookingMethodID { get; set; }
        public int PrepTimeID { get; set; }

        public Meal Meal { get; set; }

        [Display(Name = "This meal is best when the weather is:")]
        public List<SelectListItem> WeatherTypes { get; set; }

        [Display(Name = "This meal uses the:")]
        public List<SelectListItem> CookingMethods { get; set; }

        [Display(Name ="How much cooking time is needed?")]
        public CookingTime CookingTimes { get; set; }

        [Display(Name = "How much prep time is needed?")]
        public PrepTime PrepTimes { get; set; }

        public AddMealViewModel()
        { }

        public AddMealViewModel(Meal meal, IEnumerable<WeatherType> weatherType,
            IEnumerable<CookingMethod> cookingMethod, IEnumerable<CookingTime> cookingTime,
            IEnumerable<PrepTime> prepTime)
        {
            Meal = meal;

            // create Weather Type list
            WeatherTypes = new List<SelectListItem>();

            foreach (var item in weatherType)
            {
                WeatherTypes.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Description
                });
            }

            // create Cooking Method list
            CookingMethods = new List<SelectListItem>();

            foreach (var item in cookingMethod)
            {
                CookingMethods.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Description
                });
            }

            // create Cooking Time list
            CookingTimes = new List<SelectListItem>();

            foreach (var item in cookingTime)
            {
                CookingTimes.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Description
                });
            }

            // create Prep Time list
            PrepTimes = new List<SelectListItem>();

            foreach (var item in prepTime)
            {
                PrepTimes.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Description
                });
            }





        }
    }
}
