using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FNA_Snowfall_Starostin
{
    internal class Snowflake
    {
        public Vector2 Position { get; private set; }
        private readonly float speed;
        private readonly float size;
        private readonly Texture2D texture;

        /// <summary>
        /// Конструктор снежинки. Инициализирует текстуру, позицию, скорость и размер.
        /// </summary>
        public Snowflake(Texture2D texture, Vector2 startPosition, float speed, float size)
        {
            this.texture = texture;
            Position = startPosition;
            this.speed = speed;
            this.size = size;
        }

        /// <summary>
        /// Обновляет положение снежинки, перемещая её вниз.
        /// </summary>
        public void Fall(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y + speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        /// Сбрасывает позицию снежинки на указанное значение.
        /// </summary>
        public void ResetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        /// <summary>
        /// Отрисовывает снежинку на экране.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);
        }
    }
}
