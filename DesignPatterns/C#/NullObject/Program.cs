using System;
using System.Collections.Generic;

namespace NullObject
{
    public abstract class Discount
    {
        protected string Name = "Default";
        public abstract double CalculateDiscount(double productCost);
        public string GetName()
        {
            return Name;
        }
    }

    public class PremiunDiscount:Discount
    {
        public PremiunDiscount()
        {
            Name = "Premium";
        }
        public override double CalculateDiscount(double productCost)
        {
            return productCost * 0.5;
        }
    }

    public class FestivalDiscount : Discount
    {
        public FestivalDiscount()
        {
            Name = "Festival";
        }
        public override double CalculateDiscount(double productCost)
        {
            return productCost * 0.15;
        }
    }

    public class NullDiscount : Discount
    {
        public override double CalculateDiscount(double productCost)
        {
            return 0.0;
        }
    }

    class Order
    {
        double m_price = 0;
        public Order (double productPrice)
        {
            m_price = productPrice;
        }
        private List<Discount> m_availableDiscounts = new List<Discount>();
        public void AddDiscount(Discount discount)
        {
            m_availableDiscounts.Add(discount);
        }

        public double ComputeFinalPrice(string clientBonusName)
        {
            Discount discount = new NullDiscount();
            foreach (var d in m_availableDiscounts)
            {
                if(d.GetName() == clientBonusName)
                {
                    discount = d;
                    break;
                }
            }
            return m_price - discount.CalculateDiscount(m_price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(1000);
            order.AddDiscount(new PremiunDiscount());
            order.AddDiscount(new FestivalDiscount());
            Console.WriteLine($"Price with Premium discount is {order.ComputeFinalPrice("Premium")}");
            Console.WriteLine($"Price with Huge discount is {order.ComputeFinalPrice("Huge")}");
            Console.ReadKey();
        }
    }
}
