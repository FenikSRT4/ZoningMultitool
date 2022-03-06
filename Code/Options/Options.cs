using System;
using ColossalFramework.UI;
using UnityEngine;

namespace ZoningMultitool
{
    internal static class Options
    {
        public static void createZMOptionPanel(string name, UIHelper uihelper)
        {
            try
            {
                // Setup options panel reference.
                var group = uihelper.AddGroup(name) as UIHelper;
                var panel = group.self as UIPanel;

            } catch (Exception ex)
            {
                Debug.Log("Unable to create options panel" + ex.Message);
            }
        }
    }
}
