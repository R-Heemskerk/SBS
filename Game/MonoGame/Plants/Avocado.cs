using System;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Plants
{
    class Avocado : Plant
    {
        public Avocado(Texture2D texture) : base("Avocado", 1000) // 1000 secondes
        {
            this.Texture = texture;
        }
    }
}