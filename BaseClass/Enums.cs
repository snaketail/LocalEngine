using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass
{
    public enum WorkingMode
    {
        Idle,
        Interactive,
        Continuous,
        Unknown
    };

    public enum MessageType
    {
        CONFIG,
        COMMAND,
        ERROR
    };
}
