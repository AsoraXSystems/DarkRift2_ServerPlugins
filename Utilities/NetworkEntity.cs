using System;
using System.Text;

//DarkRift
using DarkRift;

//Plugins
using Utilities.Game;

namespace Utilities
{
    public class NetworkEntity : IDarkRiftSerializable
    {
        public uint ID;
        public uint TargetID;
        public string Name = "Unknown";

        public EntityState State = EntityState.Idle;

        public Vector3 Position;

        public int Health = 100;

        public float Speed = 5f;


        public void Deserialize(DeserializeEvent e)
        {
            ID = e.Reader.ReadUInt32();
            TargetID = e.Reader.ReadUInt32();
            Name = e.Reader.ReadString(Encoding.Unicode);
            State = (EntityState)e.Reader.ReadByte();
            Position = e.Reader.ReadSerializable<Vector3>();
            Health = e.Reader.ReadInt32();


        }

        public void Serialize(SerializeEvent e)
        {
            e.Writer.Write(ID);
            e.Writer.Write(TargetID);
            e.Writer.Write(Name, Encoding.Unicode);
            e.Writer.Write((byte)State);
            e.Writer.Write(Position);
            e.Writer.Write(Health);
        }
    }
}