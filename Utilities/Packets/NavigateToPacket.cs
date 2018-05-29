using DarkRift;
using Utilities.Game;

namespace Utilities.Packets
{
    public class NavigateToPacket : IDarkRiftSerializable
    {
        public Vector3 Destination;

        public void Deserialize(DeserializeEvent e)
        {
            Destination = e.Reader.ReadSerializable<Vector3>();
        }

        public void Serialize(SerializeEvent e)
        {
            e.Writer.Write(Destination);
        }
    }
}