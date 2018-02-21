using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemPineapple : IMenuOption
    {
        private Dirt dirt;

        public MenuItemPineapple(Dirt dirt)
        {
            this.dirt = dirt;
        }

        public string GetName()
        {
            return "Ananas";
        }

        public void OnClick()
        {
            dirt.SetPlant(this);
        }
    }
}
