using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FNA_Snowfall_Starostin
{
    internal class Snowflake
    {
        public Vector2 position;

        private readonly float speed;
        private readonly float size;
        private readonly Texture2D texture;

        public Snowflake(Texture2D texture, Vector2 startPosition, float speed, float size)
        {
            this.texture = texture;
            position = startPosition;
            this.speed = speed;
            this.size = size;
        }

        /// <summary>
        /// Перемещает <see cref="Snowflake"/> вниз на заданнок число <see cref="Snowflake.speed"/>
        /// </summary>
        public void Fall(GameTime gameTime)
        {
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Отрисовывает <see cref="Snowflake"/>
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);
        }
    }
}
