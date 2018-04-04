using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Plants
{
    class Markoesa : Plant
    {
        public Markoesa(Texture2D texture) : base(PlantList.Markoesa, "Markoesa", 60) // 60 secondes
        {
            this.Texture = texture;
        }
    }
}
