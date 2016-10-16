using System;
using System.Linq;
using AutoMapper;
using ScenarioSim.Core.DataTransfer;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Mapping;
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
    public class DataTransferMappingConfig : IMappingConfiguration
    {
        public void Initialize()
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
}