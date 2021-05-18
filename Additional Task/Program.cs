using Additional_Task.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Subscriber> subscribers = new Queue<Subscriber>();

            subscribers.Enqueue(new Subscriber("Sakura", "1002332308"));
            subscribers.Enqueue(new Subscriber("Georgi", "2313032137"));
            subscribers.Enqueue(new Subscriber("Lami", "5345405404"));
            subscribers.Enqueue(new Subscriber("Gregory", "9884350840"));

            Repository repo = new Repository(subscribers);


            Console.WriteLine("Write 'Sur surname' or 'Ph phone' to find subscriber by parameters or smth else to exit & print the repository.");

            while (true)
            {
                var str = Console.ReadLine().Split();
                Subscriber founded_sub = null;

                switch (str[0])
                {
                    case "Sur":
                        founded_sub = repo.getBySurname(str[1]);
                        break;

                    case "Ph":
                        founded_sub = repo.GetByPhoneNumber(str[1]);
                        break;

                    default:
                        goto Print;
                }

                Console.WriteLine(founded_sub == null ? "No subscribers were founded!" : founded_sub.ToString());                
            }

        Print:
            Console.WriteLine(repo.getString());
        }
    }
}
