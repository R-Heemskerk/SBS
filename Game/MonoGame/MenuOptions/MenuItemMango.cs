using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemMango : IMenuOption
    {
        public string GetName()
        {
            return "Mango";
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
