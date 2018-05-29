using System;
using DarkRift;

namespace Utilities.Game
{
    public class Vector3 : IDarkRiftSerializable
    {
        public static Vector3 Zero => Vector3.Create(0f, 0f, 0f);

        public static Vector3 Create(float x, float y, float z)
        {
            return new Vector3 { X = x, Y = y, Z = z };
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public void Deserialize(DeserializeEvent e)
        {
            X = e.Reader.ReadSingle();
            Y = e.Reader.ReadSingle();
            Z = e.Reader.ReadSingle();
        }

        public void Serialize(SerializeEvent e)
        {
            e.Writer.Write(X);
            e.Writer.Write(Y);
            e.Writer.Write(Z);
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + Z;
        }


        public float Magnitude
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        public static Vector3 operator /(Vector3 a, float d)
        {
            return Create(a.X / d, a.Y / d, a.Z / d);
        }

        public static Vector3 MoveTowards(Vector3 current, Vector3 target,
            float maxDistanceDelta)
        {
            var toVector = target - current;
            float dist = toVector.Magnitude;
            if (dist <= maxDistanceDelta || dist < float.Epsilon)
                return target;
            return current + (toVector / dist) * maxDistanceDelta;
        }
        public static float Distance(Vector3 a, Vector3 b)
        {
            return (a - b).Magnitude;
        }

        public static Vector3 operator -(Vector3 a, Vector3 b) { return Create(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
        public static Vector3 operator +(Vector3 a, Vector3 b) { return Create(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
        public static Vector3 operator *(Vector3 a, float d) { return Create(a.X * d, a.Y * d, a.Z * d); }
    }
}