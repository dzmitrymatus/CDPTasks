using RestSharp;
using RestSharpExtensions;
using Services.thomas_bayer_com_sqlrest_PRODUCT.Models;
using System.Net;

namespace Services.thomas_bayer_com_sqlrest_PRODUCT
{
    public class Service
    {
        private const string host = "http://www.thomas-bayer.com";
        private const string resource = "sqlrest/PRODUCT";
        protected RestClient client = new RestClient(host);


        public ProductList GetListOfProducts()
        {
            var request = new RestRequest(resource, Method.GET);
            var products = client.Execute<ProductList>(request).Data;
            return products;
        }

        public HttpStatusCode AddProduct(Product product)
        {
            var request = new RestRequest(resource, Method.POST);
            var productXML = request.XmlSerializer.Serialize(product);
            request.AddContentToBody(productXML);
            var responce = client.Execute(request);
            return responce.StatusCode;
        }

        public Product GetProduct(int Id)
        {
            var request = new RestRequest(resource + $"/{Id}", Method.GET);
            var product = client.Execute<Product>(request).Data;
            return product;
        }

        public HttpStatusCode DeleteProduct(int Id)
        {
            var request = new RestRequest(resource + $"/{Id}", Method.DELETE);
            var responce = client.Execute(request);
            return responce.StatusCode;
        }

        public HttpStatusCode DeleteProduct(Product product)
        {
            var request = new RestRequest(resource + $"/{product.Id}", Method.DELETE);
            var responce = client.Execute(request);
            return responce.StatusCode;
        }
    }
}
