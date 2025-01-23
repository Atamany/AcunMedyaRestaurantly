using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaRestaurantly.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}