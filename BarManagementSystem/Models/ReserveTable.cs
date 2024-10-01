
namespace BarManagementSystem.Models
{
    public class ReserveTable
    {
        public int reserveTableId { get; set; }
        public int tableId { get; set; }
        public string tableName { get; set; }
        public bool isReserved { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int partySize { get; set; }
        public string timeOfReserve { get; set; }
        public string notes { get; set; }
        public bool isreserveOrderCompleted { get; set; }
        public string dateOfReserve { get; set; }
        public bool isReservedCustomerShowedUp { get; set; }
    }
}