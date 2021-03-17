using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Classes.Tasks
{
    class MyTime
    {
        public int hour { get; private set; }
        public int minute { get; private set; }
        public int second { get; private set; }

        public MyTime(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public MyTime(int hour, int minute)
        {
            this.hour = hour;
            this.minute = minute;
            second = 0;
        }

        public override string ToString() 
            => string.Format("{0:00 0:00 0:00}", hour, minute, second);

        public void AddOneSecond() 
        {
            second++;
            if (second >= 60)
            {
                second = 0;
                AddOneMinute();
            }
        }

        public void AddOneMinute() 
        {
            minute++;
            if (minute >= 60)
            {
                minute = 0;
                AddOneHour();
            }
        }

        public void AddOneHour() 
        {
            hour++;
            hour %= 24;
        }

        public void AddSeconds(int s) 
        {
            second += s;
            AddMinutes(second / 60);
            second %= 60;
        }

        public void AddMinutes(int m)
        {
            minute += m;
            AddHours(minute / 60);
            minute %= 60;
        }

        public void AddHours(int h)
        {
            hour += h;
            hour %= 24;
        }

        public static MyTime DifferenceBetween(MyTime mt1, MyTime mt2) => mt1 - mt2;

        public static int TimeSinceMidnight(MyTime mt1) => mt1.second + mt1.minute * 60 + mt1.hour * 360;

        public static MyTime TimeSinceMidnight(int sec) => new MyTime(sec / 360, (sec % 360) / 60, (sec % 21600);

        public static MyTime operator -(MyTime mt1, MyTime mt2)
        {
            return new MyTime(mt1.hour - mt2.hour, mt1.minute - mt2.minute, mt1.second - mt1.second);
        }

        public static MyTime operator +(MyTime mt1, MyTime mt2)
        {
            return new MyTime(mt1.hour + mt2.hour, mt1.minute + mt2.minute, mt1.second + mt1.second);
        }

        public static bool operator >(MyTime mt1, MyTime mt2)
            => mt1.hour > mt2.hour || 
            (mt1.hour == mt2.hour && mt1.minute > mt2.minute || 
            (mt1.minute == mt2.minute && mt1.second > mt2.second));

        public static bool operator >=(MyTime mt1, MyTime mt2) => (mt1 > mt2 || mt1 == mt2);

        public static bool operator <(MyTime mt1, MyTime mt2) => !(mt1 >= mt2);

        public static bool operator <=(MyTime mt1, MyTime mt2) => !(mt1 > mt2);

        public static bool operator ==(MyTime mt1, MyTime mt2)
            => mt1.hour == mt2.hour && mt1.minute == mt2.minute && mt1.second == mt2.second;

        public static bool operator !=(MyTime mt1, MyTime mt2) => !(mt1 == mt2);

        public string WhatLesson() 
        {
            if (this >= new MyTime(8, 00) && this <= new MyTime(9, 20)) return "1 Lesson";
            else
            if (this > new MyTime(9, 20) && this < new MyTime(9, 40)) return "Break between 1 & 2";
            else
            if (this >= new MyTime(9, 40) && this <= new MyTime(11, 00)) return "2 Lesson";
            else
            if (this > new MyTime(11, 00) && this < new MyTime(11, 20, 0)) return "Break between 2 & 3";
            else
            if (this >= new MyTime(11, 20) && this <= new MyTime(12, 40)) return "3 Lesson";
            else
            if (this > new MyTime(12, 40) && this < new MyTime(13, 00)) return "Break between 3 & 4";
            else
            if (this >= new MyTime(13, 00) && this <= new MyTime(14, 20)) return "4 Lesson";
            else
            if (this > new MyTime(14, 20) && this < new MyTime(14, 40)) return "Break between 4 & 5";
            else
            if (this >= new MyTime(14, 40) && this <= new MyTime(16, 00)) return "5 Lesson";
            else
            if (this > new MyTime(16, 00) && this < new MyTime(16, 20)) return "Break between 5 & 6";
            else
            if (this >= new MyTime(16, 20) && this <= new MyTime(17, 40)) return "6 Lesson";
            else 
                return "Lessons are over";
        }

    }
}
