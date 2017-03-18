using System;

namespace BraveLantern.Swatcher.Config
{
    /// <summary>
    /// This <see cref="System.Enum"/> is used to configure a <see cref="ISwatcher"/> to notify subscribers of a particular file system item type.
    /// </summary>
    /// <example>If <see cref="File"/> is selected, an <see cref="ISwatcher"/> will only give notifications for events pertaining to files.</example>
    [Flags]
    public enum SwatcherItemTypes
    {
#pragma warning disable 1591
        File = 1,
        Folder = 2,
        All = File | Folder
#pragma warning restore 1591
    };
}
