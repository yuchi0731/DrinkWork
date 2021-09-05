using DOS_Models;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DOS_DBSoure
{
    public class DrinkListManager
    {
        /// <summary>
        /// 取得目前訂單資料
        /// </summary>
        /// <returns></returns>
        public static OrderDetailModels GetCurrentOrderDetail()
        {
            string orderlist = HttpContext.Current.Session["OrderNumber"] as string;

            if (orderlist == null)
                return null;

            DataRow dr = GetOrderDetailInfo(orderlist);
            //要改orderlist

            if (dr == null) //一旦發現是空的就要清除資料
            {
                HttpContext.Current.Session["OrderDetail"] = null;
                return null;
            }

            //因為dr設為取得使用者帳號的方法，所以可以取得對應的欄位
            OrderDetailModels ordermodel = new OrderDetailModels();
            ordermodel.OrderDetailsID = dr["OrderDetailsID"].ToString();
            ordermodel.OrderNumber = dr["OrderNumber"].ToString();
            ordermodel.Account = dr["Account"].ToString();
            ordermodel.OrderTime = dr["OrderTime"].ToString();
            ordermodel.OrderEndTime = dr["OrderEndTime"].ToString();
            ordermodel.RequiredTime = dr["RequiredTime"].ToString();
            ordermodel.ProductName = dr["ProductName"].ToString();
            ordermodel.UnitPrice = dr["RequiredTime"].ToString();
            ordermodel.Toppings = dr["Toppings"].ToString();
            ordermodel.ToppingsUnitPrice = dr["ToppingsUnitPrice"].ToString();
            ordermodel.Suger = dr["Suger"].ToString();
            ordermodel.Ice = dr["Ice"].ToString();
            ordermodel.SupplierName = dr["SupplierName"].ToString();
            ordermodel.Quantity = dr["Quantity"].ToString();
            ordermodel.SubtotalAmount = dr["SubtotalAmount"].ToString();
            ordermodel.OtherRequest = dr["OtherRequest"].ToString();

            return ordermodel;
        }



        /// <summary>
        /// 取得單筆訂單一列/SQL
        /// </summary>
        /// <returns></returns>
        public static DataRow GetOrderInfo(int orderID)
        {

            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 @"SELECT 
                     OrderID, OrderNumber, Account, OrderTime, OrderEndTime, RequiredTime, SupplierName, TotalPrice
                   FROM [OrderList]
                   WHERE [OrderID]
                    ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderID", orderID));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 取得單筆訂單一列資訊SQL
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static DataRow GetOrderDetailInfo(string orderNumber)
        {
            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                $@"SELECT
                     OrderDetailsID, OrderNumber, Account, OrderTime, OrderEndTime, RequiredTime, ProductName, Quantity, UnitPrice, SubtotalAmount, Suger, Ice, Toppings, SupplierName, OtherRequest
                FROM [OrderDetails]
                WHERE OrderNumber = @orderNumber
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderNumber", orderNumber));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 取得某筆訂單所有跟團者明細資料SQL
        /// </summary>
        /// <param name="SupplierName"></param>
        /// <returns></returns>
        public static DataTable GetOrderDetailListSQL(string orderNumber)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                     OrderDetailsID, OrderNumber, Account, OrderTime, OrderEndTime, RequiredTime, ProductName, Quantity, UnitPrice, SubtotalAmount, Suger, Ice, Toppings, SupplierName, OtherRequest
                FROM [OrderDetails]
                WHERE OrderNumber = @orderNumber
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderNumber", orderNumber));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbcommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 取得個人訂單歷史紀錄SQL
        /// </summary>
        /// <param name="SupplierName"></param>
        /// <returns></returns>
        public static DataTable GetOrderUserDetailList(string account)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                     OrderDetailsID, OrderNumber, Account, OrderTime, OrderEndTime, RequiredTime, ProductName, Quantity, UnitPrice, SubtotalAmount, Suger, Ice, Toppings, SupplierName, OtherRequest
                FROM [OrderDetails]
                WHERE Account = @account
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@Account", account));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbcommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用店名，取得店家飲料品項SQL
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public static DataTable GetAllDrinkbySupplier(string supplierName)
        {

            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 $@"SELECT 
                    ProductID, ProductName, SupplierName, UnitPrice
                   FROM [Products]
                   WHERE SupplierName = @supplierName";


            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@supplierName", supplierName));

            try
            {
                return DBHelper.ReadDataTable(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 取得所有訂單歷史紀錄SQL
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllOrderList()
        {

            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 @"SELECT OrderNumber, OrderID, Account, OrderTime, OrderEndTime, RequiredTime, SupplierName, TotalPrice
                   FROM [OrderList]";

            try
            {
                return DBHelper.AllDataList(connectionString, dbCommandString);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

        }


        /// <summary>
        /// 取得選取飲料店飲品資料SQL
        /// </summary>
        /// <param name="SupplierName"></param>
        /// <returns></returns>
        public static DataTable GetChooseDrinkList(string SupplierName)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    ProductName,
                    UnitPrice
                FROM [Products]
                WHERE SupplierName = @supplierName
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@supplierName", SupplierName));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbcommand, list);
            }
            catch (Exception ex)
            {
                //Logger.WriteLog(ex);
                return null;
            }
        }













        /// <summary>
        /// 查詢訂單//強型別清單LINQ
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderList(string supplierName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.OrderLists
                         where item.SupplierName == supplierName
                         select item);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 查詢訂單明細//強型別清單LINQ
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetOrderDetailList(string supplierName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.OrderDetails
                         where item.SupplierName == supplierName
                         select item);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 取得店家名稱LINQ
        /// </summary>
        /// <returns></returns>
        public static string GetSupplierName(string product)
        {

            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    //與Products連動，並Select選擇ProductID和ProductName欄位
                    var SupplierName =
                        context.Products
                        .Where(obj => obj.ProductName == product)
                        .Select(obj => obj.SupplierName).FirstOrDefault();

                    return SupplierName;

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

        }








    }
}
