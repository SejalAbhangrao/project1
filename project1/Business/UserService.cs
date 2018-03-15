using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using project1.Models;
using project1.Util;
using project1.Business;
using project1.DatabaseMgmt;

namespace project1.Business
{
    public class UserService
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void UserSignUp(UserModel user, ResponseModel responseModel)
        {

            UserRepository userRepository = new UserRepository();
           try
            {
                log.Debug("Sign up called for user " + user.Email);
                userRepository.SignUp(user, responseModel);
            }
            catch (Exception e)
            {
                log.Error(e);
                responseModel.status = ResponseConstants.SYSTEM_ERROR;
                responseModel.message = "Internal server error.";
            }
        }

    }
}