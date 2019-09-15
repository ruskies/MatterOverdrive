using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        public void TryStart()
        {
            if (Running)
                return;

            Running = true;
        }

        public void Shutdown(int code)
        {
            Running = false;
            LastShutdownCode = code;
        }


        public bool Running { get; internal set; }
        public int LastShutdownCode { get; private set; }
    }
}
