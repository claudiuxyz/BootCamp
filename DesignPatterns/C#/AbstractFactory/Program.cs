using System;

namespace AbstractFactory
{
    interface IClothes
    {
        string GetName();
    }

    interface IShoes
    {
        string GetName();
    }

    interface IAbstractFactory
    {
        IClothes MakeClothes();
        IShoes MakeShoes();
    }

    //--------- Concrete Clothes ---------
    class SpringOutfit : IClothes
    {
        public string GetName()
        {
            return "Cardigan & jeans";
        }
    }
    class SummerOutfit : IClothes
    {
        public string GetName()
        {
            return "T-shirt & short";
        }
    }
    class AutumnOutfit : IClothes
    {
        public string GetName()
        {
            return "Jacket & jeans";
        }
    }
    class WinterOutfit : IClothes
    {
        public string GetName()
        {
            return "Coat & trousers";
        }
    }
    //--------- Concrete Shoes ---------
    class SpringShoes : IShoes
    {
        public string GetName()
        {
            return "Shoes";
        }
    }
    class SummerShoes : IShoes
    {
        public string GetName()
        {
            return "Sandals";
        }
    }
    class AutumnShoes : IShoes
    {
        public string GetName()
        {
            return "Sneakers";
        }
    }
    class WinterShoes : IShoes
    {
        public string GetName()
        {
            return "Boots";
        }
    }

    //--------- Concrete Factories ---------

    class SpringFactory : IAbstractFactory
    {
        public IClothes MakeClothes()
        {
            return new SpringOutfit();
        }
        public IShoes MakeShoes()
        {
            return new SpringShoes();
        }
    }
    class SummerFactory : IAbstractFactory
    {
        public IClothes MakeClothes()
        {
            return new SummerOutfit();
        }
        public IShoes MakeShoes()
        {
            return new SummerShoes();
        }
    }
    class AutumnFactory : IAbstractFactory
    {
        public IClothes MakeClothes()
        {
            return new AutumnOutfit();
        }
        public IShoes MakeShoes()
        {
            return new AutumnShoes();
        }
    }

    class WinterFactory : IAbstractFactory
    {
        public IClothes MakeClothes()
        {
            return new WinterOutfit();
        }
        public IShoes MakeShoes()
        {
            return new WinterShoes();
        }
    }
    //--------- Driver program ---------
    class Program
    {
        enum Seasons
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        private static IAbstractFactory getFactory(Seasons season)
        {
            switch (season)
            {
                case Seasons.Spring:
                    return new SpringFactory();
                case Seasons.Summer:
                    return new SummerFactory();
                case Seasons.Autumn:
                    return new AutumnFactory();
                case Seasons.Winter:
                    return new WinterFactory();
                default:
                    return null;
            }
        }

        static void Main(string[] args)
        {
            Seasons season = Seasons.Autumn;
            IAbstractFactory factory = getFactory(season);
            Console.WriteLine("Clothes -> "+factory.MakeClothes().GetName());
            Console.WriteLine("Shoes -> "+factory.MakeShoes().GetName());
            Console.ReadKey();
        }
    }
}
