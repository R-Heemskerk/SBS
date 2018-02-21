using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemLychees : MenuOption
    {
        public MenuItemLychees(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Lychees";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}

