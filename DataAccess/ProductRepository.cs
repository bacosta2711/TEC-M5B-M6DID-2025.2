using Domain;
using IRespository;

namespace Repository;

public class ProductRepository(TiendaDbContext context) : IProductRepository
{
    private readonly TiendaDbContext _context = context;

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(Guid id)
    {
        return _context.Products.Find(id);
    }

    public Product Save(Product product)
    { 
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public bool Delete(Guid id)
    {
        _context.Products.Remove(GetById(id));
        _context.SaveChanges();
        return true;
    }
}