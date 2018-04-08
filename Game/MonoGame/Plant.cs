using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    /// <summary>
    /// Plant object.
    /// </summary>
    public abstract class Plant
    {
        public PlantList PlantList { get; }
        public string Name { get; }
        public int GrowTime { get; }
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Constructor voor de Plant.
        /// </summary>
        /// <param name="plantList">De plant waar het over gaat.</param>
        /// <param name="name">De naam van de plant.</param>
        /// <param name="growTime">Hoe lang het duurt voordat de plant is volgroeid in secondes.</param>
        /// <seealso cref="PlantList"/>
        protected Plant(PlantList plantList, string name, int growTime)
        {
            this.PlantList = plantList;
            this.Name = name;
            this.GrowTime = growTime * 1000;
        }
    }
}