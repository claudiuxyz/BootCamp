using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ITree
{
    void Draw();
}

class TreeType : ITree // immutable - intrinsec state
{
    public string Name { get; private set; }
    public int Color { get; private set; }
    public int Texture { get; private set; }
    public TreeType(string name, int color, int texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }
    public void Draw()
    {
        Console.Write($"Tree - name: {Name}, color: {Color}, texture:{Texture}");
    }
}

class TreeFactory
{
    private static List<TreeType> m_trees;

    private static TreeFactory m_treeFactory;
    public static TreeFactory GetInstance()
    {
        if (m_treeFactory == null)
        {
            m_treeFactory = new TreeFactory();
        }
        return m_treeFactory;
    }

    private TreeFactory() {
        m_trees = new List<TreeType>();
    }

    public TreeType GetTreeType(string name, int color, int texture)
    {
        var treeType = m_trees.Find(x => x.Name == name && x.Color == color && x.Texture == texture);
        if (treeType == null)
        {
            treeType = new TreeType(name, color, texture);
            m_trees.Add(treeType);
            Console.WriteLine($"Creating tree - name: {name}, color: {color}, texture:{texture}");
            return treeType;
        }
        return treeType;
    }
}

class Tree : ITree // Extrinsec state
{
    private int m_x;
    private int m_y;
    private TreeType m_treeType;
    public Tree(int x, int y, TreeType treeType)
    {
        m_x = x;
        m_y = y;
        m_treeType = treeType;
    }

    public void Draw()
    {
        m_treeType.Draw();
        Console.WriteLine($" at {m_x}, {m_y}");
    }
}

public class Forest : ITree
 {
    private List<Tree> m_forest;
    public Forest()
    {
        m_forest = new List<Tree>();
    }

    public void PlantTree(int x, int y, string name, int color, int texture)
    {
        var treeType = TreeFactory.GetInstance().GetTreeType(name, color, texture);
        var tree = new Tree(x, y, treeType);
        m_forest.Add(tree);
    }

    public void Draw()
    {
        Console.WriteLine("============= FOREST ===============");
        foreach (var tree in m_forest)
        {
            tree.Draw();
        }
    }
 }
namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tree_names = { "Alder", "Ash", "Birch" };
            Forest forest = new Forest();
            Random r = new Random();
            int rInt = r.Next(0, 100);
            for (int i = 0; i < 100; i++)
            {
                forest.PlantTree(r.Next(0, 1023), r.Next(0, 1080), tree_names.OrderBy(x => r.Next()).Take(1).First(), r.Next(0, 2), r.Next(0, 3));
            }
            forest.Draw();
            Console.ReadKey();

        }
    }
}
