using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using project1.Models;
using project1.Util;
using project1.Business;
using project1.Controllers;

namespace project1.Controllers
{

    public class UserController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Route("api/user/userSignUp")]
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel SignUpUser(UserModel user)
        {
            UserService userService = new UserService();
            ResponseModel responseModel = new ResponseModel();
            try
            {
                userService.UserSignUp(user, responseModel);
            }
            catch (Exception e)
            {
                responseModel.status = ResponseConstants.SYSTEM_ERROR;
                log.Error(e);
            }
            return responseModel;
        }

        [Route("api/user/updateUser")]
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel UpdateUser(UserModel user)
        {
            UserService userService = new UserService();
            ResponseModel responseModel = new ResponseModel();
            try
            {
                userService.UpdateUser(user, responseModel);
            }
            catch (Exception e)
            {
                responseModel.status = ResponseConstants.SYSTEM_ERROR;
                log.Error(e);
            }
            return responseModel;
        }


        [Route("api/user/deleteUser")]
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel DeleteUser(UserModel user)
        {
            UserService userService = new UserService();
            ResponseModel responseModel = new ResponseModel();
            try
            {
                userService.DeleteUser(user, responseModel);
            }
            catch (Exception e)
            {
                responseModel.status = ResponseConstants.SYSTEM_ERROR;
                log.Error(e);
            }
            return responseModel;
        }



        [Route("api/user/getUser")]
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel RetrieveUser(UserModel user)
        {
            UserService userService = new UserService();
            ResponseModel responseModel = new ResponseModel();
            try
            {
                userService.RetrieveUser(user, responseModel);
            }
            catch (Exception e)
            {
                responseModel.status = ResponseConstants.SYSTEM_ERROR;
                log.Error(e);
            }
            return responseModel;
        }
    }
}