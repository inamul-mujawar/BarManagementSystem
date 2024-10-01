
namespace BarManagementSystem.Models
{
    public class TableOrder
    {
        public int tableId { get; set; }
        public string tableName { get; set; }
        public int menuItemId { get; set; }
        public string menuItemName { get; set; }
        public int orderItemQuantity { get; set; }
        public string menuItemQty { get; set; }
        public decimal orderItemPrice { get; set; }
        public string invoiceNumber { get; set; }
        public bool isOrderCompleted { get; set; }
    }
}