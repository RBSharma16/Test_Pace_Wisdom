using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaceWisdomAssignment.Models
{
    public class items
    {
        public string title { get; set; }
        public string link { get; set; }
        public media media { get; set; }
        public string date_taken { get; set; }
        public string description { get; set; }
        public string published { get; set; }
        public string author { get; set; }
        public string author_id { get; set; }
        public string tags { get; set; }
    }
}