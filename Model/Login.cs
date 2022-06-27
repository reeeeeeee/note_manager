using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Info.Model
{
    public class Login
    {
        [Key]
        public string UserID { get; set; }
        public string EmpPass { get; set; }
    }
}
