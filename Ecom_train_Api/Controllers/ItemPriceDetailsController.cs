using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom_train_Api.Models;

namespace Ecom_train_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPriceDetailsController : ControllerBase
    {
        private readonly Training_DBContext _context;

        public ItemPriceDetailsController(Training_DBContext context)
        {
            _context = context;
        }

        // GET: api/ItemPriceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPriceDetail>>> GetItemPriceDetails()
        {
            return await _context.ItemPriceDetails.ToListAsync();
        }

        // GET: api/ItemPriceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPriceDetail>> GetItemPriceDetail(int id)
        {
            var itemPriceDetail = await _context.ItemPriceDetails.FindAsync(id);

            if (itemPriceDetail == null)
            {
                return NotFound();
            }

            return itemPriceDetail;
        }

        // PUT: api/ItemPriceDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPriceDetail(int id, ItemPriceDetail itemPriceDetail)
        {
            if (id != itemPriceDetail.IpdId)
            {
                return NotFound();
            }

            _context.Entry(itemPriceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPriceDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/ItemPriceDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPriceDetail>> PostItemPriceDetail(ItemPriceDetail itemPriceDetail)
        {
            _context.ItemPriceDetails.Add(itemPriceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPriceDetail", new { id = itemPriceDetail.IpdId }, itemPriceDetail);
        }

        // DELETE: api/ItemPriceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPriceDetail(int id)
        {
            var itemPriceDetail = await _context.ItemPriceDetails.FindAsync(id);
            if (itemPriceDetail == null)
            {
                return NotFound();
            }

            _context.ItemPriceDetails.Remove(itemPriceDetail);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ItemPriceDetailExists(int id)
        {
            return _context.ItemPriceDetails.Any(e => e.IpdId == id);
        }
    }
}
