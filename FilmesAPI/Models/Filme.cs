using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "O diretor é obrigatório")]
        public string Diretor { get; set; }
        
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A druação não pode ser maior do que 600 minutos")]
        public int Duracao { get; set; }
    }
}
