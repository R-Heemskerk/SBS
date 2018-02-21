using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Plant
    {
        public static readonly Plant ANANAS = new Plant("Ananas", 1000);

        public static IEnumerable<Plant> Values
        {
            get { yield return ANANAS; }
        }

        public string Name { get; }
        public int GrowTime { get; }
        public Texture2D Texture { get; private set; }

        public Plant(string name, int growTime)
        {
            this.Name = name;
            this.GrowTime = growTime;
        }

        public void LoadContent(ContentManager content, string path)
        {
            Texture = content.Load<Texture2D>(path);
        }

    }
}
