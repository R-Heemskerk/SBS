using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public abstract class MenuOption
    {
        protected Dirt dirt;

        protected MenuOption(Dirt dirt)
        {
            this.dirt = dirt;
        }

        public abstract string GetName();
        public abstract void OnClick();
    }
}
