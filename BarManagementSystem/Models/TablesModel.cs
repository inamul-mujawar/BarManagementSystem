
using System.Collections.Generic;

namespace BarManagementSystem.Models
{
    public class TablesModel
    {
        public TableCountInfo tableCountInfo { get; set; }
        public IEnumerable<TableLocation> listOftableLocation { get; set; }
        public IEnumerable<Tables> listOfAllTables { get; set; }

        public IEnumerable<ReserveTable> listOfReserveTables { get; set; }
    }
}