using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher
{
    public sealed class InvalidConfigurationException : ApplicationException
    {
        public InvalidConfigurationException(string message):base(message)
        {}
    }
}
