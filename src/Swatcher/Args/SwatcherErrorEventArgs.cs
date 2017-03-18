using System;

namespace BraveLantern.Swatcher.Args
{
    /// <summary>
    /// Class SwatcherErrorEventArgs. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public sealed class SwatcherErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwatcherErrorEventArgs"/> class.
        /// </summary>
        /// <param name="swatcherId">The swatcher identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public SwatcherErrorEventArgs(int? swatcherId, string message, string stackTrace)
        {
            SwatcherId = swatcherId;
            Message = message;
            StackTrace = stackTrace;
            TimeOccurred = DateTime.UtcNow;
            EventId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the Swatcher identifier, if provided.
        /// </summary>
        /// <value>The Swatcher identifier.</value>
        public long? SwatcherId { get; }
        /// <summary>
        /// Gets a unique id for this event.
        /// </summary>
        /// <value>The event identifier.</value>
        public Guid EventId { get; }
        /// <summary>
        /// Gets the innermost exception message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; }
        /// <summary>
        /// Gets the innermost stack trace.
        /// </summary>
        /// <value>The stack trace.</value>
        public string StackTrace { get; }
        /// <summary>
        /// Gets the UTC time that this exception occurred.
        /// </summary>
        /// <value>The received time.</value>
        public DateTime TimeOccurred { get; }
    }
}
