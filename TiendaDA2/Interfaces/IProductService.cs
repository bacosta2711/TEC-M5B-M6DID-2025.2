using TiendaDA2.Models;

namespace TiendaDA2.Interfaces;

public interface IProductService
{
    public IEnumerable<ProductModel> GetAll();
    public ProductModel GetById(Guid id);
    public bool Delete(Guid id);
    public ProductModel Save(ProductModel product);
}