using System.Collections.Generic;
using Artemis.Core.Modules;

namespace WinLockState.DataModels
{
    public class PluginDataModel : DataModel
    {
        public PluginDataModel()
        {

        }

        // Your datamodel can have regular properties and you can annotate them if you'd like
        [DataModelProperty(Name = "Lock State", Description = "Current PC lock state")]
        public bool WinLockState { get; set; }
    }
}