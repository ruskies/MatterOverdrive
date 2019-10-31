using System;
using System.Collections.Generic;
using MatterOverdrive.Modules;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        private Dictionary<Module, int> _modules;



        public void InstallOrUpgradeModule(ModuleVersion moduleVersion) => InstallOrUpgradeModule(moduleVersion.module, moduleVersion.version);

        public void InstallOrUpgradeModule(Module module, int version = 1)
        {
            if (_modules.ContainsKey(module) && _modules[module] >= version)
                return;

            _modules.Add(module, version);

            this.SendIfLocal(new PlayerModuleStateChanged(module.UnlocalizedName, version));
        }


        public bool HasModule(ModuleVersion moduleVersion) => HasModule(moduleVersion.module, moduleVersion.version);

        public bool HasModule(Module module, int version = 1)
        {
            if (!_modules.ContainsKey(module))
                return false;

            return _modules[module] >= version;
        }


        public bool HasModules(params Module[] modules)
        {
            for (int i = 0; i < modules.Length; i++)
                if (!HasModule(modules[i]))
                    return false;

            return true;
        }

        public bool HasModules(params ModuleVersion[] moduleVersions)
        {
            for (int i = 0; i < moduleVersions.Length; i++)
                if (!HasModule(moduleVersions[i]))
                    return false;

            return true;
        }


        public void ForAllInstalledModules(Action<Module, int> action)
        {
            foreach (KeyValuePair<Module, int> kvp in _modules)
                action(kvp.Key, kvp.Value);
        }

        public bool ForAllInstalledModules(Func<Module, int, bool> predicate)
        {
            foreach (KeyValuePair<Module, int> kvp in _modules)
                if (!predicate(kvp.Key, kvp.Value))
                    return false;

            return true;
        }


        #region Hooks

        private void InitializeModules()
        {
            _modules = new Dictionary<Module, int>();
        }

        private void ModifyWeaponDamageModules(Item item, ref float add, ref float mult, ref float flat)
        {
            foreach (KeyValuePair<Module, int> kvp in _modules)
                kvp.Key.ModifyPlayerWeaponDamage(this, kvp.Value, item, ref add, ref mult, ref flat);
        }

        private void NaturalLifeRegenModules(ref float regen)
        {
            foreach (KeyValuePair<Module, int> kvp in _modules)
                kvp.Key.NaturalPlayerLifeRegen(this, kvp.Value, ref regen);
        }

        private void OnHitNPCModules(Item item, NPC target, int damage, float knockback, bool crit) =>
            ForAllInstalledModules((module, version) => module.OnPlayerHitNPC(this, item, target, damage, knockback, crit));

        private void ResetEffectsModules() => ForAllInstalledModules((module, version) => module.ResetPlayerEffects(this, version));

        #endregion


        public int InstalledModulesCount => _modules.Count;


        public int this[Module module] => _modules[module];
    }
}
