using Microsoft.AspNetCore.Mvc;
using Moq;
using TiendaDA2.Controllers;
using TiendaDA2.Interfaces;
using TiendaDA2.Models;

namespace Test;

[TestClass]
public class ProductControllerTest
{
    private Mock<IProductService> _mockService = null!;
    private ProductsController _controller = null!;
    private  List<ProductModel> _products = null!;
    private Guid _knowedId = new Guid();
    private ProductModel _myProduct = null!;
    
    [TestInitialize]
    public void Setup()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductsController(_mockService.Object);
        ProductModel _myProduct = new ProductModel
        {
            id = _knowedId,
            name = "Table",
            brand = "Ikea",
            price = 100
        };
        
        
        var products = new List<ProductModel>
        {
            _myProduct,
            new ProductModel
            {
                id = Guid.NewGuid(),
                name = "Chair",
                brand = "Ikea",
                price = 50
            }
        };
    }

    [TestMethod]
    public void GetAll()
    {
        // Arrange
        _mockService.Setup(s => s.GetAll()).Returns(_products);

        // Act
        var result = _controller.GetAll() as OkObjectResult;

        // Assert
        Assert.AreEqual(200, result.StatusCode);
    }
    
    [TestMethod]
    public void GetById()
    {
        _mockService.Setup(s => s.GetById(_knowedId)).Returns(_myProduct);

        // Act
        var result = _controller.GetById(_knowedId) as OkObjectResult;

        // Assert
        Assert.AreEqual(200, result.StatusCode);
    }

}