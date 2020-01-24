using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace ShootEm_Up
{
    public enum GameState { Intro, Running, GameOver };
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GameState myGameState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player myPlayer;

        Texture2D myVideoTexture;
        Video myVideo;
        VideoPlayer myVideoPlayer;
        TileMap myTileMap;
        Texture2D myBackgroundTexture;

        Texture2D myOlafTexture;
        Texture2D myTestTile;

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
            //graphics.IsFullScreen = true;
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
            myOlafTexture = Content.Load<Texture2D>("Olaf");
            myTestTile = Content.Load<Texture2D>("Tile");
            myPlayer = new Player(myOlafTexture);
            myBackgroundTexture = Content.Load<Texture2D>("Background");
            myTileMap = new TileMap(Content.Load<Texture2D>("Tile1"), Content.Load<Texture2D>("Tile2"), Content.Load<Texture2D>("Tile3"), Content.Load<Texture2D>("Tile4"), Content.Load<Texture2D>("Tile5"), 
                Content.Load<Texture2D>("Tile6"), Content.Load<Texture2D>("Tile7"), Content.Load<Texture2D>("Tile8"), Content.Load<Texture2D>("Tile9"), Content.Load<Texture2D>("Tile10"), 
                Content.Load<Texture2D>("Tile11"), Content.Load<Texture2D>("Tile12"), Content.Load<Texture2D>("Tile13"), Content.Load<Texture2D>("Tile14"), Content.Load<Texture2D>("Tile15"), 
                Content.Load<Texture2D>("Tile16"), Content.Load<Texture2D>("Tile17"), Content.Load<Texture2D>("Tile18"));
            myTileMap.Initialize();


            myVideoPlayer.Play(myVideo);

            // TODO: use this.Content to load your game content here
            //"),  Content.Load<Texture2D>("Tile
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
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    myVideoPlayer.Stop();
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
            myPlayer.Update(gameTime, myGameState);
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
                spriteBatch.Draw(myBackgroundTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);

                myPlayer.Draw(spriteBatch);
                myTileMap.Draw(spriteBatch);

            }
            else if (myGameState == GameState.GameOver)
            {

            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
