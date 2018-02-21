using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        public interface IDrawGraph
        {
            string CreateGraph();
        }
        
         class LineGraph :IDrawGraph
        {
            public string CreateGraph()
            {
                return "Line Graph Created!";
            }

        }
        class PiChart:IDrawGraph
        {
            public string CreateGraph()
            {
                return "Pie Chart Graph Created!";
            }
        }
        public class GraphContext
        {
            IDrawGraph dgraph;
            public GraphContext(IDrawGraph graph)
            {
                this.dgraph = graph;
            }
            public void GraphContextCreate()
            {
                Console.WriteLine(this.dgraph.CreateGraph());
            }
        }
        static void Main(string[] args)
        {
            GraphContext graph1 = new GraphContext(new PiChart());
            graph1.GraphContextCreate();
            GraphContext graph2 = new GraphContext(new LineGraph());
            graph2.GraphContextCreate();
            Console.ReadKey();
        }
    }
}
