using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ShootEm_Up
{
    public class Player
    {
        float myHealth;
        Vector2 myPosition;
        Texture2D myTexture;

        public Player(Texture2D aTexture)
        {
            myTexture = aTexture;
            myPosition = new Vector2(0f, 0f);
        }

        public void Update(GameTime gameTime)
        {
            Movement();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myPosition, null, Color.White);
        }
        
        public void Movement()
        {
            
        }

        public void Shoot()
        {
            throw new System.NotImplementedException();
        }
    }
}