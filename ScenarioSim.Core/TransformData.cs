using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public struct Transform
    {
        public Vector3f Position;
        public Vector3f Rotation;
        public Vector3f Scale;

        public Transform(Vector3f position, Vector3f rotation, Vector3f scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        public override string ToString()
        {
            return string.Format("Position:{0}; Rotation:{1}; Scale:{2}", Position, Rotation, Scale);
        }
    }

    public struct Vector3f
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return string.Format("[{0} {1} {2}]", X, Y, Z);
        }
    }
}
