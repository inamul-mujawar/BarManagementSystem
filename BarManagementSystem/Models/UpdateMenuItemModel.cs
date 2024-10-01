
using System.Collections.Generic;

namespace BarManagementSystem.Models
{
    public class UpdateMenuItemModel
    {
        public IEnumerable<MenuCategory> listOfMenuCategory { get; set; }
        public IEnumerable<MenuItems> listOfMenuItems { get; set; }
    }
}