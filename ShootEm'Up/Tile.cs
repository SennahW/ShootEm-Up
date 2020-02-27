using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ShootEm_Up
{
    class Tile
    {
        Texture2D myTexture;
        TileType myTileType;
        Vector2 myPosition;
        Rectangle myRectangle;
        float myTileID;

        public Tile(Texture2D aTexture, TileType aTileType, Vector2 aPosistion, float aTileID)
        {
            myTexture = aTexture;
            myTileType = aTileType;
            myPosition = aPosistion;
            myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), myTexture.Width, myTexture.Height);
            myTileID = aTileID;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myTileType != TileType.Gas)
            {
                spriteBatch.Draw(myTexture, myPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }

        public Rectangle AccessRectangle { get => myRectangle; set => myRectangle = value; }
        public float AccessFloat { get => myTileID; set => myTileID = value; }
        public TileType AccessTileType { get => myTileType; set => myTileType = value; }
    }
}
