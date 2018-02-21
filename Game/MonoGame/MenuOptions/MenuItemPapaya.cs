using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemPapaya : MenuOption
    {
        public MenuItemPapaya(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Papaya";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}

