using FitnessCoach.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FitnessCoach.Api.Controllers
{
    public class WorkoutsController : ApiController
    {
        private FitnessCoachContext db = new FitnessCoachContext();

        // GET: api/Workouts
        public IQueryable<Workout> GetWorkouts()
        {
            return db.Workouts;
        }

        // GET: api/Workouts/5
        [ResponseType(typeof(Workout))]
        public async Task<IHttpActionResult> GetWorkout(int id)
        {
            Workout workout = await db.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        // PUT: api/Workouts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkout(int id, Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workout.WorkoutId)
            {
                return BadRequest();
            }

            db.Entry(workout).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Workouts
        [ResponseType(typeof(Workout))]
        public async Task<IHttpActionResult> PostWorkout(Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workouts.Add(workout);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workout.WorkoutId }, workout);
        }

        // DELETE: api/Workouts/5
        [ResponseType(typeof(Workout))]
        public async Task<IHttpActionResult> DeleteWorkout(int id)
        {
            Workout workout = await db.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            db.Workouts.Remove(workout);
            await db.SaveChangesAsync();

            return Ok(workout);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkoutExists(int id)
        {
            return db.Workouts.Count(e => e.WorkoutId == id) > 0;
        }
    }
}