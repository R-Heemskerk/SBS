using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemAnanas : MenuOption
    {
        public MenuItemAnanas(Dirt dirt) : base(dirt)
        {
        }

        public override string GetName()
        {
            return "Ananas";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}