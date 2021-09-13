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
        /// 寫出所有現在跟團OrderList
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
        /// 寫出所有歷史OrderList
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



        /// <summary>
        /// 寫出當前使用者所有OrderDetail;;OrderByRtime
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
        /// 寫出當前使用者所有OrderDetail;;OrderByOtime
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



        #region OrderDetailList

        /// <summary>
        /// 跟團建立新OrderDetail
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

        #endregion





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
        public static void CreateNewProduct(int productID, string productName, string supplierName, decimal unitPrice, int unitsMaxOrder, string categoryName, string picture)
        {
            try
            {

                using (DKContextModel context = new DKContextModel())
                {

                    Product newproduct = new Product();
                    //加入
                    newproduct.ProductID = productID;
                    newproduct.ProductName = productName;
                    newproduct.SupplierName = supplierName;
                    newproduct.UnitPrice = unitPrice;
                    newproduct.UnitsMaxOrder = unitsMaxOrder;
                    newproduct.CategoryName = categoryName;
                    newproduct.Picture = picture;

                    context.Products.Add(newproduct);
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
        public static void UpdateNewProduct(int productID, string productName, string supplierName, decimal unitPrice, int unitsMaxOrder, string categoryName, string picture)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var product =
                                    context.Products
                                    .Where(obj => obj.ProductName == productName).FirstOrDefault();


                    //變更
                    product.ProductID = productID;
                    product.ProductName = productName;
                    product.SupplierName = supplierName;
                    product.UnitPrice = unitPrice;
                    product.UnitsMaxOrder = unitsMaxOrder;
                    product.CategoryName = categoryName;
                    product.Picture = picture;

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



    }
}
