using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public struct Transform
    {
        public Vector3f Position { get; set; }
        public Vector3f Rotation { get; set; }
        public Vector3f Scale { get; set; }

        public Transform(Vector3f position, Vector3f rotation, Vector3f scale)
            : this()
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
}
