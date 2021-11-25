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
    public class EditorialsController : ControllerBase
    {
        private readonly BookContext _context;

        public EditorialsController(BookContext context)
        {
            _context = context;
        }
        //read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> GetEditorialItems()
        {
           
            return await _context.EditorialItems.ToListAsync();
        
        
        }

        //detalle
        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> GetEditorialItem(int id)
        {
            var editorialItem = await _context.EditorialItems.FindAsync(id);

            if(editorialItem == null)
            {
                return NotFound();
            }
            return editorialItem;          
           
        }

        //ENVIO
        [HttpPost]
        public async Task<ActionResult<Editorial>> PostEditorial(Editorial item)
        {
            _context.EditorialItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEditorialItem), new { id = item.EditorialId}, item);
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEditorial(int id, Editorial item)
        {
            if(id != item.EditorialId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEditorialItem), new { id = item.EditorialId }, item);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEditorial(int id)
        {
            var editorialItem = await _context.EditorialItems.FindAsync(id);

            _context.Remove(editorialItem).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Ok(editorialItem);         
        }

    }
}
