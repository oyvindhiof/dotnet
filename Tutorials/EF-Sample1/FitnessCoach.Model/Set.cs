namespace FitnessCoach.Model
{
    public class Set
    {
        public int SetId { get; set; }
        public int Ordinal { get; set; }
        public int Repetitions { get; set; }
        public double Weigth { get; set; }

        public int ExerciseId { get; set; }

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual Exercise Exercise { get; set; }
    }
}