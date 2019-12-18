using BerlinClock.Classes;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            ITimeFormat clock = new BerlinClockImpl(aTime);
            return clock.ToString();
        }
    }
}
