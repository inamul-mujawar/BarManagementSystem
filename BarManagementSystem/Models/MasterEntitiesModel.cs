
using System.Collections.Generic;

namespace BarManagementSystem.Models
{
    public class MasterEntitiesModel
    {
        public IEnumerable<MenuCategory> listOfMenuCategory{ get; set; }
        public IEnumerable<PaymentMode> listOfPaymentMode { get; set; }
        public IEnumerable<Admin> listOfAdminDetails { get; set; }
        public IEnumerable<TableLocation> listOfTableLocation { get; set; }
        public IEnumerable<GST> listOfGSTDetails { get; set; }
        public IEnumerable<Tables> listOfTables { get; set; }
        public IEnumerable<PriceInput> listOfPriceInput { get; set; }
    }
}