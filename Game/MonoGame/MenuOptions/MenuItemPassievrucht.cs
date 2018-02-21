using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemPassievrucht : MenuItem
    {
        public MenuItemPassievrucht(Dirt dirt) : base(PlantList.Passievrucht, dirt)
        {
        }

        public override string GetName()
        {
            return "Passievrucht";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}

