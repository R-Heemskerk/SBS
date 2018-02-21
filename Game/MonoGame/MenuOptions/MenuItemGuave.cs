using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemGuave : IMenuOption
    {
        public string GetName()
        {
            return "Guave";
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
