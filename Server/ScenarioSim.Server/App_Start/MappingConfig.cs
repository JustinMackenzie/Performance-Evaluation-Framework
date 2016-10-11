using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ScenarioSim.Core.Entities;
using ScenarioSim.Server.Models;

namespace ScenarioSim.Server
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
                cfg.CreateMap<Scenario, ScenarioViewModel>();
                cfg.CreateMap<ScenarioTaskDefinition, TaskDefinitionViewModel>()
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
                cfg.CreateMap<ScenarioEvent, EventViewModel>();
                cfg.CreateMap<Schema, SchemaViewModel>()
                    .ForMember(dest => dest.Tasks,
                        opt => opt.ResolveUsing<TaskResolver>());
                cfg.CreateMap<TaskTransition, TaskTransitionViewModel>();
                cfg.CreateMap<Task, TaskViewModel>()
                    .Include<ParallelTask, TaskViewModel>()
                    .Include<CompositeTask, TaskViewModel>()
                    .ForMember(dest => dest.TaskType,
                        opts => opts.MapFrom(src => src.GetType().Name));
                cfg.CreateMap<ParallelTask, TaskViewModel>();
                cfg.CreateMap<CompositeTask, TaskViewModel>();
            });
        }
    }

    /// <summary>
    /// Resolves a hierarchical task representation to a flat list of tasks.
    /// </summary>
    public class TaskResolver : IValueResolver<Schema, SchemaViewModel, List<TaskViewModel>>
    {
        /// <summary>
        /// Resolves the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="destMember">The dest member.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public List<TaskViewModel> Resolve(Schema source, SchemaViewModel destination, List<TaskViewModel> destMember, ResolutionContext context)
        {
            List<TaskViewModel> result = new List<TaskViewModel>();
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
        private void AddTask(Task task, List<TaskViewModel> result, ResolutionContext context, Guid? parentTaskId = null)
        {
            TaskViewModel model = context.Mapper.Map<Task, TaskViewModel>(task);
            model.ParentTaskId = parentTaskId;
            result.Add(model);
            if (task is CompositeTask)
                foreach (Task t in ((CompositeTask)task).Tasks)
                    AddTask(t, result, context, task.Id);
        }
    }
}