﻿using System;
using System.Collections.Generic;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class SimulationComponentRepository : ISimulationComponentRepository
    {
        Dictionary<Type, ISimulationComponent> components;

        public SimulationComponentRepository()
        {
            components = new Dictionary<Type, ISimulationComponent>();
        }

        public void AddComponent(ISimulationComponent component)
        {
            components.Add(component.GetType(), component);
        }

        public ISimulationComponent GetComponent(Type type)
        {
            if (!components.ContainsKey(type))
                return null;
            return components[type];
        }

        public IEnumerable<ISimulationComponent> GetAllComponents()
        {
            return components.Values;
        }
    }
}