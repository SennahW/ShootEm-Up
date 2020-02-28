using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ShootEm_Up
{
    class TileGround : Tile
    {
        public TileGround(Texture2D aTexture, TileType aTileType, Vector2 aPosistion, float aTileID)
        {
            myTexture = aTexture;
            myTileType = aTileType;
            myPosition = aPosistion;
            myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), myTexture.Width, myTexture.Height);
            myTileID = aTileID;
        }

        public override void Update(Player aPlayer, Tile[,] aTileArray)
        {
            TileCollsion(aPlayer, aTileArray);

        }
        
        public void TileCollsion(Player aPlayer, Tile[,] aTileArray)
        {
            aPlayer.AccessGroundBool = false;

            for (int y = 0; y < aTileArray.GetLength(0); y++)
            {
                for (int x = 0; x < aTileArray.GetLength(1); x++)
                {
                    if (aTileArray[y, x].AccessTileType == TileType.Solid)
                    {

                        if (aTileArray[y, x].AccessFloat != 17f)
                        {
                            if (aPlayer.AccessRectangle.Intersects(aTileArray[y, x].AccessRectangle))
                            {

                                //aPlayer.AccessVelocity = new Vector2(aPlayer.AccessVelocity.X, 0);
                                aPlayer.AccessGroundBool = true;
                            }
                        }
                    }
                    //if (myPlayerIsGrounded == true)
                    //{
                    //    if (aPlayer.AccessRectangle.Left < aTileArray[y, x].AccessRectangle.Right && aPlayer.AccessRectangle.Right < aTileArray[y, x].AccessRectangle.Left)
                    //    {
                    //        if (tempRunOnceperUpdate == false)
                    //        {
                    //            aPlayer.AccessVelocity = new Vector2(0, -10);
                    //        }
                    //    }
                    //}
                }
            }
        }
    }
}
