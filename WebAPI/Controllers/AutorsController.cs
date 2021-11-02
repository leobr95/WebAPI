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
    public class AutorsController : ControllerBase
    {
        private readonly BookContext _context;

        public AutorsController(BookContext context)
        {
            _context = context;
        }
        //read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutorItems()
        {
           
            return await _context.AutorItems.ToListAsync();
        
        
        }

        //detalle
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutorItem(int id)
        {
            var autorItem = await _context.AutorItems.FindAsync(id);

            if(autorItem == null)
            {
                return NotFound();
            }
            return autorItem;          
           
        }

        //ENVIO
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor item)
        {
            _context.AutorItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAutorItem), new { id = item.AutorId}, item);
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAutor(int id, Autor item)
        {
            if(id != item.AutorId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAutorItem), new { id = item.AutorId }, item);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAutor(int id)
        {
            var autorItem = await _context.AutorItems.FindAsync(id);

            _context.Remove(autorItem).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Ok(autorItem);         
        }

    }
}
