using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Choose type of receiving information...\n" +
                "{txt} to get from txt file\n{json} to get from json file\n{keyboard} to get from console");
            
            List<Zodiak> list;

            var str = Console.ReadLine();
            if (str == "txt")
            {
                if (FileParser.IsTxtFileExist())
                {
                    list = FileParser.GetZodiaksFromFile();
                }
                else
                {
                    Console.WriteLine("File doesn't exist yet.\n");
                    goto Start;
                }
            }
            else
            if (str == "json")
            {
                if (FileParser.IsJsonFileExist())
                {
                    list = FileParser.DeserializeFile();
                }
                else
                {
                    Console.WriteLine("File doesn't exist yet.\n");
                    goto Start;
                }
            }
            else
            if (str == "keyboard")
            {
                list = new List<Zodiak>();
                Console.WriteLine("Print number of Zodiaks:");
                try
                {
                    var N = int.Parse(Console.ReadLine());

                    for (int i = 0; i < N; i++)
                    {
                        Console.WriteLine($"Print zodiak #{i + 1} | name surname zodiak day.month.year");
                        var (name, surname, sign, birthday) = FileParser.SplitData(Console.ReadLine());
                        if (!Validator.IsValidate(sign, birthday))
                        {
                            var need_sign = Validator.GetZodiakType(birthday);
                            Console.WriteLine($"Your zodiak sign should be {need_sign} by your birth date.");
                            i--;
                        }
                        else 
                            list.Add(new Zodiak(name, surname, sign, birthday));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception is " + e + "\n");
                    goto Start;
                }                
            }
            else goto Start;


            var repository = new ZodiakRepository(list);
            repository.SortByBirthday();

            FileParser.SerializeFile(repository.zodiaks);
            FileParser.WriteToFile(repository.zodiaks);
            Console.WriteLine("Saves were changed\n");

            Console.WriteLine("Print surname so we could it find.");
            Console.WriteLine(string.Join("\n", 
                repository.GetZodiakBySurname(Console.ReadLine())
                ));
        }
    }
}
