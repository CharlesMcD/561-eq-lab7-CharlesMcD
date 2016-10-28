using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Test1() 
        {
            var controllerUnderTest = new HomeController();
            var result = controllerUnderTest.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}