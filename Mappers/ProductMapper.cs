using Domain;
using TiendaDA2.Models;

namespace Mappers;

public static class ProductMapper
{
    public static ProductModel ToModel(Product product)
    {
        return new ProductModel
        {
            id = product.id,
            name = product.name,
            brand = product.brand,
            price = product.price,
        };
    }
    
    public static IEnumerable<ProductModel> ToModel(IEnumerable<Product> myProducts)
    {
        var products = new List<ProductModel>();
        foreach(var p in myProducts)
        {
            products.Add(ToModel(p));
        }

        return products;
    }
    
    public static Product ToEntity(ProductModel product)
    {
        return new Product
        {
            name = product.name,
            brand = product.brand,
            price = product.price,
        };
    }
}