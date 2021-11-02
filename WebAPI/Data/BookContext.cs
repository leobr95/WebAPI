using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> BookItems { get; set; }
        public DbSet<Autor>  AutorItems { get; set; }
        public DbSet<Negocio> NegocioItems { get; set; }
    }
}
