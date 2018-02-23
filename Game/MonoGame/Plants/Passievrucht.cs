using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Plants
{
    class Passievrucht : Plant
    {
        public Passievrucht(Texture2D texture) : base("Passievrucht", 1000) // 1000 secondes
        {
            this.Texture = texture;
        }
    }
}
