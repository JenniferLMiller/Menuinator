using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menuinator.Models.SupportTables
{
    public class CookingMethod : SupportTable
    {
        public static implicit operator CookingMethod(int v)
        {
            throw new NotImplementedException();
        }
    }
}
