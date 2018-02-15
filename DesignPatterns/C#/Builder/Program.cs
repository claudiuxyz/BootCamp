using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        enum PizzaType
        {
            Vegetarian,
            Marinara,
            Margherita
        }
        public abstract class PizzaCooks // Builders
        {
            public abstract void PrepareFlatbread();
            public abstract void AddTopping();
            public abstract void MakeSauce();
            public abstract void Pack();
            public string GetPizza()
            {
                return m_pizza;
            }
            protected string m_pizza;
        }

        public class VegetarianCook : PizzaCooks
        {
            public override void PrepareFlatbread()
            {
                m_pizza += "Flatbread: whole flour\n";
            }

            public override void AddTopping()
            {
                m_pizza += "Topping: mozzarella cheese, fresh cilantro and a squeeze of lime juice\n";
            }

            public override void MakeSauce()
            {
                m_pizza += "Sauce: tomatoes, juonion powder, red pepper flakes, basil and oregano\n";
            }

            public override void Pack()
            {
                m_pizza = "--- Vegetarian Pizza ---\n" + m_pizza;
            }
        }

        class MasterChef // Director
        {
            public void SetOrder(PizzaType pizzaType)
            {
                switch (pizzaType)
                {
                    case PizzaType.Vegetarian:
                        m_cook = new VegetarianCook();
                        break;
                }
            }

            public void  MakeAndServePizza()
            {
                m_cook.PrepareFlatbread();
                m_cook.AddTopping();
                m_cook.MakeSauce();
                m_cook.Pack();
                Console.WriteLine(m_cook.GetPizza());
            }

            private PizzaCooks m_cook;
        }
        static void Main(string[] args) //Client
        {
            MasterChef chef = new MasterChef();
            chef.SetOrder(PizzaType.Vegetarian);
            chef.MakeAndServePizza();
            Console.ReadKey();
        }
    }
}
