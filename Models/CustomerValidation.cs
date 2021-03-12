using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent_a_ride.Models
{
    [MetadataType(typeof(customerpartial))]

    public partial class Customer
    {
        public class customerpartial
        {
            public string CustomerName { get; set; }
            [DisplayName("Address of Customer")]
            public string CustomerAddress { get; set; }
            public Nullable<int> Mobilenumber { get; set; }
            public Nullable<int> LicenceNumber { get; set; }
        }
    }
}