using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Task__2_14 : IRunnable
    {
        public void Run()
        {
            List<Student> students = new List<Student>();

            var av_mark_st = students.Select(x => x.surName);
        }
    }
}
