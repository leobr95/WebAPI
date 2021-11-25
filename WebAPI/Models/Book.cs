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
        public int Fecha { get; set; }
        public int Costo { get; set; }
        public int PrecioSugerido { get; set; }
        public string Autor { get; set; }
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }

    }
}
