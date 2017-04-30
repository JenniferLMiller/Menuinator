using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menuinator.Models
{
    public class MealMenu
    {
        public int MealID { get; set; }
        public Meal Meal { get; set; }

        public int MenuID { get; set; }
        public Menu Menu { get; set; }
    }
}
