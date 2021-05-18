using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.Views_Commands
{
    static class DateValidator
    {

        public static bool IsDayValidate(string str_day)
        {
            if (str_day == "") return true;
            try
            {
                var n = int.Parse(str_day);

                return (n > 0 && n <= 31);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsMonthValidate(string str_month)
        {
            if (str_month == "") return true;
            try
            {
                var n = int.Parse(str_month);

                return (n > 0 && n <= 12);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
