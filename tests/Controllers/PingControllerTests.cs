using NUnit.Framework;
using NFluent;
using BlogApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Controllers.Tests
{
    [TestFixture]
    public class PingControllerTests
    {
        [Test]
        public void PingControllerTest()
        {
            var controller = new PingController(null);

            var result = controller.GetPing();

            Check.That(result.Value).IsEqualTo("I'm alive !!");
        }
    }
}