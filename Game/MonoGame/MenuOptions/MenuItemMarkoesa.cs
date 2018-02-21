using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemMarkoesa : MenuItem
    {
        public MenuItemMarkoesa(Dirt dirt) : base(PlantList.Mango, dirt)
        {
        }

        public override string GetName()
        {
            return "Markoesa";
        }
    }
}
