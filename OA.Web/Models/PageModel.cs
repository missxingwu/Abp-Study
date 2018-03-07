using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA.Web.Models
{
    public class PageModel
    {
        public int sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
       // public List<List<string>> aaData { get; set; }
        public string sColumns { get; set; }

        public List<string[]> aaData { get; set; }
       
    }
}