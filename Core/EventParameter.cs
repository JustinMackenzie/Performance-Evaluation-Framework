﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScenarioSim.Core
{
    [XmlInclude(typeof(Vector3f))]
    public class EventParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Name, Value);

        }
    }
}
