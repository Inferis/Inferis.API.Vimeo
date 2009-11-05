using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Inferis.API.Vimeo
{
    public interface INetwork
    {
        TextReader GetResponse(string uri);
        TextReader GetResponse(Uri uri);
    }
}
