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
    public class EditMealViewModel : AddMealViewModel
    {
        public int mealID { get; set; }
   
        public EditMealViewModel()
        { }

       public EditMealViewModel(
                int MealID,
                string MealName,
                string MealDescription,
                string MealUserID,
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
            mealID = MealID;
            Name = MealName;
            Description = MealDescription;
            UserID = MealUserID;

            // create Weather Type list
            WeatherTypes = new List<SelectListItem>();
            WeatherTypes = PopulateViewList.EditViewModelList(weatherType, WeatherTypeID);

            // create Cooking Method list
            CookingMethods = new List<SelectListItem>();
            CookingMethods = PopulateViewList.EditViewModelList(cookingMethod, CookingMethodID);

            // create Alternate Cooking Method list
            AltCookingMethods = new List<SelectListItem>();
            AltCookingMethods = PopulateViewList.EditViewModelList(altCookingMethod, AltCookingMethodID);

            // create Cooking Time list
            CookingTimes = new List<SelectListItem>();
            CookingTimes = PopulateViewList.EditViewModelList(cookingTime, CookingTimeID);

            // create Prep Time list
            PrepTimes = new List<SelectListItem>();
            PrepTimes = PopulateViewList.EditViewModelList(prepTime, PrepTimeID);
        }
    }
}
