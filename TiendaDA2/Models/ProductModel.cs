namespace TiendaDA2.Models;

public class ProductModel
{   
    public Guid id { get; set; }
    required public string name { get; set; }
    required public string brand { get; set; }
    required public decimal price { get; set; }
}