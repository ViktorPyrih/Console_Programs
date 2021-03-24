using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
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
            Reformate();
        }

        public MyTime(int hour, int minute)
        {
            this.hour = hour;
            this.minute = minute;
            second = 0;
            Reformate();
        }

        private void Reformate()
        {
            minute += second / 60;
            second %= 60;
            hour += minute / 60;

            if ((hour < 0 || minute < 0 || second < 0) && !(hour <= 0 && minute <= 0 && second <= 0))
            {
                // convert to seconds & back
                var sec = TimeSinceMidnight(this);
                var mt = TimeSinceMidnight(sec);
                hour = mt.hour;
                minute = mt.minute;
                second = mt.second;
            }

            hour %= 24;
        } 

        public override string ToString() => string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);

        public void AddOneSecond() 
        {
            second++;
            Reformate();
        }

        public void AddOneMinute() 
        {
            minute++;
            Reformate();
        }

        public void AddOneHour() 
        {
            hour++;
            Reformate();
        }

        public void AddSeconds(int s) 
        {
            second += s;
            Reformate();
        }

        public void AddMinutes(int m)
        {
            minute += m;
            Reformate();
        }

        public void AddHours(int h)
        {
            hour += h;
            Reformate();
        }

        public static MyTime DifferenceBetween(MyTime mt1, MyTime mt2) => mt1 - mt2;

        public static int TimeSinceMidnight(MyTime mt1) => mt1.second + mt1.minute * 60 + mt1.hour * 3600;

        public static MyTime TimeSinceMidnight(int sec) => new MyTime(sec / 3600, (sec % 3600) / 60, ((sec % 3600) % 60));

        public static MyTime operator -(MyTime mt1, MyTime mt2) 
            => new MyTime(mt1.hour - mt2.hour, mt1.minute - mt2.minute, mt1.second - mt2.second);

        public static MyTime operator +(MyTime mt1, MyTime mt2) 
            => new MyTime(mt1.hour + mt2.hour, mt1.minute + mt2.minute, mt1.second + mt2.second);

        public static bool operator >(MyTime mt1, MyTime mt2)
            => mt1.hour > mt2.hour || 
            (mt1.hour == mt2.hour && mt1.minute > mt2.minute || 
            (mt1.hour == mt2.hour && mt1.minute == mt2.minute && mt1.second > mt2.second));

        public static bool operator >=(MyTime mt1, MyTime mt2) => (mt1 > mt2 || mt1 == mt2);

        public static bool operator <(MyTime mt1, MyTime mt2) => !(mt1 >= mt2);

        public static bool operator <=(MyTime mt1, MyTime mt2) => !(mt1 > mt2);

        public static bool operator ==(MyTime mt1, MyTime mt2)
            => mt1.hour == mt2.hour && mt1.minute == mt2.minute && mt1.second == mt2.second;

        public static bool operator !=(MyTime mt1, MyTime mt2) => !(mt1 == mt2);

        public override bool Equals(object obj) => obj is MyTime && (obj as MyTime) == this;

        public override int GetHashCode() => TimeSinceMidnight(this);

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
