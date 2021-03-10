using System;
using Lab_2.Classes.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entry point
            while (true)
            {
                try
                {
                    BlockChoice();
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong!=(");
                }
            }
        }

        static void BlockChoice()
        {
            while (true)
            {
                Console.WriteLine("Choose block to run (print zero to exit):");
                
                if (!int.TryParse(Console.ReadLine(), out int block)) 
                    continue;
                
                switch (block)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        TaskChoice(1);
                        break;
                    case 2:
                        TaskChoice(2);
                        break;
                    case 3:
                        TaskChoice(3);
                        break;
                    default:
                        continue;
                }
            }
        }

        private static void TaskChoice(int block)
        {
            while (true)
            {
                Console.WriteLine("Choose person from below:");
                Console.WriteLine("1 - Igor\n2 - Denis");
                
                if(!int.TryParse(Console.ReadLine(), out int task)) 
                    continue;
                
                switch (task)
                {
                    case 1:
                        IgorTasks(block);
                        break;
                    case 2:
                        DenisTasks(block);
                        break;
                    default:
                        continue;
                } 
            }
        }

        private static void IgorTasks(int block)
        {
            switch (block)
            {
                case 1:
                    new Task__1_8().Run();
                    break;
                case 2:
                    new Task__2_8().Run();
                    break;
                case 3:
                    new Task__3_8().Run();
                    break;
            }

            BlockChoice();
        }
        
        private static void DenisTasks(int block)
        {
            switch (block)
            {
                case 1:
                    new Task__1_10().Run();
                    break;
                case 2:
                    new Task__2_10().Run();
                    break;
                case 3:
                    new Task__3_10().Run();
                    break;
            }

            BlockChoice();
        }
    }
}
