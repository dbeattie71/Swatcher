using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace BraveLantern.Swatcher.Extensions
{
    internal static class InteropExtensions
    {
        internal static bool IsHandleValid(this SafeFileHandle handle)
        {
            return handle != null && !handle.IsInvalid && !handle.IsClosed;
        }
    }
}
