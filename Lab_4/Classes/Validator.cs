using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    static class Validator
    {
        public static bool IsValidate(ZodiakTypes zodiakType, DateTime birthday)
        {
            ZodiakTypesDateTable.TryGetValue(zodiakType, out DateTime[] datetimes);

            return 
                birthday.DayOfYear >= datetimes[0].DayOfYear && 
                birthday.DayOfYear <= datetimes[1].DayOfYear;
        }

        public static ZodiakTypes GetZodiakType(DateTime birthday)
        {
            foreach (var sign in Enum.GetValues(typeof(ZodiakTypes)).Cast<ZodiakTypes>())
            {
                if (IsValidate(sign, birthday)) return sign;
            }
            return 0;
        }

        private static Dictionary<ZodiakTypes, DateTime[]> ZodiakTypesDateTable = new Dictionary<ZodiakTypes, DateTime[]>
        {
            { ZodiakTypes.Aries, new DateTime[2] {new DateTime(2000, 03, 21), new DateTime(2000, 04, 19) } },
            { ZodiakTypes.Taurus, new DateTime[2] {new DateTime(2000, 04, 20), new DateTime(2000, 05, 20) } },
            { ZodiakTypes.Gemini, new DateTime[2] {new DateTime(2000, 05, 21), new DateTime(2000, 06, 20) } },
            { ZodiakTypes.Cancer, new DateTime[2] {new DateTime(2000, 06, 21), new DateTime(2000, 07, 22) } },
            { ZodiakTypes.Leo, new DateTime[2] {new DateTime(2000, 07, 23), new DateTime(2000, 08, 22) } },
            { ZodiakTypes.Virgo, new DateTime[2] {new DateTime(2000, 08, 23), new DateTime(2000, 09, 22) } },
            { ZodiakTypes.Libra, new DateTime[2] {new DateTime(2000, 09, 23), new DateTime(2000, 10, 22) } },
            { ZodiakTypes.Scorpio, new DateTime[2] {new DateTime(2000, 10, 23), new DateTime(2000, 11, 22) } },
            { ZodiakTypes.Sagittarius, new DateTime[2] {new DateTime(2000, 11, 23), new DateTime(2000, 12, 21) } },
            { ZodiakTypes.Capricorn, new DateTime[2] {new DateTime(2000, 12, 22), new DateTime(2000, 01, 19) } },
            { ZodiakTypes.Aquarius, new DateTime[2] {new DateTime(2000, 01, 20), new DateTime(2000, 02, 18) } },
            { ZodiakTypes.Pisces, new DateTime[2] {new DateTime(2000, 02, 19), new DateTime(2000, 03, 20) } }
        };
    }
}
