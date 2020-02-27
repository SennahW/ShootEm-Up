using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ShootEm_Up
{
    class TileSolid : Tile
    {
        public TileSolid(Texture2D aTexture, TileType aTileType, Vector2 aPosistion, float aTileID)
        {
            myTexture = aTexture;
            myTileType = aTileType;
            myPosition = aPosistion;
            myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), myTexture.Width, myTexture.Height);
            myTileID = aTileID;
        }

        bool myPlayerIsGrounded = false;
        public void Update(GameTime gameTime, Player aPlayer, Tile[,] aTileArray)
        {

        }
    }
}