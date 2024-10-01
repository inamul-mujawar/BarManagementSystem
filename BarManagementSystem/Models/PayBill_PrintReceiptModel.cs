using System.Collections.Generic;

namespace BarManagementSystem.Models
{
    public class PayBill_PrintReceiptModel
    {
        public string insertResponse { get; set; }
        public IEnumerable<OrderDetails> listOfPaidOrderDetails { get; set; }
        public string invoiceNumber { get; set; }
        public GST gstInfo { get; set; }
    }
}