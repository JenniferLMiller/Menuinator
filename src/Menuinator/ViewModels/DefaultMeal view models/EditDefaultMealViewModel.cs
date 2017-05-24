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
    public class EditDefaultMealViewModel : AddDefaultMealViewModel
    {
        public int DefaultMealID { get; set; }
   
        public EditDefaultMealViewModel()
        { }

       public EditDefaultMealViewModel(
                int defaultMealID,
                string defaultMealName,
                string defaultMealDescription,
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
            DefaultMealID = defaultMealID;
            Name = defaultMealName;
            Description = defaultMealDescription;

            // create Weather Type list
            WeatherTypes = new List<SelectListItem>();
            WeatherTypes = PopulateList(weatherType, WeatherTypeID);

            // create Cooking Method list
            CookingMethods = new List<SelectListItem>();
            CookingMethods = PopulateList(cookingMethod, CookingMethodID);

            // create Alternate Cooking Method list
            AltCookingMethods = new List<SelectListItem>();
            AltCookingMethods = PopulateList(altCookingMethod, AltCookingMethodID);

            // create Cooking Time list
            CookingTimes = new List<SelectListItem>();
            CookingTimes = PopulateList(cookingTime, CookingTimeID);

            // create Prep Time list
            PrepTimes = new List<SelectListItem>();
            PrepTimes = PopulateList(prepTime, PrepTimeID);
        }

        private List<SelectListItem> PopulateList(IEnumerable<SupportTable> inputTable, int currentSelection)
        {
            List<SelectListItem> newList = new List<SelectListItem>();

            //Add the currently selected item to newList first
            foreach (var item in inputTable)
            {
                if(item.ID == currentSelection)
                {
                    newList.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Description
                    });
                };
            }
            //Add all of the items in inputTable in order including the previously selected item
            foreach (var item in inputTable)
            {
                if (item.ID != currentSelection)
                {
                    newList.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Description
                    });
                }
            }

            return newList;
        }
    }
}
