using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace ShootEm_Up
{
    class Tile
    {
        protected Texture2D myTexture;
        protected TileType myTileType;
        protected Vector2 myPosition;
        protected Rectangle myRectangle;
        protected float myTileID;

        public virtual void Update(Player aPlayer, Tile[,] aTileArray)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
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
