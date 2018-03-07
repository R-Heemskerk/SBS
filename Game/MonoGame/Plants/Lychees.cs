using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Plants
{
    class Lychees : Plant
    {
        public Lychees(Texture2D texture) : base("Lychees", 60) // 60 secondes
        {
            this.Texture = texture;
        }
    }
}
