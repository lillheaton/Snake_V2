using Definitions.EventArguments;
using Lidgren.Network;
using System.Collections.Generic;


namespace Server
{
    class Server
    {
        private static NetworkServerManager ServerManager { get; set; }
        private static List<NetConnection> ClientConnections { get; set; }
        private static GameServer GameServer { get; set; }

        static void Main(string[] args)
        {
            ServerManager.Connect();
            ServerManager.NewConnection += ServerNewConnection;
        }

        static void TryStartGame()
        {
            if (ClientConnections.Count > 1)
            {
                GameServer = new GameServer(ServerManager, ClientConnections);
            }
        }

        static void ServerNewConnection(object sender, ConnectionEventArgs e)
        {
            ClientConnections.Add(e.NetConnection);
            TryStartGame();
        }
    }
}
