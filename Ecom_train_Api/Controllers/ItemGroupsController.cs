using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom_train_Api.Models;
using Ecom_train_Api.Input;
using System.Net.Http;
using System.Net.Http.Headers;
using Ecom_train_Api.Output;
namespace Ecom_train_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemGroupsController : ControllerBase
    {
        private readonly Training_DBContext _context;

        public ItemGroupsController(Training_DBContext context)
        {
            _context = context;
        }

        // GET: api/ItemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemGroup>>> GetItemGroups()
        {
            return await _context.ItemGroups.ToListAsync();
        }

        // GET: api/ItemGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemGroup>> GetItemGroup(int id)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(id);

            if (itemGroup == null)
            {
                return NotFound();
            }

            return Ok(itemGroup);
        }

        // PUT: api/ItemGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemGroup(int id, ItemGroup itemGroup)
        {
            if (id != itemGroup.IgId)
            {
                return NotFound();
            }

            _context.Entry(itemGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated Succesfully");
        }

        // POST: api/ItemGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemGroup>> PostItemGroup(ItemGroup itemGroup)
        {
            var query = _context.ItemGroups.SingleOrDefault(x => x.IgName == itemGroup.IgName);
            if (query != null)
            {
                return NotFound("Item Grroup Already Exixts");
            }
            else
            {
                _context.ItemGroups.Add(itemGroup);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItemGroup", new { id = itemGroup.IgId }, itemGroup);
            }

        }

        // DELETE: api/ItemGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemGroup(int id)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            _context.ItemGroups.Remove(itemGroup);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ItemGroupExists(int id)
        {
            return _context.ItemGroups.Any(e => e.IgId == id);
        }
    }
}
