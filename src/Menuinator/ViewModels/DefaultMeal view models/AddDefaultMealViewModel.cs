using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menuinator.Models;
using Menuinator.Models.SupportTables;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Menuinator.ViewModels
{
    public class AddDefaultMealViewModel
    {
        [Required(ErrorMessage = "Meal name is required")]
        [Display(Name = "Meal Name:")]
        public string Name { get; set; }

        [Display(Name = "Description, sides, etc.:")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "This meal is best when the weather is:")]
        public int WeatherTypeID { get; set; }

        public List<SelectListItem> WeatherTypes { get; set; }

        [Required]
        [Display(Name = "This meal uses the:")]
        public int CookingMethodID { get; set; }

        public List<SelectListItem> CookingMethods { get; set; }

        [Display(Name = "Alternative or additional cooking appliance:")]
        public int AltCookingMethodID { get; set; }

        public List<SelectListItem> AltCookingMethods { get; set; }

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
            IEnumerable<CookingMethod> altCookingMethod,
            IEnumerable<CookingTime> cookingTime,
            IEnumerable<PrepTime> prepTime)
        {
            // create Weather Type list
            WeatherTypes = new List<SelectListItem>();
            WeatherTypes = PopulateList(weatherType);

            // create Cooking Method list
            CookingMethods = new List<SelectListItem>();
            CookingMethods = PopulateList(cookingMethod);

            // create Alternate Cooking Method list
            AltCookingMethods = new List<SelectListItem>();
            AltCookingMethods = PopulateList(altCookingMethod);

            // create Cooking Time list
            CookingTimes = new List<SelectListItem>();
            CookingTimes = PopulateList(cookingTime);

            // create Prep Time list
            PrepTimes = new List<SelectListItem>();
            PrepTimes = PopulateList(prepTime);
        }

        private List<SelectListItem> PopulateList(IEnumerable<SupportTable> inputTable)
        {
            List<SelectListItem> newList = new List<SelectListItem>();

            foreach (var item in inputTable)
            {
                newList.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Description
                });
            }

            return newList;
        }
    }
}
