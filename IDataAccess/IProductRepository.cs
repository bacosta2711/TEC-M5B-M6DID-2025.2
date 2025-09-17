using Domain;

namespace IRespository;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    Product Save(Product product);
    bool Delete(Guid id);
}