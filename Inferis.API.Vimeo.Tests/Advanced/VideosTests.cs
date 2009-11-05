using System;
using System.Diagnostics;
using System.IO;
using Moq;
using NUnit.Framework;

namespace Inferis.API.Vimeo.Tests.Advanced
{
    [TestFixture]
    public class VideosTests
    {
        public const string Key = "123";
        public const string Secret = "456";

        [Test]
        public void GetAll_MakesProperRequest()
        {
            var expectedUri = "http://vimeo.com/api/rest/v2?user_id=789&method=vimeo.videos.GetAll&api_key=123&api_sig=d3b82526b48311089bf3747c374d63ed";
            var network = new Mock<INetwork>();
            network
                .Setup(n => n.GetResponse(It.Is<Uri>(uri => uri.AbsoluteUri == expectedUri)))
                .Returns(new Func<Uri, TextReader>(s => new StreamReader(typeof(VideosTests).Assembly.GetManifestResourceStream("Inferis.API.Vimeo.Tests.TestResponses.vimeo.videos.getall.xml"))));

            var vimeo = new Vimeo.Advanced.Vimeo(Key, Secret, network.Object);
            vimeo.Videos.GetAll("789");
        }

        [Test]
        public void GetAll_Returns_Result()
        {
            var expectedUri = "http://vimeo.com/api/rest/v2?user_id=789&method=vimeo.videos.GetAll&api_key=123&api_sig=d3b82526b48311089bf3747c374d63ed";
            var network = new Mock<INetwork>();
            network
                .Setup(n => n.GetResponse(It.Is<Uri>(uri => uri.AbsoluteUri == expectedUri)))
                .Returns(new Func<Uri, TextReader>(s => new StreamReader(typeof(VideosTests).Assembly.GetManifestResourceStream("Inferis.API.Vimeo.Tests.TestResponses.vimeo.videos.getall.xml"))));

            var vimeo = new Vimeo.Advanced.Vimeo(Key, Secret, network.Object);
            var result = vimeo.Videos.GetAll("789");
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result.OnThisPage);
            Assert.AreEqual(2, result.Total);
            Assert.AreEqual(50, result.PerPage);
        }
    }
}
