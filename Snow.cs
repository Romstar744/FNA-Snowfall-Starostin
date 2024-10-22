using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FNA_Snowfall_Starostin
{
    public class Snow : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D snowflakeTexture;
        private Texture2D backgroundTexture;
        private List<Snowflake> snowflakes;

        private const int WindowHeight = 600;
        private const int WindowWidth = 800;
        private readonly Random random = new Random();

        /// <summary>
        /// Конструктор игры Snow. Инициализирует параметры графики.
        /// </summary>
        public Snow()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Инициализация игры. Можно добавить логику, если требуется.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Загрузка контента (текстуры снежинки и создание объектов снежинок).
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowflakeTexture = Content.Load<Texture2D>("snowflake");
            backgroundTexture = Content.Load<Texture2D>("background");

            snowflakes = new List<Snowflake>();

            for (var i = 0; i < 200; i++)
            {
                var size = (float)random.Next(3, 7) / 100;
                var speed = (float)random.NextDouble() * 50f + 20f;
                var startPosition = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight));

                snowflakes.Add(new Snowflake(snowflakeTexture, startPosition, speed, size));
            }
        }

        /// <summary>
        /// Обновление логики игры: обработка падения снежинок и их перерождение.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var snowflake in snowflakes)
            {
                snowflake.Fall(gameTime);

                if (snowflake.Position.Y > WindowHeight)
                {
                    snowflake.ResetPosition(new Vector2(random.Next(0, WindowWidth), -50));
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Отрисовка снежинок на экране.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, WindowWidth, WindowHeight), Color.White);

            foreach (var snowflake in snowflakes)
            {
                snowflake.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
