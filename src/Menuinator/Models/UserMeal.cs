using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menuinator.Models
{
    public class UserMeal
    {
        public int AppUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int MealID { get; set; }
        public Meal Meal { get; set; }
    }
}
