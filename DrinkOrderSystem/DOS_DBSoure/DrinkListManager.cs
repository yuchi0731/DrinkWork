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
        public static void GetDrinkInfo()
        {
            using (DKContextModel context = new DKContextModel())
            {
                var prod = context.Products.First();//連動到第一筆資料
                Console.WriteLine(prod.ProductID);//寫出第一筆資料的ProductName

                //與Products連動，並Select選擇ProductID和ProductName欄位
                var productNameAndID =
                    context.Products.Select(obj => obj.ProductID + ":" + obj.ProductName);


                foreach (var item in productNameAndID)//取得每一筆ProductIDProductName
                {
                    Console.WriteLine(item);
                }

                //如果今天寫的是webform
                //this.GridView1.DataSource = context.Products.ToList();
                //this.GridView1.DataBinf();
            }
        }


        /// <summary>
        /// 取得訂單資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static DataRow GetOrderInfo(string orderNumber)
        {
            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                $@"SELECT
                    OrderNumber, Account, OrderTime, OrderEndTime, RequiredTime, ProductName, Quantity, UnitPrice, Suger, Ice, toppings, SupplierName, OtherRequest
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
        /// 取得目前訂單資料
        /// </summary>
        /// <returns></returns>
        public static OrderDetailModels GetCurrentOrderDetail()
        {
            string orderlist = HttpContext.Current.Session["OrderDetail"] as string;

            if (orderlist == null)
                return null;

            DataRow dr = GetOrderInfo(orderlist);
            //要改orderlist

            if (dr == null) //一旦發現是空的就要清除資料
            {
                HttpContext.Current.Session["OrderDetail"] = null;
                return null;
            }

            //因為dr設為取得使用者帳號的方法，所以可以取得對應的欄位
            OrderDetailModels ordermodel = new OrderDetailModels();
            ordermodel.OrderNumber = dr["OrderNumber"].ToString();
            ordermodel.Account = dr["Account"].ToString();
            ordermodel.OrderTime = dr["OrderTime"].ToString();
            ordermodel.OrderEndTime = dr["OrderEndTime"].ToString();
            ordermodel.RequiredTime = dr["RequiredTime"].ToString();
            ordermodel.ProductName = dr["ProductName"].ToString();
            ordermodel.Quantity = dr["Quantity"].ToString();
            ordermodel.UnitPrice = dr["RequiredTime"].ToString();
            ordermodel.Suger = dr["Suger"].ToString();
            ordermodel.Ice = dr["Ice"].ToString();
            ordermodel.toppings = dr["toppings"].ToString(); ordermodel.SupplierName = dr["SupplierName"].ToString();
            ordermodel.OtherRequest = dr["OtherRequest"].ToString();




            return ordermodel;

        }




        /// <summary>
        /// 取得使用者目前的收支資料
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    ID,
                    UserID,
                    Caption,
                    Amount,
                    ActType,
                    CreateDate,
                    Body
                FROM [AccountingNote]
                WHERE UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

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
        /// 取得店家飲料品項資料
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public static DataTable GetAllDrinkbySupplier(string supplierName)
        {

            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 $@"SELECT ProductName, UnitPrice, Discount, CategoryName, SupplierName
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
        /// 取得所有訂單歷史紀錄
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
        /// 取得單筆訂單List
        /// </summary>
        /// <returns></returns>
        public static DataRow GetAllOrderList(int orderID)
        {

            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 @"SELECT OrderNumber, OrderID, Account, OrderTime, OrderEndTime, RequiredTime, SupplierName, TotalPrice
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
        /// 取得選取飲料店飲品資料
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
        /// 查詢訂單//強型別清單
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
        /// 查詢訂單明細//強型別清單
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
        /// 取得某筆訂單資料
        /// </summary>
        /// <param name="SupplierName"></param>
        /// <returns></returns>
        public static DataTable GetOrderDetailListSQL(string orderNumber)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    OrderNumber, Account, OrderTime, OrderEndTime, RequiredTime, ProductName, Quantity, UnitPrice, Suger, Ice, toppings, SupplierName, OtherRequest
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
        /// 取得個人訂單歷史紀錄
        /// </summary>
        /// <param name="SupplierName"></param>
        /// <returns></returns>
        public static DataTable GetOrderUserDetailList(string account)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    OrderNumber, Account, OrderTime, OrderEndTime, RequiredTime, ProductName, Quantity, UnitPrice, Suger, Ice, toppings, SupplierName, OtherRequest
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







        public static string GetSupplierName()
        {


            using (DKContextModel context = new DKContextModel())
            {
                var prod = context.Suppliers.First();//連動到第一筆資料
                Console.WriteLine(prod.SupplierName);//寫出第一筆資料的ProductName

                //與Products連動，並Select選擇ProductID和ProductName欄位
                var SupplierName =
                    context.Products.Select(obj => obj.SupplierName);


                foreach (var item in SupplierName)//取得每一筆SupplierID
                {
                    return item;
                }

                //如果今天寫的是webform
                //this.GridView1.DataSource = context.Products.ToList();
                //this.GridView1.DataBinf();
            }

            return null;
        }

        //public static DataTable GetAllDrinkInfo(Guid supplierID)
        //{

        //    string connectionString = DBHelper.GetConnectionString();

        //    string daCommandString =
        //         @"SELECT ProductName, UnitPrice, Discount, CategoryName, SupplierID
        //           FROM [Products]
        //           WHERE SupplierID = @supplierID";


        //    List<SqlParameter> list = new List<SqlParameter>();
        //    list.Add(new SqlParameter("@supplierID", supplierID));

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(daCommandString, connection))
        //        {


        //            try
        //            {
        //                connection.Open();
        //                SqlDataReader reader = command.ExecuteReader();

        //                DataTable dt = new DataTable();
        //                dt.Load(reader);
        //                reader.Close();
        //                return dt;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.ToString());
        //                return null;
        //            }
        //        }
        //    }

        //}










    }
}
