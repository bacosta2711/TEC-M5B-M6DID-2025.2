using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Test;

[TestClass]
public class ProductRepositoryTest
{
        private TiendaDbContext _context = null!;
        private ProductRepository _repository = null!;
        private SqliteConnection _connection = null!;

        [TestInitialize]
        public void Setup()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<TiendaDbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new TiendaDbContext(options);
            _context.Database.EnsureCreated();

            _repository = new ProductRepository(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
            _connection.Close();
            _connection.Dispose();
        }

        [TestMethod]
        public void Save()
        {
            var p = new Product
            {
                id = Guid.NewGuid(), 
                name = "Table",
                brand = "ACME",
                price = 100
            };

            var saved = _repository.Save(p);
            var fromDb = _context.Products.Find(saved.id);

            
            Assert.AreEqual(p.id, fromDb!.id);
        }

        [TestMethod]
        public void GetAll()
        {
            var p1 = new Product { id = Guid.NewGuid(), name = "A", brand = "B", price = 10 };
            var p2 = new Product { id = Guid.NewGuid(), name = "C", brand = "D", price = 20 };

            _repository.Save(p1);
            _repository.Save(p2);

            var all = _repository.GetAll().ToList();

            Assert.AreEqual(2, all.Count);
        }

        [TestMethod]
        public void GetById()
        {
            var p = new Product { id = Guid.NewGuid(), name = "X", brand = "Y", price = 50m };
            _repository.Save(p);

            var found = _repository.GetById(p.id);

            Assert.IsNotNull(found);
        }
        
        [TestMethod]
        public void Delete_Found_Removes_And_Returns_True()
        {
            var p = new Product { id = Guid.NewGuid(), name = "Del", brand = "BR", price = 5m };
            _repository.Save(p);

            var ok = _repository.Delete(p.id);
            var fromDb = _context.Products.Find(p.id);

            Assert.IsTrue(ok);
        }

        
}