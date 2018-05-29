﻿using DarkRift;

namespace Utilities.Messages.Responses
{
    public class SpawnFromMasterToSpawnerFailedMessage : FailedMessage
    {
        public int SpawnTaskID;

        public override void Serialize(SerializeEvent e)
        {
            base.Serialize(e);
            e.Writer.Write(SpawnTaskID);
        }

        public override void Deserialize(DeserializeEvent e)
        {
            base.Deserialize(e);
            SpawnTaskID = e.Reader.ReadInt32();
        }
    }
}