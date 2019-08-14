using FirstWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace FirstWebAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestHello()
        {
            //using (var client = new WebClient())
            //{
            //    var responseString = client.DownloadString("http://localhost:53386/api/message/hello");
            //    Assert.Equal("Hi", responseString);
            //}
            MessageController messageController = new MessageController();
            ActionResult<string> actionResult = messageController.Get("Hello");
            Assert.Equal("Hi", actionResult);
        }
        [Fact]
        public void TestHi()
        {
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString("http://localhost:53386/api/message/hi");
                Assert.Equal("Hello", responseString);
            }
            //MessageController messageController = new MessageController();
            //var actionResult= messageController.Get();
        }
        [Fact]
        public void TestNothing()
        {
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString("http://localhost:53386/api/message/");
                Assert.Equal("Welcome", responseString);
            }
            //MessageController messageController = new MessageController();
            //var actionResult= messageController.Get();
        }
    }
}
