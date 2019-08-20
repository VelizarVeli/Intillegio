using System;
using Intillegio.Web.Controllers;
using Xunit;

namespace Intillegio.Web.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result = Math.Pow(2, 10);
            Assert.Equal(1024, result);
        }
    }
}
