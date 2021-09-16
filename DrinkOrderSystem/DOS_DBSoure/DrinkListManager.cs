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
        /// 寫出所有OrderList
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderList()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          select list);

                    var orderList = query.ToList();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }




        /// <summary>
        /// 寫出所有OrderDetail
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetOrderDetail()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 寫出當前使用者所有OrderDetail
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetUserDetailList(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.Account == account
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        #region OrderRecords

        /// <summary>
        /// 寫出所有歷史OrderList,篩選帳號
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderListRecordByAccount(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var query =
                         (from list in context.OrderLists
                          where list.Account == account & list.OrderEndTime <= DateTime.Now
                          select list);

                    var orderList = query.ToList();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 寫出所有歷史OrderList,篩選訂單編號
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderListRecordByOrderNumber(string ordernumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var query =
                         (from list in context.OrderLists
                          where list.OrderNumber == ordernumber & list.OrderEndTime <= DateTime.Now
                          select list);

                    var orderList = query.ToList();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// OrderRecords:寫出所有歷史OrderList
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderListRecord()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var query =
                         (from list in context.OrderLists
                          where list.OrderEndTime <= DateTime.Now
                          select list);

                    var orderList = query.ToList();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// OrderRecords:依訂購時間，寫出所有OrderDetail;;OrderBy近至遠
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderByRtime()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          orderby list.OrderTime descending
                          where list.OrderEndTime <= DateTime.Now
                          select list);

                    var order = query.ToList();
                    return order;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// OrderRecords:依訂購時間，寫出所有OrderDetail;;OrderBy遠至近
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderByOtime()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          orderby list.OrderTime
                          where list.OrderEndTime <= DateTime.Now
                          select list);

                    var order = query.ToList();
                    return order;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        #endregion

        #region NowOrdering



        /// <summary>
        /// NowOrdering:寫出所有歷史OrderList,篩選帳號
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetNowOrderingByAccount(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var query =
                         (from list in context.OrderLists
                          where list.Account == account & list.OrderEndTime > DateTime.Now
                          select list);

                    var orderList = query.ToList();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// NowOrdering:寫出所有歷史OrderList,篩選訂單編號
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetNowOrderingByOrderNumber(string ordernumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var query =
                         (from list in context.OrderLists
                          where list.OrderNumber == ordernumber & list.OrderEndTime > DateTime.Now
                          select list);

                    var orderList = query.ToList();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// NowOrdering:寫出所有現在跟團OrderList
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderListNoOrdering()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var query =
                         (from list in context.OrderLists
                          where list.OrderEndTime > DateTime.Now
                          select list);

                    var orderList = query.ToList();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// NowOrdering:依訂購時間，寫出所有OrderDetail;;OrderBy近至遠
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderByRtimeNowOrdering()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          orderby list.OrderTime descending
                          where list.OrderEndTime > DateTime.Now
                          select list);

                    var order = query.ToList();
                    return order;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// NowOrdering:依訂購時間，寫出所有OrderDetail;;OrderBy遠至近
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderByOtimeNowOrdering()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          orderby list.OrderTime
                          where list.OrderEndTime > DateTime.Now
                          select list);

                    var order = query.ToList();
                    return order;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        #endregion


        #region UserDetail OrderBy



        /// <summary>
        /// 依訂購時間，寫出當前使用者所有OrderDetail;;OrderBy近至遠
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetUserDetailOrderByRtime(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.Account == account
                          orderby list.OrderTime descending
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 依訂購時間，寫出當前使用者所有OrderDetail;;OrderBy遠至近
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetUserDetailOrderByOtime(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.Account == account
                          orderby list.OrderTime 
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 寫出當前使用者所有OrderDetail;;OrderByProduct
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetUserDetailOrderByProduct(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.Account == account
                          orderby list.ProductName
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        #endregion




        /// <summary>
        /// 取得該帳號快結束未結帳訂單
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static OrderList GetGTEOrderListInfo(string account)
        {
            var time = DateTime.Now.AddHours(1.5);
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          where list.Account == account
                          orderby list.RequiredTime < time
                          select list);

                    var orderList = query.FirstOrDefault();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 如果此人有開過團
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static OrderList GetCheckUserhasOrderList(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          where
                              list.Account == account
                          select list);

                    var orderList = query.FirstOrDefault();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>
        /// 尚有未結帳訂單
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static OrderList GetneedCheckoutOrderList(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          where 
                              list.Account == account 
                              & list.Established == "NO" 
                              & list.RequiredTime > DateTime.Now                
                          select list);

                    var orderList = query.FirstOrDefault();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }




        /// <summary>
        /// 取出自己最近一筆OrderNumber;;OrderBy
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static string GetUserLastOrderNumber(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          where list.Account == account
                          orderby list.OrderTime
                          select list.OrderNumber);

                    var orderDetail = query.FirstOrDefault();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 利用OrderNumber取的OrderList
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static OrderList GetOrderListInfo(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderLists
                          where list.OrderNumber == orderNumber
                          select list);

                    var orderList = query.FirstOrDefault();
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>
        /// 利用OrderNumber取的OrderDetail
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static OrderDetail GetOrderDetailInfo(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.OrderNumber == orderNumber
                          select list);

                    var orderDetail = query.FirstOrDefault();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>
        /// 篩選OrderDetail By account
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetOrderDetailInfoByAccount(string account, string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.Account == account & list.OrderNumber == orderNumber
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 篩選OrderDetail By productName
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetOrderDetailInfoByProductName(string productName, string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.ProductName == productName & list.OrderNumber == orderNumber
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>
        /// 利用OrderNumber取的OrderDetailList
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetOrderDetailListbyorderNumber(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from list in context.OrderDetails
                          where list.OrderNumber == orderNumber
                          select list);

                    var orderDetail = query.ToList();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }




        /// <summary>
        /// 利用OrderNumber取的OrderList
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<OrderList> GetOrderListbyorderNumber(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.OrderLists
                         where item.OrderNumber == orderNumber
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
        /// 利用OrderNumber取得OrderDetail
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static OrderDetail GetOrderDetailListfromorderNumber(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.OrderDetails
                         where item.OrderNumber == orderNumber
                         select item);

                    var orderDetail = query.FirstOrDefault();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 利用OrderID取得OrderDetail
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static OrderDetail GetOrderDetailfromorderID(Guid orderID)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.OrderDetails
                         where item.OrderDetailsID == orderID
                         select item);

                    var orderDetail = query.FirstOrDefault();
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用OrderID取得OrderDetailList
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<OrderDetail> GetOrderDetailListfromorderID(Guid orderID)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.OrderDetails
                         where item.OrderDetailsID == orderID
                         select item);

                    var orderDetail = query.ToList();
                    return orderDetail;
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
        /// 利用supplierName取得商品資訊
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Product> GetProducts(string supplierName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.Products
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
        /// 利用廠商名取得所有商品名字
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public static List<string> GetALLProduct(string supplierName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from item in context.Products
                         where item.SupplierName == supplierName
                         select item.ProductName);

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


        /// <summary>
        /// 取得商品單價
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public static decimal GetUnitPrice(string ProductName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var price = context.Products
                        .Select(obj => obj.UnitPrice);
                    var UnitPrice = price.FirstOrDefault();
                    return UnitPrice;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return decimal.Zero;
            }
        }



        #region 開團跟團

        /// <summary>
        /// 開團建立OrderList
        /// </summary>
        /// <param name="orderDetail"></param>
        public static void StartGroup(OrderListModels orderlist)
        {

            try
            {

                using (DKContextModel context = new DKContextModel())
                {

                    OrderList neworderList = new OrderList();
                    //加入
                    neworderList.OrderID = orderlist.OrderID;
                    neworderList.OrderNumber = orderlist.OrderNumber;
                    neworderList.Account = orderlist.Account;
                    neworderList.OrderTime = orderlist.OrderTime;
                    neworderList.OrderEndTime = orderlist.OrderEndTime;
                    neworderList.RequiredTime = orderlist.RequiredTime;
                    neworderList.SupplierName = orderlist.SupplierName;
                    neworderList.TotalPrice = orderlist.TotalPrice;
                    neworderList.TotalCups = orderlist.TotalCups;
                    neworderList.Established = orderlist.Established;

                    context.OrderLists.Add(neworderList);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return;
            }
        }

        /// <summary>
        /// 跟團建立新OrderDetail(包括開團者)
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productName"></param>
        /// <param name="supplierName"></param>
        /// <param name="unitPrice"></param>
        /// <param name="unitsMaxOrder"></param>
        /// <param name="categoryName"></param>
        /// <param name="picture"></param>
        public static void AddGroup(OrderDetailModels orderDetail)
        {

            try
            {

                using (DKContextModel context = new DKContextModel())
                {

                    OrderDetail neworderDetail = new OrderDetail();
                    //加入
                    neworderDetail.OrderDetailsID = orderDetail.OrderDetailsID;
                    neworderDetail.OrderNumber = orderDetail.OrderNumber;
                    neworderDetail.Account = orderDetail.Account;
                    neworderDetail.OrderTime = orderDetail.OrderTime;
                    neworderDetail.OrderEndTime = orderDetail.OrderEndTime;
                    neworderDetail.RequiredTime = orderDetail.RequiredTime;
                    neworderDetail.ProductName = orderDetail.ProductName;
                    neworderDetail.Quantity = orderDetail.Quantity;
                    neworderDetail.UnitPrice = orderDetail.UnitPrice;
                    neworderDetail.Suger = orderDetail.Suger;
                    neworderDetail.Ice = orderDetail.Ice;
                    neworderDetail.Toppings = orderDetail.Toppings;
                    neworderDetail.ToppingsUnitPrice = orderDetail.ToppingsUnitPrice;
                    neworderDetail.SubtotalAmount = orderDetail.SubtotalAmount;
                    neworderDetail.SupplierName = orderDetail.SupplierName;
                    neworderDetail.OtherRequest = orderDetail.OtherRequest;
                    neworderDetail.Established = orderDetail.Established;

                    context.OrderDetails.Add(neworderDetail);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return;
            }
        }


        /// <summary>
        /// 算訂單總金額
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static decimal GetAllAmount(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var List =
                        context.OrderDetails
                        .Where(obj => obj.OrderNumber == orderNumber);

                    decimal totalAmount = 0;
                    foreach (var subList in List)
                    {
                        totalAmount += subList.SubtotalAmount;
                    }

                    return totalAmount;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return 0;
            }
        }

        /// <summary>
        /// 算訂單總杯數
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static int GetAllCup(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var List =
                        context.OrderDetails
                        .Where(obj => obj.OrderNumber == orderNumber);

                    int cups = 0;
                    foreach (var subList in List)
                    {
                        cups += subList.Quantity;
                    }

                    return cups;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return 0;
            }
        }

        /// <summary>
        /// 更新總金額及杯數
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="totalAmount"></param>
        /// <param name="cups"></param>
        /// <returns></returns>
        public static bool UpdateGroup(string orderNumber, decimal totalAmount, int cups)
        {

            try
            {

                using (DKContextModel context = new DKContextModel())
                {

                    var updatelist =
                        context.OrderLists
                        .Where(obj => obj.OrderNumber == orderNumber).FirstOrDefault();

                    if (updatelist != null)
                    {
                        updatelist.TotalPrice = totalAmount;
                        updatelist.TotalCups = cups;
                    }





                    context.SaveChanges();

                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }


        #endregion




        /// <summary>
        /// 刪除訂單List,Detail
        /// </summary>
        public static void DeleteListDetail(string orderNumber)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    //查出List資料
                    var DeleteList =
                        context.OrderLists.Where(obj => obj.OrderNumber == orderNumber).FirstOrDefault();
                    //查出Detail資料
                    var DeleteDetail =
                        context.OrderDetails.Where(obj => obj.OrderNumber == orderNumber).FirstOrDefault();

                    //如果不為null執行刪除
                    if (DeleteList != null)
                    {
                        context.OrderLists.Remove(DeleteList);
                    }


                    if (DeleteDetail != null)
                    {
                        context.OrderDetails.Remove(DeleteDetail);
                    }

                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return;
            }
        }


        /// <summary>
        /// 送出表單後更改成立欄位
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="totalAmount"></param>
        /// <param name="cups"></param>
        /// <returns></returns>
        public static bool UpdateEstablished(string orderNumber)
        {

            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var updatelist =
                        context.OrderLists
                        .Where(obj => obj.OrderNumber == orderNumber).FirstOrDefault();

                    if (updatelist != null)
                    {
                        updatelist.Established = "Established";
                    }

                    var updateDetaillist =
                        context.OrderDetails
                        .Where(obj => obj.OrderNumber == orderNumber).FirstOrDefault();

                    if (updateDetaillist != null)
                    {
                        updateDetaillist.Established = "Established";
                    }

                    context.SaveChanges();

                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }


        /// <summary>
        /// 判斷訂單時間更改成立欄位; 需求時間小於1小時 未送出，流單
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="totalAmount"></param>
        /// <param name="cups"></param>
        /// <returns></returns>
        public static bool CheckEstablishedorFail()
        {

            DateTime overTime = DateTime.Now.AddHours(1);

            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var updatelist =
                        context.OrderLists
                        .Where(obj => obj.RequiredTime < overTime).FirstOrDefault();

                    if (updatelist != null)
                    {
                        updatelist.Established = "Fail";
                    }

                    var updateDetaillist =
                        context.OrderDetails
                        .Where(obj => obj.RequiredTime < overTime).FirstOrDefault();

                    if (updatelist != null)
                    {
                        updatelist.Established = "Fail";
                    }

                    context.SaveChanges();

                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }




        /// <summary>
        /// 修改單筆訂單
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool UpdateDetailInfo(OrderDetail orderDetail)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    //取得資料(Lambda)
                    var detail =
                            context.OrderDetails
                            .Where(obj => obj.OrderDetailsID == orderDetail.OrderDetailsID).FirstOrDefault();


                    if (detail != null)//如果DB有資料的話
                    {

                        detail.ProductName = orderDetail.ProductName;
                        detail.Quantity = orderDetail.Quantity;
                        detail.Suger = orderDetail.Suger;
                        detail.Ice = orderDetail.Ice;
                        detail.Toppings = orderDetail.Toppings;
                        detail.SubtotalAmount = orderDetail.SubtotalAmount;

                        context.SaveChanges();

                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }





        #region memo

        /// <summary>
        /// 建立新飲料
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productName"></param>
        /// <param name="supplierName"></param>
        /// <param name="unitPrice"></param>
        /// <param name="unitsMaxOrder"></param>
        /// <param name="categoryName"></param>
        /// <param name="picture"></param>
        public static void CreateNewProduct(Product product)
        {
            try
            {

                using (DKContextModel context = new DKContextModel())
                {

                    //Product newproduct = new Product();
                    ////加入
                    //newproduct.ProductID = product.ProductID;
                    //newproduct.ProductName = product.ProductName;
                    //newproduct.SupplierName = product.SupplierName;
                    //newproduct.UnitPrice = product.UnitPrice;
                    //newproduct.UnitsMaxOrder = product.UnitsMaxOrder;
                    //newproduct.Discount = product.Discount;
                    //newproduct.CategoryName = product.CategoryName;
                    //newproduct.Picture = product.Picture;

                    context.Products.Add(product);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return;
            }
        }

        /// <summary>
        /// 修改飲料資料
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productName"></param>
        /// <param name="supplierName"></param>
        /// <param name="unitPrice"></param>
        /// <param name="unitsMaxOrder"></param>
        /// <param name="categoryName"></param>
        /// <param name="picture"></param>
        public static bool UpdateProduct(Product product)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var prod =
                       context.Products
                       .Where(obj => obj.ProductName == product.ProductName).FirstOrDefault();


                    if (prod != null)
                    {
                        prod.ProductName = product.ProductName;
                        prod.SupplierName = product.SupplierName;
                        prod.UnitPrice = product.UnitPrice;
                        prod.UnitsMaxOrder = product.UnitsMaxOrder;
                        prod.Discount = product.Discount;
                        prod.CategoryName = product.CategoryName;
                        prod.Picture = product.Picture;

                        context.SaveChanges();
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }


        /// <summary>
        /// 刪除飲料資料
        /// </summary>
        public static void DeleteProductlinq(string productName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    //查出分類&產品
                    var DeleteProduct =
                        context.Products.Where(obj => obj.ProductName == productName
                        ).FirstOrDefault();

                    //如果不為null執行刪除
                    if (DeleteProduct != null)
                    {
                        context.Products.Remove(DeleteProduct);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return;
            }

        }

        #endregion



    }
}
