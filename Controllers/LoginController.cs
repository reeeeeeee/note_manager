using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Employee_Info.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public JsonResult Post([FromBody]SignupAccount account)
        {
            int i = 0;
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"Signup.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            foreach (var item in jsonObj)
            {
                string stremail = item["email"].ToString();
                string strpass = item["password"].ToString();

                if (stremail == account.email && strpass == account.password)
                {
                    i = 1;
                    return new JsonResult(i);
                }
                else
                {
                    i = 0;
                }
            }
            return new JsonResult(i);
        }
    }
}
