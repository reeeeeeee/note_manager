using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Employee_Info.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public JsonResult Post([FromBody] AccountRegistration acc)
        {
            int i = 0;
            List<AccountRegistration> notelist = new List<AccountRegistration>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"Signup.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            if (jsonObj != null)
            {
                foreach (var item in jsonObj)
                {
                    var Note = new AccountRegistration
                    {
                        name = item["name"],
                        email = item["email"].ToString(),
                        dateofbirth = item["dateofbirth"].ToString(),
                        password = item["password"].ToString()
                    };
                    notelist.Add(Note);
                }
                notelist.Add(new AccountRegistration()
                {
                    name = acc.name,
                    email = acc.email,
                    dateofbirth = acc.dateofbirth,
                    password = acc.password
                });
                i = 1;
            }
            else
            {
                notelist.Add(new AccountRegistration()
                {
                    name = acc.name,
                    email = acc.email,
                    dateofbirth = acc.dateofbirth,
                    password = acc.password
                });
                i = 1;
            }

            var jsonData = JsonConvert.SerializeObject(notelist);
            System.IO.File.WriteAllText(folderDetails, jsonData);
            return new JsonResult(i);
        }
    }
}