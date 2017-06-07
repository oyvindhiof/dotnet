//using FitnessCoach.DataAccess;
using FitnessCoach.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace FitnessCoach.SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            Workout[] workouts = LoadSampleWorkouts();

            // Fill DB with sample data from JSON-file
            using (var db = new FitnessCoachContext())
            {
                db.Workouts.AddRange(workouts);
                db.SaveChanges();
            }
        }

        private static Workout[] LoadSampleWorkouts()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(path);
            var workoutFilePath = Path.Combine(directory, @"Data\workouts.json");

            return JsonConvert.DeserializeObject<Workout[]>(File.ReadAllText(workoutFilePath));
        }
    }
}