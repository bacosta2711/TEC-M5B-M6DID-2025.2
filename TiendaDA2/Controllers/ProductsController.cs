using Microsoft.AspNetCore.Mvc;
using TiendaDA2.Models;

namespace TiendaDA2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private IEnumerable<string> _myProducts = new[] { "Table", "Chair", "Shirt", "Trousers" };
[HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_myProducts.ToList());
    }
    
    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        return Ok(_myProducts.Where(p=>p.Equals(name)).ToList());
    }
    
    [HttpGet("starts-with")]
    public IActionResult StartWith([FromQuery]string? pattern)
    {
        return Ok(_myProducts.Where(p=>p.StartsWith(pattern)).ToList());
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] ProductRequest product)
    {
        _myProducts = _myProducts.Append(product.name);
        return Ok(product);
    }
    
    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        _myProducts = _myProducts.Where(p => p!=name);
        return Ok(_myProducts.ToList());
    }
    
}