namespace MiltonHotel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model4 : DbContext
    {
        public Model4()
            : base("name=card")
        {
        }

        public virtual DbSet<CARD> CARDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}