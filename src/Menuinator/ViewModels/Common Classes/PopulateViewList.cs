using Menuinator.Models.SupportTables;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menuinator.ViewModels.Common_Classes
{
    public class PopulateViewList
    {
        //
        // populate drop downs for the "Add" view models
        //
        public static List<SelectListItem> AddViewModelList(IEnumerable<SupportTable> inputTable)
        {
            List<SelectListItem> newList = new List<SelectListItem>();

            foreach (var item in inputTable)
            {
                newList.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Description
                });
            }

            return newList;
        }

        //
        // populate drop downs for the "Edit" view models
        //
        public static List<SelectListItem> EditViewModelList(IEnumerable<SupportTable> inputTable, int currentSelection)
        {
            List<SelectListItem> newList = new List<SelectListItem>();

            //Add the currently selected item to newList first
            foreach (var item in inputTable)
            {
                if (item.ID == currentSelection)
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

        //
        // populate drop downs for the "View" (details and delete) view models
        //
        public static List<SelectListItem> View_ViewModelList(IEnumerable<SupportTable> inputTable, int currentSelection)
        {
            List<SelectListItem> newList = new List<SelectListItem>();

            //Add the currently selected item to newList first
            foreach (var item in inputTable)
            {
                if (item.ID == currentSelection)
                {
                    newList.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Description
                    });
                };
            }

            return newList;
        }


    }
}
