using Domain;
using IRespository;
using Moq;
using TiendaDA2.Services;

namespace Test;

[TestClass]
public class ProductServiceTest
{
        private Mock<IProductRepository> _repoMock = null!;
        private ProductService _service = null!;
        private IEnumerable<Product> _products = Enumerable.Empty<Product>();

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IProductRepository>(MockBehavior.Strict);
            _service = new ProductService(_repoMock.Object);
            var _products = new[]
            {
                new Product { id = Guid.NewGuid(), name = "Table" },
                new Product { id = Guid.NewGuid(), name= "Chair" }
            };
        }

        [TestMethod]
        public void GetAll()
        {
            _repoMock.Setup(r => r.GetAll()).Returns(_products);

            var result = _service.GetAll();

            _repoMock.VerifyAll();
        }

        [TestMethod]
        public void GetById()
        {
            var id = Guid.NewGuid();
            var expected = new Product { id = id, name = "Shirt" };

            _repoMock.Setup(r => r.GetById(id)).Returns(expected);

            var actual = _service.GetById(id);

            _repoMock.VerifyAll();
        }

        [TestMethod]
        public void Delete()
        {
            var id = Guid.NewGuid();

            _repoMock.Setup(r => r.Delete(id)).Returns(true);

            var ok = _service.Delete(id);

            _repoMock.VerifyAll();
        }

        [TestMethod]
        public void Save()
        {
            var incoming = new Product { id = Guid.Empty, name = "Trousers", brand = "ACME", price = 10m };
            
            _repoMock
                .Setup(r => r.Save(It.IsAny<Product>()))
                .Returns((Product p) => p);

            var saved = _service.Save(incoming);

            _repoMock.VerifyAll();
        }

}