using System;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class BerlinClockImplTest
    {
        [TestMethod]
        public void TestFistRowOfLampsIsLit()
        {
            //Test if first row lamp is switched off
            string aTime = "13:00:01";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("O", clock.FirstRow());
        }

        [TestMethod]
        public void TestFistRowOfLampsIsOff()
        {
            //Test if first row lamp is switched on
            string aTime = "13:00:02";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("Y", clock.FirstRow());
        }

        [TestMethod]
        public void TestSecondRowOfLampsIsLit()
        {
            //Test if second row lamps are all switched on
            string aTime = "21:50:02";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("RRRR", clock.SecondRow());
        }

        [TestMethod]
        public void TestSecondRowOfLampsIsOff()
        {
            //Test if second row lamps are all switched off
            string aTime = "04:03:02";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("OOOO", clock.SecondRow());
        }

        [TestMethod]
        public void TestThirdRowOfLampsIsLit()
        {
            //Test if third row lamps are all switched on
            string aTime = "04:59:59";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("RRRR", clock.ThirdRow());
        }

        [TestMethod]
        public void TestThirdRowOfLampsIsOff()
        {
            //Test if third row lamps are all switched off
            string aTime = "00:00:00";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("OOOO", clock.ThirdRow());
        }


        [TestMethod]
        public void TestFourthRowOfLampsIsLit()
        {
            //Test if fourth row lamps are all switched on
            string aTime = "04:59:59";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("YYRYYRYYRYY", clock.FourthRow());
        }

        [TestMethod]
        public void TestFourthRowOfLampsIsOff()
        {
            //Test if fourth row lamps are all switched off
            string aTime = "00:04:00";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("OOOOOOOOOOO", clock.FourthRow());
        }

        [TestMethod]
        public void TestFifthRowOfLampsIsLit()
        {
            //Test if fourth row lamps are all switched on
            string aTime = "08:59:59";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("YYYY", clock.FifthRow());
        }

        [TestMethod]
        public void TestFifthRowOfLampsIsOff()
        {
            //Test if fourth row lamps are all switched off
            string aTime = "00:05:00";

            BerlinClockImpl clock = new BerlinClockImpl(aTime);

            Assert.AreEqual("OOOO", clock.FifthRow());
        }

        [TestMethod]
        public void TestInvalidTimeFormat()
        {
            //Test if invalid format throws a ArgumentException
            string aTime = "24:05:00";

            BerlinClockImpl clock;

            Assert.ThrowsException<ArgumentException>(() => clock = new BerlinClockImpl(aTime));
        }

        [TestMethod]
        public void TestMidnight2400()
        {
            //Test if special case works (24:00:00). In this case, the second row must be RRRR and not OOOO
            string aTime = "24:00:00";

            BerlinClockImpl clock = new BerlinClockImpl(aTime); ;

            Assert.AreEqual("RRRR", clock.SecondRow());
        }
    }
}
