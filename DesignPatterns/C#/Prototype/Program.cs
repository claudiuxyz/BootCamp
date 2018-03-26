using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public abstract class Character
    {
        public string Name { get; set; }
        public abstract Character Clone();
        public int Level { set; get; }
        protected int m_clonesCount;
    }

    public class Heroe : Character
    {
        public Heroe()
        {
            m_clonesCount = 0;
        }      
        
        public string ItemInLeftHand { set; get; }
        public string ItemInRightHand { set; get; }
        public string HelmetType { set; get; }
        public string BootsType { set; get; }
        public string ArmorType { set; get; }
        public override string ToString()
        {
            return $"Name: {Name}\n\tEquiped with: {ItemInLeftHand}, {ItemInRightHand}, {HelmetType}, {BootsType}, {ArmorType}\n\tLevel: {Level}";
        }

        public override Character Clone()
        {
            var clone = (Heroe)this.MemberwiseClone();
            m_clonesCount++;
            clone.Name = string.Format("{0}_{1}", this.Name, m_clonesCount);
            return clone;
        }
    }

    public class Monster : Character
    {
        public Monster()
        {
            m_clonesCount = 0;
        }
        public string ClassType { set; get; }
        public string Size { set; get; }
        public string MagicSkills { set; get; }

        public override string ToString()
        {
            return $"Name: {Name}\n\tAttributes: {ClassType}, {Size}, {MagicSkills}\n\tLevel: {Level}";
        }

        public override Character Clone()
        {
            var clone = (Monster)this.MemberwiseClone();
            m_clonesCount++;
            clone.Name = string.Format("{0}=>{1}", this.Name, m_clonesCount);
            return clone;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Heroe theHeroe = new Heroe();
            theHeroe.Name = "FiercefulMan";
            theHeroe.ItemInLeftHand = "DaedricShield";
            theHeroe.ItemInRightHand = "LargeSword";
            theHeroe.Level = 777;
            theHeroe.HelmetType = "DeadSkull";
            theHeroe.BootsType = "AmelyOnSale";
            theHeroe.ArmorType = "AwesomeChestAndVIPack";

            Monster theMonster = new Monster();
            theMonster.Name = "TheIntimidatingVillain";
            theMonster.ClassType = "FlyingRaptor";
            theMonster.Level = 123;
            theMonster.MagicSkills = "CanEatFiercefullDudes";
            theMonster.Size = "NotSoBad";

            List<Heroe> armyOfHeroes = new List<Heroe>() { theHeroe };
            List<Monster> armyOfMonsters = new List<Monster>() { theMonster};
            for (int i = 0; i < 10; i++)
            {
                armyOfHeroes.Add((Heroe)theHeroe.Clone());
                armyOfMonsters.Add((Monster)theMonster.Clone());
            }
            Console.WriteLine("ARMY OF HEROES:");
            foreach (var heroe in armyOfHeroes)
            {
                Console.WriteLine(heroe);
            }
            Console.WriteLine("\nARMY OF MONSTERS:");
            foreach (var monster in armyOfMonsters)
            {
                Console.WriteLine(monster);
            }
            Console.ReadKey();
        }
    }
}
