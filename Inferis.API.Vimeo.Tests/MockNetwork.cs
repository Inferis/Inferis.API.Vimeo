using System;
using System.IO;

namespace Inferis.API.Vimeo.Tests
{
    public class MockNetwork : INetwork
    {
        public string Response { get; set; }

        public TextReader GetResponse(string uri)
        {
            return GetResponse(new Uri(uri));
        }

        public TextReader GetResponse(Uri uri)
        {
            return new StringReader(Response);
        }
    }
}
