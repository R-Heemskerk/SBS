using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemPineapple : IMenuOption
    {
        public string GetName()
        {
            return "Ananas";
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
