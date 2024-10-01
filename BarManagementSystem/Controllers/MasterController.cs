using BarManagementSystem.DAL;
using BarManagementSystem.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BarManagementSystem.Controllers
{
    public class MasterController : Controller
    {
        MasterDal _masterDal = new MasterDal();
        BarDal barDal = new BarDal();

        [Authorize]
        public ActionResult AddMenuItems()
        {
            TempData["AddMenuItem"] = TempData["AddMenuItem"] != null ? TempData["AddMenuItem"] : null;
            return View(barDal.ListOfMenuCategory());
        }

        [HttpPost]
        public ActionResult AddMenuItems(MenuItems menuItem)
        {
            if(menuItem != null)
            {
                if(_masterDal.AddMenuItems(menuItem) > 0)
                    TempData["AddMenuItem"] = "Success";
            }
            
            return Redirect("/Master/AddMenuItems");
        }

        [HttpGet]
        public JsonResult DetailsOfMenuItems(int menuItemId)
        {
            MenuItems mi = barDal.ListOfMenuItems().Where(x => x.menuItemId == menuItemId).SingleOrDefault();
            return Json(mi, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult UpdateDeleteMenuItems()
        {
            UpdateMenuItemModel uMenuItemModel = new UpdateMenuItemModel();
            uMenuItemModel.listOfMenuItems = barDal.ListOfMenuItems();
            uMenuItemModel.listOfMenuCategory = barDal.ListOfMenuCategory();
            return View(uMenuItemModel);
        }

        [HttpPost]
        public JsonResult UpdateMenuItems(MenuItems uMenuItem)
        {
            if(uMenuItem != null)
            {              
                return Json(_masterDal.UpdateMenuItems(uMenuItem) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Cart is Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMenuItems(int menuItemId)
        {
            string updateResponse = string.Empty;
            if (barDal.ListOfOrderDetails().Where(x => x.menuItemId == menuItemId).Count() > 0)
                updateResponse = "Exists";
            else
                updateResponse = _masterDal.DeleteMenuItem(menuItemId) > 0 ? "Success" : "Error";

            return Json(updateResponse, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult RecentOrders()
        {
            RecentOrderModel recentOrderM = new RecentOrderModel();
            recentOrderM.listOfPaidOrderDetails = barDal.ListOfRecentOrdersOverview().Where(todaysData => Convert.ToDateTime(todaysData.dateOfPayment) >= DateTime.Today);
            recentOrderM.totalCounterAmount = _masterDal.GetTotalCounterAmount();
            return View(recentOrderM);
        }

        [Authorize]
        public ActionResult AllOrders()
        {
            return View(barDal.ListOfRecentOrdersOverview());
        }

        [Authorize]
        public ActionResult ReserveTables()
        {
            return View(barDal.GetListOfReservedTableDetails().Where(todaysData => Convert.ToDateTime(todaysData.dateOfReserve) >= DateTime.Today));
        }

        [Authorize]
        public ActionResult MasterEntities()
        {
            MasterEntitiesModel masterEntities = new MasterEntitiesModel();

            masterEntities.listOfAdminDetails = barDal.ListOfAdminDetails();
            masterEntities.listOfMenuCategory = barDal.ListOfMenuCategory();
            masterEntities.listOfPaymentMode = barDal.ListOfPaymentMode();
            masterEntities.listOfTableLocation = barDal.ListOfTableLocation();
            masterEntities.listOfGSTDetails = barDal.ListOfGSTInfo();
            masterEntities.listOfTables = barDal.ListOfTableInfo();
            masterEntities.listOfPriceInput = barDal.ListOfPriceInput();
            return View(masterEntities);
        }

        [Authorize]
        public ActionResult SyncDataBase()
        {
            //BackUpDatabase getDBName = new BackUpDatabase();
            ViewBag.dbName = _masterDal.NameOfServerDatabase();
            TempData["BackUpDb"] = TempData["BackUpDb"] != null ? TempData["BackUpDb"] : null;
            return View();
        }

        [HttpPost]
        public ActionResult SyncDataBase(BackUpDatabase backDb)
        {
            
            _masterDal.BackUpServerDbToLocalPath(backDb);
            TempData["BackUpDb"] = "Success";
            return Redirect("/Master/SyncDataBase");
        }

        [HttpPost]
        public JsonResult AddAdminUser(Admin obj)
        {
            return Json(_masterDal.AddAdminUser(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateAdminUser(Admin obj)
        {
            return Json(_masterDal.UpdateAdminUser(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteAdminUser(Admin obj)
        {
            return Json(_masterDal.DeleteAdminUser(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMenuCategory(MenuCategory obj)
        {
            return Json(_masterDal.AddMenuCategory(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateMenuCategory(MenuCategory obj)
        {
            return Json(_masterDal.UpdateMenuCategory(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMenuCategory(MenuCategory obj)
        {
            string updateResponse = string.Empty;
            if (barDal.ListOfOrderDetails().Where(x => x.menuCategoryId == obj.menuCategoryId).Count() > 0)
                updateResponse = "Exists";
            else
                 updateResponse = _masterDal.DeleteMenuCategory(obj) > 0 ? "Success" : "Error";
            return Json(updateResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPaymentMode(PaymentMode obj)
        {
            return Json(_masterDal.AddPaymentMode(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdatePaymentMode(PaymentMode obj)
        {
            return Json(_masterDal.UpdatePaymentMode(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeletePaymentMode(PaymentMode obj)
        {
            string updateResponse = string.Empty;
            if (barDal.ListOfRecentOrdersOverview().Where(x => x.paymentModeId == obj.paymentModeId).Count() > 0)
                updateResponse = "Exists";
            else
                updateResponse = _masterDal.DeletePaymentMode(obj) > 0 ? "Success" : "Error";
            return Json(updateResponse, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult AddTableLocation(TableLocation obj)
        {
            return Json(_masterDal.AddTableLocation(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTableLocation(TableLocation obj)
        {
            return Json(_masterDal.UpdateTableLocation(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTableLocation(TableLocation obj)
        {
            string updateResponse = string.Empty;
            if ((barDal.ListOfRecentOrdersOverview().Where(x => x.tableLocationId == obj.tableLocationId).Count() > 0) ||
                (barDal.ListOfTableInfo().Where(y => y.tableLocationId == obj.tableLocationId).Count() > 0))
                updateResponse = "Exists";
            else
                updateResponse = _masterDal.DeleteTableLocation(obj) > 0 ? "Success" : "Error";
            return Json(updateResponse, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult UpdateGSTInfo(GST obj)
        {
            return Json(_masterDal.UpdateGSTInfo(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddTableInfo(Tables obj)
        {
            return Json(_masterDal.AddTableInfo(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTableInfo(Tables obj)
        {
            return Json(_masterDal.UpdateTableInfo(obj) > 0 ? "Success" : "Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTable(Tables obj)
        {
            string updateResponse = string.Empty;
            if ((barDal.ListOfRecentOrdersOverview().Where(x => x.tableId == obj.tableId).Count() > 0) ||
                (barDal.GetListOfReservedTableDetails().Where(y => y.tableId == obj.tableId).Count() > 0))
                updateResponse = "Exists";
            else
                updateResponse = _masterDal.DeleteTable(obj) > 0 ? "Success" : "Error";
            return Json(updateResponse, JsonRequestBehavior.AllowGet);

        }
    }
}