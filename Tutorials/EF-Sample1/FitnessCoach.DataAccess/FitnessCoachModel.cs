namespace FitnessCoach.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class FitnessCoachModel : DbContext
    {
        public FitnessCoachModel()
            : base("name=FitnessCoachDbConnectionString")
        {
        }

        public DbSet<Set> Sets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
