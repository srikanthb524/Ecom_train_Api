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
    public class AdminPrivilagesController : ControllerBase
    {
        private readonly Training_DBContext _context;

        public AdminPrivilagesController(Training_DBContext context)
        {
            _context = context;
        }

        // GET: api/AdminPrivilages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminPrivilage>>> GetAdminPrivilages()
        {
            return await _context.AdminPrivilages.ToListAsync();
        }

        // GET: api/AdminPrivilages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminPrivilage>> GetAdminPrivilage(int id)
        {
            var adminPrivilage = await _context.AdminPrivilages.FindAsync(id);

            if (adminPrivilage == null)
            {
                return NotFound();
            }

            return adminPrivilage;
        }

        // PUT: api/AdminPrivilages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminPrivilage(int id, AdminPrivilage adminPrivilage)
        {
            if (id != adminPrivilage.ApId)
            {
                return BadRequest();
            }

            _context.Entry(adminPrivilage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminPrivilageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdminPrivilages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminPrivilage>> PostAdminPrivilage(AdminPrivilage adminPrivilage)
        {
            _context.AdminPrivilages.Add(adminPrivilage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminPrivilage", new { id = adminPrivilage.ApId }, adminPrivilage);
        }

        // DELETE: api/AdminPrivilages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminPrivilage(int id)
        {
            var adminPrivilage = await _context.AdminPrivilages.FindAsync(id);
            if (adminPrivilage == null)
            {
                return NotFound();
            }

            _context.AdminPrivilages.Remove(adminPrivilage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminPrivilageExists(int id)
        {
            return _context.AdminPrivilages.Any(e => e.ApId == id);
        }
    }
}
