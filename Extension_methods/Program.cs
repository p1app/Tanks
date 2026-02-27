using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_methods
{

    static class MyExtasions
    {
        public static GetFullName(this Student student)
        {
            return student.name + " " + student.age;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
