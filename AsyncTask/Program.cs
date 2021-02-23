using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var cooking = new Cooking();
            await cooking.Cook();

            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds / 1000 + " s");
        }
    }

    class Cooking
    {

        public async Task Cook()
        {
            var burger = MakeBurger();
            var cola = PourCola();
            var potato = FryPotato();

            var tasks = new List<Task> { burger, cola, potato };

            while (tasks.Count > 0)
            {
                var finished = await Task.WhenAny(tasks);
                
                if (finished == burger)
                {
                    Console.WriteLine("Take your burger.");
                }
                if (finished == cola)
                {
                    Console.WriteLine("Drink your Cola.");
                }
                if (finished == potato)
                {
                    Console.WriteLine("Eat potato");
                }

                tasks.Remove(finished);
            }

            Console.WriteLine("Everything is done!");
        }

        private async Task<Burger> MakeBurger()
        {
            await Task.Delay(5000);
            return new Burger();
        }

        private async Task<Cola> PourCola()
        {
            await Task.Delay(3000);
            return new Cola();
        }

        private async Task<Potato> FryPotato()
        {
            await Task.Delay(2000);
            return new Potato();
        }
    }



    class Burger
    {

    }
    class Cola
    {

    }
    class Potato
    {

    }

}


