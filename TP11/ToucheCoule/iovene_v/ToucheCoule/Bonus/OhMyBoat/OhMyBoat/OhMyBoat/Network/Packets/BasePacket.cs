using OhMyBoat.IO;

namespace OhMyBoat.Network.Packets
{
    public abstract class BasePacket
    {
        public delegate void CallBackMethod(Events.NetworkEvent eEvent);

        public CallBackMethod EventCallBackMethod { get; private set; }

        public abstract byte OpCode { get; }

        public abstract void Unpack(Client client, Packet packet);

        public abstract void Pack(Client client, object data);

        public void SetEventCallBack(CallBackMethod callBackMethod)
        {
            EventCallBackMethod = callBackMethod;
        }
    }
}
