using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemDragonfruit : MenuItem
    {
        public MenuItemDragonfruit(Dirt dirt) : base(PlantList.Dragonfruit, dirt)
        {
        }

        public override string GetName()
        {
            return "Dragonfruit";
        }
    }
}