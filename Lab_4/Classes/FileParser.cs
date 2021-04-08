using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    static class FileParser
    {
        private static string PATH__json = Environment.CurrentDirectory + @"\Saves.json";
        private static string PATH__txt = Environment.CurrentDirectory + @"\Saves.txt";

        public static bool IsJsonFileExist() => File.Exists(PATH__json);
        public static bool IsTxtFileExist() => File.Exists(PATH__txt);

        public static void SerializeFile(List<Zodiak> list)
            => File.WriteAllText(PATH__json, JsonConvert.SerializeObject(list));
        
        public static List<Zodiak> DeserializeFile()
            => JsonConvert.DeserializeObject<List<Zodiak>>(File.ReadAllText(PATH__json));

        public static void WriteToFile(List<Zodiak> list)
            => File.WriteAllText(PATH__txt, string.Join("\n", list));

        public static List<Zodiak> GetZodiaksFromFile()
        {
            var text_arr = File.ReadAllText(PATH__txt).Split(new string[] { "\n" }, StringSplitOptions.None);
            var list = new List<Zodiak>();

            foreach (var item in text_arr)
            {
                var (name, surname, sign, birthday) = SplitData(item);
                list.Add(new Zodiak(name, surname, sign, birthday));
            }

            return list;
        }


        public static (string, string, ZodiakTypes, DateTime ) SplitData(string data)
        {
            var str = data.Split();
            string name = str[0];
            string surname = str[1];
            ZodiakTypes zodiakType = (ZodiakTypes)Enum.Parse(typeof(ZodiakTypes), str[2]);

            var b_day_arr = str[3].Split('.').Select(int.Parse).ToArray();
            DateTime birthday = new DateTime(b_day_arr[2], b_day_arr[1], b_day_arr[0]);

            return (name, surname, zodiakType, birthday);
        }
    }
}
