using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Info.Model
{
    public class NoteType
    {
        public int NoteTypeID { get; set; }
        public string NoteTypeName { get; set; }
    }

    public class AllNote
    {
        public int NoteTypeID { get; set; }

        public string NoteText { get; set; }
        public string Datetime { get; set; }
        public string InoperationID { get; set; }
    }
}
