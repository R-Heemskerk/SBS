using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Plants
{
    class Mango : Plant
    {
        public Mango(Texture2D texture) : base(PlantList.Mango, "Mango", 40) // 40 secondes
        {
            this.Texture = texture;
        }
    }
}