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

        Input myInput;
        KeyboardState myCurrentKey;

        Rectangle myRectangle;
        Texture2D myTexture;

        public Player(Texture2D aTexture)
        {
            myTexture = aTexture;
            myPosition = new Vector2(0f, 200f);
            myInput = new Input { Jump = Keys.W, WalkLeft = Keys.A, WalkRight = Keys.D, Shoot = Keys.Space };
        }

        public void Update(GameTime gameTime, GameState aGameState, bool aGroundBool)
        {
            myGameTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (aGameState == GameState.Running)
            {
                Movement(aGroundBool);
                myPosition += myVelocity;
                myVelocity = new Vector2(0, 0);
                myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), 90, 175);
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
          //  spriteBatch.Draw(myTexture, myPosition, Color.White);
            spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Left, myRectangle.Top, 2, myRectangle.Height), Color.Black); // Left
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Right, myRectangle.Top, 2, myRectangle.Height), Color.Black); // Right
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Left, myRectangle.Top, myRectangle.Width, 2), Color.Black); // Top
            spriteBatch.Draw(myTexture, new Rectangle(myRectangle.Left, myRectangle.Bottom, myRectangle.Width, 2), Color.Black); // Bottom
        }

        public void Movement(bool aGroundBool)
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

            if (myCurrentKey.IsKeyDown(myInput.Jump) && aGroundBool == true)
            {
                myVelocity.Y -= 20f * myGameTime;
            }
            
        }

        public void Shoot()
        {
        }

        public Vector2 AccessPosition { get => myPosition; set => myPosition = value; }
        public Vector2 AccessVelocity { get => myVelocity; set => myVelocity = value; }
        public Rectangle AccessRectangle { get => myRectangle; set => myRectangle = value; }

    }
}