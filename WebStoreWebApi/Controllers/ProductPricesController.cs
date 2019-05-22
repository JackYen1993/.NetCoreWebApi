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
    public class ProductPricesController : ControllerBase
    {
        private readonly WebStoreDbContext _context;

        public ProductPricesController(WebStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPrice>>> GetProductPrices()
        {
            return await _context.ProductPrices.ToListAsync();
        }

        // GET: api/ProductPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPrice>> GetProductPrice(Guid id)
        {
            var productPrice = await _context.ProductPrices
                                .Include(pp => pp.Product)
                                .FirstOrDefaultAsync(pp => pp.Id == id);

            if (productPrice == null)
            {
                return NotFound();
            }

            return productPrice;
        }

        // PUT: api/ProductPrices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPrice(Guid id, ProductPrice productPrice)
        {
            if (id != productPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(productPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPriceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductPrice", new { id = productPrice.Id }, productPrice);
        }

        // POST: api/ProductPrices
        [HttpPost]
        public async Task<ActionResult<ProductPrice>> PostProductPrice(ProductPrice productPrice)
        {
            _context.ProductPrices.Add(productPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductPrice", new { id = productPrice.Id }, productPrice);
        }

        // DELETE: api/ProductPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPrice(Guid id)
        {
            var productPrice = await _context.ProductPrices.FindAsync(id);
            if (productPrice == null)
            {
                return NotFound();
            }

            _context.ProductPrices.Remove(productPrice);
            await _context.SaveChangesAsync();

            return Ok("Deleted!");
        }

        private bool ProductPriceExists(Guid id)
        {
            return _context.ProductPrices.Any(e => e.Id == id);
        }
    }
}
