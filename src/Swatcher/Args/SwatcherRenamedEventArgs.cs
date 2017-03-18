using System;
using System.IO;
using BraveLantern.Swatcher.Config;

namespace BraveLantern.Swatcher.Args
{
    /// <summary>
    /// Class SwatcherRenamedEventArgs. This class cannot be inherited.
    /// </summary>
    public sealed class SwatcherRenamedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwatcherRenamedEventArgs"/> class.
        /// </summary>
        /// <param name="config">Configuration for the <see cref="ISwatcher"/> that created this <see cref="SwatcherRenamedEventArgs"/> instance.</param>
        /// <param name="name">The <b>new</b> name of the item that changed.</param>
        /// <param name="oldName">The <b>old</b> name of the item changed.</param>
        public SwatcherRenamedEventArgs(ISwatcherConfig config, string name, string oldName) 
        {
            SwatcherId = config.Id;
            OldName = oldName;
            FullPath = config.PathToWatch;
            Name = name;
            EventId = Guid.NewGuid();
            TimeOccurred = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the swatcher identifier, if provided.
        /// </summary>
        /// <value>The swatcher identifier.</value>
        public int? SwatcherId { get; }
        /// <summary>
        /// Gets the type of the change.
        /// </summary>
        /// <value>The type of the change.</value>
        public WatcherChangeTypes ChangeType { get;}
        /// <summary>
        /// Gets the old full path.
        /// </summary>
        /// <value>The old full path.</value>
        public string OldFullPath { get;}
        /// <summary>
        /// Gets the old name.
        /// </summary>
        /// <value>The old name.</value>
        public string OldName { get; }
        /// <summary>
        /// Gets the full path to the file or folder that was renamed.
        /// </summary>
        /// <value>The full path.</value>
        public string FullPath { get; }
        /// <summary>
        /// Gets the name of the file or folder that was renamed.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }
        /// <summary>
        /// Gets a unique id for this event.
        /// </summary>
        /// <value>The event identifier.</value>
        public Guid EventId { get; }
        /// <summary>
        /// Gets the UTC time that this event occurred.
        /// </summary>
        /// <value>The received time.</value>=
        public DateTime TimeOccurred { get; }
    }
}
