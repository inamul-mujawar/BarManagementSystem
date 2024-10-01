
using System.Collections.Generic;

namespace BarManagementSystem.Models
{
    public class TableOrderModel
    {
        public IEnumerable<MenuCategory> listOfMenuCategories { get; set; }
        public IEnumerable<TableOrder> listOfMenuItemsOrdered { get; set; }
        public Tables tableOrderInfo { get; set; }

        public IEnumerable<MenuItems> listOfMenuItems { get; set; }
        public ReserveTable reserveTableInfo { get; set; }
        public GST gstInfo { get; set; }
    }
}