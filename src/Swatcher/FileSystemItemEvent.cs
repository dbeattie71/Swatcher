using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher
{
    internal enum FileSystemItemEvent
    {
        Created = 1,
        Deleted = 2,
        Changed = 3,
        RenamedOldName = 4,
        RenamedNewName = 5
    };
}
