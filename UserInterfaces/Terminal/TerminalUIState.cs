using MatterOverdrive.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader.UI.Elements;
using Terraria.UI;
using WebmilioCommons.Inputs;

namespace MatterOverdrive.UserInterfaces.Terminal
{
    // TO DO:
    // [ ] Add CapsLock
    // [ ] Add Keyboard Delay
    // [ ] Fix keys being stuck??? ( Has to do w/ KeyboardManager implementation )

    public class TerminalUIState : UIState
    {
        private const float
            PANEL_WIDTH = 500,
            PANEL_HEIGHT = 500;

        public override void OnInitialize()
        {
            Visible = true;

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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Output.MarginTop = 0.1f;

            if (FocusedOnInput)
            {
                Main.chatRelease = false; // prevents chat from being opened when you hit Enter while focused on console
                WriteText();
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
            Main.blockInput = FocusedOnInput;
            Main.clrInput();
            Main.editChest = FocusedOnInput;
            Main.editSign = FocusedOnInput;
            PlayerInput.WritingText = FocusedOnInput;
            InputField.TextColor = FocusedOnInput ? Color.Yellow : Color.White;
        }

        // this sucks but there is no way around this as far as i'm aware
        // we have to manually filter out keys...
        // and manually implement special keys
        private void WriteText()
        {
            List<Keys> filteredKeys = new List<Keys>
            {
                Keys.LeftShift, Keys.LeftControl, Keys.Space, Keys.Escape,
                Keys.Back, Keys.OemTilde, Keys.CapsLock, Keys.Add, Keys.Subtract,
                Keys.Insert, Keys.Home, Keys.End, Keys.Scroll, Keys.Enter, Keys.Decimal,
                Keys.Tab, Keys.LeftWindows, Keys.RightWindows, Keys.Delete,
                Keys.PageDown, Keys.PageUp, Keys.Pause, Keys.NumLock
            };


            InputField.WriteOnKey(Keys.Add, "+");
            InputField.WriteOnKey(Keys.Subtract, "-");
            InputField.WriteOnKey(Keys.OemPeriod, ".", ">");
            InputField.WriteOnKey(Keys.OemComma, ",", "<");
            InputField.WriteOnKey(Keys.Space, " ");

            InputField.WriteOnKey(Keys.D1, "1", "!");
            InputField.WriteOnKey(Keys.D2, "2", "@");
            InputField.WriteOnKey(Keys.D3, "3", "#");
            InputField.WriteOnKey(Keys.D4, "4", "$");
            InputField.WriteOnKey(Keys.D5, "5", "%");
            InputField.WriteOnKey(Keys.D6, "6", "^");
            InputField.WriteOnKey(Keys.D7, "7", "&");
            InputField.WriteOnKey(Keys.D8, "8", "*");
            InputField.WriteOnKey(Keys.D9, "9", "(" );
            InputField.WriteOnKey(Keys.D0, "0", ")");

            InputField.WriteOnKey(Keys.OemSemicolon, ";", ":");
            InputField.WriteOnKey(Keys.Decimal, ".");
            InputField.WriteOnKey(Keys.Divide, "/");
            InputField.WriteOnKey(Keys.Multiply, "*");
            InputField.WriteOnKey(Keys.OemQuestion, "/", "?");
            InputField.WriteOnKey(Keys.OemTilde, "`", "~");
            InputField.WriteOnKey(Keys.OemQuotes, "'", '"'.ToString());

            InputField.WriteOnKey(Keys.OemPlus, "=", "+");
            InputField.WriteOnKey(Keys.OemMinus, "-", "_");
            InputField.WriteOnKey(Keys.OemCloseBrackets, "]", "}");
            InputField.WriteOnKey(Keys.OemOpenBrackets, "[", "{");


            // Idk if its good approach or not, as i haven't seen how KeyboardManager works.
            foreach (Keys key in KeyboardManager.justPressed)
            {
                if (key == Keys.Back)
                    InputField.Backspace();

                if(key == Keys.Enter && InputField.Text.Length > 0)
                {
                    SendCommand();
                }

                string keyName = key.ToString();

                if (keyName.Contains("Oem")
                    || keyName.Contains("Alt")
                    || keyName.Contains("Control")
                    || (keyName.Contains("D") && keyName.Any(char.IsDigit))
                    )
                    filteredKeys.Add(key);

                if (keyName.Contains("NumPad"))
                    keyName = keyName.Replace("NumPad", ""); // should make numpad numbers be easier to type

                if (filteredKeys.Contains(key))
                    continue;

                if (InputField.Text.Length < 100)
                {
                    InputField.WriteOnKey(key, keyName);
                }
            }
        }

        private void SendCommand()
        {
            UIText latestText = new UIText("> " + InputField.Text);

            while (latestText.Text.Length < 70)
            {
                latestText.SetText(latestText.Text + " ");
            }

            Output.Add(latestText);
            Output._items.Sort();

            if (InputField.Text == "> ")
                Output.Clear();

            InputField.SetText("");
            Recalculate();
            OutputScrollBar.ViewPosition = float.MaxValue;
        }

        public UIScrollbar OutputScrollBar { get; private set; }

        public UIGrid Output { get; private set; }

        public UITextBox InputField { get; private set; }

        public UIPanel MainPanel { get; private set; }

        public bool Visible { get; set; }

        public bool FocusedOnInput { get; private set; }
    }
}
