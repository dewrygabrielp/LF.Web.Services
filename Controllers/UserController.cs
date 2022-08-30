using LF.Web.Services.Models;
using LF.Web.Services.Models.Request;
using LF.Web.Services.Models.Response;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LF.Web.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]

        public IActionResult Get()
        {
            Response oResponse = new Response();

            IEnumerable<UserModel> lst;
            try
            {


                using (LiveFlowingContext db = new LiveFlowingContext())
                {

                    lst = db.UserModel.ToList();
                    oResponse.Success = 1;
                    oResponse.Data = lst;

                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }

        [HttpGet]
        [Route("loginuser/{emailField}/{passwordField}")]
        public IActionResult Get(string emailField, string passwordField)
        {
            Response oResponse = new Response();

          
            try
            {


                using (LiveFlowingContext db = new LiveFlowingContext())
                {
                    var userInfo = db.UserModel.Where(u => u.EmailField == emailField && u.PasswordField == passwordField).ToList();
                   
                    oResponse.Success = 1;
                    oResponse.Data = userInfo;

                }
            }
            catch (Exception ex)
            {
                
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse.Data);

        }
        [HttpGet("{Id}")]

        public IActionResult Getpath(int id)
        {
            Response oResponse = new Response();


            try
            {


                using (LiveFlowingContext db = new LiveFlowingContext())
                {
                    var user = db.UserModel.Find(id);


                    oResponse.Success = 1;
                    oResponse.Data = user;

                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }
        [HttpPost]

        public IActionResult Post(UserRequest oUserRequest)
        {
            Response oResponse = new Response();


            try
            {

                using (LiveFlowingContext db = new LiveFlowingContext())
                {


                    UserModel oUser = new UserModel();
                    oUser.EmailField = oUserRequest.EmailField;
                    oUser.PasswordField = oUserRequest.PasswordField;
                    oUser.CreationDate = oUserRequest.CreationDate;
                    oUser.NameField = oUserRequest.NameField;
                    oUser.AgeField = oUserRequest.AgeField;
                    db.UserModel.Add(oUser);
                    db.SaveChanges();
                    oResponse.Success = 1;

                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }
        [HttpPut]
        public IActionResult Put(UserRequest oUserRequest)
        {
            Response oResponse = new Response();


            try
            {

                using (LiveFlowingContext db = new LiveFlowingContext())
                {


                    UserModel oUser = db.UserModel.Find(oUserRequest.UserId);

                    oUser.EmailField = oUserRequest.EmailField;
                    oUser.PasswordField = oUserRequest.PasswordField;
                    oUser.CreationDate = oUserRequest.CreationDate;
                    oUser.NameField = oUserRequest.NameField;
                    oUser.AgeField = oUserRequest.AgeField;

                    db.Entry(oUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oResponse.Success = 1;

                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Response oResponse = new Response();


            try
            {

                using (LiveFlowingContext db = new LiveFlowingContext())
                {


                    UserModel oUser = db.UserModel.Find(Id);
                    db.Remove(oUser);
                    db.SaveChanges();
                    oResponse.Success = 1;

                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }

    }
}
