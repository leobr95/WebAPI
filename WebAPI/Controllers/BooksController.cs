using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }
        //read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookItems()
        {
            
            return await _context.BookItems
                .Include(s => s.Autor)
                .ToListAsync();
        
        
          }

        //detalle
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookItem(int id)
        {
            var bookItem = await _context.BookItems.FindAsync(id);

            if(bookItem == null)
            {
                return NotFound();
            }
            return bookItem;          
           
        }

        //ENVIO
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book item)
        {
            _context.BookItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookItem), new { id = item.BookId}, item);
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBook(int id, Book item)
        {
            if(id != item.BookId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookItem), new { id = item.AutorId }, item);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAutor(int id)
        {
            var bookItem = await _context.BookItems.FindAsync(id);

            _context.Remove(bookItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Ok(bookItem);
        }

    }
}
