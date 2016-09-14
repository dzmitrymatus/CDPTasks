using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Services.thomas_bayer_com_sqlrest_PRODUCT.Models
{
    [SerializeAs(Name = "PRODUCT")]
    public class Product
    {
        [SerializeAs(Name ="ID")]
        [DeserializeAs(Name = "ID")]
        public int Id { get; set; }
        [SerializeAs(Name = "NAME")]
        [DeserializeAs(Name = "NAME")]
        public string Name { get; set; }
        [SerializeAs(Name = "PRICE")]
        [DeserializeAs(Name = "PRICE")]
        public double Price { get; set; }
    }
}
