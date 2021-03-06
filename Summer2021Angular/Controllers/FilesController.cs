using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summer2021Angular.Data;
using Summer2021Angular.Models.Courses;

namespace Summer2021Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly Summer2021AngularContext _context;

        public FilesController(Summer2021AngularContext context)
        {
            _context = context;
        }

        // GET: api/Files
        [HttpGet]
        public async Task<ActionResult<IEnumerable<File>>> GetFile()
        {
            return await _context.File.ToListAsync();
        }

        // GET: api/Files/5
        [HttpGet("{id}")]
        public async Task<ActionResult<File>> GetFile(int id)
        {
            var file = await _context.File.FindAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            return file;
        }

        // PUT: api/Files/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFile(int id, File file)
        {
            if (id != file.FileId)
            {
                return BadRequest();
            }

            _context.Entry(file).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileExists(id))
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

        // POST: api/Files
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<File>> PostFile(File file)
        {
            _context.File.Add(file);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFile", new { id = file.FileId }, file);
        }

        // DELETE: api/Files/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var file = await _context.File.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.File.Remove(file);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileExists(int id)
        {
            return _context.File.Any(e => e.FileId == id);
        }
    }
}
