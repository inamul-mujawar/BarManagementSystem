
namespace BarManagementSystem.Models
{
    public class Tables
    {
        public int tableId { get; set; }
        public string tableName { get; set; }
        public int tableLocationId { get; set; }
        public string tableLocation { get; set; }
        public bool isOccupied { get; set; }
        public bool isReserved { get; set; }
        public bool isRecieptPrinted { get; set; }
        public string timeSinceIsOccupied { get; set; }
        public decimal tableAmount { get; set; }
        public int countOnReceiptPrinted { get; set; }
        public string timeOfReserve { get; set; }
        // to map in table order js file
        public bool isReservedCustomerShowedUp { get; set; }

    }
}