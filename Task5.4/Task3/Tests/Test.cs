using NUnit.Framework;
using RestSharp;
using Services.thomas_bayer_com_sqlrest_PRODUCT.Models;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        [TestCase]
        public void AddProduct()
        {
            var client = new RestClient("http://www.thomas-bayer.com");
            Random rnd = new Random();

            var request = new RestRequest("sqlrest/PRODUCT/", Method.GET);            
            var products = client.Execute<ProductList>(request).Data;

            var newProduct = new Product() { Id = rnd.Next(1,10000), Name = "Example", Price = 55 };
            request = new RestRequest("/sqlrest/PRODUCT/", Method.POST);

            var eee = request.XmlSerializer.Serialize(newProduct);
            var parametr = new MyParameter() { Value = eee, Type = ParameterType.RequestBody };
            request.AddParameter(parametr);


            var result = client.Execute(request);

            var aaa = 5;
        }

    }
}
