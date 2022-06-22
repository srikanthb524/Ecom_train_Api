using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecom_train_Api.Models;
using Ecom_train_Api.Input;
using Ecom_train_Api.Output;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_train_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginsController : ControllerBase
    {
        private readonly Training_DBContext _context;

        public AdminLoginsController(Training_DBContext context)
        {
            _context = context;
        }

        // GET: api/AdminLogins
        [HttpPost("login")]
        public async Task<ActionResult<IEnumerable<loginOutput>>> GetAdminLogins(loginInputs inputs)
        {
            inputs.userName = inputs.userName.ToLower();

            var user = _context.AdminLogins.SingleOrDefault(x => x.AUsername == inputs.userName);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                bool isvalidPassword = BCrypt.Net.BCrypt.Verify(inputs.password, user.APassword);
                if (isvalidPassword)
                {
                    var query = from u in _context.AdminLogins
                                where u.AUsername == inputs.userName
                                select new loginOutput
                                {
                                    AArId = u.AArId,
                                    AId = u.AId,
                                    AStatus = u.AStatus,
                                    AUsername = u.AUsername,
                                    ATs = u.ATs
                                };
                    return Ok(query);
                }
                return NotFound();
            }
        }

        //GET :api/AdminLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminLogin>>> GetAdminLogins()
        {
            return await _context.AdminLogins.ToListAsync();
        }

        // GET: api/AdminLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminLogin>> GetAdminLogin(int id)
        {
            var adminLogin = await _context.AdminLogins.FindAsync(id);

            if (adminLogin == null)
            {
                return NotFound();
            }

            return adminLogin;
        }

        // PUT: api/AdminLogins/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminLogin(int id, AdminLogin adminLogin)
        {
            if (id != adminLogin.AId)
            {
                return NotFound();
            }
            adminLogin.AUsername = adminLogin.AUsername.ToLower();
            adminLogin.APassword = BCrypt.Net.BCrypt.HashPassword(adminLogin.APassword);
            _context.Entry(adminLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminLoginExists(id))
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

        // POST: api/AdminLogins       
        [HttpPost]
        public async Task<ActionResult<AdminLogin>> PostAdminLogin(AdminLogin adminLogin)
        {
            adminLogin.AUsername = adminLogin.AUsername.ToLower();
            var user = _context.AdminLogins.SingleOrDefault(x => x.AUsername == adminLogin.AUsername);
            if (user != null)
            {
                return NotFound();
            }

            adminLogin.APassword = BCrypt.Net.BCrypt.HashPassword(adminLogin.APassword);
            _context.AdminLogins.Add(adminLogin);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAdminLogin", new { id = adminLogin.AId }, adminLogin);
        }

        // DELETE: api/AdminLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminLogin(int id)
        {
            var adminLogin = await _context.AdminLogins.FindAsync(id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            _context.AdminLogins.Remove(adminLogin);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AdminLoginExists(int id)
        {
            return _context.AdminLogins.Any(e => e.AId == id);
        }

    }
}
