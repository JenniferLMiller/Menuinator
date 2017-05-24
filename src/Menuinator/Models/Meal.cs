using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menuinator.Models.SupportTables;

namespace Menuinator.Models
{
    public class Meal : SupportTable
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public int WeatherTypeID { get; set; }
        public WeatherType WeatherType { get; set; }

        public int CookingMethodID { get; set; }
        public CookingMethod CookingMethod { get; set; }

        public int AltCookingMethodID { get; set; }
        public CookingMethod AltCookingMethod { get; set; }

        public int PrepTimeID { get; set; }
        public PrepTime PrepTime { get; set; }

        public int CookingTimeID { get; set; }
        public CookingTime CookingTime { get; set; }

        public string UserID { get; set; }
    }
}
