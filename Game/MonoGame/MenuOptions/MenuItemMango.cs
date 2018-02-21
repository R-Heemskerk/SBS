using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemMango : IMenuOption
    {
        private Dirt dirt;

        public MenuItemMango(Dirt dirt)
        {
            this.dirt = dirt;
        }

        public string GetName()
        {
            return "Mango";
        }

        public void OnClick()
        {
            dirt.SetPlant(this);
        }
    }
}
