using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using System.Runtime.CompilerServices;


namespace MLApplication_frontend.Components.Environment
{
    public partial class EnvironmentButtonBlock
    {
        [Parameter] public Action<int>? UpdateNodeStateSelectionValue { get; set; }

        /// <summary>
        /// Update the selection value for the setting of the node states
        /// 0 = Empty
        /// 1 = Goal
        /// 2 = Obstical
        /// 3 = Start Location
        /// </summary>
        /// <param name="newValue"></param>
        public void Handle_UpdateNodeStateSlectionValue(int newValue) {
            UpdateNodeStateSelectionValue?.Invoke(newValue);
        }
    }
}
