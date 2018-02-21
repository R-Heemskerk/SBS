using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public static class PlantFactory
    {
        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();

        public static void LoadContent()
        {
            //Laad plaatjes --> textures
        }

        public static Plant GetPlant(string plantname)
        {
            Plant plant = null;
            switch (plantname)
            {
                case "Pineapple":
                    //plant = new Plant(textures[plantname]);
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
