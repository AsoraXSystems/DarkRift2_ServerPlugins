using DarkRift;
using Utilities.Game;

namespace Utilities.Packets
{
    public class PositionPacket : IDarkRiftSerializable
    {
        public Vector3 Vector3 { get; set; }

        public void Deserialize(DeserializeEvent e)
        {
            throw new System.NotImplementedException();
        }

        public void Serialize(SerializeEvent e)
        {
            throw new System.NotImplementedException();
        }
    }
}