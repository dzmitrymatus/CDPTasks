using Services.thomas_bayer_com_sqlrest_PRODUCT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace thomas_bayer_com_sqlrest_PRODUCT_Tests
{
    public class ProductsFactory
    {
        public static Product CreateNewProductWithUniqueId(IEnumerable<int> values)
        {
            return new Product()
            {
                Id = CreateUniqueId(values),
                Name = "Example",
                Price = 20
            };
        }

        private static int CreateUniqueId(IEnumerable<int> values)
        {
            Random rnd = new Random();
            var id = rnd.Next(1, 10000);
            while (values.Contains(id))
            {
                id = rnd.Next(1, 10000);
            }
            return id;
        }
    }
}
