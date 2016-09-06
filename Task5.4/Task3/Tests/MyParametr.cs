using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class MyParameter : Parameter
    {
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Value);
        }
    }
}
