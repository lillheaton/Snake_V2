using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Definitions.NetworkPackages;

using Lidgren.Network;

namespace Server
{
    public class Player
    {
        public GameServer Game { get; set; }
        public NetConnection NetConnection { get; set; }

        public Player(GameServer game, NetConnection netConnection)
        {
            this.NetConnection = netConnection;
            this.Game = game;
        }

        public void SendPackage(IBasePackage package)
        {
            Game.ServerManager.Send(NetConnection, package);
        }
    }
}
