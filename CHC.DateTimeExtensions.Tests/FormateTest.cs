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
        private const string FormateShortDateString = "yyyy�~MM��dd��";
        private const string FormateLongDateString = "����yyyy�~MM��dd��";
        private const string FormateLongDateAndWeekString = "����yyyy�~MM��dd�� ddd";

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

            Assert.AreEqual($"101�~02��29��", date.FormatROC(FormateShortDateString)); 
        }

        [TestMethod]
        public void LognData()
        {
            var date = new DateTime(2012, 02, 29);

            Assert.AreEqual($"����101�~02��29��", date.FormatROC(FormateLongDateString));
        }

        [TestMethod]
        public void LongDateAndWeek()
        {
            var date = new DateTime(2012, 02, 29);


            Assert.AreEqual("����101�~02��29�� �g�T", date.FormatROC(FormateLongDateAndWeekString));
        }


        [TestMethod]
        public void LongDateAndLongWeek()
        {
            var date = new DateTime(2012, 02, 29);
            DateTimeExtensions.Initialization(new String[] { "�P����", "�P���@", "�P���G", "�P���T", "�P���|", "�P����", "�P����" });

            Assert.AreEqual("����101�~02��29�� �P���T", date.FormatROC(FormateLongDateAndWeekString));
        }
    }
}