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
            myRectangle = new Rectangle(new Point((int)myPosition.X, (int)myPosition.Y), new Point(myTexture.Width, myTexture.Height));
        } 

        public void Update()
        {
            myRectangle = new Rectangle(new Point((int)myPosition.X, (int)myPosition.Y), new Point(myTexture.Width, myTexture.Height));
            if (myDirection)
            {
                myPosition.X = myPosition.X + 25;
            }
            else
            {
                myPosition.X = myPosition.X - 25;
            }
            myPosition.Y = myPosition.Y + 1f;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
        }

        public Rectangle AccessSnowballRectangle { get => myRectangle; set => myRectangle = value; }

    }
}
