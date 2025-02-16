using BettingSite.Data;
using BettingSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;  // Make sure this is included

namespace BettingSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{   
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDTO>>> GetProducts()
    {
        var products = await _context.Products
            .AsQueryable()
            .Select(p => new ProductDTO 
            { 
                id = p.id, 
                name = p.name,
                description = p.description,
                basePrice = p.basePrice,
            })
            .ToListAsync();
            
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        return Ok(await _context.Products.FindAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct(ProductPostDTO product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        var newProduct = new Product {
        name = product.name,
        description = product.description,
        basePrice = product.basePrice
        };

        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProduct),new { id = newProduct.id }, newProduct);
        
    }
    
}