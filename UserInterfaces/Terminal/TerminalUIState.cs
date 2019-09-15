using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader.UI.Elements;
using Terraria.UI;

namespace MatterOverdrive.UserInterfaces.Terminal
{
    public class TerminalUIState : UIState
    {
        private const float
            PANEL_WIDTH = 500,
            PANEL_HEIGHT = 500;

        public override void OnInitialize()
        {
            MainPanel = new UIPanel();
            MainPanel.Width.Set(PANEL_WIDTH, 0);
            MainPanel.Height.Set(PANEL_HEIGHT, 0);
            MainPanel.BackgroundColor = Color.Black;
            MainPanel.SetPadding(0);
            MainPanel.OverflowHidden = true;

            MainPanel.VAlign = 0.5f;
            MainPanel.HAlign = 0.5f;

            OutputScrollBar = new UIScrollbar();
            OutputScrollBar.Width.Set(20, 0);
            OutputScrollBar.Height.Set(460, 0);
            OutputScrollBar.Left.Set(PANEL_WIDTH - 40, 0);
            OutputScrollBar.Top.Set(20, 0);

            Output = new UIGrid();
            Output.Width.Set(PANEL_WIDTH - 60, 0);
            Output.Height.Set(PANEL_HEIGHT - 100, 0);
            Output.SetScrollbar(OutputScrollBar);
            Output.VAlign = 0.1f;
            Output.HAlign = 0.1f;

            InputField = new UITextBox("");
            InputField.Width.Set(PANEL_WIDTH - 80, 0);
            InputField.Height.Set(20, 0);
            InputField.Top.Set(PANEL_HEIGHT - 60, 0);
            InputField.Left.Set(20, 0);
            InputField.SetTextMaxLength(100);
            InputField.DrawPanel = true;
            InputField.OnClick += new MouseEvent(Focus);
            InputField.OverflowHidden = true;
            InputField.DrawPanel = false;

            MainPanel.Append(OutputScrollBar);
            MainPanel.Append(Output);
            MainPanel.Append(InputField);

            base.Append(MainPanel);
        }

        // TO DO: Fix chat being required to be active to be able to type [X]

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Output.MarginTop = 0.1f;

            if (FocusedOnInput && InputField.Text.Length < 100)
            {
                Main.GetInputText("");
            }

            if (WebmilioCommons.Inputs.KeyboardManager.pressed.Contains(Keys.Back) && FocusedOnInput)
                InputField.Backspace();

            if(WebmilioCommons.Inputs.KeyboardManager.justPressed.Contains(Keys.Enter) && InputField.Text.Length > 0 && FocusedOnInput)
            {
                UIText latestText = new UIText("> " + InputField.Text);

                while (latestText.Text.Length < 70)
                    {
                        latestText.SetText(latestText.Text + " ");
                    }

                Output.Add(latestText);
                Output._items.Sort();

                if (InputField.Text == ">clear")
                    Output.Clear();

                InputField.SetText("");
                Recalculate();
                OutputScrollBar.ViewPosition = float.MaxValue;
            }

            if(FocusedOnInput)
            {
                Main.clrInput();
                Main.chatRelease = true;
                Main.editChest = true;
                Main.editSign = true;
                PlayerInput.WritingText = true;
            }

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (MainPanel.ContainsPoint(Main.MouseScreen))
                Main.LocalPlayer.mouseInterface = true;

            base.DrawSelf(spriteBatch);
        }

        private void Focus(UIMouseEvent evt, UIElement listeningElement)
        {
            FocusedOnInput = !FocusedOnInput;
            Main.clrInput();
            Main.chatRelease = FocusedOnInput;
            Main.editChest = FocusedOnInput;
            Main.editSign = FocusedOnInput;
            PlayerInput.WritingText = FocusedOnInput;
            InputField.TextColor = FocusedOnInput ? Color.Yellow : Color.White;
        }

        public UIScrollbar OutputScrollBar { get; private set; }

        public UIGrid Output { get; private set; }

        public UITextBox InputField { get; private set; }

        public UIPanel MainPanel { get; private set; }

        public bool Visible { get; set; }

        public bool FocusedOnInput { get; private set; }
    }
}
