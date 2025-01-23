using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcunMedyaRestaurantly.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        [StringLength(250)]
        public string Message { get; set; }
        public bool isRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}