using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Args;
using BraveLantern.Swatcher.Config;

namespace BraveLantern.Swatcher.Extensions
{
    internal static class SwatcherExtensions
    {
        internal static IObservable<Timestamped<T>> SelectConfiguredItemTypes<T>(
            this IObservable<Timestamped<T>> @event, ISwatcherConfig config) where T : SwatcherEventArgs
        {
            return @event
                .Select(x => new
                {
                    ItemType = GetItemType(x.Value.FullPath),
                    Model = x
                })
                .Where(x => config.ItemTypes.HasFlag(x.ItemType))
                .Select(x => x.Model);
        }

        internal static IObservable<T> SelectConfiguredItemTypes<T>(
            this IObservable<T> @event, ISwatcherConfig config) where T : SwatcherEventArgs
        {
            return @event
                .Select(x => new
                {
                    ItemType = GetItemType(x.FullPath),
                    Model = x
                })
                .Where(x => config.ItemTypes.HasFlag(x.ItemType))
                .Select(x => x.Model);
        }

        internal static IObservable<SwatcherEventArgs> WhereExists(this IObservable<SwatcherEventArgs> @events)
        {
            return @events.Where(x => File.Exists(x.FullPath) || Directory.Exists(x.FullPath));
        }

        internal static SwatcherItemTypes GetItemType(this string fullPath, bool throwIfNotExists = false)
        {
            if (File.Exists(fullPath) || Directory.Exists(fullPath))
            {
                try
                {
                    var attributes = File.GetAttributes(fullPath);
                    return attributes.HasFlag(FileAttributes.Directory)
                        ? SwatcherItemTypes.Folder
                        : SwatcherItemTypes.File;
                }
                /*a race condition occurred where the file/folder was deleted after the check but before inspecting attributes */
                catch(FileNotFoundException e)
                {
                    if (throwIfNotExists)
                        throw e;
                }
            }

            var fileName = Path.GetFileName(fullPath);

            return string.IsNullOrWhiteSpace(
                Path.GetExtension(fileName))
                ? SwatcherItemTypes.Folder
                : SwatcherItemTypes.File;
        }
    }
}