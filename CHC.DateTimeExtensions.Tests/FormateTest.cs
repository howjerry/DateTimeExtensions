using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace CHC.DateTimeExtensions.Tests
{

    [TestClass]
    public class FormateTest
    {
        private const string  FromateVeryShortDateString = "yyyy.MM.dd";
        private const string FormateShortDateString = "yyyy年MM月dd日";
        private const string FormateLongDateString = "民國yyyy年MM月dd日";
        private const string FormateLongDateAndWeekString = "民國yyyy年MM月dd日 ddd";

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void UtcDate()
        {
            var date = new DateTime(2012, 02, 29).ToUniversalTime();

            Assert.AreEqual($"101.02.29", date.FormatROC(FromateVeryShortDateString));
        }

        [TestMethod]
        public void VeryShortDate()
        {
            var date = new DateTime(2012, 02, 29);

            Assert.AreEqual($"101.02.29", date.FormatROC(FromateVeryShortDateString));
        }

        [TestMethod]
        public void ShortDate()
        {
            var date = new DateTime(2012, 02, 29);

            Assert.AreEqual($"101年02月29日", date.FormatROC(FormateShortDateString)); 
        }

        [TestMethod]
        public void LognData()
        {
            var date = new DateTime(2012, 02, 29);

            Assert.AreEqual($"民國101年02月29日", date.FormatROC(FormateLongDateString));
        }

        [TestMethod]
        public void LongDateAndWeek()
        {
            var date = new DateTime(2012, 02, 29);


            Assert.AreEqual("民國101年02月29日 週三", date.FormatROC(FormateLongDateAndWeekString));
        }


        [TestMethod]
        public void LongDateAndLongWeek()
        {
            var date = new DateTime(2012, 02, 29);
            DateTimeExtensions.Initialization(new String[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" });

            Assert.AreEqual("民國101年02月29日 星期三", date.FormatROC(FormateLongDateAndWeekString));
        }
    }
}