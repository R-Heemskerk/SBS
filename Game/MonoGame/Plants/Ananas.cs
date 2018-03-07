using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Plants
{
    class Ananas : Plant
    {
        public Ananas(Texture2D texture) : base("Ananas", 1000 * 30) // 1000 milisecondes x 30 = 30 sec
        {
            this.Texture = texture;
        }
    }
}
