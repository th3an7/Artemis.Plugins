using System.Collections.Generic;
using Artemis.Core;
using Artemis.Core.Modules;
using SkiaSharp;
using WinLockState.DataModels;
using System;
using System.Management;
using Microsoft.Win32;

namespace WinLockState
{
    // The core of your module. Hover over the method names to see a description.
    [PluginFeature(Name = "WinLockState", Icon = "MicrosoftWindows")]
    public class PluginModule : Module<PluginDataModel>
    {
        // This is useful if your module targets a specific game or application.
        // If this list is not null and not empty, the data of your module is only available to profiles specifically targeting it
        public override List<IModuleActivationRequirement> ActivationRequirements => null;
        
        // This is the beginning of your plugin feature's life cycle. Use this instead of a constructor.
        public override void Enable()
        {
            OnSessionChange();
        }

        public void OnSessionChange()
        {
            SystemEvents.SessionSwitch += new 
                SessionSwitchEventHandler(SystemEvents_SessionSwitch);
        }

        public void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                DataModel.WinLockState = true;
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                DataModel.WinLockState = false;
            }
        }

        // This is the end of your plugin feature's life cycle.
        public override void Disable()
        {

        }

        public override void Update(double deltaTime)
        {
            // This is where you can add your update logic
        }
    }
}