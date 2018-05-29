using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DarkRift;
using DarkRift.Server;

namespace ServerPlugins
{
    public delegate void MessageHandler(IClient client, Message message);

    public abstract class ServerPluginBase : Plugin
    {
        public override bool ThreadSafe => true;
        public override Version Version => new Version(1, 0, 0);

        private readonly Dictionary<ushort, MessageHandler> handlers;

        protected ServerPluginBase(PluginLoadData pluginLoadData) : base(pluginLoadData)
        {
            handlers = new Dictionary<ushort, MessageHandler>();
            ClientManager.ClientConnected += OnClientConnected;
        }

        protected virtual void OnClientConnected(object sender, ClientConnectedEventArgs e)
        {
            e.Client.MessageReceived += OnMessagereceived;
        }

        private void OnMessagereceived(object sender, MessageReceivedEventArgs e)
        {
            var message = e.GetMessage();

            if (message != null)
            {
                WriteEvent("Received message with tag " + message.Tag, LogType.Trace);
                if (handlers.ContainsKey(message.Tag))
                {
                    handlers[message.Tag](e.Client, message);
                }
            }
            else
            {

                WriteEvent("Received message null", LogType.Trace);
            }
        }

        protected void SetHandler(ushort tag, MessageHandler handler)
        {
            handlers[tag] = handler;
        }
    }
}
