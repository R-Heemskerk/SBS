using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Plants;

namespace MonoGame
{
    public enum PlantList
    {
        Ananas,
        Avocado,
        Dragonfruit,
        Guave,
        Lychees,
        Granaatappel,
        Mango,
        Markoesa,
        Papaya,
        Passievrucht
    }

    public static class PlantFactory
    {
        private static readonly Dictionary<PlantList, Texture2D> textures = new Dictionary<PlantList, Texture2D>();

        public static void LoadContent(ContentManager content)
        {
            textures.Add(PlantList.Ananas, content.Load<Texture2D>("Images/ananas"));
            textures.Add(PlantList.Avocado, content.Load<Texture2D>("Images/avocado"));
            textures.Add(PlantList.Dragonfruit, content.Load<Texture2D>("Images/dragonfruit"));
            textures.Add(PlantList.Guave, content.Load<Texture2D>("Images/guave"));
            textures.Add(PlantList.Lychees, content.Load<Texture2D>("Images/lychees"));
            textures.Add(PlantList.Granaatappel, content.Load<Texture2D>("Images/granaatappel"));
            textures.Add(PlantList.Mango, content.Load<Texture2D>("Images/mango"));
            textures.Add(PlantList.Markoesa, content.Load<Texture2D>("Images/Markoesa"));
            textures.Add(PlantList.Papaya, content.Load<Texture2D>("Images/papaya"));
            textures.Add(PlantList.Passievrucht, content.Load<Texture2D>("Images/passievrucht"));
        }

        public static Plant GetPlant(PlantList plant)
        {
            switch (plant)
            {
                case PlantList.Ananas:
                    return new Ananas(textures[PlantList.Ananas]);

                case PlantList.Avocado:
                    return new Avocado(textures[PlantList.Avocado]);

                case PlantList.Dragonfruit:
                    return new Dragonfruit(textures[PlantList.Dragonfruit]);

                case PlantList.Guave:
                    return new Guave(textures[PlantList.Guave]);

                case PlantList.Lychees:
                    return new Lychees(textures[PlantList.Lychees]);

                case PlantList.Granaatappel:
                    return new Granaatappel(textures[PlantList.Granaatappel]);

                //TODO: Doe dit ook voor alle andere vruchten

                default:
                    return null;
            }
        }
    }
}
