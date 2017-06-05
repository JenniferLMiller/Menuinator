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
    public class ViewMealViewModel : AddMealViewModel
    {
        public int MealID { get; set; }
   
        public ViewMealViewModel()
        { }

       public ViewMealViewModel(
                int mealID,
                string mealName,
                string mealDescription,
                string mealLocation,
                IEnumerable<WeatherType> weatherType,
                int WeatherTypeID,
                IEnumerable<CookingMethod> cookingMethod,
                int CookingMethodID,
                IEnumerable<CookingMethod> altCookingMethod,
                int AltCookingMethodID,
                IEnumerable<CookingTime> cookingTime,
                int CookingTimeID,
                IEnumerable<PrepTime> prepTime,
                int PrepTimeID)
        {
            MealID = mealID;
            Name = mealName;
            Description = mealDescription;

            // create Weather Type list
            WeatherTypes = new List<SelectListItem>();
            WeatherTypes = PopulateViewList.View_ViewModelList(weatherType, WeatherTypeID);

            // create Cooking Method list
            CookingMethods = new List<SelectListItem>();
            CookingMethods = PopulateViewList.View_ViewModelList(cookingMethod, CookingMethodID);

            // create Alternate Cooking Method list
            AltCookingMethods = new List<SelectListItem>();
            AltCookingMethods = PopulateViewList.View_ViewModelList(altCookingMethod, AltCookingMethodID);

            // create Cooking Time list
            CookingTimes = new List<SelectListItem>();
            CookingTimes = PopulateViewList.View_ViewModelList(cookingTime, CookingTimeID);

            // create Prep Time list
            PrepTimes = new List<SelectListItem>();
            PrepTimes = PopulateViewList.View_ViewModelList(prepTime, PrepTimeID);
        }
    }
}
