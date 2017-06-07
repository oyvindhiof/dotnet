using FitnessCoach.Model;
using static Newtonsoft.Json.JsonConvert;
using static System.IO.File;
using static System.IO.Path;
using static System.Reflection.Assembly;

namespace FitnessCoach.SampleData
{
    class Program
    {
        /// <summary>
        /// Loads sample data from a JSON file into the database.
        /// </summary>
        static void Main()
        {
            using (var db = new FitnessCoachContext())
            {
                db.Workouts.AddRange(LoadSampleWorkouts());
                db.SaveChanges();
            }
        }

        private static Workout[] LoadSampleWorkouts()
        {
            var directory = GetDirectoryName(GetExecutingAssembly().Location);
            var workoutFilePath = Combine(directory, @"Data\workouts.json");

            return DeserializeObject<Workout[]>(ReadAllText(workoutFilePath));
        }
    }
}