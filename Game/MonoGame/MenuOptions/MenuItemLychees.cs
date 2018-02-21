using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemLychees : MenuItem
    {
        public MenuItemLychees(Dirt dirt) : base(PlantList.Lychees, dirt)
        {
        }

        public override string GetName()
        {
            return "Lychees";
        }
    }
}

