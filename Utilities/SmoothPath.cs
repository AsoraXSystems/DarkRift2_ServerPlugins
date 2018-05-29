using System.Collections;
using System.Collections.Generic;
using DarkRift;
using Utilities.Game;

namespace Utilities
{
    public class SmoothPath : IDarkRiftSerializable, IEnumerable<Vector3>
    {
        public const int MAX_POLYS = 256;
        public const int MAX_SMOOTH = 2048;

        public int PointsCount;
        public readonly List<Vector3> Points = new List<Vector3>();
        public void Deserialize(DeserializeEvent e)
        {
            PointsCount = e.Reader.ReadInt32();
            for (int i = 0; i < PointsCount; ++i)
            {
                Points.Add(e.Reader.ReadSerializable<Vector3>());
            }
        }

        public void Serialize(SerializeEvent e)
        {
            e.Writer.Write(Points.Count);
            foreach (var point in Points)
            {
                e.Writer.Write(point);
            }
        }

        public IEnumerator<Vector3> GetEnumerator()
        {
            return Points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}