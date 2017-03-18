using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct QueuedCompletionStatus
    {
        internal unsafe NativeOverlapped* OverlappedPointer;
        internal uint CompletionKey;
        internal uint BytesRead;
    }
}
