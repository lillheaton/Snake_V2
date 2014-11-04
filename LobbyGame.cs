using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake_V2
{
    public class LobbyGame : BaseGame
    {
        public LobbyGame(NetworkClientManager networkClientManager) : base(networkClientManager)
        {
            this.NetworkClientManager.ConnectionApprove += this.NetworkClientManagerConnectionApprove;
        }

        private void NetworkClientManagerConnectionApprove(object sender, EventArgs e)
        {
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, AssetsManager assets)
        {
            spriteBatch.DrawString(assets.FontDictionary["MyFont"], this.NetworkClientManager.ConnectionStatus.ToString(), new Vector2(10,10), Color.Red);
            base.Draw(spriteBatch, assets);
        }
    }
}
