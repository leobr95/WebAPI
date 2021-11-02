using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Titulo { get; set; }
        public int Año { get; set; }
        public int NumeroPagina { get; set; }
        public string Genero { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

    }
}
