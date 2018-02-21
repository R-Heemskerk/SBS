using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemGuave : MenuItem
    {
        public MenuItemGuave(Dirt dirt) : base(PlantList.Guave, dirt)
        {
        }

        public override string GetName()
        {
            return "Guave";
        }
    }
}
