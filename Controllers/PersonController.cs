using LF.Web.Services.Models;
using LF.Web.Services.Models.Request;
using LF.Web.Services.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LF.Web.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        [HttpGet]

        public IActionResult Get()
        {
            Response oResponse = new Response();

            IEnumerable<PersonModel> lst;
            try
            {


                using (LiveFlowingContext db = new LiveFlowingContext())
                {
                    lst = db.PersonModel.ToList();
                    oResponse.Success = 1;
                    oResponse.Data = lst;

                }
            }
            catch(Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }
        [HttpGet("{Id}")]

        public IActionResult Getpath(int id)
        {
            Response oResponse = new Response();

          
            try
            {
                

                using (LiveFlowingContext db = new LiveFlowingContext())
                {
                    var person = db.PersonModel.Find(id);

                    
                    oResponse.Success = 1;
                    oResponse.Data = person;

                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }
        [HttpPost]

        public IActionResult Post(PersonRequest oPersonRequest)
        {
            Response oResponse = new Response();


            try
            {

                using (LiveFlowingContext db = new LiveFlowingContext())
                {


                    PersonModel oPerson = new PersonModel();
                    oPerson.NameField = oPersonRequest.NameField;
                    oPerson.AgeField = oPersonRequest.AgeField;
                    db.PersonModel.Add(oPerson);
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
        public IActionResult Put(PersonRequest oPersonRequest)
        {
            Response oResponse = new Response();


            try
            {

                using (LiveFlowingContext db = new LiveFlowingContext())
                {


                    PersonModel oPerson = db.PersonModel.Find(oPersonRequest.PersonId);
                    
                    oPerson.NameField = oPersonRequest.NameField;
                    oPerson.AgeField = oPersonRequest.AgeField;
                    
                    db.Entry(oPerson).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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


                    PersonModel oPerson = db.PersonModel.Find(Id);
                    db.Remove(oPerson);
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
