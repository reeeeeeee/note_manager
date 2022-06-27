using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Employee_Info.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"Signup.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            foreach (var item in jsonObj["SignupAccount"])
            {
                var Signup = new SignupAccount
                {
                    name= item["name"].ToString(),
                    email = item["email"].ToString(),
                    dateofbirth = item["dateofbirth"].ToString(),
                    password = item["password"].ToString()
                    //    Code = item["Code"].ToString(),
                    //    Description = item["Description"].ToString(),
                    //    AgencyId = id,
                    //    IsActive = true,
                    //    IsDeleted = false,
                    //    AddedBy = User.GetUserId(),
                    //    ModifiedBy = User.GetUserId()
                    //AddedOn = DateTime.Now,
                    //    ModifiedOn = DateTime.Now
                };
                return new JsonResult(Signup);
            }
            return null;
        }
    }
}