
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Editorial
    {
        public int EditorialId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Book> Books { get; set; }
    }
}
