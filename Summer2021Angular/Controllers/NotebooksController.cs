﻿using System;
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
    public class NotebooksController : ControllerBase
    {
        private readonly Summer2021AngularContext _context;

        public NotebooksController(Summer2021AngularContext context)
        {
            _context = context;
        }

        // GET: api/Notebooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notebook>>> GetNotebook()
        {
            return await _context.Notebook.ToListAsync();
        }

        // GET: api/Notebooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notebook>> GetNotebook(int id)
        {
            var notebook = await _context.Notebook.FindAsync(id);

            if (notebook == null)
            {
                return NotFound();
            }

            return notebook;
        }

        // PUT: api/Notebooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotebook(int id, Notebook notebook)
        {
            if (id != notebook.NotebookId)
            {
                return BadRequest();
            }

            _context.Entry(notebook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotebookExists(id))
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

        // POST: api/Notebooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notebook>> PostNotebook(Notebook notebook)
        {
            _context.Notebook.Add(notebook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotebook", new { id = notebook.NotebookId }, notebook);
        }

        // DELETE: api/Notebooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotebook(int id)
        {
            var notebook = await _context.Notebook.FindAsync(id);
            if (notebook == null)
            {
                return NotFound();
            }

            _context.Notebook.Remove(notebook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotebookExists(int id)
        {
            return _context.Notebook.Any(e => e.NotebookId == id);
        }
    }
}
