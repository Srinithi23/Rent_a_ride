//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rent_a_ride
{
    using System;
    using System.Collections.Generic;
    
    public partial class BikeRent
    {
        public int Id { get; set; }
        public string BikeId { get; set; }
        public string CustomerId { get; set; }
        public Nullable<int> Fee { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
