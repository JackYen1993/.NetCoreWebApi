using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebStoreWebApi.AppSettingsClass;
using WebStoreWebApi.Models;

namespace WebStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreUsersController : ControllerBase
    {
        private readonly WebStoreDbContext _context;
        private readonly ILogger _logger;

        private readonly IConfiguration _configuration;
        private readonly IOptions<MySettings> _myConfigSetting;

        public StoreUsersController(WebStoreDbContext context, ILogger<StoreUsersController> logger, 
            IOptions<MySettings> myConfigSetting, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _myConfigSetting = myConfigSetting;
            _configuration = configuration;
        }

        // GET: api/StoreUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreUser>>> GetUsers()
        {
            _logger.LogDebug("Someone looking for user!");
            _logger.LogInformation("Someone looking for user!");
            _logger.LogWarning("Someone looking for user!");
            _logger.LogError("Someone looking for user!");
            _logger.LogCritical("Someone looking for user!");

            // Get information from appsettings.json
            //return Ok(_myConfigSetting.Value);
            //return Ok(_configuration["MySettings:Name"]);

            return await _context.StoreUsers.ToListAsync();
        }

        // GET: api/StoreUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreUser>> GetUser(Guid id)
        {
            var user = await _context.StoreUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/StoreUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, StoreUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // POST: api/StoreUsers
        [HttpPost]
        public async Task<ActionResult<StoreUser>> PostUser(StoreUser user)
        {
            _context.StoreUsers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/StoreUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.StoreUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.StoreUsers.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Deleted!");
        }

        private bool UserExists(Guid id)
        {
            return _context.StoreUsers.Any(e => e.Id == id);
        }
    }
}
