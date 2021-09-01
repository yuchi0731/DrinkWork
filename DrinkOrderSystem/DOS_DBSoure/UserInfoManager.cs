using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_DBSoure
{
    public class UserInfoManager
    {





        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 @"SELECT [UserID], [Account], [Password]
                   FROM UserAccount
                   WHERE [Account] = @account
                 ";


            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

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
        /// 取得所有使用者資料(SQL)
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public static DataTable GetAllDrinkInfo()
        {

            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 $@"SELECT 
                            EmployeeID, 
                            DepartmentID, 
                            Department, 
                            LastName, 
                            FirstName,
                            Contact,
                            Email,
                            ext,
                            Phone,
                            JobGrade,
                            CreateDate
                   FROM [UsersInfo]
                   ";



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
        /// 創造新使用者帳號密碼(SQL)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="PWD"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="userlevel"></param>
        public static void CreateNewUser(string account, string PWD)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" INSERT INTO [dbo].[UserAccount]
                (
                    UserID
                   ,Account
                   ,Password
                )
                 VALUES
                (
                    @userID
                   ,@account
                   ,@password
                )
                ";

            string userid = Guid.NewGuid().ToString();

            List<SqlParameter> createuserlist = new List<SqlParameter>();
            createuserlist.Add(new SqlParameter("@userID", userid));
            createuserlist.Add(new SqlParameter("@account", account));
            createuserlist.Add(new SqlParameter("@password", PWD));
            try
            {
                DBHelper.CreatData(connStr, dbcommand, createuserlist);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }



        /// <summary>
        /// 創造新使用者資訊(SQL)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="PWD"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="userlevel"></param>
        public static void CreateUserDetail(string account, int employeeID, string departmentID, string department, string firstName, string lastName, string contact, string email, string ext, string phone, int jobGrade, string description, string responseSuppliers, byte[] photo)
        {


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" INSERT INTO [dbo].[UserInfo]
                (
                    Account
                   ,EmployeeID
                   ,DepartmentID
                   ,Department
                   ,FirstName
                   ,LastName
                   ,Contact
                   ,Email
                   ,ext
                   ,Phone
                   ,JobGrade
                   ,Description
                   ,ResponseSuppliers
                   ,Photo
                   ,CreateDate
                   ,LastModified
                )
                 VALUES
                (
                    @account
                   ,@employeeID
                   ,@departmentID
                   ,@department
                   ,@firstName
                   ,@lastName
                   ,@contact
                   ,@email
                   ,@ext
                   ,@phone
                   ,@jobGrade
                   ,@description
                   ,@responseSuppliers
                   ,@photo
                   ,@createDate
                   ,@lastModified
                )
                ";
  

            List<SqlParameter> createuserlist = new List<SqlParameter>();
            createuserlist.Add(new SqlParameter("@account", account));
            createuserlist.Add(new SqlParameter("@employeeID", employeeID));
            createuserlist.Add(new SqlParameter("@departmentID", departmentID));
            createuserlist.Add(new SqlParameter("@department", department));
            createuserlist.Add(new SqlParameter("@firstName", firstName));
            createuserlist.Add(new SqlParameter("@lastName", lastName));
            createuserlist.Add(new SqlParameter("@contact", contact));
            createuserlist.Add(new SqlParameter("@email", email));
            createuserlist.Add(new SqlParameter("@ext", ext));
            createuserlist.Add(new SqlParameter("@phone", phone));
            createuserlist.Add(new SqlParameter("@jobGrade", jobGrade));
            createuserlist.Add(new SqlParameter("@description", description));
            createuserlist.Add(new SqlParameter("@responseSuppliers", responseSuppliers));
            createuserlist.Add(new SqlParameter("@photo", photo));
            createuserlist.Add(new SqlParameter("@createDate", DateTime.Now));
            createuserlist.Add(new SqlParameter("@lastModified", DateTime.Now));

            try
            {
                DBHelper.CreatData(connStr, dbcommand, createuserlist);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);

            }

        }


        /// <summary>
        /// 修改使用者帳號密碼(SQL)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="PWD"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="userlevel"></param>
        public static void UpdateUserAccount(Guid userid, string account, string PWD)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" UPDATE [dbo].[UserAccount]
                (
                    UserID
                   ,Account
                   ,Password
                )
                 VALUES
                (
                    @userID
                   ,@account
                   ,@password
                )
                ";

            List<SqlParameter> updatelist = new List<SqlParameter>();
            updatelist.Add(new SqlParameter("@userID", userid));
            updatelist.Add(new SqlParameter("@account", account));
            updatelist.Add(new SqlParameter("@password", PWD));
            try
            {
                DBHelper.CreatData(connStr, dbcommand, updatelist);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }


        /// <summary>
        /// 修改使用者密碼SQL
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        public static void UpdatePWD(string account, string pwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                @" UPDATE
                        [dbo].[UserAccount]
                   SET
                        PWD = @pwd
                   WHERE
                        Account = @account
                                        ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    //要插入的數值
                    comm.Parameters.AddWithValue("@account", account);
                    comm.Parameters.AddWithValue("@pwd", pwd);

                    try
                    {
                        conn.Open();
                        int effectRows = comm.ExecuteNonQuery(); //ExecuteNonQuery不回傳值
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }

        }

        /// <summary>
        /// 修改使用者資訊SQL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <param name="email"></param>
        public static void UpdateUserInfo(string account, int employeeID, string departmentID, string department, string firstName, string lastName, string contact, string email, string ext, string phone, int jobGrade, string description, string responseSuppliers, string photo, DateTime createDate)
        {


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" UPDATE [dbo].[UserInfo]
                (
                    Account
                   ,EmployeeID
                   ,DepartmentID
                   ,Department
                   ,FirstName
                   ,LastName
                   ,Contact
                   ,Email
                   ,ext
                   ,Phone
                   ,JobGrade
                   ,Description
                   ,ResponseSuppliers
                   ,Photo
                   ,CreateDate
                   ,LastModified
                )
                 VALUES
                (
                    @account
                   ,@employeeID
                   ,@departmentID
                   ,@department
                   ,@firstName
                   ,@lastName
                   ,@contact
                   ,@email
                   ,@ext
                   ,@phone
                   ,@jobGrade
                   ,@description
                   ,@responseSuppliers
                   ,@photo
                   ,@createDate
                   ,@lastModified
                )
                ";


            List<SqlParameter> updatelist = new List<SqlParameter>();
            updatelist.Add(new SqlParameter("@account", account));
            updatelist.Add(new SqlParameter("@employeeID", employeeID));
            updatelist.Add(new SqlParameter("@departmentID", departmentID));
            updatelist.Add(new SqlParameter("@department", department));
            updatelist.Add(new SqlParameter("@firstName", firstName));
            updatelist.Add(new SqlParameter("@lastName", lastName));
            updatelist.Add(new SqlParameter("@contact", contact));
            updatelist.Add(new SqlParameter("@email", email));
            updatelist.Add(new SqlParameter("@ext", ext));
            updatelist.Add(new SqlParameter("@phone", phone));
            updatelist.Add(new SqlParameter("@jobGrade", jobGrade));
            updatelist.Add(new SqlParameter("@description", description));
            updatelist.Add(new SqlParameter("@photo", photo));
            updatelist.Add(new SqlParameter("@createDate", createDate));
            updatelist.Add(new SqlParameter("@lastModified", DateTime.Now));

            try
            {
                DBHelper.CreatData(connStr, dbcommand, updatelist);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);

            }

        }



        /// <summary>
        /// 刪除使用者SQL
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteUserSQL(Guid id)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" DELETE [UserAccount]
                WHERE UserID = @userid
                ";
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@userid", id));
            try
            {
                DBHelper.ModifyData(connStr, dbcommand, paramlist);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }






        /// <summary>
        /// 新增使用者帳號密碼LINQ
        /// </summary>
        public static void CreateUserlinq(string account, string pwd)
        {
            using (DKContextModel context = new DKContextModel())
            {
                try
                {
                    Guid id = Guid.NewGuid();

                    UserAccount newuser = new UserAccount();//宣告newuser為一UserAccounts的新資料列
                                                            //給予欄位數值
                    newuser.UserID = id;
                    newuser.Account = account;
                    newuser.Password = pwd;

                    context.UserAccounts.Add(newuser);//連動DOS的UserAccounts資料表並加入新資料列newuser

                    context.SaveChanges();//寫入DOS
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return;
                }

            }
        }

        /// <summary>
        /// 新增使用者資料LINQ
        /// </summary>
        /// <param name="account"></param>
        /// <param name="employeeID"></param>
        /// <param name="departmentID"></param>
        /// <param name="department"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="contact"></param>
        /// <param name="email"></param>
        /// <param name="ext"></param>
        /// <param name="phone"></param>
        /// <param name="jobGrade"></param>
        /// <param name="description"></param>
        /// <param name="responseSuppliers"></param>
        /// <param name="photo"></param>
        /// <param name="EditDate"></param>
        public static void CreateNewUserInfolinq(string account, int employeeID, string departmentID, string department, string firstName, string lastName, string contact, string email, string ext, string phone, int jobGrade, string description, string responseSuppliers, byte[] photo,DateTime Createdate, DateTime LastDate)
        {
            using (DKContextModel context = new DKContextModel())
            {
                try
                {
                    UserInfo newuserInfo = new UserInfo();
                    //變更
                    newuserInfo.Account = account;
                    newuserInfo.EmployeeID = employeeID;
                    newuserInfo.Department = departmentID;
                    newuserInfo.FirstName = department;
                    newuserInfo.FirstName = firstName;
                    newuserInfo.LastName = lastName;
                    newuserInfo.Contact = contact;
                    newuserInfo.Email = email;
                    newuserInfo.ext = ext;
                    newuserInfo.Phone = phone;
                    newuserInfo.JobGrade = jobGrade;
                    newuserInfo.Description = description;
                    newuserInfo.ResponseSuppliers = responseSuppliers;
                    newuserInfo.Photo = photo;
                    newuserInfo.CreateDate = Createdate;
                    newuserInfo.LastModified = LastDate;

                    context.UserInfoes.Add(newuserInfo);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return;
                }
            }
        }



        /// <summary>
        /// 修改使用者帳號LINQ
        /// </summary>
        public static void UpdateUserAccountlinq(Guid id, string account)
        {
            using (DKContextModel context = new DKContextModel())
            {
                //取得資料(Lambda)
                var userid =
                        context.UserAccounts
                        .Where(obj => obj.UserID == id).FirstOrDefault();

                //變更
                userid.Account = account;

                context.SaveChanges();
            }
        }



        /// <summary>
        /// 修改使用者密碼LINQ
        /// </summary>
        public static void UpdateUserPWDlinq(string account, string pwd)
        {
            using (DKContextModel context = new DKContextModel())
            {
                //取得資料(Lambda)
                var useracc =
                        context.UserAccounts
                        .Where(obj => obj.Account == account).FirstOrDefault();

                //變更
                useracc.Password = pwd;

                context.SaveChanges();
            }
        }


        /// <summary>
        /// 修改使用者資料LINQ
        /// </summary>
        public static void UpdateUserInfolinq(string account, int employeeID, string departmentID, string department, string firstName, string lastName, string contact, string email, string ext, string phone, int jobGrade, string description, string responseSuppliers, byte[] photo, DateTime EditDate)
        {
            using (DKContextModel context = new DKContextModel())
            {
                //取得資料(Lambda)
                var useracc =
                        context.UserInfoes
                        .Where(obj => obj.Account == account).FirstOrDefault();


                //變更
                useracc.Account = account;
                useracc.EmployeeID = employeeID;
                useracc.Department = departmentID;
                useracc.FirstName = department;
                useracc.FirstName = firstName;
                useracc.LastName = lastName;
                useracc.Contact = contact;
                useracc.Email = email;
                useracc.ext = ext;
                useracc.Phone = phone;
                useracc.JobGrade = jobGrade;
                useracc.Description = description;
                useracc.ResponseSuppliers = responseSuppliers;
                useracc.Photo = photo;
                useracc.LastModified = EditDate;

                context.SaveChanges();

            }
        }



        /// <summary>
        /// 刪除使用者LINQ
        /// </summary>
        public static void DeleteUserlinq(string account)
        {
            using (DKContextModel context = new DKContextModel())
            {
                //查出分類&產品
                var DeleteuserAccount =
                    context.UserAccounts.Where(obj => obj.Account == account
                    ).FirstOrDefault();
                var DeleteuserInfo =
                    context.UserInfoes.Where(obj => obj.Account == account).FirstOrDefault();

                //如果不為null執行刪除
                if (DeleteuserAccount != null)
                {
                    context.UserAccounts.Remove(DeleteuserAccount);
                }


                if (DeleteuserInfo != null)
                {
                    context.UserInfoes.Remove(DeleteuserInfo);
                }

                //結果寫入DB
                context.SaveChanges();
            }
        }






        /// <summary>
        /// 查詢使用者userID
        /// </summary>
        public static Guid GetUserID(string account)
        {
            using (DKContextModel context = new DKContextModel())
            {
                var userAccount = 
                    context.UserAccounts
                    .Select(obj => obj.UserID);

                var id = userAccount.FirstOrDefault();
                    return id;

            }

        }





    }
}
