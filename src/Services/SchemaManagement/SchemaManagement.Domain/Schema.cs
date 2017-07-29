using System;
using System.Collections.Generic;
using System.Linq;
using SchemaManagement.Domain.Exceptions;
using SchemaManagement.Domain.SeedWork;

namespace SchemaManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Schema.Domain.Entity" />
    /// <seealso cref="Schema.Domain.IAggregateRoot" />
    public class Schema : Entity, IAggregateRoot
    {
        /// <summary>
        /// The events
        /// </summary>
        private List<Event> _events;

        /// <summary>
        /// The task transitions
        /// </summary>
        private List<TaskTransition> _taskTransitions;

        /// <summary>
        /// The tasks
        /// </summary>
        private List<Task> _tasks;

        /// <summary>
        /// The objects
        /// </summary>
        private List<Asset> _assets;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public IReadOnlyList<Event> Events => this._events.AsReadOnly();

        /// <summary>
        /// Gets the task transitions.
        /// </summary>
        /// <value>
        /// The task transitions.
        /// </value>
        public IReadOnlyList<TaskTransition> TaskTransitions => this._taskTransitions.AsReadOnly();

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public IReadOnlyList<Task> Tasks => this._tasks.AsReadOnly();

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>
        /// The objects.
        /// </value>
        public IReadOnlyList<Asset> Assets => this._assets.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public Schema(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this._events = new List<Event>();
            this._taskTransitions = new List<TaskTransition>();
            this._tasks = new List<Task>();
            this._assets = new List<Asset>();
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="name">The name.</param>
        public Event AddEvent(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name cannot be null or empty.", nameof(name));

            if (this._events.Any(e => e.Name == name))
                throw new SchemaDomainException($"Cannot add event. There already exists an event in the schema with the name '{name}'.");

            Event @event = new Event(name);
            this._events.Add(@event);
            return @event;
        }

        /// <summary>
        /// Adds the task.
        /// </summary>
        /// <param name="name">The name.</param>
        public Task AddTask(string name)
        {
            Task task = new Task(name);
            this._tasks.Add(task);

            return task;
        }

        /// <summary>
        /// Adds the task transition.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="sourceTaskName">Name of the source task.</param>
        /// <param name="destinationTaskName">Name of the destination task.</param>
        /// <exception cref="Schema.Domain.SchemaDomainException">
        /// </exception>
        public TaskTransition AddTaskTransition(string eventName, string sourceTaskName, string destinationTaskName)
        {
            if (!this._events.Any(e => e.Name == eventName))
            {
                throw new SchemaDomainException($"Cannot add task transition. There is no event with the name '{eventName}'.");
            }

            if (!this._tasks.Any(t => t.Name == sourceTaskName))
            {
                throw new SchemaDomainException($"Cannot add task transition. There is no task with the name '{sourceTaskName}'");
            }

            if (!this._tasks.Any(t => t.Name == destinationTaskName))
            {
                throw new SchemaDomainException($"Cannot add task transition. There is no task with the name '{destinationTaskName}'");
            }

            if (this._taskTransitions.Any(t => t.EventName == eventName && t.SourceTaskName == sourceTaskName))
            {
                throw new SchemaDomainException($"Cannot add task transition. There is already a transition from the source task '{sourceTaskName}' for the event '{eventName}'.");
            }

            TaskTransition taskTransition = new TaskTransition(eventName, sourceTaskName, destinationTaskName);
            this._taskTransitions.Add(taskTransition);

            return taskTransition;
        }

        /// <summary>
        /// Adds the schema object.
        /// </summary>
        public Asset AddAsset(string name, string tag)
        {
            Asset asset = new Asset(name, tag);
            this._assets.Add(asset);
            return asset;
        }
    }
}
