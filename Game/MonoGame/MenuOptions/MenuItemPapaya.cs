using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemPapaya : MenuItem
    {
        public MenuItemPapaya(Dirt dirt) : base(PlantList.Papaya, dirt)
        {
        }

        public override string GetName()
        {
            return "Papaya";
        }
    }
}

