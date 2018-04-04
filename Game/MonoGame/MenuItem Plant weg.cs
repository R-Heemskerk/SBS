using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class MenuItem_Plant_weg : MenuItem
    {
        public MenuItem_Plant_weg(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Oogsten";
        }

        public override void OnClick(Main main)
        {
            if (dirt.GrowTime <= 0)
            {
                dirt.Plant = null;
            }
        }
    }
}
