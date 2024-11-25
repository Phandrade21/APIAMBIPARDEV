using APIAMBIPARDEV.Data;
using APIAMBIPARDEV.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAMBIPARDEV.Controllers
{[Route("api/[controller]")]
 [ApiController]
    public class OcorrenciasController : ControllerBase
    {

        private readonly DataContext _context;

        public OcorrenciasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Ocorrencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetOcorrencias()
        {
            var ocorrencias = await _context.Ocorrencias
                .Include(c => c.ResponsavelOcorrencia)
                .Include(c => c.ResponsavelAbertura)
                .ToListAsync();

            if (ocorrencias.Count > 0)
                ocorrencias.ForEach(x => { x.ResponsavelOcorrencia.OcorrenciasResponsaveis = null; x.ResponsavelOcorrencia.OcorrenciasAbertas = null; });

            return ocorrencias;
        }

        // GET: api/Ocorrencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ocorrencia>> GetOcorrenciaPorId(int id)
        {
            var ocorrencia = await _context.Ocorrencias
                            .Include(c => c.ResponsavelOcorrencia)
                            .Include(c => c.ResponsavelAbertura)
                            .FirstOrDefaultAsync(x => x.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            ocorrencia.ResponsavelOcorrencia.OcorrenciasResponsaveis = null;
            ocorrencia.ResponsavelOcorrencia.OcorrenciasAbertas = null;



            return ocorrencia;
        }

        // PUT: api/Ocorrencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcorrencia(int id, Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(ocorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcorrenciaExists(id))
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

        // POST: api/Ocorrencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ocorrencia>> PostOcorrencia(Ocorrencia ocorrencia)
        {
            if (ocorrencia.ResponsavelOcorrencia == null || ocorrencia.ResponsavelOcorrencia == null)
            {
                return BadRequest("usuarios responsáveis não existem");
            }

            _context.Ocorrencias.Add(ocorrencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcorrenciaPorId", new { id = ocorrencia.Id }, ocorrencia);
        }

        // DELETE: api/Ocorrencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOcorrencia(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OcorrenciaExists(int id)
        {
            return _context.Ocorrencias.Any(e => e.Id == id);
        }
    }
}
