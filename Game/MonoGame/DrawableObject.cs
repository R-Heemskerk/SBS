using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    /// <summary>
    /// Een DrawableObject is een object dat op het beeldscherm kan worden getoond.
    /// </summary>
    public class DrawableObject
    {
        protected Vector2 pos;
        protected int width, height;
        protected Texture2D texture;

        /// <summary>
        /// Laad alle IO blocking content zoals plaatjes en graphics.
        /// </summary>
        /// <param name="content">ContentManager instance van MonoGame.</param>
        /// <seealso cref="ContentManager"/>
        public virtual void LoadContent(ContentManager content)
        {
        }

        /// <summary>
        /// Controlleerd of de mous op het object staat.
        /// </summary>
        /// <param name="mouse">MouseState instance van MonoGame</param>
        /// <seealso cref="MouseState"/>
        /// <returns>True als de muis op het object staat</returns>
        public bool CollidesWith(MouseState mouse)
        {
            /*
             * Muis controlle werkt via een rechthoek controller. Dit gebeurd door uiterste X en Y waardes en te controlleren of de X en Y waardes van de muis hierbinnen vallen.
             *
             * -------
             * |     |
             * |     |  <- Zijn de X en Y coördinaten binnen deze grenzen
             * |     |
             * -------
             */
            return (mouse.X > pos.X && mouse.X < pos.X + width
                                    && mouse.Y > pos.Y && mouse.Y < pos.Y + height);
        }

        /// <summary>
        /// Teken een visuele objecten.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance van MonoGame</param>
        /// <seealso cref="SpriteBatch"/>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: texture, color: Color.White,
                destinationRectangle: new Rectangle((int) pos.X, (int) pos.Y, width, height));
        }
    }
}