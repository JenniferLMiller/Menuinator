using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menuinator.Models
{
    public class DefaultMeal : SupportTable
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public WeatherType WeatherType { get; set; }
        public CookingMethod CookingMethod { get; set; }
        public PrepTime PrepTime { get; set; }
        public CookingTime CookingTime { get; set; }
    }    
}
