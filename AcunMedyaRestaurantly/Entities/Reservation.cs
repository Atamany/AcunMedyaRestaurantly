using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaRestaurantly.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public byte GuestCount { get; set; }
        public string ReservationStatus { get; set; }
    }
}