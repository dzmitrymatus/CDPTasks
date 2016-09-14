using NUnit.Framework;
using Services.thomas_bayer_com_sqlrest_PRODUCT;
using System.Net;

namespace thomas_bayer_com_sqlrest_PRODUCT_Tests
{
    [TestFixture]
    public class CreateNewProductAndDeleteTests
    {
        [TestCase]
        public void CreateNewProductAndDelete_CorrectStatusCodes()
        {
            var service = new Service();
            var products = service.GetListOfProducts();
            var product = ProductsFactory.CreateNewProductWithUniqueId(products.Value);

            //add product
            var result = service.AddProduct(product);
            Assert.That(result == HttpStatusCode.Created, "product dont created");

            //delete product
            result = service.DeleteProduct(product);
            Assert.That(result == HttpStatusCode.OK, "product dont deleted");
        }

        [TestCase]
        public void CreateNewProductAndDelete_ContainsInListOfProducts()
        {
            var service = new Service();
            var products = service.GetListOfProducts();
            var product = ProductsFactory.CreateNewProductWithUniqueId(products.Value);

            //add product
            var result = service.AddProduct(product);
            products = service.GetListOfProducts();
            Assert.That(products.Value.Contains(product.Id) == true, "product dont created");

            //delete product
            result = service.DeleteProduct(product);
            products = service.GetListOfProducts();
            Assert.That(products.Value.Contains(product.Id) == false, "product dont deleted");
        }

    }
}
