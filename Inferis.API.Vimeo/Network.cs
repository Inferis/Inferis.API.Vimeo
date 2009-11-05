using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace Inferis.API.Vimeo
{
    public class Network : INetwork
    {
        public static INetwork Default = new Network();

        private Network()
        {
            
        }

        public TextReader GetResponse(string uri)
        {
            return GetResponse(new Uri(uri));
        }

        public TextReader GetResponse(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            return new StreamReader(request.GetResponse().GetResponseStream());
        }
    }
}
