using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher.Config
{
    /// <summary>
    /// This <see cref="Enum"/> is used to specify what predicated the change event.   
    /// </summary>
    /// <example>For example, If an <see cref="ISwatcher"/> is configured with <see cref="Security"/>
    /// and <see cref="Size"/>, subscribers will only be notified when a file system item's security properties are changed
    /// (sharing, read, write, e.g.) or the file system item's size is changed. <see cref="SwatcherNotificationTypes"/> values are combined using a bitwise OR
    /// and can be combined with <see cref="SwatcherItemTypes"/> to create powerful filtering combinations.</example>
    /// <remarks>The default value is <see cref="All"/>. We suggest gradually adding removing</remarks>
    [Flags]
    public enum SwatcherNotificationTypes
    {
        /// <summary>
        /// When selected, will provide notifications to subscribers for changes to a file's name.
        /// </summary>
        /// <remarks>The <see cref="SwatcherItemTypes.File"/> flag must also be set for this to work!</remarks>
        FileName = 1,
        /// <summary>
        /// When selected, will provide notifications to subscribers for changes to a folder's name.
        /// </summary>
        /// <remarks>The <see cref="SwatcherItemTypes.Folder"/> flag must also be set for this to work!</remarks>
        FolderName = 2,
        /// <summary>
        /// When selected, will provide notifications to subscribers that are predicated on a change to a file system item's attributes.
        /// </summary>
        Attributes = 4,
        /// <summary>
        /// When selected, will provide notifications to subscribers that are predicated on a change to a file system item's size. 
        /// </summary>
        Size = 8,
        /// <summary>
        /// When selected, will provide notifications to subscribers that are predicated on a change to a file system item's last write (modified) time. 
        /// </summary>
        /// <remarks>
        /// If a file system item is written to frequently, this can result is a large volume of notifications.
        /// </remarks>
        LastWrite = 16,
        /// <summary>
        /// When selected, will provide notifications to subscribers that are predicated on a change to a file system item's last access (read) time.
        /// </summary>
        /// <remarks>
        /// If a file system item is accessed frequently, this can result in a large volume of notifications.
        /// </remarks>
        LastAccess = 32,
        /// <summary>
        /// When selected, will provide notifications to subscribers that are predicated on a change to a file system item's creation time. 
        /// </summary>
        CreationTime = 64,
        /// <summary>
        /// When selected, will provide notifications to subscribers that are predicated on a change to a file system item's security. 
        /// </summary>
        Security = 256,
        /// <summary>
        /// When selected, will provide notifications for all <see cref="SwatcherNotificationTypes"/>.
        /// </summary>
        All = FileName | FolderName | Attributes | Size | LastWrite | LastAccess | CreationTime | Security
    }
}
