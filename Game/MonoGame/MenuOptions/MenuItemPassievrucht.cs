using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemPassievrucht : IMenuOption
    {
        public string GetName()
        {
            return "Passievrucht";
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}

