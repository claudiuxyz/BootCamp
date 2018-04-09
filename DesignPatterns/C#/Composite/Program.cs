using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class PlayableItem //Component
    {
        public abstract void Play();
        protected string m_name;
        public PlayableItem(string name)
        {
            m_name = name;
        }
    }

    public class Song : PlayableItem //Leaf
    {
        public Song(string name): base(name) {}
        public override void Play()
        {
            Console.WriteLine($"Tra la la -> {m_name}");
        }
    }

    public class PlayList : PlayableItem //Composite
    {
        public PlayList(string name) : base(name)
        {
            m_childrenList = new List<PlayableItem>();
        }

        public override void Play()
        {
            foreach (var item in m_childrenList)
            {
                item.Play();
            }        }

        public void AddChild(PlayableItem item)
        {
            m_childrenList.Add(item);
        }
        private List<PlayableItem> m_childrenList;
    }
    class Program
    {
        static void Main(string[] args)
        {

            var playListMetal = new PlayList("Metal Only");
            playListMetal.AddChild(new Song("Metallica - One"));
            playListMetal.AddChild(new Song("Metallica - Master Of Puppets"));
            playListMetal.AddChild(new Song("Metallica - Damage Inc"));

            var playListBalads = new PlayList("Balads");
            playListBalads.AddChild(new Song("Metallica - Nothing Else Matters"));
            playListBalads.AddChild(new Song("Metallica - Fade To Black"));

            var playListRock = new PlayList("Fav Rock");
            playListRock.AddChild(playListMetal);
            playListRock.AddChild(playListBalads);
            playListRock.AddChild(new Song("Motorhead - Orgasmatron"));
            playListRock.Play();
            Console.ReadKey();

        }
    }
}
