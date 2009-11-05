using System.Diagnostics;
using System.IO;
using System.Net;
using Inferis.API.Vimeo.Advanced;
using Inferis.API.Vimeo.Advanced.Responses;
using Moq;
using NUnit.Framework;

namespace Inferis.API.Vimeo.Tests.Advanced
{
    [TestFixture]
    public class AuthTests
    {
        //public const string ApiKey = "12345";
        //public const string Secret = "09876";
        public const string ApiKey = "90e784a71288c03e6bc85f3db2ba5620";
        public const string Secret = "6d1f766a73558210";
        public const string GoodFrob = @"<?xml version=""1.0"" encoding=""UTF-8""?><rsp stat=""ok"" generated_in=""0.0010""><frob>6789</frob></rsp>";

        private string frob;
        private TokenInfo token;

        [Test]
        public void GetFrob_Works()
        {
            var auth = new Auth(ApiKey, Secret);
            frob = auth.GetFrob();
            var authUri = auth.GenerateAuthenticationUri(frob);

            Process.Start(authUri.AbsoluteUri);
            Debug.WriteLine(authUri.ToString());
        }

        [Test]
        public void GetToken_Works()
        {
            //frob = "936a17ea23d09ce2e5a5dd645474e517";
            Assert.IsNotEmpty(frob);

            var auth = new Auth(ApiKey, Secret);
            token = auth.GetToken(frob);
            Debug.WriteLine(token.Token);
        }

        public void GetFrob_Works2()
        {
            var network = new Mock<INetwork>();
            var good = "";
            network.Setup(n => n.GetResponse(It.Is<string>(uri => uri == ""))).Returns(new StringReader(GoodFrob));

            var auth = new Auth(ApiKey, Secret);
            var frob = auth.GetFrob();

            Assert.AreEqual("6789", frob);
        }
    }
}
