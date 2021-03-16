using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_a_ride.Models
{
    public class RentViewModel
    {
        public int Id { get; set; }
        public string CarId { get; set; }
        public string CustomerId { get; set; }
        public Nullable<int> Fee { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }

        public string Available { get; set; }


    }
}