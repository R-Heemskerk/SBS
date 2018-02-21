using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemAvocado : MenuOption
    {
        public MenuItemAvocado(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Avocado";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}

