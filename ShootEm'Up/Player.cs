using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace ShootEm_Up
{
    public class Player : Object
    {
        float myHealth;

        Vector2 myPosition;
        Vector2 myVelocity;
        float myGameTime;
        float myJumpStartY;
        bool myJumpingFlag;
        bool myGroundFlag;
        bool mySideColFlag;

        float vi = 5;
        float t = 100; // vi - initial velocity | t - time

        Input myInput;
        KeyboardState myCurrentKey;

        Rectangle myRectangle;
        Rectangle myOldRectangle;
        Texture2D myTexture;

        public Player(Texture2D aTexture)
        {
            myTexture = aTexture;
            myPosition = new Vector2(0f, 200f);
            myInput = new Input { Jump = Keys.W, WalkLeft = Keys.A, WalkRight = Keys.D, Shoot = Keys.Space };
        }

        public void Update(GameTime gameTime, GameState aGameState)
        {
            myGameTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (aGameState == GameState.Running)
            {
                myVelocity = new Vector2(0, 0);
                Movement(gameTime);
                myPosition += myVelocity;
                myOldRectangle = myRectangle;
                myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), 90, 175);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //  spriteBatch.Draw(myTexture, myPosition, Color.White);
            spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Left, myRectangle.Top, 2, myRectangle.Height), Color.Black); // Left
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Right, myRectangle.Top, 2, myRectangle.Height), Color.Black); // Right
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Left, myRectangle.Top, myRectangle.Width, 2), Color.Black); // Top
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Left, myRectangle.Bottom, myRectangle.Width, 2), Color.Black); // Bottom
        }

        public void Movement(GameTime gameTime)
        {
            myCurrentKey = Keyboard.GetState();
            if (myCurrentKey.IsKeyDown(myInput.WalkRight))
            {
                myVelocity.X += 1f * myGameTime;
            }
            else if (myCurrentKey.IsKeyDown(myInput.WalkLeft))
            {
                myVelocity.X -= 1f * myGameTime;
            }

            if (myCurrentKey.IsKeyDown(myInput.Jump) && myGroundFlag == true && myJumpingFlag == false)
            {
                myJumpingFlag = true;
                myJumpStartY = myPosition.Y;
            }

            if (myJumpingFlag == true)
            {
                myVelocity.Y -= 200;
                myJumpingFlag = false;
                
            }

            if (myGroundFlag == false)
            {
                myVelocity += new Vector2(0, 4);
            }

            if (mySideColFlag)
            {
                myVelocity.X = 0;
                mySideColFlag = false;
            }

        }

        public void Shoot()
        {

        }


        public Vector2 AccessPosition { get => myPosition; set => myPosition = value; }
        public Vector2 AccessVelocity { get => myVelocity; set => myVelocity = value; }
        public Rectangle AccessRectangle { get => myRectangle; set => myRectangle = value; }
        public Rectangle AccessOldRectangle { get => myOldRectangle; set => myOldRectangle = value; }
        public bool AccessGroundBool { get => myGroundFlag; set => myGroundFlag = value; }
        public bool AccessSideColBool { get => mySideColFlag; set => mySideColFlag = value; }
    }
}