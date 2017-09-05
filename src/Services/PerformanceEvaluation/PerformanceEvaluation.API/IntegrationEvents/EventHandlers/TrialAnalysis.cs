using System;

namespace PerformanceEvaluation.API.IntegrationEvents.EventHandlers
{
    public class TrialAnalysis
    {
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
    }
}