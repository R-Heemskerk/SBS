using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    class MenuManager : DrawableObject
    {
        private bool active = false;

        public void Update()
        {
            //check voor collisie / klikken van opties(=zaadjes planten, water geven en grond bemesten) 
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {

            }
        }
    }
}