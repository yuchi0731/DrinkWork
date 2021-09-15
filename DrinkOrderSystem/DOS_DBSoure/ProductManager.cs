using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_DBSoure
{
    public class ProductManager
    {

        /// <summary>
        /// 寫出所有商品清單
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProductList()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from product in context.Products
                         select product);

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
        /// 篩選特定廠商的商品清單
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public static List<Product> GetProductListBysupplierName(string supplierName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from product in context.Products
                         where product.SupplierName == supplierName
                         select product);

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
        /// 篩選名稱的商品清單
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public static List<Product> GetProductListByproductName(string productName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from product in context.Products
                         where product.ProductName == productName
                         select product);

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
        /// 篩選商品種類的商品清單
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public static List<Product> GetProductListByCategoryName(string categoryName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from product in context.Products
                         where product.CategoryName == categoryName
                         select product);

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

        //OrderBy
        /// <summary>
        /// 以廠商排序
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public static List<Product> OrderbyProductListBysupplierName()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from product in context.Products
                         orderby product.SupplierName
                         select product);

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
        /// 以商品名稱排序
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public static List<Product> OrderbyProductListByproductName()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from product in context.Products
                         orderby product.ProductName
                         select product);

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
        /// 增加商品
        /// </summary>
        /// <param name="product"></param>
        public static void CreateNewProduct(Product product)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
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
        /// 修改商品資料
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool UpdateProducto(Product product)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    //取得資料(Lambda)
                    var productInfo =
                            context.Products
                            .Where(obj => obj.ProductName == product.ProductName & obj.SupplierName == product.SupplierName).FirstOrDefault();


                    if (productInfo != null)//如果DB有資料的話
                    {

                        productInfo.ProductName = product.ProductName;
                        productInfo.UnitPrice = product.UnitPrice;
                        productInfo.Picture = product.Picture;

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



        /// <summary>
        /// 刪除商品資料
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="supplierName"></param>
        public static void DeleteProduct(string productName, string supplierName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var DeleteProduct =
                        context.Products.Where(obj => obj.ProductName == productName & obj.SupplierName == supplierName).FirstOrDefault();

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


        /// <summary>
        /// 刪除商品資料
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="supplierName"></param>
        public static void DeleteProductByProductID(int productID)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var DeleteProduct =
                        (from prod in context.Products
                        where prod.ProductID == productID
                        select prod).FirstOrDefault();

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

        /// <summary>
        /// 刪除廠商
        /// </summary>
        /// <param name="supplierName"></param>
        public static void DeleteSupplier(string supplierName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var DeleteProduct =
                        context.Products.Where(obj => obj.SupplierName == supplierName).FirstOrDefault();
                    var DeleteSup =
                        context.Suppliers.Where(obj => obj.SupplierName == supplierName).FirstOrDefault();

                    //如果不為null執行刪除
                    if (DeleteProduct != null)
                    {
                        context.Products.Remove(DeleteProduct);
                    }


                    if (DeleteSup != null)
                    {
                        context.Suppliers.Remove(DeleteSup);
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
