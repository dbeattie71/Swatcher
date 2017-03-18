using System;
using System.IO;
using BraveLantern.Swatcher.Extensions;

namespace BraveLantern.Swatcher.Config
{
    /// <summary>
    /// Class SwatcherConfig. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="ISwatcherConfig" />
    public sealed class SwatcherConfig : ISwatcherConfig
    {
        /// <summary>
        /// Gets an identifier for the <see cref="ISwatcher" /> instance.
        /// </summary>
        /// <value>The identifier</value>
        /// <remarks>This is solely here for the convenience of developers to make a correlation between
        /// events being consumed and the Swatcher from which they came.</remarks>
        public int? Id { get; }
        /// <summary>
        /// Gets the path to a folder that the <see cref="ISwatcher" /> or will monitor.
        /// </summary>
        /// <value>The folder path.</value>
        /// <remarks>https://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.path(v=vs.110).aspx</remarks>
        public string PathToWatch { get; private set; }

        /// <summary>
        /// Gets the change types that the <see cref="ISwatcher" /> should monitor.
        /// </summary>
        /// <value>The change types.</value>
        /// <remarks>https://msdn.microsoft.com/en-us/library/t6xf43e0(v=vs.110).aspx</remarks>
        public WatcherChangeTypes ChangeTypes { get; }
        /// <summary>
        /// Gets the <see cref="SwatcherItemTypes" /> that the <see cref="ISwatcher" /> should monitor.
        /// </summary>
        /// <value>The item types.</value>
        public SwatcherItemTypes ItemTypes { get; }
        /// <summary>
        /// Gets the notification types to apply to an <see cref="ISwatcher"/>.
        /// </summary>
        /// <value>The notification types.</value>
        public SwatcherNotificationTypes NotificationTypes { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ISwatcher"/> should monitor subfolders of the <see cref="PathToWatch"/>.
        /// </summary>
        /// <value><c>true</c> if this instance is recursive; otherwise, <c>false</c>.</value>
        /// <remarks>https://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.includesubdirectories(v=vs.110).aspx</remarks>
        public bool IsRecursive { get; }
        /// <summary>
        /// Gets a value indicating whether the <see cref="ISwatcher"/> should output logging statements.
        /// </summary>
        /// <value><c>true</c> if you want logging; otherwise, <c>false</c>.</value>
        public bool LoggingEnabled { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SwatcherConfig" /> class.
        /// </summary>
        /// <param name="id">The <see cref="ISwatcherConfig.Id" />.</param>
        /// <param name="pathToWatch">The <see cref="ISwatcherConfig.PathToWatch" />.</param>
        /// <param name="changeTypes">The <see cref="ISwatcherConfig.ChangeTypes" />.</param>
        /// <param name="itemTypes">The <see cref="ISwatcherConfig.ItemTypes" />.</param>
        /// <param name="notificationTypes">The <see cref="ISwatcherConfig.NotificationTypes" />.</param>
        /// <param name="isRecursive">The <see cref="ISwatcherConfig.IsRecursive" />.</param>
        /// <param name="loggingEnabled">The <see cref="ISwatcherConfig.LoggingEnabled"/>.</param>
        public SwatcherConfig(string pathToWatch,
            WatcherChangeTypes changeTypes,
            SwatcherItemTypes itemTypes,
            SwatcherNotificationTypes notificationTypes,
            int? id = null,
            bool isRecursive = false,
            bool loggingEnabled = false)
        {
            Id = id;
            PathToWatch = pathToWatch;
            ChangeTypes = changeTypes;
            NotificationTypes = notificationTypes;
            ItemTypes = itemTypes;
            IsRecursive = isRecursive;
            LoggingEnabled = loggingEnabled;

            Validate();
        }

        private void Validate()
        {
            try
            {
                if (!PathToWatch.EndsWith("\\", StringComparison.Ordinal))
                    PathToWatch = $@"{PathToWatch}\";


            }
            catch (FileNotFoundException)
            {
                throw new InvalidConfigurationException($"The {nameof(PathToWatch)} doesn't exist or isn't accessible.");
            }
        }
    }
}
