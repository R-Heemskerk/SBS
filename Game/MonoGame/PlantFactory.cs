using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Plants;

namespace MonoGame
{
    /// <summary>
    /// Een lijst van planten.
    /// </summary>
    public enum PlantList
    {
//        Plantzaadjes,
//        Plantje,
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

    /// <summary>
    /// De PlantFactory geeft graphics en instellingen over planten.
    /// </summary>
    public static class PlantFactory
    {
        public static List<PlantList> Plants { get; private set; }
        private static readonly Dictionary<PlantList, Texture2D> textures = new Dictionary<PlantList, Texture2D>();
        private static readonly Dictionary<PlantList, int> costPrice = new Dictionary<PlantList, int>();
        private static readonly Dictionary<PlantList, int> sellPrice = new Dictionary<PlantList, int>();

        /// <summary>
        /// Laad alle objecten.
        /// </summary>
        /// <param name="content">ContentManager instance van MonoGame</param>
        /// <seealso cref="ContentManager"/>
        public static void LoadContent(ContentManager content)
        {
            Plants = new List<PlantList>
            {
                PlantList.Ananas,
                PlantList.Avocado,
                PlantList.Dragonfruit,
                PlantList.Guave,
                PlantList.Lychees,
                PlantList.Granaatappel,
                PlantList.Mango,
                PlantList.Markoesa,
                PlantList.Papaya,
                PlantList.Passievrucht
            };

            //            textures.Add(PlantList.Plantzaadjes, content.Load<Texture2D>("Images/plantzaadjes"));
            //            textures.Add(PlantList.Plantje, content.Load<Texture2D>("Images/plantje")); 
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

            costPrice.Add(PlantList.Ananas, 1);
            costPrice.Add(PlantList.Avocado, 2);
            costPrice.Add(PlantList.Dragonfruit, 5);
            costPrice.Add(PlantList.Granaatappel, 4);
            costPrice.Add(PlantList.Guave, 4);
            costPrice.Add(PlantList.Lychees, 5);
            costPrice.Add(PlantList.Mango, 3);
            costPrice.Add(PlantList.Markoesa, 5);
            costPrice.Add(PlantList.Papaya, 3);
            costPrice.Add(PlantList.Passievrucht, 4);

            sellPrice.Add(PlantList.Ananas, 4);
            sellPrice.Add(PlantList.Avocado, 5);
            sellPrice.Add(PlantList.Dragonfruit, 10);
            sellPrice.Add(PlantList.Granaatappel, 7);
            sellPrice.Add(PlantList.Guave, 8);
            sellPrice.Add(PlantList.Lychees, 9);
            sellPrice.Add(PlantList.Mango, 6);
            sellPrice.Add(PlantList.Markoesa, 10);
            sellPrice.Add(PlantList.Papaya, 7);
            sellPrice.Add(PlantList.Passievrucht, 6);
        }

        /// <summary>
        /// Krijg de Plant object.
        /// </summary>
        /// <param name="plant">De plant waar het over gaat.</param>
        /// <returns><see cref="Plant"/></returns>
        public static Plant GetPlant(PlantList plant)
        {
            switch (plant)
            {
                case PlantList.Ananas:
                    return new Ananas(textures[PlantList.Ananas]);

                case PlantList.Mango:
                    return new Mango(textures[PlantList.Mango]);

                case PlantList.Markoesa:
                    return new Markoesa(textures[PlantList.Markoesa]);

                case PlantList.Papaya:
                    return new Papaya(textures[PlantList.Papaya]);

                case PlantList.Passievrucht:
                    return new Passievrucht(textures[PlantList.Passievrucht]);

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

                default:
                    return null;
            }
        }

        /// <summary>
        /// Hoeveel kost het om een zaadje te kopen.
        /// </summary>
        /// <param name="plant">De plant</param>
        /// <seealso cref="PlantList"/>
        /// <returns>Prijs</returns>
        public static int GetCostPrice(PlantList plant)
        {
            return costPrice.ContainsKey(plant) ? costPrice[plant] : -1;
        }

        /// <summary>
        /// Hoeveel kan er worden verdiend als een vrucht wordt verkocht.
        /// </summary>
        /// <param name="plant">De plant</param>
        /// <seealso cref="PlantList"/>
        /// <returns>Prijs</returns>
        public static int GetSellPrice(PlantList plant)
        {
            return sellPrice.ContainsKey(plant) ? sellPrice[plant] : -1;
        }
    }
}
