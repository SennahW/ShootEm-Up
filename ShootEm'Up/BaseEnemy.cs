using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace ShootEm_Up
{
    public class BaseEnemy
    {
        int myHealth;
        int myDamage;
        Vector2 myPosition;
        Texture2D myTexture;

        public BaseEnemy(Vector2 aPositon, Texture2D aTexture, int aHealth, int aDamage)
        {
            myPosition = aPositon;
            myTexture = aTexture;
            myHealth = aHealth;
            myDamage = aDamage;
        }

        public virtual void Update(Player aPlayer)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            
        }
    }
}