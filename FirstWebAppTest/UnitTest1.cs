using FirstWebApp;
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
        public void TestEntry()
        {
            var messageController = new FirstWebApp.Controllers.MessageController();
            var actualResult = messageController.Get().Value;

            var expectedResult = "Welcome";

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestHello()
        {
            var messageController = new FirstWebApp.Controllers.MessageController();
            var actualResult = messageController.Get("Hello").Value;

            var expectedResult = "Hi";

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestHi()
        {
            var messageController = new FirstWebApp.Controllers.MessageController();
            var actualResult = messageController.Get("Hi").Value;

            var expectedResult = "Hello";

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestNothing()
        {
            var messageController = new FirstWebApp.Controllers.MessageController();
            var actualResult = messageController.Get("asd").Value;

            var expectedResult = "Invalid Token";

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
