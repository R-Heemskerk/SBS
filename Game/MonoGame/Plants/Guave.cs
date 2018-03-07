using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Plants
{
    class Guave : Plant
    {
        public Guave(Texture2D texture) : base("Guave", 80) // 80 secondes
        {
            this.Texture = texture;
        }
    }
}
