﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public abstract class MenuItem
    {
        protected PlantList plant;
        protected Dirt dirt;

        protected MenuItem(PlantList plant, Dirt dirt)
        {
            this.plant = plant;
            this.dirt = dirt;
        }

        public abstract string GetName();

        public void OnClick()
        {
            dirt.Plant = PlantFactory.GetPlant(plant);
        }
    }
}
