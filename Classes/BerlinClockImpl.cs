using System;
using System.Text;

namespace BerlinClock.Classes
{
    public class BerlinClockImpl : ITimeFormat
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }

        public BerlinClockImpl(string aTime)
        {
            if(aTime.Equals("24:00:00"))
            {
                Hour = 24;
                Minute = Second = 0;
            }
            else
            {
                DateTime time;
                if (DateTime.TryParse(aTime, out time))
                {
                    Hour = time.Hour;
                    Minute = time.Minute;
                    Second = time.Second;
                }
                else
                    throw new ArgumentException("Invalid time format. Expected 00:00:00");
            }
        }

        public string FirstRow()
        {
            //Seconds (Yellow lamp)
            return Second % 2 == 0 ? "Y" : "O";
        }

        public string SecondRow()
        {
            //Hours - Red lamps switched on
            string secondRow = string.Empty.PadLeft((Hour / 5), 'R'); ;

            //Hours - Red lamps switched off
            secondRow = secondRow.PadRight(4, 'O');

            return secondRow;
        }

        public string ThirdRow()
        {
            //Hours - red lamps switched on
            string thirdRow = string.Empty.PadLeft((Hour % 5), 'R');

            //Hours - red lamps switched off
            thirdRow = thirdRow.PadRight(4, 'O');

            return thirdRow;
        }

        public string FourthRow()
        {
            //Minutes - lamps switched on (all yellow)
            string fourthRow = string.Empty.PadLeft((Minute / 5), 'Y');

            //Changing yellow lamps to red lamps
            char[] temp = fourthRow.ToCharArray();
            for (var i = 2; i < fourthRow.Length; i += 3)
            {
                temp[i] = 'R';
            }
            fourthRow = new string(temp);

            //Minutes - lamps switched off
            fourthRow = fourthRow.PadRight(11, 'O');

            return fourthRow;
        }

        public string FifthRow()
        {
            //Minutes - yellow lamps switched on
            string fifthRow = string.Empty.PadLeft((Minute % 5), 'Y');

            //Minutes - yellow lamps switched off
            fifthRow = fifthRow.PadRight(4, 'O');

            return fifthRow;
        }

        public override string ToString()
        {
            StringBuilder Lamps = new StringBuilder();
            Lamps.AppendLine(FirstRow());
            Lamps.AppendLine(SecondRow());
            Lamps.AppendLine(ThirdRow());
            Lamps.AppendLine(FourthRow());
            Lamps.Append(FifthRow());

            return Lamps.ToString();
        }
    }
}
