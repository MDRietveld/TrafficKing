using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing
{
    public class AssetsManager
    {
        public static Texture2D Drugsboat;
        public static Texture2D Policeboat;
        public static Texture2D Drugs;
        public static Texture2D Cloud;
        public static Texture2D Shadow;
        public static Texture2D Dock;
        public static Texture2D Busted;
        public static Texture2D Star;

        public static SpriteFont Verdana;

        public AssetsManager()
        {
            Drugsboat   = Game1.Instance.Content.Load<Texture2D>("drugsboat");
            Policeboat  = Game1.Instance.Content.Load<Texture2D>("policeboat");
            Drugs       = Game1.Instance.Content.Load<Texture2D>("drugs");
            Cloud       = Game1.Instance.Content.Load<Texture2D>("cloud");
            Shadow      = Game1.Instance.Content.Load<Texture2D>("shadow");
            Dock        = Game1.Instance.Content.Load<Texture2D>("dock");
            Busted      = Game1.Instance.Content.Load<Texture2D>("busted");
            Star        = Game1.Instance.Content.Load<Texture2D>("star");
            
            Verdana     = Game1.Instance.Content.Load<SpriteFont>("Verdana");
        }
    }
}
