using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ShootEm_Up
{
    public class Player : Object
    {
        float myHealth;

        Vector2 myPosition;
        Vector2 myVelocity;
        float myGameTime;
        float myAmmountJumpFrames;
        bool myJumpInProgress = false;

        Input myInput;
        KeyboardState myCurrentKey;

        Rectangle myOlafRectangle;
        Texture2D myTexture;

        public Player(Texture2D aTexture)
        {
            myTexture = aTexture;
            myPosition = new Vector2(0f, 0f);
            myInput = new Input { Jump = Keys.W, WalkLeft = Keys.A, WalkRight = Keys.D, Shoot = Keys.Space };
        }

        public void Update(GameTime gameTime, GameState aGameState)
        {
            myGameTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (aGameState == GameState.Running)
            {
                Movement();
                myPosition += myVelocity;
                myVelocity = new Vector2(0, 0);
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
          //  spriteBatch.Draw(myTexture, myPosition, Color.White);
            spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

        public void Movement()
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

            if (myCurrentKey.IsKeyDown(myInput.Jump) && myJumpInProgress != true)
            {
                myVelocity.Y -= 2f * myGameTime;
                myJumpInProgress = true;
                myAmmountJumpFrames = 0;
            }
            else if (myJumpInProgress)
            {
                switch (myAmmountJumpFrames)
                {
                    case 1:
                        myVelocity.Y -= 1.3f * myGameTime;
                        break;
                    case 2:
                        myVelocity.Y -= 1.0f * myGameTime;
                        break;
                    case 3:
                        myVelocity.Y -= 0.8f * myGameTime;
                        break;
                    case 6:
                        myJumpInProgress = false;
                        break;
                }
                myAmmountJumpFrames++;
            }
            else 
            {
                myVelocity.Y += 1f * myGameTime;
            }
        }

        public void Shoot()
        {
        }
    }
}