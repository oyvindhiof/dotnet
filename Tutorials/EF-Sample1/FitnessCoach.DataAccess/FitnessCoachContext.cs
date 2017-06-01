using FitnessCoach.Model;
using System.Data.Entity;

namespace FitnessCoach.DataAccess
{
    public class FitnessCoachContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
    }
}
