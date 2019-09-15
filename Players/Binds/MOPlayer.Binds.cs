using System.Collections.Generic;
using MatterOverdrive.Commands;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using WebmilioCommons.Inputs;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        private Dictionary<Keys, string> _binds = new Dictionary<Keys, string>();


        public void Bind(Keys key, string command) => _binds.Add(key, command);

        public void Unbind(Keys key) => _binds.Remove(key);
        public void UnbindAll() => _binds.Clear();


        private void ProcessTriggersBinds(TriggersSet triggersSet)
        {
            foreach (KeyValuePair<Keys, string> kvp in _binds)
            {
                if (KeyboardManager.IsJustPressed(kvp.Key))
                {
                    List<string> args = kvp.Value.ParseLine();

                    string usedName = args[0];
                    args.RemoveAt(0);

                    Command command = CommandLoader.Instance.New(usedName);

                    if (command.CanUse(this))
                        command.Run(this, usedName, kvp.Value, args);
                }
            }
        }
    }
}
