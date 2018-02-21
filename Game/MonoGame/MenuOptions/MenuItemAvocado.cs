using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemAvocado : IMenuOption
    {
        public string GetName()
        {
            return "Avocado";
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}

