using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project1.Models;
using project1.Util;
using System.Data.Entity;
using project1.DatabaseMgmt;
using log4net;
using System.Web.Http;


namespace project1.DatabaseMgmt
{
    public class UserRepository
    {
        private sejalEntities1 sejalDBEntities = null;


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UserRepository()
        {
            sejalDBEntities = new sejalEntities1();
        }


        public void SignUp(UserModel user, ResponseModel responseModel)
        {
            try
            {
                var userTable = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Mobile = user.Mobile,
                    Address = user.Address,
                    IsDeleted = Convert.ToByte(user.IsDeleted),
                };
                sejalDBEntities.Users.Add(userTable);
                sejalDBEntities.SaveChanges();
                user.Id = userTable.Id;
                responseModel.data = user;
                responseModel.status = ResponseConstants.SUCCESS;
                responseModel.message = "User added successfully.";
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                responseModel.data = null;
                responseModel.message = "Database error";
                responseModel.status = ResponseConstants.DATABASE_ERROR;
                log.Error(ex);
                return;
            }
            responseModel.message = "User registered successfully.";
        }

        public void UpdateUser(UserModel user, ResponseModel responseModel)
        {
            try
            {
                User userTable = (from x in sejalDBEntities.Users where x.Id == user.Id select x).FirstOrDefault();
                if (userTable!= null) {
                    userTable.FirstName = user.FirstName;
                    userTable.LastName = user.LastName;
                    userTable.Email = user.Email;
                    userTable.Mobile = user.Mobile;
                    userTable.Password = user.Password;
                    userTable.Address = user.Address;
                    userTable.IsDeleted = Convert.ToByte(user.IsDeleted);
                    sejalDBEntities.SaveChanges();
                    responseModel.data = userTable;
                    responseModel.status = ResponseConstants.SUCCESS;
                    responseModel.message = "User modified successfully.";
                }
                else
                {
                    responseModel.message = "User id is invalid";
                    responseModel.status = ResponseConstants.RECORD_NOT_FOUND;
                }

            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                responseModel.data = null;
                responseModel.message = "Database error";
                responseModel.status = ResponseConstants.DATABASE_ERROR;
                log.Error(ex);
                return;
            }
            responseModel.message = "User updated successfully.";
        }


        public void DeleteUser(UserModel user, ResponseModel responseModel)
        {
            try
            {
                User userTable = (from x in sejalDBEntities.Users where x.Id == user.Id select x).FirstOrDefault();
                if (userTable != null)
                {
                    //userTable.FirstName = user.FirstName;
                    //userTable.LastName = user.LastName;
                    //userTable.Email = user.Email;
                    //userTable.Mobile = user.Mobile;
                    //userTable.Password = user.Password;
                    //userTable.Address = user.Address;
                    userTable.IsDeleted = 1;
                    sejalDBEntities.SaveChanges();
                    responseModel.data = userTable;
                    responseModel.status = ResponseConstants.SUCCESS;
                    responseModel.message = "User deleted successfully.";
                }
                else
                {
                    responseModel.message = "User id is invalid";
                    responseModel.status = ResponseConstants.RECORD_NOT_FOUND;
                }

            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                responseModel.data = null;
                responseModel.message = "Database error";
                responseModel.status = ResponseConstants.DATABASE_ERROR;
                log.Error(ex);
                return;
            }
            responseModel.message = "User Deleted successfully.";
        }

        public void RetrieveUser(UserModel user, ResponseModel responseModel)
        {
            try
            {
                List<User> userTable = (from x in sejalDBEntities.Users where x.IsDeleted == 0 select x).ToList();
                if (userTable != null)
                {
                    responseModel.data = userTable;
                    responseModel.status = ResponseConstants.SUCCESS;
                    responseModel.message = "User list available.";
                    
                }
                else
                {
                    responseModel.message = "User list not available";
                    responseModel.status = ResponseConstants.RECORD_NOT_FOUND;
                }

            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                responseModel.data = null;
                responseModel.message = "Database error";
                responseModel.status = ResponseConstants.DATABASE_ERROR;
                log.Error(ex);
                return;
            }
            responseModel.message = "User List Retrieved successfully.";
        }
    }
}