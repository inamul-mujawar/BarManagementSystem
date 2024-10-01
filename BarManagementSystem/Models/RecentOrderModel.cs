using System.Collections.Generic;

namespace BarManagementSystem.Models
{
    public class RecentOrderModel
    {
        public IEnumerable<PaidOrder> listOfPaidOrderDetails { get; set; }
        public decimal totalCounterAmount { get; set; }
    }
}