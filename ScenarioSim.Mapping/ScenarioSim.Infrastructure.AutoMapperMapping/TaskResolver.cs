using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ScenarioSim.Core.Entities;
using Schema = ScenarioSim.Core.DataTransfer.Schema;
using Task = ScenarioSim.Core.DataTransfer.Task;

namespace ScenarioSim.Infrastructure.AutoMapperMapping
{
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