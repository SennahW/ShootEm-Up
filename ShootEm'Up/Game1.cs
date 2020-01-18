using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace ShootEm_Up
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum GameState { Intro, Running, GameOver};

        GameState myGameState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player myPlayer;

        Texture2D myVideoTexture;
        Video myVideo;
        VideoPlayer myVideoPlayer;


        bool tempRanVideo;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            myGameState = GameState.Intro;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myVideo = Content.Load<Video>("OlafNose");
            myVideoPlayer = new VideoPlayer();
            myPlayer = new Player(Content.Load<Texture2D>("Test"));

            myVideoPlayer.Play(myVideo);
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (myGameState == GameState.Intro)
            {
                if (myVideoPlayer.State == MediaState.Stopped)
                {
                    myGameState = GameState.Running;
                }
            }
            else if (myGameState == GameState.Running)
            {

            }
            else if (myGameState == GameState.GameOver)
            {

            }


            // TODO: Add your update logic here
            myPlayer.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);


            if (myGameState == GameState.Intro)
            {
                if (myVideoPlayer.State != MediaState.Stopped)
                {
                    myVideoTexture = myVideoPlayer.GetTexture();
                }

                if (myVideoTexture != null)
                {
                    spriteBatch.Draw(myVideoTexture, GraphicsDevice.Viewport.Bounds, Color.White);
                }
            }
            else if (myGameState == GameState.Running)
            {
                myPlayer.Draw(spriteBatch);
            }
            else if (myGameState == GameState.GameOver)
            {

            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
