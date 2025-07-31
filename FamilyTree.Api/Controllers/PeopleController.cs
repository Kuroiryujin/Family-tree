using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FamilyTree.Api.Data;
using FamilyTree.Shared.Dto;
using FamilyTree.Shared.Entity;

namespace FamilyTree.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/people
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPeople()

        {
            var personEntity = await _context.People.ToListAsync();
            var personDto = personEntity.Select(person => new PersonDto(person)).ToList();

            return Ok(personDto);
        }

        // GET: api/people/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonDto>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null) return NotFound();
            return new PersonDto(person);
        }

        // POST: api/people
        [HttpPost]
        public async Task<ActionResult<PersonDto>> PostPerson(PersonDto person)
        {
            _context.People.Add(new PersonEntity(person));
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // PUT: api/people/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPerson(int id, PersonDto person)
        {
            if (id != person.Id) return BadRequest();
            _context.Entry(new PersonEntity(person)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.People.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/people/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null) return NotFound();

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}