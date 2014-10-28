using Lidgren.Network;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Server
{
    public class GameServer
    {
        public NetworkServerManager ServerManager { get; set; }
        private List<NetConnection> ClientConnections { get; set; }
        private Thread GameThread { get; set; }

        public GameServer(NetworkServerManager serverManager, List<NetConnection> clientConnections)
        {
            this.ServerManager = serverManager;
            this.ClientConnections = clientConnections;
            GameThread = new Thread(this.Run);
        }

        public void Run()
        {
            var gameTime = new GameTime();
            var lastupdate = DateTime.Now;

            // Main loop
            while (true)
            {
                // Calculate elapsedGameTime
                gameTime.ElapsedGameTime = DateTime.Now - lastupdate;

                // Update game
                this.Update(gameTime);

                // Set latest update to now
                lastupdate = DateTime.Now;

                Thread.Sleep(30);
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
