using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace crudInMacos
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            PersonRepository personRepository = new();

            List<PersonModel> data = personRepository.Read();

            return Ok(new { data });
        }
        [HttpPost]
        public ActionResult Post()
        {
            var status = false;

            var mode = Request.Form["mode"];

            var name = Request.Form["name"];
            var age = Request.Form["age"];
            var gender = Request.Form["gender"];

            var personId = Request.Form["personId"];
            

            PersonRepository personRepository = new();

            List<PersonModel> data = new();

            var code = "";
            switch (mode)
            {
                case "create":
                    try
                    {
                        personRepository.Create(name, Convert.ToInt32(age), gender);

                        code = ((int)ReturnCode.CREATE_SUCCESS).ToString();
                        status = true;

                    }
                    catch (Exception ex)
                    {
                        code = ex.Message;

                    }
                    break;
                case "read":
                    try
                    {
                        data = personRepository.Read();
                        code = ((int)ReturnCode.CREATE_SUCCESS).ToString();
                        status = true;

                    }
                    catch (Exception ex)
                    {
                        code = ex.Message;

                    }

                    break;
                case "update":
                    try
                    {
                        personRepository.Update(name, gender, Convert.ToInt32(age), Convert.ToInt32(personId));
                        code = ((int)ReturnCode.UPDATE_SUCCESS).ToString();
                        status = true;

                    }
                    catch (Exception ex)
                    {
                        code = ex.Message;

                    }
                    break;
                case "delete":
                    try
                    {
                        personRepository.Delete(Convert.ToInt32(personId));

                        code = ((int)ReturnCode.DELETE_SUCCESS).ToString();
                        status = true;

                    }
                    catch (Exception ex)
                    {
                        code = ex.Message;

                    }
                    break;
                default:
                    code = ((int)ReturnCode.ACCESS_DENIED_NO_MODE).ToString();
                    break;
            }

            return Ok(new { status, code, data });
        }

    }
}
