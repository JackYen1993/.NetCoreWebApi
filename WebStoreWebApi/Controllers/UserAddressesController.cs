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
    public class UserAddressesController : ControllerBase
    {
        private readonly WebStoreDbContext _context;

        public UserAddressesController(WebStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/UserAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAddress>>> GetUserAddresses()
        {
            return await _context.UserAddresses.ToListAsync();
        }

        // GET: api/UserAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAddress>> GetUserAddress(Guid id)
        {
            var userAddress = await _context.UserAddresses
                                .Include(ua => ua.StoreUser)
                                .FirstOrDefaultAsync(ua => ua.Id == id);

            if (userAddress == null)
            {
                return NotFound();
            }

            return userAddress;
        }

        // PUT: api/UserAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAddress(Guid id, UserAddress userAddress)
        {
            if (id != userAddress.Id)
            {
                return BadRequest();
            }

            _context.UserAddresses.Update(userAddress);
            //_context.Entry(userAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAddress", new { id = userAddress.Id }, userAddress);
        }

        // POST: api/UserAddresses
        [HttpPost]
        public async Task<ActionResult<UserAddress>> PostUserAddress(UserAddress userAddress)
        {
            _context.UserAddresses.Add(userAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAddress", new { id = userAddress.Id }, userAddress);
        }

        // DELETE: api/UserAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAddress(Guid id)
        {
            var userAddress = await _context.UserAddresses.FindAsync(id);
            if (userAddress == null)
            {
                return NotFound();
            }

            _context.UserAddresses.Remove(userAddress);
            await _context.SaveChangesAsync();

            return Ok("Deleted!");
        }

        private bool UserAddressExists(Guid id)
        {
            return _context.UserAddresses.Any(e => e.Id == id);
        }
    }
}
