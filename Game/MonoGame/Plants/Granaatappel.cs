﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Plants
{
    class Granaatappel : Plant
    {
        public Granaatappel(Texture2D texture) : base(PlantList.Granaatappel, "Granaatappel", 60) // 60 secondes
        {
            this.Texture = texture;
        }
    }
}