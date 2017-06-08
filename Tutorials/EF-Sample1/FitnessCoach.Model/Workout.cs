using System.Collections.Generic;

namespace FitnessCoach.Model
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        public WorkoutType WorkoutType { get; set; }

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual List<Exercise> Exercises { get; set; }
    }
}