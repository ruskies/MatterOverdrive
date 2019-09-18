using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI.Elements;
using WebmilioCommons.Inputs;

namespace MatterOverdrive.Extensions
{
    public static class UITextBoxExtensions
    {
        /// <summary>
        /// Adds value on pressed key.
        /// </summary>
        /// <param name="uiTextbox">UITextBox</param>
        /// <param name="key">Key required</param>
        /// <param name="text">Normal text</param>
        /// <param name="shiftText">Text when shift is held down</param>
        public static void WriteOnKey(this UITextBox uiTextbox, Keys key, string text, string shiftText = "")
        {
            if (shiftText == "")
                shiftText = text.ToUpper();

            if (KeyboardManager.justPressed.Contains(key))
            {
                if (KeyboardManager.pressed.Contains(Keys.LeftShift) || KeyboardManager.pressed.Contains(Keys.RightShift))
                    uiTextbox.Write(shiftText);

                else

                    uiTextbox.Write(text.ToLower());

            }
        }
    }
}
