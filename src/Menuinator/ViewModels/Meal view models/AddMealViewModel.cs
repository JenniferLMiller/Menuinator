using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menuinator.Models;
using Menuinator.Models.SupportTables;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Menuinator.ViewModels.Common_Classes;

namespace Menuinator.ViewModels
{
    public class AddMealViewModel
    {
        [Required(ErrorMessage = "Meal name is required")]
        [Display(Name = "Meal Name:")]
        public string Name { get; set; }

        [Display(Name = "Description, sides, etc.:")]
        public string Description { get; set; }

        [Display(Name = "Recipe location - URL, cookbook, etc.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "You must be logged in to add a recipe")]
        public string UserID { get; set; }

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

        public AddMealViewModel()
        { }

        public AddMealViewModel( 
            string userId,
            IEnumerable<WeatherType> weatherType,
            IEnumerable<CookingMethod> cookingMethod,
            IEnumerable<CookingMethod> altCookingMethod,
            IEnumerable<CookingTime> cookingTime,
            IEnumerable<PrepTime> prepTime)
        {
            // include user id as foreign key to link meals with user
            UserID = userId;

            // create Weather Type list
            WeatherTypes = new List<SelectListItem>();
            WeatherTypes = PopulateViewList.AddViewModelList(weatherType);

            // create Cooking Method list
            CookingMethods = new List<SelectListItem>();
            CookingMethods = PopulateViewList.AddViewModelList(cookingMethod);

            // create Alternate Cooking Method list
            AltCookingMethods = new List<SelectListItem>();
            AltCookingMethods = PopulateViewList.AddViewModelList(altCookingMethod);

            // create Cooking Time list
            CookingTimes = new List<SelectListItem>();
            CookingTimes = PopulateViewList.AddViewModelList(cookingTime);

            // create Prep Time list
            PrepTimes = new List<SelectListItem>();
            PrepTimes = PopulateViewList.AddViewModelList(prepTime);
        }      
    }
}
