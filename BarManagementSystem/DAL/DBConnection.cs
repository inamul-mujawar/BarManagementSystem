using System.Configuration;
using System.Data.SqlClient;

namespace BarManagementSystem.DAL
{
    public class DBConnection
    {
        protected SqlConnection con = null;

        public DBConnection()
        {
            string query = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ToString();         
            con = new SqlConnection(query);
        }

        protected string GetDBName()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder(ConStr);
            return Builder.InitialCatalog;
        }
    }
}