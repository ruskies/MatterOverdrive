using System.Collections.Generic;
using System.Collections.ObjectModel;
using MatterOverdrive.Commands;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using WebmilioCommons.Inputs;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        private Dictionary<Keys, string> _binds = new Dictionary<Keys, string>();


        public void Bind(Keys key, string command)
        {
            if (_binds.ContainsKey(key))
                _binds.Remove(key);

            _binds.Add(key, command);
        } 

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

                    AndroidCommand command = CommandLoader.Instance.New(usedName);

                    command.Action(player, usedName, args.ToArray());
                }
            }
        }


        public ReadOnlyDictionary<Keys, string> Binds => new ReadOnlyDictionary<Keys, string>(_binds);
    }
}
