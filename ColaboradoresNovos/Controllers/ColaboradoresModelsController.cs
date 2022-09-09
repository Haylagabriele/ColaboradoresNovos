using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColaboradoresNovos.Data;
using ColaboradoresNovos.Models;

namespace ColaboradoresNovos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ColaboradoresModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ColaboradoresModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradoresModel>>> Getcolaboradores()
        {
          if (_context.colaboradores == null)
          {
              return NotFound();
          }
            return await _context.colaboradores.ToListAsync();
        }

        // GET: api/ColaboradoresModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradoresModel>> GetColaboradoresModel(int id)
        {
          if (_context.colaboradores == null)
          {
              return NotFound();
          }
            var colaboradoresModel = await _context.colaboradores.FindAsync(id);

            if (colaboradoresModel == null)
            {
                return NotFound();
            }

            return colaboradoresModel;
        }

        // PUT: api/ColaboradoresModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaboradoresModel(int id, ColaboradoresModel colaboradoresModel)
        {
            if (id != colaboradoresModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(colaboradoresModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradoresModelExists(id))
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

        // POST: api/ColaboradoresModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ColaboradoresModel>> PostColaboradoresModel(ColaboradoresModel colaboradoresModel)
        {
          if (_context.colaboradores == null)
          {
              return Problem("Entity set 'ApplicationDbContext.colaboradores'  is null.");
          }
            _context.colaboradores.Add(colaboradoresModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColaboradoresModel", new { id = colaboradoresModel.Id }, colaboradoresModel);
        }

        // DELETE: api/ColaboradoresModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaboradoresModel(int id)
        {
            if (_context.colaboradores == null)
            {
                return NotFound();
            }
            var colaboradoresModel = await _context.colaboradores.FindAsync(id);
            if (colaboradoresModel == null)
            {
                return NotFound();
            }

            _context.colaboradores.Remove(colaboradoresModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaboradoresModelExists(int id)
        {
            return (_context.colaboradores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
