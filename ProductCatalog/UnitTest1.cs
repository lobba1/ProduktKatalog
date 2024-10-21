using ProduktKatalog.Services;

namespace ProductCatalog
{
    public class UnitTest1
    {
        [Fact]
        public void AddProduct_ShouldAddToListAndIncreaseCount()
        {
            // Arrange
            var productService = new ProductService();
            int initialCount = productService.Count;

            // Act
            productService.AddProduct("TestProdukt1", 100.00m);

            // Assert
            Assert.Equal(initialCount + 1, productService.Count);

            var addedProduct = productService.GetAllProducts().LastOrDefault();
            Assert.NotNull(addedProduct);
            Assert.Equal("TestProdukt1", addedProduct.Name);
            Assert.Equal(100.00m, addedProduct.Price);

        }
    }
}