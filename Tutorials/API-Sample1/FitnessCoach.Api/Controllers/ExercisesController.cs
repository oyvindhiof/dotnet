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
    public class ExercisesController : ApiController
    {
        private FitnessCoachContext db = new FitnessCoachContext();

        // GET: api/Exercises
        public IQueryable<Exercise> GetExercises()
        {
            return db.Exercises;
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public async Task<IHttpActionResult> GetExercise(int id)
        {
            Exercise exercise = await db.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExercise(int id, Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.ExerciseId)
            {
                return BadRequest();
            }

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercises
        [ResponseType(typeof(Exercise))]
        public async Task<IHttpActionResult> PostExercise(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercises.Add(exercise);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exercise.ExerciseId }, exercise);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public async Task<IHttpActionResult> DeleteExercise(int id)
        {
            Exercise exercise = await db.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercise);
            await db.SaveChangesAsync();

            return Ok(exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseExists(int id)
        {
            return db.Exercises.Count(e => e.ExerciseId == id) > 0;
        }
    }
}