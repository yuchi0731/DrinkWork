using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_DBSoure
{
    public class DBHelper
    {


        /// <summary>
        /// DB連線SQL
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return val;
        }


        /// <summary>
        /// 讀取單筆資料
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="dbcommand"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataRow ReadDataRow(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());


                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt.Rows.Count == 0)
                        return null;

                    return dt.Rows[0];


                }
            }
        }



        /// <summary>
        /// 讀取整個資料
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="dbcommand"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable AllDataList(string connectionString, string dbCommandString)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommandString, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }



        /// <summary>
        /// 利用目前有的資料取得DB
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="dbcommand"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ReadDataTable(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;
                }
            }
        }



        /// <summary>
        /// 新創資料
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="dbcommand"></param>
        /// <param name="createlist"></param>
        public static void CreatData(string connStr, string dbcommand, List<SqlParameter> createlist)
        {

            //connect db & execute
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {

                    comm.Parameters.AddRange(createlist.ToArray());
                    conn.Open();
                    comm.ExecuteNonQuery();

                }


            }
        }



        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="dbcommand"></param>
        /// <param name="paramlist"></param>
        /// <returns></returns>
        public static int ModifyData(string connStr, string dbcommand, List<SqlParameter> paramlist)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(paramlist.ToArray());
                    conn.Open();
                    int effectRowsCount = comm.ExecuteNonQuery();
                    return effectRowsCount;
                }
            }
        }




    }
}
