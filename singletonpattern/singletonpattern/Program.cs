using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletonpattern
{
    class Program
    {
        public class DataLayer
        {
            protected static DataLayer SQLDriver = new DataLayer();
            public static DataLayer Instance()
            {
                
                
                    if(SQLDriver == null)
                    {
                        SQLDriver = new DataLayer();
                    }
                    return SQLDriver;
                
            }
            protected DataLayer()
            {

            }
            public void view()
            {
                Console.WriteLine("Yay Singleton it is!!");
            }
        }



        static void Main(string[] args)
        {
            DataLayer D1 = DataLayer.Instance();
            D1.view();
            DataLayer D2 = DataLayer.Instance();
            D2.view();
            DataLayer D3 = DataLayer.Instance();
            D3.view();


            Console.ReadKey();
  
        }
    }
}
