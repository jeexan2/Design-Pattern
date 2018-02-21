using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {

        #region rootclass
        public abstract class HtmlComponent
        {
            protected string name;
            protected string content;
            protected bool isComposite = true;

            public HtmlComponent(string inName)
            {
                name = inName;
            }

            public abstract void Add(HtmlComponent component);
            public abstract void Remove(HtmlComponent component);
            public abstract void Render(int depth);
          
        };
        #endregion
        #region Composite Class
        public class Composite : HtmlComponent
        {
            private IList<HtmlComponent> components = new List<HtmlComponent>();
            public Composite(string name) : base(name)
            {
                isComposite = true;

            }
            public override void Add(HtmlComponent component)
            {
                components.Add(component);
            }
            public override void Remove(HtmlComponent component)
            {
                components.Remove(component);
            }
            public override void Render(int depth)
            {
                

                Console.WriteLine("Composite:{0} is at Level {1}",name,depth);
                foreach (HtmlComponent component in components)
                    component.Render(depth + 1);
            }
        }

        #endregion
        #region leaf class
        public class Leaf : HtmlComponent
        {
            public Leaf(string name) : base(name)
            {
                isComposite = false;
            }
            public override void Add(HtmlComponent component)
            {
                Console.WriteLine("Leaf can't add component!");
            }
            public override void Remove(HtmlComponent component)
            {
                Console.WriteLine("Leaf can't remove component");
            }
            public override void Render(int depth)
            {
                Console.WriteLine("Leaf: {0} is at Level {1}", name, depth);
            }

        };
        #endregion
        static void Main(string[] args)
        {
            #region Presentation
            Composite root = new Composite("html");
            root.Add(new Leaf("img"));
            root.Add(new Leaf("br"));

            Composite comp = new Composite("div");
            comp.Add(new Leaf("hr"));
            comp.Add(new Leaf("br"));

            root.Add(comp);
            root.Add(new Leaf("img"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("br");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Render(1);

            // Wait for user
            Console.ReadKey();
            #endregion
        }
    }
}
