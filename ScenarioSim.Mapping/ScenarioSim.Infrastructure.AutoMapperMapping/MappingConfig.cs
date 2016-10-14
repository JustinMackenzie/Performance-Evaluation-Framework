using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ScenarioSim.Core.DataTransfer;
using ScenarioSim.Core.Entities;
using EventParameter = ScenarioSim.Core.DataTransfer.EventParameter;
using Scenario = ScenarioSim.Core.DataTransfer.Scenario;
using ScenarioEvent = ScenarioSim.Core.DataTransfer.ScenarioEvent;
using Schema = ScenarioSim.Core.DataTransfer.Schema;
using Task = ScenarioSim.Core.DataTransfer.Task;
using TaskPerformance = ScenarioSim.Core.DataTransfer.TaskPerformance;
using TaskTransition = ScenarioSim.Core.DataTransfer.TaskTransition;

namespace ScenarioSim.Infrastructure.AutoMapperMapping
{
    /// <summary>
    /// The configuration of the mapping.
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// Configures the mappings.
        /// </summary>
        public static void ConfigureMappings()
        {
            Mapper.Initialize(cfg =>
            {
                ConfigureScenarioMappings(cfg);
                ConfigureSchemaMappings(cfg);
                ConfigurePerformanceMappings(cfg);
            });
        }

        /// <summary>
        /// Configures the schema mappings.
        /// </summary>
        /// <param name="cfg">The CFG.</param>
        private static void ConfigureSchemaMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Core.Entities.Schema, Schema>()
                .ForMember(dest => dest.Tasks,
                    opt => opt.ResolveUsing<TaskViewModelResolver>());
            cfg.CreateMap<Core.Entities.TaskTransition, TaskTransition>();
            cfg.CreateMap<Core.Entities.Task, Task>()
                .Include<ParallelTask, Task>()
                .Include<CompositeTask, Task>()
                .ForMember(dest => dest.TaskType,
                    opts => opts.MapFrom(src => src.GetType().Name));
            cfg.CreateMap<ParallelTask, Task>();
            cfg.CreateMap<CompositeTask, Task>();

