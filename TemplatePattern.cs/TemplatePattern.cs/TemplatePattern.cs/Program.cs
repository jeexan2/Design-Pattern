using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern.cs
{
    class Program
    {
        public static class DisPoint
        {
            public static double Distance(Point p1,Point p2)
            {
                return ((p1._xlocation - p2._xlocation) * (p1._xlocation - p2._xlocation) +
                                  (p1._ylocation - p2._ylocation) * (p1._ylocation - p2._ylocation));
            }
        }
        public class Point
        {
            public double _xlocation { get; set; }
            public double _ylocation { get; set; }
            public Point()
            {

            }
            public Point(double x, double y)
            {
                _xlocation = x;
                _ylocation = y;
            }
        }
        public abstract class Shape
        { 
            public List<Point> vertex { get; set; }

            protected bool input_given = false;
            #region Factory Or Creator
            public static Shape ObjectType(int choice)
            {
                
                if (choice == 1) return new Triangle();
                else if (choice == 2) return new Rectangle();
                else  return new Circle();
               
            }
            #endregion
            public void DisplayFeature()
            {
                Console.WriteLine("/t/tShape Related Draw Application");
                Console.WriteLine("/t/tPress 1 to give input!");
                Console.WriteLine("/t/tPress 2 for getting the area");
                Console.WriteLine("/t/tPress 3 for getting the perimeter");
                Console.WriteLine("/t/tPress 4 to Break!");
                
            }
            #region HookMethod
            //hookmethod
            public virtual void GiveInput() {
                Console.WriteLine("\t\tInput is not given!Default value will be set!");

            }
            #endregion
            public abstract void ShowArea();
            public abstract void ShowPerimeter();
            public abstract void Draw();
            public void Menu()
            {
                DisplayFeature();
                //GiveInput();
                Draw();
                int key;
                while (true)
                {
                    key = Convert.ToInt32(Console.ReadLine());
                    if (key == 1)
                    {
                        GiveInput();
                        input_given = true;
                    }
                    else if (key == 2) ShowArea();
                    else if (key == 3) ShowPerimeter();
                    Draw();
                    if (key == 4) break;
                }

            }

         }
        public class Triangle : Shape {
            public Triangle()
            {
                vertex = new List<Point>();
            }
            public override void GiveInput()
            {
                Console.WriteLine("Give the input of 3 vertices");
                
                for(int i = 0; i < 3; i++)
                {
                    Point v = new Point();
                    v._xlocation = Convert.ToDouble(Console.ReadLine());
                   v._ylocation = Convert.ToDouble(Console.ReadLine());
                    vertex.Add(v);
                }
            }
            public override void Draw() {
               
                Console.WriteLine("*");
                Console.WriteLine("*  *");
                Console.WriteLine("*****");
            }
            public override void ShowArea()
            {
                if (input_given == false)
                {
                    Console.WriteLine("Area of Triangle is 7.5 sq unit");
                }
                else
                {
                    double s1, s2, s3,s, area;
                    Point v0 = new Point();
                    Point v1 = new Point();
                    Point v2 = new Point();
                    v0 = vertex[0];
                    v1 = vertex[1];
                    v2 = vertex[2];
                    s1 = DisPoint.Distance(vertex[0], vertex[1]);
                    s2 = DisPoint.Distance(vertex[1], vertex[2]);
                    s3 = DisPoint.Distance(vertex[2], vertex[0]);
                    s = (s1 + s2 + s3) * 0.5;
                    area = s * (s - s1) * (s - s2) * (s - s3);
                    Console.WriteLine("Area of Triangle is {0} sq unit", Math.Sqrt(area));

                }
            }
            public override void ShowPerimeter() {
                Point v0 = new Point();
                Point v1 = new Point();
                Point v2 = new Point();
                v0 = vertex[0];
                v1 = vertex[1];
                v2 = vertex[2];
                double ret = DisPoint.Distance(v0,v1)+DisPoint.Distance(v1,v2)
                    +DisPoint.Distance(v2,v0);
                Console.WriteLine("Perimeter is {0}", ret);
                
            }

        };
        public class Rectangle : Shape {
            public Rectangle()
            {
                vertex = new List<Point>();
            }
            public override void GiveInput()
            {
                base.GiveInput();
                Point p1 = new Point
                {
                    _xlocation = 1.0,
                    _ylocation = 1.0
                };
                Point p2 = new Point
                {
                    _xlocation = 2.0,
                    _ylocation = 2.0
                };
                Point p3 = new Point
                {
                    _xlocation = 3.0,
                    _ylocation = 3.0
                };
                Point p4 = new Point
                {
                    _xlocation = 4.0,
                    _ylocation = 4.0
                };
                vertex.Add(p1);
                vertex.Add(p2);
                vertex.Add(p3);
                vertex.Add(p4);

            }
            public override void Draw() {
                Console.WriteLine("####");
                Console.WriteLine("#  #");
                Console.WriteLine("####");
            }

            public override void ShowArea()
            {
                Console.WriteLine("Area is {0}", Math.Sqrt(DisPoint.Distance(vertex[0], vertex[2]) * DisPoint.Distance(vertex[1], vertex[3])));
            }

             public override void ShowPerimeter() {
                Console.WriteLine("Perimeter is {0}", 2 * (DisPoint.Distance(vertex[0], vertex[2]) +DisPoint.Distance(vertex[1],vertex[3])));
            }
        };
        public class Circle : Shape {
            double radius;
            public Circle()
            {
                vertex = new List<Point>();
                vertex.Add(new Point
                {
                    _xlocation = 0.0,
                    _ylocation = 0.0

                });
                radius = 5.0;
            }
            public override void Draw()
            {
            }
             public override void ShowArea() {
                Console.WriteLine("Area is {0}", Math.PI * radius * radius);
            }
            public override void ShowPerimeter() {

                Console.WriteLine("Perimeter is {0}",2 * Math.PI * radius);
            }
        };

        static void Main(string[] args)
        {
            Shape sh = Shape.ObjectType(3);
            sh.Menu();
           
        }
    }
}
