using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaRestaurantly.Entities
{
    public class Chef
    {
        public int ChefId { get; set; }
        public int Name { get; set; }
        public int Title { get; set; }
        public int ImageUrl { get; set; }
    }
}