using System;
using System.Threading.Channels;

/* 
 * 
*/

namespace hurik
{ 



    class Program
    {

        static void Main(string[] args)
        {
            var list = new List<string>();
            string path = "test.txt";

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введите {i+1} строку");
                list.Add(Console.ReadLine());
            }

            foreach (var item in list)
            {
                File.AppendAllText(path, item);
            }

            string fileString = File.ReadAllText(path);

            int count = 0;

            foreach (var item in fileString)
            {
                    count ++;
            }

            Console.WriteLine(fileString + " Колличество символов: " + count);

        }
    }
}