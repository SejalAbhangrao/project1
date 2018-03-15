using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project1.Models;
using project1.Util;
using log4net;
using System.Web.Http;


namespace project1.DatabaseMgmt
{
    public class UserRepository
    {
        private sejalEntities sejalDBEntities = null;


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UserRepository()
        {
            sejalDBEntities = new sejalEntities();
        }


        public void CreateUserEntry(UserModel user, ResponseModel responseModel)
        {
            try
            {
                var userTable =  new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Mobile = user.Mobile,
                    Address = user.Address,
                    IsDeleted = user.IsDeleted,
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
    }
}