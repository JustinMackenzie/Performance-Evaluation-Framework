using System;
using System.Collections.Generic;
using AutoMapper;
using ScenarioSim.Core.Entities;
using Schema = ScenarioSim.Core.DataTransfer.Schema;
using Task = ScenarioSim.Core.DataTransfer.Task;

namespace ScenarioSim.Infrastructure.AutoMapperMapping
{
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
}