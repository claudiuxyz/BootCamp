using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class TransactionRobot //Context
    {
        private TransactionStrategy m_strategy;
        public void SetStrategy(TransactionStrategy strategy)
        {
            m_strategy = strategy;
        }

        public void Execute()
        {
            m_strategy.ApplyAlgorithm();
        }
    }

    public abstract class TransactionStrategy
    {
        public abstract void ApplyAlgorithm();
    }

    public class SellStrategy:TransactionStrategy
    {
        public override void ApplyAlgorithm()
        {
            Console.WriteLine("Sell shares.");
        }
    }

    public class BuyStrategy : TransactionStrategy
    {
        public override void ApplyAlgorithm()
        {
            Console.WriteLine("Buy shares.");
        }
    }

    public class KeepStrategy : TransactionStrategy
    {
        public override void ApplyAlgorithm()
        {
            Console.WriteLine("Keep shares.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sellStrategy = new SellStrategy();
            var buyStrategy = new BuyStrategy();
            var keepStrategy = new KeepStrategy();

            var robot = new TransactionRobot();
            var stockPrice = 10;
            if (stockPrice > 80)
            {
                robot.SetStrategy(sellStrategy);
            } else if(stockPrice < 30)
            {
                robot.SetStrategy(buyStrategy);
            }
            else
            {
                robot.SetStrategy(keepStrategy);
            }

            robot.Execute();
            Console.ReadKey();
        }
    }
}
