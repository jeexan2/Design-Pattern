using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericdemo
{
    class Program
    {
        
        public class Singleton<T> where T : class, new()
        {
            Singleton() { }

            private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

            public static T Instance { get { return instance.Value; } }
        }
        public class Adaptor
        {
            public static Adaptor Instance { get { return Singleton<Adaptor>.Instance; } }
            public void show()
            {
                Console.WriteLine("asas");
            }
        }
        static void Main(string[] args)
        {
            Adaptor a = new Adaptor();
            a.show();
            Console.ReadKey();
        }
    }
}
