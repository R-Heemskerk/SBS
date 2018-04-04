using System;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Plants
{
    class Dragonfruit : Plant
    {
        public Dragonfruit(Texture2D texture) : base(PlantList.Dragonfruit, "Dragonfruit", 90) // 90 secondes
        {
            this.Texture = texture;
        }
    }
}
