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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentaRidedbEntities2 : DbContext
    {
        public RentaRidedbEntities2()
            : base("name=RentaRidedbEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BikeRegister> BikeRegisters { get; set; }
        public virtual DbSet<CarRegister> CarRegisters { get; set; }
        public virtual DbSet<CarRent> CarRents { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dropbike> Dropbikes { get; set; }
        public virtual DbSet<Dropcar> Dropcars { get; set; }
        public virtual DbSet<BikeRent> BikeRents { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
    }
}
