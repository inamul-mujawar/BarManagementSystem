using BarManagementSystem.DAL;
using BarManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BarManagementSystem.Controllers
{
    public class BarController : Controller
    {
        BarDal barDal = new BarDal();

        //[Route("")]
        //[Route("tables")]
        [Authorize]
        public ActionResult Tables()
        {
            TablesModel tablesModel = new TablesModel();
            tablesModel.tableCountInfo = barDal.TablesStatusInfo();          
            tablesModel.listOftableLocation = barDal.ListOfTableLocation(); 
            tablesModel.listOfAllTables = barDal.ListOfTableInfo();
            return View(tablesModel);
        }

        //[Route("tableorders")] onclick="location.href='/tableorders?tableId=@item.tableId';" 
        [Authorize]
        public ActionResult TableOrders(int tableId)
        {
            TableOrderModel tableOrderModel = new TableOrderModel();
            tableOrderModel.listOfMenuCategories = barDal.ListOfMenuCategory();
            tableOrderModel.listOfMenuItemsOrdered = barDal.ListOfTableOrders(tableId);
            tableOrderModel.tableOrderInfo = barDal.ListOfTableInfo().Where(x => x.tableId == tableId).FirstOrDefault();

            if (tableOrderModel.tableOrderInfo.isReserved == true)
            {
                tableOrderModel.reserveTableInfo = barDal.GetListOfReservedTableDetails().Where(x => x.tableId == tableId && x.isreserveOrderCompleted == false).FirstOrDefault();
                tableOrderModel.tableOrderInfo.isReservedCustomerShowedUp = tableOrderModel.reserveTableInfo.isReservedCustomerShowedUp;
            }
            else
                tableOrderModel.tableOrderInfo.isReservedCustomerShowedUp = false;
            tableOrderModel.gstInfo = barDal.ListOfGSTInfo().FirstOrDefault();

            return View(tableOrderModel);
        }

        [HttpGet]
        public JsonResult CategorySpecificMenuItems(int menuCategoryId)
        {
            return Json(barDal.ListOfMenuItems().Where(x => x.menuCategoryId == menuCategoryId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchParticularMenuItems(string searchValue)
        {
            int checkIfSearchIsBasedOnId;
            var isNumeric = int.TryParse(searchValue, out checkIfSearchIsBasedOnId);
            List<MenuItems> menuItemsList = null;
            if (searchValue != null)
            {
                if (isNumeric)
                    menuItemsList = barDal.ListOfMenuItems().Where(n => n.menuItemId == checkIfSearchIsBasedOnId).ToList();
                else if (!isNumeric)
                    menuItemsList = barDal.ListOfMenuItems().Where( m => m.menuItemName.ToUpper().Contains(searchValue.ToUpper()) || (searchValue == null)).ToList();
            }
            return Json(menuItemsList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTableOrder(int tableId)
        {
            TableOrderModel tableOrdersOnLoadData = new TableOrderModel();
            tableOrdersOnLoadData.listOfMenuItemsOrdered = barDal.ListOfTableOrders(tableId).Where(x => x.isOrderCompleted == false);
            tableOrdersOnLoadData.listOfMenuItems = barDal.ListOfMenuItems();
            tableOrdersOnLoadData.tableOrderInfo = barDal.ListOfTableInfo().Where(x => x.tableId == tableId).FirstOrDefault();
            return Json(tableOrdersOnLoadData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMenuItemToCart(TableOrder obj)
        {
            if (obj != null)
            {
                obj.invoiceNumber = barDal.ListOfTableOrders(obj.tableId).Where(x => (x.isOrderCompleted == false && x.tableId == obj.tableId)).Count() > 0 ?
                            barDal.ListOfTableOrders(obj.tableId)[0].invoiceNumber : barDal.NextInvoiceNumber();
                return Json(barDal.AddMenuItemToCart(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Cart is Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateMenuItemFromCart(TableOrder uMenuItem)
        {
            if (uMenuItem != null)
            {
                return Json(barDal.UpdateMenuItemFromCart(uMenuItem) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Cart is Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMenuItemFromCart(TableOrder obj)
        {
            if (obj != null)
            {
                return Json(barDal.DeleteMenuItemFromCart(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Cart is Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PaidOrderDetails(OrderDetails orderDetailsObj)
        {
            if (orderDetailsObj != null)
            {
                PayBill_PrintReceiptModel reprintReceipt = new PayBill_PrintReceiptModel();
                reprintReceipt.listOfPaidOrderDetails = barDal.ListOfOrderDetails().Where(x => x.invoiceNumber == orderDetailsObj.invoiceNumber).ToList();
                reprintReceipt.gstInfo = barDal.ListOfGSTInfo().FirstOrDefault();
                return Json(reprintReceipt, JsonRequestBehavior.AllowGet);
            }
            else
                return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PrintTableReceipt(int tableId)
        {
            if (tableId != 0)
            {
                PayBill_PrintReceiptModel printReceipt = new PayBill_PrintReceiptModel();
                printReceipt.insertResponse = barDal.PrintTableReceipt(tableId) > 0 ? "Success" : "Error";

                printReceipt.invoiceNumber = barDal.ListOfTableOrders(tableId).Where(x => (x.isOrderCompleted == false && x.tableId == tableId))
                                             .Select(v => v.invoiceNumber).FirstOrDefault();
                printReceipt.listOfPaidOrderDetails = barDal.ListOfOrderDetails().Where(x => x.invoiceNumber == printReceipt.invoiceNumber).ToList();
                printReceipt.gstInfo = barDal.ListOfGSTInfo().FirstOrDefault();
                return Json(printReceipt, JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Cart is Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PayTableBill(PaidOrder obj)
        {
            if (obj != null)
            {
                PayBill_PrintReceiptModel payBill = new PayBill_PrintReceiptModel();
                obj.invoiceNumber = barDal.ListOfTableOrders(obj.tableId).Where(x => (x.isOrderCompleted == false && x.tableId == obj.tableId))
                                                             .Select(v => v.invoiceNumber).FirstOrDefault();

                payBill.insertResponse = barDal.PayTableBill(obj) > 0 ? "Success" : "Error";
                payBill.invoiceNumber = obj.invoiceNumber;
                payBill.listOfPaidOrderDetails = barDal.ListOfOrderDetails().Where(x => x.invoiceNumber == obj.invoiceNumber).ToList();
                payBill.gstInfo = barDal.ListOfGSTInfo().SingleOrDefault();
                return Json(payBill, JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Cart is Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FilteredTransactionsData(string fromDate, string toDate)
        {
                return Json(barDal.GetFiltredAllOrdersOverview(fromDate, toDate).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CheckReserveTableTime(ReserveTable obj)
        {
            string response = string.Empty;
            foreach (var item in barDal.GetListOfReservedTableDetails().Where(todaysData => Convert.ToDateTime(todaysData.dateOfReserve) >= DateTime.Today))
            {
                if (item.tableId == obj.tableId)
                    response = Convert.ToDateTime(item.timeOfReserve).AddMinutes(60) >= Convert.ToDateTime(obj.timeOfReserve) ? "RExists" : "Success";

            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReserveTable(ReserveTable reserveTable)
        {
            return Json(barDal.ReserveTable(reserveTable) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CancelTableReservation(ReserveTable obj)
        {
                return Json(barDal.ChangeStatusOfReserveTable(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReservedCustomerShowedUp(ReserveTable obj)
        {
            return Json(barDal.ReservedCustomerShowedUp(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }
    }
}