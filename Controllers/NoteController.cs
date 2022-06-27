using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Employee_Info.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            List<NoteType> notelist = new List<NoteType>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"Note.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            //var users = JsonConvert.DeserializeObject<List<NoteType>>(jsonObj);
            foreach (var item in jsonObj["NoteType"])
            {
                var Note = new NoteType
                {
                    NoteTypeID = item["NoteTypeID"],
                    NoteTypeName = item["NoteTypeName"].ToString()
                };
                notelist.Add(Note);
            }
            return new JsonResult(notelist);
        }

        [HttpGet]
        [Route("LoadAllNote")]
        public JsonResult GetAllNote()
        {
            List<AllNote> notelist = new List<AllNote>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"AllNote.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            //var users = JsonConvert.DeserializeObject<List<NoteType>>(jsonObj);
            if (jsonObj != null)
            {
                foreach (var item in jsonObj)
                {
                    //var settings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd", DateTimeZoneHandling = DateTimeZoneHandling.Utc };
                    //var json = JsonConvert.SerializeObject(item["Datetime"], settings);
                    string sa = item["Datetime"];
                    DateTime dt = new DateTime();
                    dt = parseDateTimeFromStringLiteral(sa);

                    var Note = new AllNote
                    {
                        NoteTypeID = item["NoteTypeID"],
                        NoteText = item["NoteText"].ToString(),
                        Datetime = dt.ToShortDateString(),
                        InoperationID = item["InoperationID"]
                    };
                    notelist.Add(Note);
                }
            }
            else
            {
                return new JsonResult(notelist);
            }
            
            return new JsonResult(notelist);
        }

        [HttpGet]
        [Route("LoadTodayRemTodo")]
        public JsonResult GetTodayRemTodo()
        {
            List<AllNote> notelist = new List<AllNote>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"AllNote.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            //var users = JsonConvert.DeserializeObject<List<NoteType>>(jsonObj);
            if (jsonObj != null)
            {
                foreach (var item in jsonObj)
                {
                    string sa = item["Datetime"];
                    DateTime dt = new DateTime();
                    dt = parseDateTimeFromStringLiteral(sa);

                    DateTime dateTime = DateTime.UtcNow.Date;
                    if ((item["NoteTypeID"]==2 || item["NoteTypeID"]==3) && (dateTime.ToString("d") == dt.ToString("d")))
                    {
                        var Note = new AllNote
                        {
                            NoteTypeID = item["NoteTypeID"],
                            NoteText = item["NoteText"].ToString(),
                            Datetime = dt.ToShortDateString(),
                            InoperationID = item["InoperationID"]
                        };
                        notelist.Add(Note);
                    }
                }
            }
            else
            {
                return new JsonResult(notelist);
            }

            return new JsonResult(notelist);
        }

        [HttpGet]
        [Route("LoadWeekRemTodo")]
        public JsonResult GetWeekRemTodo()
        {
            List<AllNote> notelist = new List<AllNote>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"AllNote.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            //var users = JsonConvert.DeserializeObject<List<NoteType>>(jsonObj);
            if (jsonObj != null)
            {
                foreach (var item in jsonObj)
                {
                    string sa = item["Datetime"];
                    DateTime dt = new DateTime();
                    dt = parseDateTimeFromStringLiteral(sa);

                    DateTime dateTime = DateTime.UtcNow.Date;

                    

                    if ((item["NoteTypeID"] == 2 || item["NoteTypeID"] == 3) && (dateTime<=dt || dateTime.AddDays(7)<=dt))
                    {
                        var Note = new AllNote
                        {
                            NoteTypeID = item["NoteTypeID"],
                            NoteText = item["NoteText"].ToString(),
                            Datetime = dt.ToShortDateString(),
                            InoperationID = item["InoperationID"]
                        };
                        notelist.Add(Note);
                    }
                }
            }
            else
            {
                return new JsonResult(notelist);
            }

            return new JsonResult(notelist);
        }

        [HttpGet]
        [Route("LoadMonthRemTodo")]
        public JsonResult GetMonthRemTodo()
        {
            List<AllNote> notelist = new List<AllNote>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"AllNote.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            //var users = JsonConvert.DeserializeObject<List<NoteType>>(jsonObj);
            if (jsonObj != null)
            {
                foreach (var item in jsonObj)
                {
                    string sa = item["Datetime"];
                    DateTime dt = new DateTime();
                    dt = parseDateTimeFromStringLiteral(sa);

                    DateTime dateTime = DateTime.UtcNow.Date;



                    if ((item["NoteTypeID"] == 2 || item["NoteTypeID"] == 3) && (dateTime <= dt || dateTime.AddDays(30) <= dt))
                    {
                        var Note = new AllNote
                        {
                            NoteTypeID = item["NoteTypeID"],
                            NoteText = item["NoteText"].ToString(),
                            Datetime = dt.ToShortDateString(),
                            InoperationID = item["InoperationID"]
                        };
                        notelist.Add(Note);
                    }
                }
            }
            else
            {
                return new JsonResult(notelist);
            }

            return new JsonResult(notelist);
        }

        private static DateTime parseDateTimeFromStringLiteral(string str)
        {
            return JsonConvert.DeserializeObject<DateTime>(@"""" + str + @"""");
        }

        [HttpPost]
        public JsonResult Post([FromBody] AllNote acc)
        {
            int i = 0;
            List<AllNote> notelist = new List<AllNote>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"AllNote.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            if (jsonObj != null)
            {
                foreach (var item in jsonObj)
                {
                    var Note = new AllNote
                    {
                        NoteTypeID = item["NoteTypeID"],
                        NoteText = item["NoteText"].ToString(),
                        Datetime = item["Datetime"],
                        InoperationID= item["InoperationID"].ToString()
                    };
                    notelist.Add(Note);
                }
                notelist.Add(new AllNote()
                {
                    NoteTypeID = acc.NoteTypeID,
                    NoteText = acc.NoteText,
                    Datetime = acc.Datetime,
                    InoperationID = acc.InoperationID == "" ? "N/A" : acc.InoperationID
                });
                i = 1;
            }
            else
            {
               
                notelist.Add(new AllNote()
                {
                    NoteTypeID = acc.NoteTypeID,
                    NoteText = acc.NoteText,
                    Datetime = acc.Datetime,
                    InoperationID = acc.InoperationID == "" ? "N/A" : acc.InoperationID
                });
                i = 1;
            }

            var jsonData = JsonConvert.SerializeObject(notelist);
            System.IO.File.WriteAllText(folderDetails, jsonData);
            return new JsonResult(i);
        }

    }
}