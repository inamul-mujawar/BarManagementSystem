
namespace BarManagementSystem.Models
{
    public class OrderDetails
    {
        public int menuItemId { get; set; }
        public string menuItemName { get; set; }
        public int menuCategoryId { get; set; }
        public int tableId { get; set; }
        public int menuItemQuantity { get; set; }
        public decimal orderItemPrice { get; set; }
        public string invoiceNumber { get; set; }
        public bool isOrderCompleted { get; set; }
        public string menuItemQty { get; set; }
    }
}