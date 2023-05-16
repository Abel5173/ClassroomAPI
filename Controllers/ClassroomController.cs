using ClassroomAPI.Data;
using ClassroomAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassroomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomController : ControllerBase
    {
        private readonly ClassroomContext _context;

        public ClassroomController(ClassroomContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {
            var classroom = await _context.classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }

        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            _context.classrooms.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassroom), new { id = classroom.Id }, classroom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom(int id, Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var classroom = await _context.classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            _context.classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
