using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferis.API.Vimeo.Advanced.Responses
{
    // used in Auth.GetToken
    public class TokenInfo
    {
        public string Token { get; set; }
        public Permission Perms { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
    }
}
