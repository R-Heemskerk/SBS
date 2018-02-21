using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemPineapple : MenuOption
    {
        private Dirt dirt;

        public MenuItemPineapple(Dirt dirt) : base(dirt)
        {
            this.dirt = dirt;
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }


        public override void OnClick()
        {
            //            dirt.SetPlant(this);
        }
    }
}
