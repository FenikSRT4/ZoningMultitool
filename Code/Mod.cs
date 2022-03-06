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
            Options.createZMOptionPanel(Name, helper as UIHelper);
        }
    }
}
