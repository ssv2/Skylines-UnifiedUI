namespace UnifiedUI.API {
    using ColossalFramework;
    using ColossalFramework.UI;
    using KianCommons;
    using System;
    using System.Collections.Generic;
    using UnifiedUI.GUI;
    using UnifiedUI.LifeCycle;



    public static class UUIMod {
        private static ExternalButton Register(
            string name, string groupName, string tooltip, string spritefile) {
            if(!MainPanel.Instance)
                LifeCycle.Load();
            return MainPanel.Instance.Register(
                name: name, groupName: groupName, tooltip: tooltip, spritefile: spritefile);
        }

        public static UIComponent Register
            (string name, string groupName, string tooltip, string spritefile,
            Action<bool> onToggle, Action<ToolBase> onToolChanged,
            SavedInputKey activationKey, Dictionary<SavedInputKey, Func<bool>> activeKeys) {
            if(!MainPanel.Instance)
                LifeCycle.Load();
            var ret = Register(name: name, groupName: groupName, tooltip: tooltip, spritefile: spritefile);
            ret.ActivationKey = activationKey;
            ret.ActiveKeys = activeKeys;
            ret.OnToggleCallBack = onToggle;
            ret.OnToolChangedCallBack = onToolChanged;
            return ret;
        }


        public static UIComponent Register
            (string name, string groupName, string tooltip, string spritefile, ToolBase tool,
            SavedInputKey activationKey, Dictionary<SavedInputKey, Func<bool>> activeKeys) {
            var ret = Register(name: name, groupName: groupName, tooltip: tooltip, spritefile: spritefile);
            ret.ActivationKey = activationKey;
            ret.ActiveKeys = activeKeys;
            ret.Tool = tool;
            return ret;

        }

        public static void Register(
            Action onToggle,
            SavedInputKey activationKey,
            Dictionary<SavedInputKey, Func<bool>> activeKeys) {
            try {
                if(!MainPanel.Instance)
                    LifeCycle.Load();

                if(activationKey != null && onToggle != null)
                    MainPanel.Instance.CustomHotkeys[activationKey] = onToggle;

                if(activeKeys != null) {
                    foreach(var pair in activeKeys) {
                        Assertion.AssertNotNull(pair.Key, "hotkey cannot be null in 'activeKeys'");
                        Assertion.AssertNotNull(pair.Value, "IsActive cannot be null in 'activeKeys'");
                        MainPanel.Instance.CustomActiveHotkeys[pair.Key] = pair.Value;
                    }
                }
            } catch(Exception ex) {
                Log.Exception(ex);
            }
        }
    }
}
