using DOS_Models;
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
    public class DrinkListManagerSQL
    {

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
        /// 取得指定訂單資訊SQL
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static DataRow GetOrderDetailInfoSQL(string orderNumber)
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



    }
}