            cfg.CreateMap<Schema, Core.Entities.Schema>()
                .ForMember(dest => dest.Task,
                    opt => opt.ResolveUsing<TaskResolver>());
            cfg.CreateMap<TaskTransition, Core.Entities.TaskTransition>();
            cfg.CreateMap<Task, Core.Entities.Task>();
            cfg.CreateMap<Task, CompositeTask>();
            cfg.CreateMap<Task, ParallelTask>();
        }

        /// <summary>
        /// Configures the scenario mappings.
        /// </summary>
        /// <param name="cfg">The CFG.</param>
        private static void ConfigureScenarioMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Core.Entities.Scenario, Scenario>();
            cfg.CreateMap<ScenarioTaskDefinition, TaskDefinition>()
                .ForMember(dest => dest.TaskValues,
                    opts => opts.MapFrom(
                        src =>
                            src.TaskValues.GetType()
                                .GetProperties()
                                .Where(x => !x.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                                .ToDictionary(x => x.Name,
                                    x =>
                                        x.GetGetMethod().Invoke(src.TaskValues, null) == null
                                            ? string.Empty
                                            : x.GetGetMethod().Invoke(src.TaskValues, null).ToString())))
                .ForMember(dest => dest.TaskValuesType, opts => opts.MapFrom(src => src.TaskValues.GetType().Name));
            cfg.CreateMap<Core.Entities.ScenarioEvent, ScenarioEvent>();

            cfg.CreateMap<Scenario, Core.Entities.Scenario>();
            cfg.CreateMap<TaskDefinition, ScenarioTaskDefinition>()
                .ForMember(dest => dest.TaskValues, opts => opts.ResolveUsing<TaskValuesResolver>());
            cfg.CreateMap<ScenarioEvent, Core.Entities.ScenarioEvent>();
        }

        /// <summary>
        /// Configures the performance mappings.
        /// </summary>
        /// <param name="cfg">The CFG.</param>
        public static void ConfigurePerformanceMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ScenarioPerformance, Performance>();
            cfg.CreateMap<Event, PerformanceEvent>();
            cfg.CreateMap<Core.Entities.EventParameter, EventParameter>();
            cfg.CreateMap<Core.Entities.TaskPerformance, TaskPerformance>();

            cfg.CreateMap<Performance, ScenarioPerformance>();
            cfg.CreateMap<PerformanceEvent, Event>();
            cfg.CreateMap<EventParameter, Core.Entities.EventParameter>();
            cfg.CreateMap<TaskPerformance, Core.Entities.TaskPerformance>();
        }
    }

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

    /// <summary>
    /// Resolves a hierarchical task representation to a flat list of tasks.
    /// </summary>
    public class TaskViewModelResolver : IValueResolver<Core.Entities.Schema, Schema, List<Task>>
    {
        /// <summary>
        /// Resolves the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="destMember">The dest member.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public List<Task> Resolve(Core.Entities.Schema source, Schema destination, List<Task> destMember, ResolutionContext context)
        {
            List<Task> result = new List<Task>();
            AddTask(source.Task, result, context);
            return result;
        }

        /// <summary>
        /// Adds the task to the resulting list of tasks.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="result">The result.</param>
        /// <param name="context">The context.</param>
        /// <param name="parentTaskId">The parent task identifier.</param>
        private void AddTask(Core.Entities.Task task, List<Task> result, ResolutionContext context, Guid? parentTaskId = null)
        {
            Task model = context.Mapper.Map<Core.Entities.Task, Task>(task);
            model.ParentTaskId = parentTaskId;
            result.Add(model);
            if (task is CompositeTask)
                foreach (Core.Entities.Task t in ((CompositeTask)task).Tasks)
                    AddTask(t, result, context, task.Id);
        }
    }

    /// <summary>
    /// Resolves a flat list of tasks to a hierarchical representation.
    /// </summary>
    public class TaskResolver : IValueResolver<Schema, Core.Entities.Schema, Core.Entities.Task>
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
        public Core.Entities.Task Resolve(Schema source, Core.Entities.Schema destination, Core.Entities.Task destMember, ResolutionContext context)
        {
            Task rootTask = source.Tasks.SingleOrDefault(t => t.ParentTaskId == null);
            return MakeTask(rootTask, source.Tasks, context);
        }

        /// <summary>
        /// Makes the task.
        /// </summary>
        /// <param name="taskTransferObject">The task transfer object.</param>
        /// <param name="sourceTasks">The source tasks.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        private Core.Entities.Task MakeTask(Task taskTransferObject, List<Task> sourceTasks, ResolutionContext context)
        {
            Core.Entities.Task task = null;

            switch (taskTransferObject.TaskType)
            {
                case "Task":
                    task = context.Mapper.Map<Task, Core.Entities.Task>(taskTransferObject);
                    break;
                case "CompositeTask":
                    task = context.Mapper.Map<Task, CompositeTask>(taskTransferObject);

                    CompositeTask compositeTask = (CompositeTask) task;
                    compositeTask.Tasks = new List<Core.Entities.Task>();

                    foreach (Task model in sourceTasks.Where(t => t.ParentTaskId == taskTransferObject.Id))
                    {
                        compositeTask.Tasks.Add(MakeTask(model, sourceTasks, context));
                    }
                    break;
                case "ParallelTask":
                    task = context.Mapper.Map<Task, ParallelTask>(taskTransferObject);

                    ParallelTask parallelTask = (ParallelTask)task;
                    parallelTask.Tasks = new List<Core.Entities.Task>();

                    foreach (Task model in sourceTasks.Where(t => t.ParentTaskId == taskTransferObject.Id))
                    {
                        parallelTask.Tasks.Add(MakeTask(model, sourceTasks, context));
                    }
                    break;
                default:
                    throw new InvalidOperationException($"Unknown task type '{taskTransferObject.TaskType}' received.");
            }

            return task;
        }
    }
}