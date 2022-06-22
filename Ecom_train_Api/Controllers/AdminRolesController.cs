using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom_train_Api.Models;

namespace Ecom_train_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRolesController : ControllerBase
    {
        private readonly Training_DBContext _context;

        public AdminRolesController(Training_DBContext context)
        {
            _context = context;
        }

        // GET: api/AdminRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRole>>> GetAdminRoles()
        {
            return await _context.AdminRoles.ToListAsync();
        }

        // GET: api/AdminRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminRole>> GetAdminRole(int id)
        {
            var adminRole = await _context.AdminRoles.FindAsync(id);

            if (adminRole == null)
            {
                return NotFound();
            }

            return adminRole;
        }

        // PUT: api/AdminRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminRole(int id, AdminRole adminRole)
        {
            if (id != adminRole.ArId)
            {
                return BadRequest();
            }

            _context.Entry(adminRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminRoleExists(id))
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

        // POST: api/AdminRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminRole>> PostAdminRole(AdminRole adminRole)
        {
            _context.AdminRoles.Add(adminRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminRole", new { id = adminRole.ArId }, adminRole);
        }

        // DELETE: api/AdminRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminRole(int id)
        {
            var adminRole = await _context.AdminRoles.FindAsync(id);
            if (adminRole == null)
            {
                return NotFound();
            }

            _context.AdminRoles.Remove(adminRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminRoleExists(int id)
        {
            return _context.AdminRoles.Any(e => e.ArId == id);
        }
    }
}
