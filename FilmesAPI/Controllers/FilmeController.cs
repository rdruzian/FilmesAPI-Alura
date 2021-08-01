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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);

            // CreatedAtAction indica que o registro foi criado, mostra qual endpoint pode ser usado para recuperar o item, qual o ID e com qual dados ele foi craido
            return CreatedAtAction(nameof(RecuperarFilmeId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmeId(int id)
        {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
                return Ok(filme);

            return NotFound();
        }
    }
}
