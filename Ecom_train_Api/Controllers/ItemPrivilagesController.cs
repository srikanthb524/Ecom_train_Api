using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom_train_Api.Models;
using System.IO;
using System.Net.Http.Headers;

namespace Ecom_train_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPrivilagesController : ControllerBase
    {
        private readonly Training_DBContext _context;

        public ItemPrivilagesController(Training_DBContext context)
        {
            _context = context;
        }

        // GET: api/ItemPrivilages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPrivilage>>> GetItemPrivilages()
        {
            return await _context.ItemPrivilages.ToListAsync();
        }

        // GET: api/ItemPrivilages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPrivilage>> GetItemPrivilage(int id)
        {
            var itemPrivilage = await _context.ItemPrivilages.FindAsync(id);

            if (itemPrivilage == null)
            {
                return NotFound("Item Not Found");
            }

            return Ok(itemPrivilage);
        }

        // PUT: api/ItemPrivilages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPrivilage(int id, ItemPrivilage itemPrivilage)
        {
            if (id != itemPrivilage.IId)
            {
                return NotFound("Item Not Found");
            }

            _context.Entry(itemPrivilage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPrivilageExists(id))
                {
                    return NotFound("Item Not Found");
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/ItemPrivilages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<ItemPrivilage>> PostItemPrivilage(ItemPrivilage itemPrivilage)
        {
            itemPrivilage.IName = itemPrivilage.IName.ToLower();
            var query = _context.ItemPrivilages.SingleOrDefault(x => x.IName == itemPrivilage.IName);
            if (query != null)
            {
                return NotFound("Item Already Exixts");
            }
            else
            {
                _context.ItemPrivilages.Add(itemPrivilage);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItemPrivilage", new { id = itemPrivilage.IId }, itemPrivilage);
            }

        }



        // DELETE: api/ItemPrivilages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPrivilage(int id)
        {
            var itemPrivilage = await _context.ItemPrivilages.FindAsync(id);
            if (itemPrivilage == null)
            {
                return NotFound();
            }

            _context.ItemPrivilages.Remove(itemPrivilage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPrivilageExists(int id)
        {
            return _context.ItemPrivilages.Any(e => e.IId == id);
        }



    }
}
