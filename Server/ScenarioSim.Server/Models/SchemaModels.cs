using System;
using System.Collections.Generic;

namespace ScenarioSim.Server.Models
{
    /// <summary>
    /// The view model for schema details.
    /// </summary>
    public class SchemaViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the task transitions.
        /// </summary>
        /// <value>
        /// The task transitions.
        /// </value>
        public List<TaskTransitionViewModel> TaskTransitions { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public List<TaskViewModel> Tasks { get; set; }
    }

    /// <summary>
    /// Represents a transition from one task to another.
    /// </summary>
    public class TaskTransitionViewModel
    {
        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; set; }

        /// <summary>
        /// Gets or sets the source identifier.
        /// </summary>
        /// <value>
        /// The source identifier.
        /// </value>
        public Guid SourceId { get; set; }

        /// <summary>
        /// Gets or sets the destination identifier.
        /// </summary>
        /// <value>
        /// The destination identifier.
        /// </value>
        public Guid DestinationId { get; set; }

        /// <summary>
        /// Gets or sets the performer action identifier.
        /// </summary>
        /// <value>
        /// The performer action identifier.
        /// </value>
        public Guid PerformerActionId { get; set; }
    }

    /// <summary>
    /// Represents a task.
    /// </summary>
    public class TaskViewModel
    {
        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        /// <value>
        /// The type of the task.
        /// </value>
        public string TaskType { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent task identifier.
        /// </summary>
        /// <value>
        /// The parent task identifier.
        /// </value>
        public Guid? ParentTaskId { get; set; }
    }

    /// <summary>
    /// The create schema view model.
    /// </summary>
    public class CreateSchemaViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }

    public class SchemaDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }

    /// <summary>
    /// The edit schema view model.
    /// </summary>
    public class EditSchemaViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}