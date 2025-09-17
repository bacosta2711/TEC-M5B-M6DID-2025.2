using Mappers;
using Microsoft.AspNetCore.Mvc;
using TiendaDA2.Interfaces;
using TiendaDA2.Models;

namespace TiendaDA2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService _service) : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(ProductMapper.ToModel(_service.GetAll()));
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(ProductMapper.ToModel(_service.GetById(id)));
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] ProductModel product)
    {
        return Ok(ProductMapper.ToModel( _service.Save(ProductMapper.ToEntity(product))));
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok(_service.Delete(id));
    }
    
}