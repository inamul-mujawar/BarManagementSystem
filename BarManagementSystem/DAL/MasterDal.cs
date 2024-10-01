using BarManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BarManagementSystem.DAL
{
    public class MasterDal : DBConnection
    {
        public int AddMenuItems(MenuItems menuItem)
        {
            try
            {
                SqlCommand _command = new SqlCommand("AddMenuItems", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@menuCategoryId", menuItem.menuCategoryId);
                _command.Parameters.AddWithValue("@itemName", menuItem.menuItemName);
                _command.Parameters.AddWithValue("@itemPrice", menuItem.itemPrice);
                _command.Parameters.AddWithValue("@halfItemPrice", menuItem.halfItemPrice);
                _command.Parameters.AddWithValue("@thirtyMLPrice", menuItem.thirtyMLPrice);
                _command.Parameters.AddWithValue("@sixtyMLPrice", menuItem.sixtyMLPrice);
                _command.Parameters.AddWithValue("@ninetyMLPrice", menuItem.ninetyMLPrice);
                _command.Parameters.AddWithValue("@quarterMLPrice", menuItem.quarterMLPrice);


                int insertValue = _command.ExecuteNonQuery();
                return insertValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateMenuItems(MenuItems menuItem)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateMenuItems", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@menuItemId", menuItem.menuItemId);
                _command.Parameters.AddWithValue("@menuCategoryId", menuItem.menuCategoryId);
                _command.Parameters.AddWithValue("@itemName", menuItem.menuItemName);
                _command.Parameters.AddWithValue("@itemPrice", menuItem.itemPrice);
                _command.Parameters.AddWithValue("@halfItemPrice", menuItem.halfItemPrice);
                _command.Parameters.AddWithValue("@thirtyMLPrice", menuItem.thirtyMLPrice);
                _command.Parameters.AddWithValue("@sixtyMLPrice", menuItem.sixtyMLPrice);
                _command.Parameters.AddWithValue("@ninetyMLPrice", menuItem.ninetyMLPrice);
                _command.Parameters.AddWithValue("@quarterMLPrice", menuItem.quarterMLPrice);


                int updateValue = _command.ExecuteNonQuery();
                return updateValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteMenuItem(int menuItemId)
        {
            try
            {
                SqlCommand _command = new SqlCommand("DeleteMenuItem", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@menuItemId", menuItemId);

                int deleteValue = _command.ExecuteNonQuery();
                return deleteValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public decimal GetTotalCounterAmount()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetTotalCounterAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //List<PaidOrder> paidOrderList = new List<PaidOrder>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    decimal tableAmount = Convert.ToDecimal(reader["TotalCounterAmount"]);
                    return tableAmount;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int AddAdminUser(Admin admin)
        {
            try
            {
                SqlCommand _command = new SqlCommand("AddAdminUser", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@adminUserName", admin.userName);
                _command.Parameters.AddWithValue("@adminPassword", admin.password);
                _command.Parameters.AddWithValue("@isAdministrator", admin.isAdminstrator);

                int insertValue = _command.ExecuteNonQuery();
                return insertValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateAdminUser(Admin admin)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateAdminUser", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@adminId", admin.adminId);
                _command.Parameters.AddWithValue("@adminUserName", admin.userName);
                _command.Parameters.AddWithValue("@adminPassword", admin.password);
                _command.Parameters.AddWithValue("@isAdministrator", admin.isAdminstrator);

                int updateValue = _command.ExecuteNonQuery();
                return updateValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteAdminUser(Admin admin)
        {
            try
            {
                SqlCommand _command = new SqlCommand("DeleteAdminUser", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@adminId", admin.adminId);

                int deleteValue = _command.ExecuteNonQuery();
                return deleteValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int AddMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                SqlCommand _command = new SqlCommand("AddMenuCategory", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@menuCategory", menuCategory.menuCategory);
                _command.Parameters.AddWithValue("@priceInputId", menuCategory.priceInputId);

                int insertValue = _command.ExecuteNonQuery();
                return insertValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateMenuCategory", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@menuCategoryId", menuCategory.menuCategoryId);
                _command.Parameters.AddWithValue("@menuCategory", menuCategory.menuCategory);
                _command.Parameters.AddWithValue("@priceInputId", menuCategory.priceInputId);

                int updateValue = _command.ExecuteNonQuery();
                return updateValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                SqlCommand _command = new SqlCommand("DeleteMenuCategory", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@menuCategoryId", menuCategory.menuCategoryId);

                int deleteValue = _command.ExecuteNonQuery();
                return deleteValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int AddPaymentMode(PaymentMode paymentMode)
        {
            try
            {
                SqlCommand _command = new SqlCommand("AddPaymentMode", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@paymentMode", paymentMode.paymentMode);

                int insertValue = _command.ExecuteNonQuery();
                return insertValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdatePaymentMode(PaymentMode paymentMode)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdatePaymentMode", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@paymentModeId", paymentMode.paymentModeId);
                _command.Parameters.AddWithValue("@paymentMode", paymentMode.paymentMode);

                int updateValue = _command.ExecuteNonQuery();
                return updateValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeletePaymentMode(PaymentMode paymentMode)
        {
            try
            {
                SqlCommand _command = new SqlCommand("DeletePaymentMode", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@paymentModeId", paymentMode.paymentModeId);

                int deleteValue = _command.ExecuteNonQuery();
                return deleteValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int AddTableLocation(TableLocation tableLocation)
        {
            try
            {
                SqlCommand _command = new SqlCommand("AddTableLocation", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableLocation", tableLocation.tableLocation);

                int insertValue = _command.ExecuteNonQuery();
                return insertValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateTableLocation(TableLocation tableLocation)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateTableLocation", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableLocationId", tableLocation.tableLocationId);
                _command.Parameters.AddWithValue("@tableLocation", tableLocation.tableLocation);

                int updateValue = _command.ExecuteNonQuery();
                return updateValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteTableLocation(TableLocation tableLocation)
        {
            try
            {
                SqlCommand _command = new SqlCommand("DeleteTableLocation", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableLocationId", tableLocation.tableLocationId);

                int deleteValue = _command.ExecuteNonQuery();
                return deleteValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateGSTInfo(GST gst)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateGSTInfo", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@gstId", gst.gstId);
                _command.Parameters.AddWithValue("@cgst", gst.cgst);
                _command.Parameters.AddWithValue("@sgst", gst.sgst);
                _command.Parameters.AddWithValue("@vat", gst.vat);

                int updateValue = _command.ExecuteNonQuery();
                return updateValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int AddTableInfo(Tables table)
        {
            try
            {
                SqlCommand _command = new SqlCommand("AddTables", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableName", table.tableName);
                _command.Parameters.AddWithValue("@tableLocationId", table.tableLocationId);

                int insertValue = _command.ExecuteNonQuery();
                return insertValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateTableInfo(Tables table)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateTableInfo", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", table.tableId);
                _command.Parameters.AddWithValue("@tableName", table.tableName);
                _command.Parameters.AddWithValue("@tableLocationId", table.tableLocationId);

                int updateValue = _command.ExecuteNonQuery();
                return updateValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteTable(Tables table)
        {
            try
            {
                SqlCommand _command = new SqlCommand("DeleteTable", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", table.tableId);

                int deleteValue = _command.ExecuteNonQuery();
                return deleteValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void BackUpServerDbToLocalPath(BackUpDatabase backDB)
        {
            try
            {                
                string BackUpquery = string.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", backDB.dbName, backDB.filePath+@"\BackUpDBFile.bak");
                using (var command = new SqlCommand(BackUpquery, con))
                {
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public string NameOfServerDatabase()
        {
            try
            {
                return GetDBName();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

    }
}