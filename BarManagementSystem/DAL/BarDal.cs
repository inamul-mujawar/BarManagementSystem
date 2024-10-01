using BarManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BarManagementSystem.DAL
{
    public class BarDal : DBConnection
    {
        public List<Admin> ListOfAdminDetails()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfAdminInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<Admin> adminList = new List<Admin>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Admin admin = new Admin()
                    {
                        adminId = Convert.ToInt32(reader["AdminId"]),
                        userName = reader["AdminUserName"].ToString(),
                        password = reader["AdminPassword"].ToString(),
                        isAdminstrator= Convert.ToBoolean(reader["IsAdministrator"])

                    };
                    adminList.Add(admin);
                }
                return adminList;
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

        public List<Tables> ListOfTableInfo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfTableInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<Tables> tableInfoList = new List<Tables>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tables table = new Tables()
                    {
                        tableId = Convert.ToInt32(reader["TableId"]),
                        tableName = reader["TableName"].ToString(),
                        tableLocationId = Convert.ToInt32(reader["TableLocationId"]),
                        tableLocation = reader["TableLocation"].ToString(),
                        isReserved = Convert.ToBoolean(reader["IsReserved"]),
                        isOccupied = Convert.ToBoolean(reader["IsOccupied"]),
                        isRecieptPrinted = Convert.ToBoolean(reader["IsReceiptPrinted"]),
                        timeSinceIsOccupied = reader["TimeSinceTableIsOccupied"].ToString(),
                        timeOfReserve = reader["TimeOfReserve"].ToString(),
                        tableAmount = Convert.ToDecimal(reader["TableAmount"]),
                         countOnReceiptPrinted = Convert.ToInt32(reader["CountOnReceiptPrinted"]),
                         isReservedCustomerShowedUp = Convert.ToBoolean(reader["IsReservedCustomerHere"])
                    };
                    tableInfoList.Add(table);
                }
                return tableInfoList;
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

        public TableCountInfo TablesStatusInfo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetTablesStatusInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                TableCountInfo tableCountInfo = null;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tableCountInfo = new TableCountInfo()
                    {
                        isReservedTables = Convert.ToInt32(reader["CountOnIsReserved"]),
                        isEmptyTables = Convert.ToInt32(reader["CountOnIsEmpty"]),
                        isRunningTables = Convert.ToInt32(reader["CountOnIsOccupied"]),
                        isReceiptPrintedTables = Convert.ToInt32(reader["IsReceiptPrinted"]),

                    };                  
                }
                return tableCountInfo;
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

        public List<PriceInput> ListOfPriceInput()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfPriceInput", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<PriceInput> priceInputList = new List<PriceInput>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PriceInput priceInput = new PriceInput()
                    {
                        priceInputId = Convert.ToInt32(reader["PriceInputId"]),
                        priceInput = Convert.ToInt32(reader["PriceInput"])

                    };
                    priceInputList.Add(priceInput);
                }
                return priceInputList;
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

        public List<MenuCategory> ListOfMenuCategory()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfMenuCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<MenuCategory> menuCategoryList = new List<MenuCategory>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MenuCategory menuCategory = new MenuCategory()
                    {
                        menuCategoryId = Convert.ToInt32(reader["MenuCategoryId"]),
                        menuCategory = reader["MenuCategory"].ToString(),
                        priceInputId = Convert.ToInt32(reader["PriceInputId"]),
                        priceInput = Convert.ToInt32(reader["PriceInput"])

                    };
                    menuCategoryList.Add(menuCategory);
                }
                return menuCategoryList;
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

        public List<TableLocation> ListOfTableLocation()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfTableLocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<TableLocation> tableLocationList = new List<TableLocation>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TableLocation tableLocation = new TableLocation()
                    {
                        tableLocationId = Convert.ToInt32(reader["TableLocationId"]),
                        tableLocation = reader["TableLocation"].ToString()

                    };
                    tableLocationList.Add(tableLocation);
                }
                return tableLocationList;
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

        public List<PaymentMode> ListOfPaymentMode()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfPaymentMode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<PaymentMode> paymentModeList = new List<PaymentMode>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaymentMode paymentMode = new PaymentMode()
                    {
                        paymentModeId = Convert.ToInt32(reader["PaymentModeId"]),
                        paymentMode = reader["PaymentMode"].ToString()

                    };
                    paymentModeList.Add(paymentMode);
                }
                return paymentModeList;
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

        public List<GST> ListOfGSTInfo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfGST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<GST> gstList = new List<GST>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GST gst = new GST()
                    {
                        gstId = Convert.ToInt32(reader["GSTId"]),
                        cgst = Convert.ToDecimal(reader["CGST"]),
                        sgst = Convert.ToDecimal(reader["SGST"]),
                        vat = Convert.ToDecimal(reader["VAT"])

                    };
                    gstList.Add(gst);
                }
                return gstList;
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

        public List<TableOrder> ListOfTableOrders(int tableId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfTableOrders", con);
                cmd.Parameters.AddWithValue("@tableId", tableId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<TableOrder> tableOrdersList = new List<TableOrder>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TableOrder tableOrder = new TableOrder()
                    {
                        tableId = Convert.ToInt32(reader["TableId"]),
                        tableName = reader["TableName"].ToString(),
                        menuItemId = Convert.ToInt32(reader["MenuItemId"]),
                        menuItemName = reader["ItemName"].ToString(),
                        orderItemQuantity = Convert.ToInt32(reader["OrderItemQuantity"]),
                        orderItemPrice = Convert.ToDecimal(reader["OrderItemPrice"]),
                        invoiceNumber = reader["InvoiceNumber"].ToString(),
                        isOrderCompleted = Convert.ToBoolean(reader["IsOrderCompleted"]),
                        menuItemQty = reader["MenuItemQuantity"].ToString()                 
                    };
                    tableOrdersList.Add(tableOrder);
                }
                return tableOrdersList;
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

        public List<MenuItems> ListOfMenuItems()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfMenuItems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<MenuItems> menuItemsList = new List<MenuItems>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MenuItems menuItem = new MenuItems()
                    {
                        menuItemId = Convert.ToInt32(reader["MenuItemId"]),
                        menuCategoryId = Convert.ToInt32(reader["MenuCategoryId"]),
                        menuCategory = reader["MenuCategory"].ToString(),
                        menuItemName = reader["ItemName"].ToString(),
                        itemPrice = Convert.ToDecimal(reader["ItemPrice"]),
                        halfItemPrice = Convert.ToDecimal(reader["HalfItemPrice"]),
                        thirtyMLPrice = Convert.ToDecimal(reader["ThirtyMLPrice"]),
                        sixtyMLPrice = Convert.ToDecimal(reader["SixtyMLPrice"]),
                        ninetyMLPrice = Convert.ToDecimal(reader["NinetyMLPrice"]),
                        quarterMLPrice = Convert.ToDecimal(reader["QuarterMLPrice"]),
                        dateOfCreation = reader["DateOfCreation"].ToString(),
                        dateOfUpdation = reader["DateOfUpdation"].ToString(),
                        priceInput = Convert.ToInt32(reader["PriceInput"])

                    };
                    menuItemsList.Add(menuItem);
                }
                return menuItemsList;
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

        public string NextInvoiceNumber()
        {
            try
            {
                SqlCommand _command = new SqlCommand("GetNextOrderInvoiceNumber", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();

                //List<ProductPurchaseCash> productPurchaseCashList = new List<ProductPurchaseCash>();
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    NextRefNumber nextNumber = new NextRefNumber()
                    {
                        InvoiceNumber = reader["NextInvoiceNumber"].ToString()
                    };
                    return nextNumber.InvoiceNumber;
                }
                return null;

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

        public int ChangeStatusOfTableOnAddingMenuItemToCart(TableOrder obj)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateTableStatusInfo", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", obj.tableId);
                _command.Parameters.AddWithValue("@itemPrice", obj.orderItemPrice);

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

        public List<PaidOrder> ListOfRecentOrdersOverview()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetRecentOrdersOverview", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<PaidOrder> paidOrderList = new List<PaidOrder>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaidOrder paidOrder = new PaidOrder()
                    {
                        paidOrderId = Convert.ToInt32(reader["PaidOrderId"]),
                        tableId = Convert.ToInt32(reader["TableId"]),
                        tableName = reader["TableName"].ToString(),
                        tableLocationId = Convert.ToInt32(reader["TableLocationId"]),
                        tableLocation = reader["TableLocation"].ToString(),
                        tableAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        timeUltilizedOnTable = reader["TimeUtilizedOnTable"].ToString(),
                        paymentModeId = Convert.ToInt32(reader["PaymentModeId"]),
                        paymentMode = reader["PaymentMode"].ToString(),
                        dateOfPayment = reader["DateOfPayment"].ToString(),
                        invoiceNumber = reader["InvoiceNumber"].ToString()
                    };
                    paidOrderList.Add(paidOrder);
                }
                return paidOrderList;
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

        public List<OrderDetails> ListOfOrderDetails()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetRecentOrdersDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<OrderDetails> orderList = new List<OrderDetails>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetails order = new OrderDetails()
                    {
                        menuItemId = Convert.ToInt32(reader["MenuItemId"]),
                        menuItemName = reader["ItemName"].ToString(),
                        menuCategoryId = Convert.ToInt32(reader["MenuCategoryId"]),
                        tableId = Convert.ToInt32(reader["TableId"]),
                        menuItemQuantity = Convert.ToInt32(reader["OrderItemQuantity"]),
                        orderItemPrice = Convert.ToDecimal(reader["OrderItemPrice"]),
                        isOrderCompleted = Convert.ToBoolean(reader["IsOrderCompleted"]),
                        invoiceNumber = reader["InvoiceNumber"].ToString(),
                        menuItemQty = reader["MenuItemQuantity"].ToString()
                    };
                    orderList.Add(order);
                }
                return orderList;
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

        public int AddMenuItemToCart(TableOrder obj)
        {
            try
            {
                if (ChangeStatusOfTableOnAddingMenuItemToCart(obj) > 0)
                {
                    SqlCommand _command = new SqlCommand("AddMenuItemToCart", con);
                    _command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    _command.Parameters.AddWithValue("@tableId", obj.tableId);
                    _command.Parameters.AddWithValue("@menuItemId", obj.menuItemId);
                    _command.Parameters.AddWithValue("@orderItemQuantity", obj.orderItemQuantity);
                    _command.Parameters.AddWithValue("@orderItemPrice", obj.orderItemPrice);
                    _command.Parameters.AddWithValue("@invoiceNumber", obj.invoiceNumber);
                    _command.Parameters.AddWithValue("@menuItemQty", obj.menuItemQty);

                    int insertValue = _command.ExecuteNonQuery();

                    return insertValue;
                }
                else
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

        public int UpdateMenuItemFromCart(TableOrder obj)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateMenuItemFromCart", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", obj.tableId);
                _command.Parameters.AddWithValue("@menuItemId", obj.menuItemId);
                _command.Parameters.AddWithValue("@menuItemQuantity", obj.orderItemQuantity);
                _command.Parameters.AddWithValue("@orderItemPrice", obj.orderItemPrice);
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

        public int DeleteMenuItemFromCart(TableOrder obj)
        {
            try
            {
                SqlCommand _command = new SqlCommand("DeleteMenuItemFromCart", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", obj.tableId);
                _command.Parameters.AddWithValue("@menuItemId", obj.menuItemId);
                _command.Parameters.AddWithValue("@menuItemQty", obj.menuItemQty);
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

        public int PrintTableReceipt(int tableId)
        {
            try
            {
                SqlCommand _command = new SqlCommand("PrintTableReceipt", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", tableId);

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

        public int PayTableBill(PaidOrder obj)
        {
            try
            {
                SqlCommand _command = new SqlCommand("PayTableBill", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", obj.tableId);
                _command.Parameters.AddWithValue("@tableAmount", obj.tableAmount);
                _command.Parameters.AddWithValue("@invoiceNumber", obj.invoiceNumber);
                _command.Parameters.AddWithValue("@paymentModeId", obj.paymentModeId);


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

        public List<PaidOrder> GetFiltredAllOrdersOverview(string fromDate,string toDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetFiltredAllOrdersOverview", con);
                cmd.Parameters.AddWithValue("@startDate", fromDate);
                cmd.Parameters.AddWithValue("@endDate", toDate);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<PaidOrder> paidOrderList = new List<PaidOrder>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaidOrder paidOrder = new PaidOrder()
                    {
                        paidOrderId = Convert.ToInt32(reader["PaidOrderId"]),
                        tableId = Convert.ToInt32(reader["TableId"]),
                        tableName = reader["TableName"].ToString(),
                        tableLocation = reader["TableLocation"].ToString(),
                        tableAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        timeUltilizedOnTable = reader["TimeUtilizedOnTable"].ToString(),
                        paymentModeId = Convert.ToInt32(reader["PaymentModeId"]),
                        paymentMode = reader["PaymentMode"].ToString(),
                        dateOfPayment = reader["DateOfPayment"].ToString(),
                        invoiceNumber = reader["InvoiceNumber"].ToString()
                    };
                    paidOrderList.Add(paidOrder);
                }
                return paidOrderList;
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

        public int ReserveTable(ReserveTable obj)
        {
            try
            {
                    SqlCommand _command = new SqlCommand("ReserveTableFor", con);
                    _command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    _command.Parameters.AddWithValue("@tableId", obj.tableId);
                    _command.Parameters.AddWithValue("@name", obj.name);
                    _command.Parameters.AddWithValue("@phone", obj.phone);
                    _command.Parameters.AddWithValue("@partySize", obj.partySize);
                    _command.Parameters.AddWithValue("@timeOfReserve", obj.timeOfReserve);
                    _command.Parameters.AddWithValue("@notes", obj.notes);

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

        public int ChangeStatusOfReserveTable(ReserveTable obj)
        {
            try
            {
                SqlCommand _command = new SqlCommand("UpdateReserveTableStatusInfo", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", obj.tableId);
                _command.Parameters.AddWithValue("@reserveTableId", obj.reserveTableId);

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

        public List<ReserveTable> GetListOfReservedTableDetails()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetListOfReservedTableDetails", con);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                List<ReserveTable> reserveTableList = new List<ReserveTable>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReserveTable reserveTable = new ReserveTable()
                    {
                        reserveTableId = Convert.ToInt32(reader["ReserveTableId"]),
                        tableId = Convert.ToInt32(reader["TableId"]),
                        tableName = reader["TableName"].ToString(),
                        isReserved = Convert.ToBoolean(reader["IsReserved"]),
                        name = reader["Name"].ToString(),
                        phone = reader["Phone"].ToString(),
                        partySize = Convert.ToInt32(reader["PartySize"]),
                        timeOfReserve = reader["TimeOfReserve"].ToString(),
                        notes = reader["Notes"].ToString(),
                        isreserveOrderCompleted = Convert.ToBoolean(reader["IsReserveOrderCompleted"]),
                        isReservedCustomerShowedUp = Convert.ToBoolean(reader["IsReserveCustomerHere"]),
                        dateOfReserve = reader["DateOfReserve"].ToString(),
                    };
                    reserveTableList.Add(reserveTable);
                }
                return reserveTableList;
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

        public int ReservedCustomerShowedUp(ReserveTable obj)
        {
            try
            {
                SqlCommand _command = new SqlCommand("ReservedCustomerShowedUpStatus", con);
                _command.CommandType = CommandType.StoredProcedure;
                con.Open();
                _command.Parameters.AddWithValue("@tableId", obj.tableId);
                _command.Parameters.AddWithValue("@reserveTableId", obj.reserveTableId);

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

    }
}