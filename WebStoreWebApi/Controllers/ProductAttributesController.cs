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
    public class ProductAttributesController : ControllerBase
    {
        private readonly WebStoreDbContext _context;

        public ProductAttributesController(WebStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductAttributes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductAttribute>>> GetProductAttributes()
        {
            return await _context.ProductAttributes.ToListAsync();
        }

        // GET: api/ProductAttributes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductAttribute>> GetProductAttribute(Guid id)
        {
            var productAttribute = await _context.ProductAttributes
                                .Include(pa => pa.Product)
                                .FirstOrDefaultAsync(pa => pa.Id == id);

            if (productAttribute == null)
            {
                return NotFound();
            }

            return productAttribute;
        }

        // PUT: api/ProductAttributes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductAttribute(Guid id, ProductAttribute productAttribute)
        {
            if (id != productAttribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(productAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductAttributeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductAttribute", new { id = productAttribute.Id }, productAttribute);
        }

        // POST: api/ProductAttributes
        [HttpPost]
        public async Task<ActionResult<ProductAttribute>> PostProductAttribute(ProductAttribute productAttribute)
        {
            _context.ProductAttributes.Add(productAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductAttribute", new { id = productAttribute.Id }, productAttribute);
        }

        // DELETE: api/ProductAttributes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAttribute(Guid id)
        {
            var productAttribute = await _context.ProductAttributes.FindAsync(id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            _context.ProductAttributes.Remove(productAttribute);
            await _context.SaveChangesAsync();

            return Ok("Deleted!");
        }

        private bool ProductAttributeExists(Guid id)
        {
            return _context.ProductAttributes.Any(e => e.Id == id);
        }
    }
}
