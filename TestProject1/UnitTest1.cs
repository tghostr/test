using SF2022UserNNLib;

namespace TestProject1
{
    public class Tests
    {
        Calculations calculations = new Calculations();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var startTimes = new TimeSpan[] { new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0) };
            var durations = new int[] { 15, 20 };
            var beginWorkTime = new TimeSpan(8, 0, 0);
            var endWorkTime = new TimeSpan(10, 0, 0);
            var consultationTime = 30;

            var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkTime, endWorkTime, consultationTime);

            var expected = new string[] { "08:00-08:30", "08:30-09:00", "09:00-09:30", "09:30-10:00" };

            Assert.AreEqual(expected, result);
        }
    }
}