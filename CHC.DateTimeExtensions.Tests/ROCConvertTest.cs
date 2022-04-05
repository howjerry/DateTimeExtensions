using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CHC.DateTimeExtensions.Tests
{
    [TestClass]
    public class ROCConvertTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestMethod]
        public void Utc()
        {
            Assert.AreEqual(new DateTime(2012, 02, 29), "101.02.29".ConvertByROCDateToDateTime());
        }
    }
}
