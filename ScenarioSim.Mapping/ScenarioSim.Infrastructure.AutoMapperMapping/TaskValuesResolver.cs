using System;
using AutoMapper;
using ScenarioSim.Core.DataTransfer;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.AutoMapperMapping
{
    /// <summary>
    /// Resolves task values polymorphic relationship based off of a dictionary of values representation.
    /// </summary>
    public class TaskValuesResolver : IValueResolver<TaskDefinition, ScenarioTaskDefinition, TaskValues>
    {
        /// <summary>
        /// Implementors use source object to provide a destination object.
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object, if exists</param>
        /// <param name="destMember">Destination member</param>
        /// <param name="context">The context of the mapping</param>
        /// <returns>
        /// Result, typically build from the source resolution result
        /// </returns>
        public TaskValues Resolve(TaskDefinition source, ScenarioTaskDefinition destination, TaskValues destMember,
            ResolutionContext context)
        {
            TaskValues taskValues = null;

            switch (source.TaskValuesType)
            {
                case "FittsTaskValues":
                    taskValues = new FittsTaskValues(float.Parse(source.TaskValues["D"]),
                        float.Parse(source.TaskValues["W"]));
                    break;
                case "ReactionTaskValues":
                    taskValues = new ReactionTaskValues(float.Parse(source.TaskValues["Delay"]));
                    break;
                case "RandomReactionTaskValues":
                    taskValues = new RandomReactionTaskValues
                    {
                        MeanDelay = float.Parse(source.TaskValues["MeanDelay"]),
                        VarianceDelay = float.Parse(source.TaskValues["VarianceDelay"])
                    };
                    break;
                case "DynamicFittsTaskValues":
                    taskValues = new DynamicFittsTaskValues
                    {
                        EventName = source.TaskValues["EventName"],
                        ParameterName = source.TaskValues["ParameterName"],
                        Target = Vector3f.Parse(source.TaskValues["Target"])
                    };
                    break;
                case "SteeringTaskValues":
                    taskValues = new SteeringTaskValues(float.Parse(source.TaskValues["A"]),
                        float.Parse(source.TaskValues["W"]));
                    break;
                default:
                    throw new InvalidOperationException($"The task values of type '{source.TaskValuesType} is unsupported.'");
            }

            return taskValues;
        }
    }
}