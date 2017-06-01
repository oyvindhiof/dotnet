using FitnessCoach.Model;
using Newtonsoft.Json;
using System.IO;

namespace FitnessCoach.SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(path);
            var workoutFilePath = Path.Combine(directory, @"Data\workouts.json");

            var workouts = JsonConvert.DeserializeObject<Workout[]>(File.ReadAllText(workoutFilePath));
        }
    }
}
