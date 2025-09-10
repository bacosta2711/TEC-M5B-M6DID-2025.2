using TiendaDA2.Interfaces;
using TiendaDA2.Models;

namespace TiendaDA2.Services;

public class ProductService : IProductService
{
    private IEnumerable<ProductModel?> _myProducts = new List<ProductModel>();
    
    public IEnumerable<ProductModel> GetAll()
    {
        return _myProducts;
    }

    public ProductModel GetById(Guid id)
    {
        return _myProducts.Where(p => p.id == id).SingleOrDefault();
    }

    public bool Delete(Guid id)
    {
        _myProducts= _myProducts.Where(p => p.id != id);
        return true;
    }

    public ProductModel Save(ProductModel product)
    {
        product.id = Guid.NewGuid();
        _myProducts = _myProducts.Append(product);
        return product;
    }
}