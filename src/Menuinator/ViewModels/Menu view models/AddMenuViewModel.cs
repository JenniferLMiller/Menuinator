using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menuinator.Models.SupportTables;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Menuinator.ViewModels.Common_Classes;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Soap;


namespace Menuinator.ViewModels.Menu_view_models
{
    public class AddMenuViewModel
    {
        [Display(Name = "Description (optional)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must be logged in to create a menu")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "The number of meals to plan is required")]
        [Display(Name = "How many meals are you planning?")]
        public int MealCount { get; set; }

        [Required]
        [Display(Name = "This meal is best when the weather is:")]
        public int WeatherTypeID { get; set; }

        public List<SelectListItem> WeatherTypes { get; set; }

        public DateTime DateCreated { get; set; }

        public AddMenuViewModel()
        { }

        //Create a new Menu
        public AddMenuViewModel(
            string description,
            string userId,
            int mealCount,
            int weatherTypeID,
            IEnumerable<WeatherType> weatherType)
        {    
            Description = description;
            MealCount = mealCount;

            // include user id as foreign key to link meals with user
            UserID = userId;

            // include Weather type id as a foreign key to the weather type table
            WeatherTypeID = weatherTypeID;

            // create Weather Type list
            WeatherTypes = new List<SelectListItem>();
            WeatherTypes = PopulateViewList.AddViewModelList(weatherType);

            DateCreated = DateTime.Now;
        }
    }
}
