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

        public Player()
        {
            myPosition = new Vector2(0f, 0f);
        }

        public void Update(GameTime gameTime)
        {
            Movement();
        }

        public void Movement()
        {
            
        }

        public void Shoot()
        {
        }
    }
}