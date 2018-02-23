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
            Margherita,
            //QuattroFormaggi
        }
        // ------------- Abastract builder -------------
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

        // ------------- Concrete builder -------------

        public class VegetarianCook : PizzaCooks
        {
            public override void PrepareFlatbread()
            {
                m_pizza += "Flatbread: whole wheat flour\n";
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

        public class MarinaraCook : PizzaCooks
        {
            public override void PrepareFlatbread()
            {
                m_pizza += "Flatbread: all-purpose flour \n";
            }

            public override void AddTopping()
            {
                m_pizza += "Topping: olive oil, cherry tomatoes, basil, oregano and garlic\n";
            }

            public override void MakeSauce()
            {
                m_pizza += "Sauce: tomato paste, chopped parsley, minced garlic, oregano, salt, and pepper\n";
            }

            public override void Pack()
            {
                m_pizza = "--- Marinara Pizza ---\n" + m_pizza;
            }
        }

        public class MargheritaCook : PizzaCooks
        {
            public override void PrepareFlatbread()
            {
                m_pizza += "Flatbread: wheat flour - crispy-chewy\n";
            }

            public override void AddTopping()
            {
                m_pizza += "Topping: sliced tomatoes with seeds removed, low-moisture mozzarella, and a smattering of minced fresh basil\n";
            }

            public override void MakeSauce()
            {
                m_pizza += "Sauce: marinara sauce, salt, pepper\n";
            }

            public override void Pack()
            {
                m_pizza = "--- Margherita Pizza ---\n" + m_pizza;
            }
        }
        class Chef // Director
        {
            public void SetOrder(PizzaType pizzaType)
            {
                switch (pizzaType)
                {
                    case PizzaType.Vegetarian:
                        m_cook = new VegetarianCook();
                        break;
                    case PizzaType.Margherita:
                        m_cook = new MargheritaCook();
                        break;
                    case PizzaType.Marinara:
                        m_cook = new MarinaraCook();
                        break;
                    default:
                        throw new Exception("Unknown pizza type "+pizzaType.ToString());

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
            Chef masterChef = new Chef();
            foreach (PizzaType pizzaType in Enum.GetValues(typeof(PizzaType)))
            {
                try
                {
                    masterChef.SetOrder(pizzaType);
                    masterChef.MakeAndServePizza();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
