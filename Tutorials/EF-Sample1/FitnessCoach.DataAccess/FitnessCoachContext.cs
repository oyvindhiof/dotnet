using FitnessCoach.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

public partial class FitnessCoachContext : DbContext
{
    public FitnessCoachContext()
        : base("name=FitnessCoachConnectionString") { }

    public virtual DbSet<Workout> Workouts { get; set; }
    public virtual DbSet<Exercise> Exercises { get; set; }
    public virtual DbSet<Set> Sets { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        Configuration.ProxyCreationEnabled = false;

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        modelBuilder.Entity<Workout>()
            .HasMany(w => w.Exercises)
            .WithMany(e => e.Workouts)
            .Map(m =>
            {
                m.ToTable("WorkoutExercise");
                m.MapLeftKey("ExerciseId");
                m.MapRightKey("WorkoutId");
            });
    }
}