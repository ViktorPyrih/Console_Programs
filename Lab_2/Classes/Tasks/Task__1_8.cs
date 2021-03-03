using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Classes.Tasks
{
    class Task__1_8 : BaseInit_OneDim, IRunnable
    {
        public Task__1_8() : base("8.Знищити всi елементи мiж першим iз максимальних за значенням i останнiм iз мiнiмальних за " +
                                        "значенням; самi перший з максимальних та останнiй з мiнiмальних теж знищити; врахувати, що " +
                                        "невiдомо, який з них записано в масивi ранiше."){}

        public void Run()
        {            
            var max_index = 0;
            var min_index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[max_index]) max_index = i;
                if (array[i] <= array[min_index]) min_index = i;
            }

            var from_el = Math.Min(max_index, min_index);
            var to_el = Math.Max(max_index, min_index);
            var range = Enumerable.Range(from_el, to_el - from_el + 1);

            var new_arr = new int[array.Length - range.Count()];

            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (!range.Contains(i))
                {
                    new_arr[j] = array[i];
                    j++;
                }
            }

            Console.WriteLine("New array:");
            new_arr.Print();
        }
    }
}
