using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.utils
{
    public static class ValidationUtils
    {
        public static bool isValidMark(string markString) 
        {
            return byte.TryParse(markString, out byte mark) 
                && mark >= 1 
                && mark <= 5; 
        }
    }
}
