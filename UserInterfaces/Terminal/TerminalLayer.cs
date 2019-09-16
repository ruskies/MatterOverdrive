using Terraria;
using Terraria.UI;

namespace MatterOverdrive.UserInterfaces.Terminal
{
    public class TerminalLayer : GameInterfaceLayer
    {
        public TerminalLayer() : base("MatterOverdrive: TerminalLayer", InterfaceScaleType.UI)
        {
            TerminalUIState = new TerminalUIState();
            TerminalUIState.Activate();

            TerminalInterface = new UserInterface();
            TerminalInterface.SetState(TerminalUIState);
        }


        protected override bool DrawSelf()
        {
            if(TerminalUIState.Visible)
                TerminalUIState.Draw(Main.spriteBatch);

            return true;
        }


        public TerminalUIState TerminalUIState { get; }
        public UserInterface TerminalInterface { get; }
    }
}
