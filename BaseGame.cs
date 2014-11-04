
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake_V2
{
    public abstract class BaseGame
    {
        protected NetworkClientManager NetworkClientManager { get; set; }        

        protected BaseGame(NetworkClientManager networkClientManager)
        {
            this.NetworkClientManager = networkClientManager;
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch, AssetsManager assets)
        {
            
        }
    }
}
