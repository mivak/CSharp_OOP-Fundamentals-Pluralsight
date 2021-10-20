using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveTest()
        {
            var productRepository = new ProductRepository();
            var expected = new Product(2)
            {
                ProductName = "Sunflowers",
                ProductDescription = "Yellow mini sunflowers",
                CurrentPrice = 15.96M
            };

            var actual = productRepository.Retrieve(2);

            Assert.AreEqual(expected.ProductId, actual.ProductId);
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
        }

        [TestMethod]
        public void SaveTestValid()
        {
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                ProductName = "Sunflowers",
                ProductDescription = "4 bright Yellow mini sunflowers",
                CurrentPrice = 18M,
                HasChanges = true
            };

            var actual = productRepository.Save(updatedProduct);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void SaveTestMissingPrice()
        {
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                ProductName = "Sunflowers",
                ProductDescription = "4 bright Yellow mini sunflowers",
                CurrentPrice = null,
                HasChanges = true
            };

            var actual = productRepository.Save(updatedProduct);

            Assert.IsFalse(actual);
        }
    }
}
