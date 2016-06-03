using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Playback
{
    /// <summary>
    /// The scenario playback service is used to playback and 
    /// review a previous scenario performance.
    /// </summary>
    public interface IScenarioPlayback
    {
        /// <summary>
        /// The index of the current event in the playback.
        /// </summary>
        int CurrentEventIndex { get; }

        /// <summary>
        /// Starts or resumes the replay of the performance.
        /// </summary>
        /// <param name="result">The performance result to replay.</param>
        void Play(ScenarioResult result);

        /// <summary>
        /// Pauses the current playback of the performance.
        /// </summary>
        void Pause();

        /// <summary>
        /// Restarts the current playback of the performance.
        /// </summary>
        void Restart();

        /// <summary>
        /// Stops the current playback of the performance.
        /// </summary>
        void Stop();

        /// <summary>
        /// Registers the given event enactor so that playback events 
        /// can be acted out.
        /// </summary>
        /// <param name="enactor">The enactor to register.</param>
        void EnqueueEnactor(IEventEnactor enactor);

        /// <summary>
        /// Retrieves all the names of the currently active tasks in the playback.
        /// </summary>
        IEnumerable<string> ActiveTasks { get; }

        /// <summary>
        /// Retrieves all of the currently active metric results in the playback.
        /// </summary>
        IEnumerable<AccuracyMetricResult> ActiveResults { get; }

        /// <summary>
        /// Plays the previous event.
        /// </summary>
        void Previous();

        /// <summary>
        /// Plays the next event.
        /// </summary>
        void Next();

    }
}
