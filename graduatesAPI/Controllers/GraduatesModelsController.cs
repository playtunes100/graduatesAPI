using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using graduatesAPI.Models;

namespace graduatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraduatesModelsController : ControllerBase
    {
        private readonly GraduatesContext _context;

        public GraduatesModelsController(GraduatesContext context)
        {
            _context = context;
        }

        // GET: api/GraduatesModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GraduatesModel>>> GetGraduatesModels()
        {
            return await _context.GraduatesModels.ToListAsync();
        }

        // GET: api/GraduatesModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GraduatesModel>> GetGraduatesModel(Guid id)
        {
            var graduatesModel = await _context.GraduatesModels.FindAsync(id);

            if (graduatesModel == null)
            {
                return NotFound();
            }

            return graduatesModel;
        }

        // PUT: api/GraduatesModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraduatesModel(Guid id, GraduatesModel graduatesModel)
        {
            if (id != graduatesModel.GraduateId)
            {
                return BadRequest();
            }

            _context.Entry(graduatesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraduatesModelExists(id))
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

        // POST: api/GraduatesModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GraduatesModel>> PostGraduatesModel(GraduatesModel graduatesModel)
        {
            _context.GraduatesModels.Add(graduatesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGraduatesModel", new { id = graduatesModel.GraduateId }, graduatesModel);
        }

        // DELETE: api/GraduatesModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduatesModel(Guid id)
        {
            var graduatesModel = await _context.GraduatesModels.FindAsync(id);
            if (graduatesModel == null)
            {
                return NotFound();
            }

            graduatesModel.IsDeleted = true;

            _context.Entry(graduatesModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GraduatesModelExists(Guid id)
        {
            return _context.GraduatesModels.Any(e => e.GraduateId == id);
        }
    }
}
