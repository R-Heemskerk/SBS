﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    interface IMenuOption
    {
        string GetName();

        void OnClick();
    }
}
