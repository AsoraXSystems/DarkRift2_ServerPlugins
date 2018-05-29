using DarkRift;

namespace Utilities.Packets
{
    public class RoomAccessValidatePacket : IDarkRiftSerializable
    {
        public int RoomID;
        public string Token;
        public int ClientID;


        public void Deserialize(DeserializeEvent e)
        {
            Token = e.Reader.ReadString();
            RoomID = e.Reader.ReadInt32();
            ClientID = e.Reader.ReadInt32();
        }

        public void Serialize(SerializeEvent e)
        {
            e.Writer.Write(Token);
            e.Writer.Write(RoomID);
            e.Writer.Write(ClientID);
        }
    }
}