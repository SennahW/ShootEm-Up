using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootEm_Up
{
    class Snowball
    {
        Texture2D myTexture;
        Vector2 myPosition;
        bool myDirection;
        Rectangle myRectangle;

        public Snowball(bool aDirection, Vector2 aStartPosition)
        {
            myDirection = aDirection;
            myPosition = aStartPosition;
            myTexture = SnowballManager.AccessSnowballtexture; 
        } 

        public void Update()
        {
            if (myDirection)
            {
                myPosition.X = myPosition.X + 3;
            }
            else
            {
                myPosition.X = myPosition.Y- 3;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
        }
    }
}
