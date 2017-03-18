using System;
using System.Threading;

namespace BraveLantern.Swatcher.Args
{
    sealed class SwatcherAsyncResult : IAsyncResult
    {
        public byte[] Buffer { get; set; }
        public bool IsCompleted { get; }
        public WaitHandle AsyncWaitHandle { get; }
        public object AsyncState { get; }
        public bool CompletedSynchronously { get; }
    }
}
