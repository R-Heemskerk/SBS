using System;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Plants
{
    class Avocado : Plant
    {
        public Avocado(Texture2D texture) : base(PlantList.Avocado, "Avocado", 45) // 45 secondes
        {
            this.Texture = texture;
        }
    }
}