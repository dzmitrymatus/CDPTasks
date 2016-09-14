using RestSharp;

namespace RestSharpExtensions
{
    public class RequestParameter : Parameter
    {
        public RequestParameter()
        {
            this.Name = "";
            this.ContentType = "";
            this.Name = "";
            this.Value = "";
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Value);
        }
    }
}
