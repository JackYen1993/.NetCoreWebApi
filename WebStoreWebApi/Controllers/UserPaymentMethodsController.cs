using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreWebApi.Models;

namespace WebStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentMethodsController : ControllerBase
    {
        private readonly WebStoreDbContext _context;

        public UserPaymentMethodsController(WebStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/UserPaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPaymentMethod>>> GetUserPaymentMethods()
        {
            return await _context.UserPaymentMethods.ToListAsync();
        }

        // GET: api/UserPaymentMethods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPaymentMethod(Guid id)
        {
            var userPaymentMethod = await _context.UserPaymentMethods
                                .Include(upm => upm.User)
                                .FirstOrDefaultAsync(upm => upm.Id == id);

            if (userPaymentMethod == null)
            {
                return NotFound();
            }

            return Ok(userPaymentMethod);
        }

        // PUT: api/UserPaymentMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPaymentMethod(Guid id, UserPaymentMethod userPaymentMethod)
        {
            if (id != userPaymentMethod.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPaymentMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPaymentMethodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserPaymentMethod", new { id = userPaymentMethod.Id }, userPaymentMethod);
        }

        // POST: api/UserPaymentMethods
        [HttpPost]
        public async Task<ActionResult<UserPaymentMethod>> PostUserPaymentMethod(UserPaymentMethod userPaymentMethod)
        {
            userPaymentMethod.Expiry = DateTime.Now.AddYears(3);
            _context.UserPaymentMethods.Add(userPaymentMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPaymentMethod", new { id = userPaymentMethod.Id }, userPaymentMethod);
        }

        // DELETE: api/UserPaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPaymentMethod(Guid id)
        {
            var userPaymentMethod = await _context.UserPaymentMethods.FindAsync(id);
            if (userPaymentMethod == null)
            {
                return NotFound();
            }

            _context.UserPaymentMethods.Remove(userPaymentMethod);
            await _context.SaveChangesAsync();

            return Ok("Deleted!");
        }

        private bool UserPaymentMethodExists(Guid id)
        {
            return _context.UserPaymentMethods.Any(e => e.Id == id);
        }
    }
}
