using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menuinator.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Menuinator.ViewModels
{
    public class AddDefaultMealViewModel
    {
        [Required(ErrorMessage = "Meal name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "This meal is best when the weather is:")]
        public int WeatherTypeID { get; set; }

        public List<SelectListItem> WeatherTypes { get; set; }

        [Required]
        [Display(Name = "This meal uses the:")]
        public int CookingMethodID { get; set; }

        public List<SelectListItem> CookingMethods { get; set; }

        [Required]
        [Display(Name ="How much cooking time is needed?")]
        public int CookingTimeID { get; set; }

        public List<SelectListItem> CookingTimes { get; set; }
 
        [Required]
        [Display(Name = "How much prep time is needed?")]
        public int PrepTimeID { get; set; }

        public List<SelectListItem> PrepTimes { get; set; }

        public AddDefaultMealViewModel()
        { }

        public AddDefaultMealViewModel( 
            IEnumerable<WeatherType> weatherType,
            IEnumerable<CookingMethod> cookingMethod, 
            IEnumerable<CookingTime> cookingTime,
            IEnumerable<PrepTime> prepTime)
        {
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
