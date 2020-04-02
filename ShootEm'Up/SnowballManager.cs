using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ShootEm_Up
{
    static class SnowballManager
    {
        static List<Snowball> mySnowballList = new List<Snowball>();
        static Texture2D mySnowballTexture;

        public static void Update()
        {
            for (int i = 0; i < mySnowballList.Count; i++)
            {
                mySnowballList[i].Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < mySnowballList.Count; i++)
            {
                mySnowballList[i].Draw(spriteBatch);
            }
        }

        public static void AddSnowball(Snowball aSnowball)
        {
            mySnowballList.Add(aSnowball);
        }

        public static void RemoveSnowball(int anID)
        {
            mySnowballList.RemoveAt(anID);
        }

        public static Texture2D AccessSnowballtexture { get => mySnowballTexture; set => mySnowballTexture = value; }
        public static List<Snowball> AccessSnowballList { get => mySnowballList; set => mySnowballList = value; }
    }
}
