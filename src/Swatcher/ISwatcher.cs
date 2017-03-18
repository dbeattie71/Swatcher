using System;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Args;

namespace BraveLantern.Swatcher
{
    /// <summary>
    /// The contract for consuming the reactive version of a <see cref="Swatcher"/>.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ISwatcher : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        bool IsDisposed { get; }
        /// <summary>
        /// Returns a value indicating whether or not this Swatcher is running.
        /// </summary>
        /// <value><c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
        bool IsRunning { get; }
        /// <summary>
        /// Gets a stream of SwatcherEventArgs that are pushed when a <b>change</b> event occurs.
        /// </summary>
        /// <value>The SwatcherEventArgs meta for a <b>change</b> event.</value>
        IObservable<SwatcherEventArgs> Changed { get; }
        /// <summary>
        /// Gets a stream of SwatcherCreatedEventArgs that are pushed when a <b>created</b> event occurs.
        /// </summary>
        /// <value>The SwatcherCreatedEventArgs meta for a <b>created</b> event.</value>
        IObservable<SwatcherCreatedEventArgs> Created { get; }
        /// <summary>
        /// Gets a stream of SwatcherEventArgs that are pushed when a <b>deleted</b> event occurs.
        /// </summary>
        /// <value>The SwatcherEventArgs meta for a <b>deleted</b> event.</value>
        IObservable<SwatcherEventArgs> Deleted { get; }
        /// <summary>
        /// Gets a stream of SwatcherEventArgs that are pushed when a <b>renamed</b> event occurs.
        /// </summary>
        /// <value>The SwatcherEventArgs meta for a <b>renamed</b> event.</value>
        IObservable<SwatcherRenamedEventArgs> Renamed { get; }
        /// <summary>
        /// Provides notifications when a <b>change</b> event occurs.
        /// </summary>
        /// <value>The SwatcherEventArgs meta for a <b>change</b> event.</value>
        event EventHandler<SwatcherEventArgs> ItemChanged;
        /// <summary>
        /// Provides notifications when a <b>created</b> event occurs.
        /// </summary>
        /// <value>The SwatcherEventArgs meta for a <b>created</b> event.</value>
        event EventHandler<SwatcherCreatedEventArgs> ItemCreated;
        /// <summary>
        /// Provides notifications when a <b>deleted</b> event occurs.
        /// </summary>
        /// <value>The SwatcherEventArgs meta for a <b>deleted</b> event.</value>
        event EventHandler<SwatcherEventArgs> ItemDeleted;
        /// <summary>
        /// Provides notifications when a <b>renamed</b> event occurs.
        /// </summary>
        /// <value>The SwatcherEventArgs meta for a <b>renamed</b> event.</value>
        event EventHandler<SwatcherRenamedEventArgs> ItemRenamed;
        /// <summary>
        /// Causes the <see cref="ISwatcher"/> to start listening for file system events.
        /// </summary>
        Task Start();
        /// <summary>
        /// Causes the <see cref="ISwatcher"/> to stop listening for file system events.
        /// </summary>
        /// <remarks>If a long running file copy|create|upload operation was in progress when 
        /// the <see cref="Stop"/> method is called, the <see cref="Created"/> stream will still notify subscribers when that
        /// operation is completed as long as the subscription is in place and the <see cref="IDisposable.Dispose"/> method
        /// has not been called. </remarks>
        Task Stop();
    }
}