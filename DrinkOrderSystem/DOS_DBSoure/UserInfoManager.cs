﻿using DOS_Models;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_DBSoure
{
    public class UserInfoManager
    {








        //以下LINQ

        /// <summary>
        /// 寫出所有使用者資料LINQ
        /// </summary>
        public static List<UserInfo> GetAllUserListLINQ()
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from user in context.UserInfoes
                         select user);

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
        /// 查詢使用者userID
        /// </summary>
        public static Guid GetUserID(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var userID =
                        context.UserAccounts
                        .Where(obj => obj.Account == account)
                        .Select(obj => obj.UserID).FirstOrDefault();

                    
                    return userID;

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return Guid.Empty;
            }


        }


        /// <summary>
        /// 利用帳號取得使用者帳號密碼
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static UserAccount GetUserAccount(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from user in context.UserAccounts
                         where user.Account == account
                         select user);

                    var useraccount = query.FirstOrDefault();
                    return useraccount;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用帳號取得使用者資料
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfo(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                         (from user in context.UserInfoes
                          where user.Account == account
                          select user);

                    var useraccount = query.FirstOrDefault();
                    return useraccount;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>
        /// 利用員工ID查詢資料LINQ
        /// </summary>
        public static List<UserInfo> GetUserInfoEmployeeID(int employeeID)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {

                    var query =
                                (from selectuser in context.UserInfoes
                                 where selectuser.EmployeeID == employeeID
                                 select selectuser);

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
        public static void CreateNewUserInfolinq(string account, int employeeID, string departmentID, string department, string firstName, string lastName, string contact, string email, string ext, string phone, int jobGrade, string description, string responseSuppliers, string photo)
        {
            using (DKContextModel context = new DKContextModel())
            {
                try
                {
                    UserInfo newuserInfo = new UserInfo();
                    //加入
                    newuserInfo.Account = account;
                    newuserInfo.EmployeeID = employeeID;
                    newuserInfo.DepartmentID = departmentID;
                    newuserInfo.Department = department;
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
                    newuserInfo.CreateDate = DateTime.Now;
                    newuserInfo.LastModified = DateTime.Now;

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
        public static void UpdateUserInfolinq(string account, int employeeID, string departmentID, string department, string firstName, string lastName, string contact, string email, string ext, string phone, int jobGrade, string description, string responseSuppliers, string photo, DateTime EditDate)
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
                //查出userAccount資料
                var DeleteuserAccount =
                    context.UserAccounts.Where(obj => obj.Account == account).FirstOrDefault();
                //查出userInfo資料
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
               
                context.SaveChanges();
            }
        }















    }
}
