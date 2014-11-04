using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Snake_V2
{
    public class AssetsManager
    {
        private ContentManager contentManager;
        public Dictionary<string, SpriteFont> FontDictionary;

        public AssetsManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            this.Init();
        }

        public void Init()
        {
            FontDictionary = new Dictionary<string, SpriteFont>();
            FontDictionary.Add("MyFont", contentManager.Load<SpriteFont>("Fonts/MyFont"));
        }
    }
}