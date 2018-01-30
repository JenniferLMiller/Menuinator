using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menuinator.Models.SupportTables;

namespace Menuinator.Models
{
    public class Menu : SupportTable
    {
        public DateTime DateCreated { get; set; }
        public int mealCount { get; set; }

        public int WeatherTypeID { get; set; }
     //   public WeatherType WeatherType { get; set; }

        public string UserID { get; set; }

    }
}
