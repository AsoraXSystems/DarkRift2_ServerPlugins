using DarkRift;

namespace Utilities.Messages
{
    public abstract class ResponseMessage : IDarkRiftSerializable
    {
        public ResponseStatus Status;

        public virtual void Deserialize(DeserializeEvent e)
        {
            Status = (ResponseStatus)e.Reader.ReadInt16();
        }

        public virtual void Serialize(SerializeEvent e)
        {
            e.Writer.Write((short)Status);
        }
    }
}