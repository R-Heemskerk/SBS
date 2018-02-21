using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemAnanas : MenuItem
    {
        public MenuItemAnanas(Dirt dirt) : base(PlantList.Ananas, dirt)
        {
        }

        public override string GetName()
        {
            return "Ananas";
        }
    }
}