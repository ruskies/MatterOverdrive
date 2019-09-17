using WebmilioCommons.Extensions;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        private bool _osRunning;

        // stuff gave me errors so i commented it out

        public void TryStart()
        {
            if (Running)
                return;

            //this.SendIfLocal<PlayerOSRunningStateChanging>();

            Running = true;
        }

        public void Shutdown(int code)
        {
            //this.SendIfLocal<PlayerOSRunningStateChanging>();

            Running = false;
            LastShutdownCode = code;
        }


        public bool Running
        {
            get => _osRunning;
            set
            {
                if (_osRunning == value)
                    return;

                _osRunning = value;

                //this.SendIfLocal<PlayerOSRunningStateChanged>();
            }
        }

        public int LastShutdownCode { get; private set; }
    }
}
