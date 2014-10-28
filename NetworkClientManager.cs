using Definitions.EventArguments;
using Definitions.NetworkPackages;
using Lidgren.Network;
using Snake.Definitions;
using System;
using System.Threading;

namespace Snake_V2
{
    public class NetworkClientManager
    {
        private NetClient Client { get; set; }
        private NetPeerConfiguration Config { get; set; }
        private NetIncomingMessage IncomingPackage { get; set; }
        private Thread ListenThread { get; set; }

        public bool IsConnected { get; private set; }
        public event EventHandler<PackageEventArgs> IncomingDataPackage;


        public NetworkClientManager()
        {
            this.Config = new NetPeerConfiguration("SnakeGame");
            this.Config.Port = 14243;

            this.Client = new NetClient(this.Config);
            this.Client.Start();

            this.ListenThread = new Thread(this.Listen);
        }

        public void Connect()
        {
            this.Client.Connect("localhost", 14242);
            this.ListenThread.Start();
        }

        public void Disconnect()
        {
            this.Client.Disconnect("Bye");
            this.ListenThread.Abort();
        }

        public void Listen()
        {
            while (true)
            {
                while ((this.IncomingPackage = this.Client.ReadMessage()) != null && this.ListenThread.IsAlive)
                {
                    switch (this.IncomingPackage.MessageType)
                    {
                        case NetIncomingMessageType.ConnectionApproval:
                            break;

                        case NetIncomingMessageType.Data:
                            this.ManageIncomingData(this.IncomingPackage);
                            break;
                    }
                }
            }
        }

        public void Send(IBasePackage package)
        {
            this.Client.SendMessage(package.Encrypt(this.Client), NetDeliveryMethod.ReliableOrdered);
        }

        public void ManageIncomingData(NetIncomingMessage dataPackage)
        {
            switch (dataPackage.PeekByte())
            {
                case (byte)PackageType.Handshake:
                    this.IsConnected = true;
                    break;

                default:
                    this.OnIncomingDataPackage(dataPackage);
                    break;
            }
        }

        protected virtual void OnIncomingDataPackage(NetIncomingMessage dataPackage)
        {
            var handler = this.IncomingDataPackage;
            if (handler != null)
            {
                handler(this, new PackageEventArgs(dataPackage));
            }
        }
    }
}
