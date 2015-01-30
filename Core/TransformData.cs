using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    struct TransformData
    {
        public Vector3f Position;
        public Vector3f Rotation;
        public Vector3f Scale;
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
