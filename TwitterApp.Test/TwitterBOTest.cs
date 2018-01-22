using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using TwitterApp.BLL;
using TwitterApp.Controllers;
using TwitterApp.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TwitterApp.Test
{
    [TestFixture]
    public class TwitterBOTest
    {
        private Mock<TwitterDataBO> _mockTwitterDataBo;
        private Mock<ITwitterBO> _mockTwitterBo;
        private string sampleResponseData;
        private Mock<HomeController> _mockController;

        [SetUp]
        public void SetUp()
        {
            _mockTwitterDataBo = new Mock<TwitterDataBO>();
            _mockTwitterBo = new Mock<ITwitterBO>();
            sampleResponseData = @"[{ ""Foo"": ""Bar"" }]";
            _mockController = new Mock<HomeController>(_mockTwitterBo.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockTwitterBo = null;
            _mockTwitterDataBo = null;
        }

        /// <summary>
        /// Test method using Moq
        /// </summary>
        [Test]
        public void ShouldReceiveNoTweets()
        {
            _mockTwitterDataBo.Setup(x => x.GetTwitterData()).Returns(string.Empty);

            TwitterBO obje = new TwitterBO(_mockTwitterDataBo.Object);

            Assert.AreEqual(obje.GetTweets().Count, 0);
        }

        [Test]
        public void ShouldReceiveTweets()
        {
            _mockTwitterDataBo.Setup(x => x.GetTwitterData())
                .Returns(() => sampleResponseData);

            TwitterBO obje = new TwitterBO(_mockTwitterDataBo.Object);

            Assert.AreEqual(obje.GetTweets().Count, 1);

        }

        [Test]
        public void SearchBasedOnInput()
        {
            var model = new List<TwitterModel>
            {
                new TwitterModel
                {
                  TweetContent = "national day test",
                    UserName = "test"
                }
            };
            _mockTwitterBo.Setup(x => x.SearchTweet(It.IsAny<string>(), It.IsAny<List<TwitterModel>>()))
                .Returns(() => model);

            TwitterBO obje = new TwitterBO(_mockTwitterDataBo.Object);

            Assert.AreEqual(obje.SearchTweet("national", model).Count, 1);
        }
    }
}
