namespace MiltonHotel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<ROOM> ROOMS { get; set; }
        public virtual DbSet<CARD> CARDs { get; set; }
        public virtual DbSet<BOOKING> BOOKINGs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<ROOM>()
           //     .HasOptional(e => e.ROOMS1)
            //    .WithRequired(e => e.ROOM1);
        }
    }
}
