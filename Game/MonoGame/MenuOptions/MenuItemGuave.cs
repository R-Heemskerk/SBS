using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemGuave : MenuOption
    {
        public MenuItemGuave(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Guave";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}
