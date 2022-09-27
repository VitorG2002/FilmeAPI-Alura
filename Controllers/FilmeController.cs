using FilmeAPI.Data;
using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FilmeController : ControllerBase
    {
        private readonly FilmeContext _context;

        public FilmeController(FilmeContext context) { _context = context; }


        [HttpGet]
        public async Task<IActionResult> GetFilmes()
        {
            return Ok(await _context.Filmes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddFilme([FromBody] Filme filme)
        {
            _context.Add(filme);
            await _context.SaveChangesAsync();
            return Ok(await _context.Filmes.ToListAsync());
            //     return CreatedAtAction(nameof(GetFilme), new { Id = filme.Id }, filme);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);
            if (filme == null)
            {
                return NotFound();

            }
            else
                return Ok(await filme);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilme([FromBody] Filme request)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == request.Id);
            if (filme == null)
                return NotFound();

            filme.Titulo = request.Titulo;
            filme.Diretor = request.Diretor;

            await _context.SaveChangesAsync();

            return Ok(await _context.Filmes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);
            if (filme != null)
            {
                _context.Remove(filme);
                await _context.SaveChangesAsync();
                return Ok(await _context.Filmes.ToListAsync());
            }
            else
                return NotFound();

        }

    }
}
