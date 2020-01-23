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

        public Tile (Texture2D aTexture, TileType aTileType)
        {
            myTexture = aTexture;
            myTileType = aTileType;
        }


    }
}
