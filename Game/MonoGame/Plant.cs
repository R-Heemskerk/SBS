using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public abstract class Plant
    {
        public PlantList PlantList { get; }
        public string Name { get; }
        public int GrowTime { get; }
        public Texture2D Texture { get; set; }

        protected Plant(PlantList plantList, string name, int growTime)
        {
            this.PlantList = plantList;
            this.Name = name;
            this.GrowTime = growTime * 1000;
        }

        public void Update(GameTime gametime)
        {
            
        }
    }
}