using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace ShootEm_Up
{
    public enum GameState { Intro, Running, GameOver };
    public enum Level { One, Two, Three };
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GameState myGameState;
        Level myLevel = Level.One;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera myCamera;

        Player myPlayer;

        Texture2D myVideoTexture;
        Video myVideo;
        VideoPlayer myVideoPlayer;

        TileMap myTileMap;
        Texture2D myBackgroundTexture;
        List<ParallaxingBackground> myBackgroundList;
        Collisions myCollisions;

        Texture2D myOlafTexture;

        public Player AccessPlayer { get => myPlayer; set => myPlayer = value; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            myCamera = new Camera();
            myGameState = GameState.Intro;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myVideo = Content.Load<Video>("OlafNose");
            myVideoPlayer = new VideoPlayer();
            myOlafTexture = Content.Load<Texture2D>("Olaf");
            myPlayer = new Player(myOlafTexture);
            myTileMap = new TileMap(Content.Load<Texture2D>("Tile1"), Content.Load<Texture2D>("Tile2"), Content.Load<Texture2D>("Tile3"), Content.Load<Texture2D>("Tile4"), Content.Load<Texture2D>("Tile5"),
                Content.Load<Texture2D>("Tile6"), Content.Load<Texture2D>("Tile7"), Content.Load<Texture2D>("Tile8"), Content.Load<Texture2D>("Tile9"), Content.Load<Texture2D>("Tile10"),
                Content.Load<Texture2D>("Tile11"), Content.Load<Texture2D>("Tile12"), Content.Load<Texture2D>("Tile13"), Content.Load<Texture2D>("Tile14"), Content.Load<Texture2D>("Tile15"),
                Content.Load<Texture2D>("Tile16"), Content.Load<Texture2D>("Tile17"), Content.Load<Texture2D>("Tile18"));
            myTileMap.Initialize();
            myBackgroundTexture = Content.Load<Texture2D>("Background");
            myBackgroundList = new List<ParallaxingBackground>();
            myBackgroundList.Add(new ParallaxingBackground(myBackgroundTexture, this, new Vector2(0, 0)));
            myCollisions = new Collisions();

            myVideoPlayer.Play(myVideo);

            //"),  Content.Load<Texture2D>("Tile
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                myLevel = Level.Two;
            }

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
                CheckBackground();
                myPlayer.Update(gameTime, myGameState, myCollisions.AccessGroundBool);

                myTileMap.Update(myPlayer, myLevel);

                for (int i = 0; i < myBackgroundList.Count; i++)
                {
                    myBackgroundList[i].Update();
                }
            }
            else if (myGameState == GameState.GameOver)
            {

            }

            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (myGameState == GameState.Intro)
            {
                spriteBatch.Begin();
                GraphicsDevice.Clear(Color.CornflowerBlue);

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
                spriteBatch.Begin(transformMatrix: myCamera.myTransform);
                GraphicsDevice.Clear(Color.CornflowerBlue);

                myCamera.Update(myPlayer.AccessPosition, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
                for (int i = 0; i < myBackgroundList.Count; i++)
                {
                    myBackgroundList[i].Draw(spriteBatch);
                }

                myTileMap.Draw(spriteBatch, myLevel);
                myPlayer.Draw(spriteBatch);

            }
            else if (myGameState == GameState.GameOver)
            {
                spriteBatch.Begin();
                GraphicsDevice.Clear(Color.CornflowerBlue);

            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void CheckBackground()
        {
            if (myPlayer.AccessPosition.X + GraphicsDevice.DisplayMode.Width / 2 > myBackgroundList[myBackgroundList.Count - 1].AccessPosition.X)
            {
                myBackgroundList.Add(new ParallaxingBackground(myBackgroundTexture, this, new Vector2(myBackgroundList[myBackgroundList.Count - 1].AccessPosition.X + myBackgroundTexture.Width * 1.5f, 0)));
            }
        }
    }
}
