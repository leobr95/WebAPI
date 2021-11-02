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
    public class NegociosController : ControllerBase
    {
        private readonly BookContext _context;

        public NegociosController(BookContext context)
        {
            _context = context;
        }
        //read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negocio>>> GetNegocioItems()
        {
            
            return await _context.NegocioItems.ToListAsync();
        
        
          }

        //detalle
        [HttpGet("{id}")]
        public async Task<ActionResult<Negocio>> GetNegocioItem(int id)
        {
            var negocioItem = await _context.NegocioItems.FindAsync(id);

            if(negocioItem == null)
            {
                return NotFound();
            }
            return negocioItem;          
           
        }

        //ENVIO
        [HttpPost]
        public async Task<ActionResult<Negocio>> PostNegocio(Negocio item)
        {
            _context.NegocioItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNegocioItem), new { id = item.NegocioId}, item);
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> PutNegocio(int id, Negocio item)
        {
            if(id != item.NegocioId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNegocioItem), new { id = item.NegocioId }, item);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAutor(int id)
        {
            var negocioItem = await _context.NegocioItems.FindAsync(id);

            _context.Remove(negocioItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Ok(negocioItem);
        }

    }
}
