using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemMarkoesa : MenuOption
    {
        public MenuItemMarkoesa(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Markoesa";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}
