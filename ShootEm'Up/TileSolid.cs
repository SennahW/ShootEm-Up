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

        public override void Update(Player aPlayer, Tile[,] aTileArray)
        {
            TileCollision(aPlayer, aTileArray);
        }

        public void TileCollision(Player aPlayer, Tile[,] aTileArray)
        {
            if (myTileType == TileType.Solid)
            {
                if (myTileID != 17f)
                {
                myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), 90, 175);
                    if (new Rectangle(Convert.ToInt32(aPlayer.AccessPosition.X) + Convert.ToInt32(aPlayer.AccessVelocity.X), Convert.ToInt32(aPlayer.AccessPosition.Y), aPlayer.AccessRectangle.Width,aPlayer.AccessRectangle.Height).Intersects(myRectangle))
                    {
                        aPlayer.AccessVelocity = new Vector2(0, aPlayer.AccessVelocity.Y);  
                    }
                }
            }
        }
    }
}