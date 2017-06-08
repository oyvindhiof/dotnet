using System.Collections.Generic;

namespace FitnessCoach.Model
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int Ordinal { get; set; }
        public string Name { get; set; }

        public ExerciseType ExerciseType { get; set; }

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual List<Set> Sets { get; set; }

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual List<Workout> Workouts { get; set; }
    }
}