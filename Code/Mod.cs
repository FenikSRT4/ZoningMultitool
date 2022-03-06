using ICities;
using ColossalFramework.UI;

namespace ZoningMultitool
{
    public class ZoningMultitoolMod : IUserMod
    {
        public string Name => string.Format("{0} v{1}", ModName, ModVersion);

        public string Description => "A Multitool mod for zoning.";

        private string ModName = "Zoning Multitool";

        private string ModVersion = "0.0.1";

        /// <summary>
        /// Called by the game when the mod options panel is setup.
        /// </summary>
        public void OnSettingsUI(UIHelperBase helper)
        {
            // Setup options panel reference.
            //Options.optionsPanel = ((UIHelper)helper).self as UIScrollablePanel;
            //Options.optionsPanel.autoLayout = false;
            var group = helper.AddGroup(Name) as UIHelper;
            var panel = group.self as UIPanel;
        }

        public void OnDisabled()
        {
            //Harmony Unpatch
        }

        public void OnEnabled()
        {
            //Load Settings
            //Harmony Patch

            // Attaching options panel event hook - check to see if UIView is ready.
            if (UIView.GetAView() != null)
            {
                // It's ready - attach the hook now.
                Options.OptionsPanelHook();
            }
            else
            {
                // Otherwise, queue the hook for when the intro's finished loading.
                LoadingManager.instance.m_introLoaded += Options.OptionsPanelHook;
            }
        }
    }
}
