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
    public class ProductAssetsController : ControllerBase
    {
        private readonly WebStoreDbContext _context;

        public ProductAssetsController(WebStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductAssets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductAsset>>> GetProductAssets()
        {
            return await _context.ProductAssets.ToListAsync();
        }

        // GET: api/ProductAssets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductAsset>> GetProductAsset(Guid id)
        {
            var productAsset = await _context.ProductAssets
                                .Include(pa => pa.Product)
                                .FirstOrDefaultAsync(pa => pa.Id == id);

            if (productAsset == null)
            {
                return NotFound();
            }

            return productAsset;
        }

        // PUT: api/ProductAssets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductAsset(Guid id, ProductAsset productAsset)
        {
            if (id != productAsset.Id)
            {
                return BadRequest();
            }

            _context.Entry(productAsset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductAssetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductAsset", new { id = productAsset.Id }, productAsset);
        }

        // POST: api/ProductAssets
        [HttpPost]
        public async Task<ActionResult<ProductAsset>> PostProductAsset(ProductAsset productAsset)
        {
            _context.ProductAssets.Add(productAsset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductAsset", new { id = productAsset.Id }, productAsset);
        }

        // DELETE: api/ProductAssets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsset(Guid id)
        {
            var productAsset = await _context.ProductAssets.FindAsync(id);
            if (productAsset == null)
            {
                return NotFound();
            }

            _context.ProductAssets.Remove(productAsset);
            await _context.SaveChangesAsync();

            return Ok("Deleted!");
        }

        private bool ProductAssetExists(Guid id)
        {
            return _context.ProductAssets.Any(e => e.Id == id);
        }
    }
}
