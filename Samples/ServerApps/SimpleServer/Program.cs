using System;
using System.Threading;
using ENet;

namespace SimpleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Library.Initialize();
            Console.WriteLine("Simple Server");

            using (var host = new Host())
            {
                host.Create(5000, 1);
                var peer = new Peer();

                while (host.Service(1) >= 0)
                {
                    Event @event;

                    while (host.CheckEvents(out @event) > 0)
                    {
                        switch (@event.Type)
                        {
                            case EventType.Connect:
                                peer = @event.Peer;
                                for (var i = 0; i < 200; i++)
                                {
                                    peer.Send((byte)i, new byte[] { 0, 0 });
                                }
                                break;

                            case EventType.Receive:
                                var data = @event.Packet.GetBytes();
                                var value = BitConverter.ToUInt16(data, 0);
                                if (value % 1000 == 1)
                                {
                                    Console.WriteLine("  Server: Ch={0} Recv={1}", @event.ChannelID, value);
                                }
                                value++;
                                peer.Send(@event.ChannelID, BitConverter.GetBytes(value));
                                @event.Packet.Dispose();
                                break;
                        }
                    }
                }
            }
        }
    }
}
