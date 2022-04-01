using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AnimalShelter.Filter;
using AnimalShelter.Helpers;
using AnimalShelter.Models;
using AnimalShelter.Services;
using AnimalShelter.Wrappers;
namespace AnimalShelter.Controllers

{
    [ApiVersion("1.0")]
    [Route("api/{m:apiVersion}/Animals")]
    public class AnimalsV1Controller : Controller
    {
        private readonly AnimalShelterContext db;
        private readonly IUriService uriService;
        public AnimalsV1Controller(AnimalShelterContext db, IUriService uriService)
        {
            this.db = db;
            this.uriService = uriService;

        }
          //GET: api/Animals
        ///<summary>
        ///Shows paginated version of results 
        ///</summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await db.Animals
                .Skip((validFilter.PageNumber - 1) *validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await db.Animals.CountAsync();
            var pagedResponse = PaginationHelper.CreatePagedResponse<Animal>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedResponse);
        }
    }
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalShelterContext _db;

        public AnimalsController(AnimalShelterContext db )
        {
            _db = db;

        }

     

        ///GET:api/Animals/
        ///<summary>
        ///Gets Animals based on query url
        ///</summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> Get(string breed, string type, string name, string gender, int toDate, int fromDate)
        {
            var query = _db.Animals.AsQueryable();

            if (breed != null)
            {
                query = query.Where(entry => entry.Breed == breed);
            }
            if (type != null)
            {
                query = query.Where(entry => entry.Type == type);
            }
            if(name != null)
            {
                query = query.Where(entry => entry.Name ==name);
            }
            if(gender != null)
            {
                query = query.Where(entry => entry.Gender == gender);
            }
            return await query.ToListAsync();
        }
        
        // GET: api/Animals/5/
        ///<summary>
        ///Gets Animals based on id
        ///</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimal(int id)
        {
            var animal = await _db.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT: api/Animals/5
        ///<summary>
        ///Updates Animal based on id
        ///</summary>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return BadRequest();
            }

            _db.Entry(animal).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Animals
        ///<summary>
        ///Creates a new animal in the database
        ///</summary>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            _db.Animals.Add(animal);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.AnimalId }, animal);
        }

        // DELETE: api/Animals/5
        ///<summary>
        ///Deletes animal based on id
        ///</summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _db.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _db.Animals.Remove(animal);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return _db.Animals.Any(e => e.AnimalId == id);
        }
    }
}
