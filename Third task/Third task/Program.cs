using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Third_task
{
    class Program
    {
        static void Main(string[] args)
        {
           Student Maksym = new Student("Maksym Matsapura","Physics",5);
            Student Vera = new Student("Vera Morgunenko", "Physics", 3);
            Student Sasha = new Student("Sasha Gulitskiy", "Physics", 7);
            Student Nazar = new Student("Nazar Spodar", "Physics", 10);
            var example = new BinaryTree<Student>();
            example.SomeMyEvent += Handler;
            example.RemoveEvent += Handler;
            example.Addel(Sasha);
            example.InsertItems<Student>(Vera,Nazar,Maksym);
            example.Remove(Maksym);
            foreach (var ex in example)
            {
                Console.WriteLine(ex);
            }
            BinaryTree<int> forint = new BinaryTree<int>();
            forint.InsertItems<int>(10,34,55,6,8,0,12,4);
            foreach (var ex in forint)
            {
                Console.WriteLine(ex);
            }
        }
      private static void Handler(object message)
        {
            Console.WriteLine(message);
        }
    }
}
