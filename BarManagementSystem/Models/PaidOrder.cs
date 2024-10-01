
namespace BarManagementSystem.Models
{
    public class PaidOrder
    {
        public int paidOrderId { get; set; }
        public int tableId { get; set; }
        public string tableName { get; set; }
        public int tableLocationId  { get; set; }
        public string tableLocation { get; set; }
        public decimal tableAmount { get; set; }
        public string timeUltilizedOnTable { get; set; }
        public string invoiceNumber { get; set; }
        public int paymentModeId { get; set; }
        public string paymentMode { get; set; }
        public string dateOfPayment { get; set; }
    }
}