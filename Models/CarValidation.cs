using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent_a_ride.Models
{
    [MetadataType(typeof(CarRegisterpartial))]
    public partial class CarRegister
    {
        public class CarRegisterpartial
        {
            [Display(Name="Car Number")]
            [Required]
            public string CarNum { get; set; }
          

            public string Brand { get; set; }
            public string Model { get; set; }
            public string Available { get; set; }
        }
    }
}