using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ShootEm_Up
{
    class TileAir : Tile
    {
        public TileAir(Texture2D aTexture, TileType aTileType, Vector2 aPosistion, float aTileID)
        {
            myTexture = aTexture;
            myTileType = aTileType;
            myPosition = aPosistion;
            myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), myTexture.Width, myTexture.Height);
            myTileID = aTileID;
        }

        bool myPlayerIsGrounded = false;
        public void Update(Player aPlayer, Tile[,] aTileArray)
        {
        }
        public bool AccessGroundBool { get => myPlayerIsGrounded; set => myPlayerIsGrounded = value; }
    }
}
