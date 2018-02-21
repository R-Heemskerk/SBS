using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemLychees : IMenuOption
    {
        public string GetName()
        {
            return "Lychees";
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}

