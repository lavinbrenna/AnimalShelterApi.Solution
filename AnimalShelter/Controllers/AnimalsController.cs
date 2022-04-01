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
    // [ApiVersion("1.0")]
    // [Route("api/{m:apiVersion}/Animals")]
    // public class AnimalsV1Controller : Controller
    // {
    //     [HttpGet]
    //     public IEnumerable<string> Get()
    //     {
    //         return new string[] {"Value1 from Version 1", "value2 from Version 1"};
    //     }
    // }

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalShelterContext db;
        private readonly IUriService uriService;

        public AnimalsController(AnimalShelterContext db, IUriService uriService)
        {
            this.db = db;
            this.uriService = uriService;

        }

        // GET: api/Animals
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
        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var animal = await db.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return BadRequest();
            }

            db.Entry(animal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            db.Animals.Add(animal);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.AnimalId }, animal);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            db.Animals.Remove(animal);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return db.Animals.Any(e => e.AnimalId == id);
        }
    }
}
