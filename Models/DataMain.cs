using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaceWisdomAssignment.Models
{
    public class DataMain
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string modified { get; set; }
        public string generator { get; set; }
        public List<items> items { get; set; }
    }
}