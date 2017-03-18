using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher.Extensions
{
    internal static class ExceptionExtensions
    {
        internal static Exception InnermostException(this Exception source)
        {
            while (source.InnerException != null)
            {
                source = source.InnerException;
            }
            return source;
        }
    }
}
