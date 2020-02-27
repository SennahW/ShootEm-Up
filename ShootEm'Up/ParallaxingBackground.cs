using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ShootEm_Up
{
    class ParallaxingBackground : Objects
    {
        Texture2D myTexture;
        Vector2 myPosition;
        Game1 myGame1;

        public ParallaxingBackground(Texture2D aBackgroundTexture, Game1 aGame1, Vector2 aStartPosition)
        {
            myTexture = aBackgroundTexture;
            myGame1 = aGame1;
            myPosition += aStartPosition;
        }

        public void Update()
        {
            myPosition.X -= myGame1.AccessPlayer.AccessVelocity.X * 0.1f;
        } 

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
        }

        public Vector2 AccessPosition { get => myPosition; set => myPosition = value; }

    }
}
