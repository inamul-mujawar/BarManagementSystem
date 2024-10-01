
namespace BarManagementSystem.Models
{
    public class MenuItems
    {
        public int menuItemId { get; set; }
        public int menuCategoryId { get; set; }
        public string menuCategory { get; set; }
        public string menuItemName { get; set; }
        public decimal itemPrice { get; set; }
        public decimal halfItemPrice { get; set; }
        public decimal thirtyMLPrice { get; set; }
        public decimal sixtyMLPrice { get; set; }
        public decimal ninetyMLPrice { get; set; }
        public decimal quarterMLPrice { get; set; }
        public string  dateOfCreation { get; set; }
        public string dateOfUpdation { get; set; }
        public int priceInput { get; set; }

    }
}