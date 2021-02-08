using GigHub1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub1.ViewModel
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcommingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}