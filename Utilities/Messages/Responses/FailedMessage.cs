﻿using System.Text;
using DarkRift;

namespace Utilities.Messages.Responses
{
    public class FailedMessage : ResponseMessage
    {
        public string Reason;

        public override void Deserialize(DeserializeEvent e)
        {
            base.Deserialize(e);
            Reason = e.Reader.ReadString(Encoding.Unicode);
        }

        public override void Serialize(SerializeEvent e)
        {
            base.Serialize(e);
            e.Writer.Write(Reason);
        }
    }
}