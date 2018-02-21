using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemDragonfruit : MenuOption
    {
        public MenuItemDragonfruit(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Dragonfruit";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}