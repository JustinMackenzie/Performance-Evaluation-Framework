using System;

namespace Gateway.API.Query.PerformanceEvaluation
{
    public class TrialAnalysis
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public float Distance { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the milliseconds.
        /// </summary>
        /// <value>
        /// The milliseconds.
        /// </value>
        public long Milliseconds { get; set; }

        /// <summary>
        /// Gets or sets the trial identifier.
        /// </summary>
        /// <value>
        /// The trial identifier.
        /// </value>
        public Guid TrialId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialAnalysis"/> class.
        /// </summary>
        public TrialAnalysis()
        {
            this.Id = Guid.NewGuid();
        }
    }
}