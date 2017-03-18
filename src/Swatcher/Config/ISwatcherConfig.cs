using System.IO;

namespace BraveLantern.Swatcher.Config
{
    /// <summary>
    /// The contract for defining configuration options on an <see cref="ISwatcher"/>.
    /// </summary>
    public interface ISwatcherConfig
    {
        /// <summary>
        /// Gets an identifier for the <see cref="ISwatcher"/> instance.
        /// </summary>
        /// <value>The identifier</value>
        /// <remarks>This is solely here for the convenience of developers to make a correlation between 
        /// events being consumed and the Swatcher from which they came.</remarks>
        int? Id { get; }
        /// <summary>
        /// Gets the path to a folder that the <see cref="ISwatcher"/> will watch.
        /// </summary>
        /// <value>The path to watch.</value>
        string PathToWatch { get; }
        /// <summary>
        /// Gets a value indicating whether the <see cref="ISwatcher"/> should monitor subfolders of the <see cref="PathToWatch"/>.
        /// </summary>
        /// <value><c>true</c> if this instance is recursive; otherwise, <c>false</c>.</value>
        bool IsRecursive { get; }
        /// <summary>
        /// Gets the change types that the <see cref="ISwatcher"/> should monitor. 
        /// </summary>
        /// <value>The change types.</value>
        WatcherChangeTypes ChangeTypes { get; }
        /// <summary>
        /// Gets the <see cref="SwatcherItemTypes"/> that the <see cref="ISwatcher"/> should monitor. 
        /// </summary>
        /// <value>The item types.</value>
        SwatcherItemTypes ItemTypes { get; }
        /// <summary>
        /// Gets the notification types to apply to an <see cref="ISwatcher"/>.
        /// </summary>
        /// <value>The notification types.</value>
        SwatcherNotificationTypes NotificationTypes { get; }
        /// <summary>
        /// Gets a value indicating whether the <see cref="ISwatcher"/> should output logging statements.
        /// </summary>
        /// <value><c>true</c> if you want logging; otherwise, <c>false</c>.</value>
        bool LoggingEnabled { get; }
    }
}