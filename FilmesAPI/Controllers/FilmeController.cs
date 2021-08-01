using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context { get; set; }

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            //no _context tem acesso a lista de filmes, trabalhando igual anteriormente
            _context.Filmes.Add(filme);
            // SaveChanges realiza o insert no banco
            _context.SaveChanges();
            // CreatedAtAction indica que o registro foi criado, mostra qual endpoint pode ser usado para recuperar o item, qual o ID e com qual dados ele foi craido
            return CreatedAtAction(nameof(RecuperarFilmeId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmeId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
                return Ok(filme);

            return NotFound();
        }
    }
}
