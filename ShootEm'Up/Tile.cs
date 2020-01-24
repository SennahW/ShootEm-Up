using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace ShootEm_Up
{
    class Tile
    {
        Texture2D myTexture;
        TileType myTileType;
        Vector2 myPosition;

        public Tile (Texture2D aTexture, TileType aTileType, Vector2 aPosistion)
        {
            myTexture = aTexture;
            myTileType = aTileType;
            myPosition = aPosistion;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myTileType != TileType.Gas)
            {
                spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
