using System;
using ColossalFramework.UI;
using UnityEngine;

namespace ZoningMultitool
{
    internal static class Options
    {
        // Parent UI panel reference.
        internal static UIScrollablePanel optionsPanel;
        private static UIPanel gameOptionsPanel;

        // Instance reference.
        private static GameObject optionsGameObject;
        internal static bool IsOpen => optionsGameObject != null;

        public static void OptionsPanelHook()
        {
            gameOptionsPanel = UIView.library.Get<UIPanel>("OptionsPanel");

            if(gameOptionsPanel == null)
            {
                //Log out message here
                return;
            }

            gameOptionsPanel.eventVisibilityChanged += zoningMultitoolEventVisibilityChanged;
            //TODO: recreate panel on locale change

        }

        private static void zoningMultitoolEventVisibilityChanged(UIComponent component, bool isVisible)
        {
            if (isVisible)
            {
                createZMOptionPanel();
            } 
            else
            {
                destroyZMOptionPanel();
            }
        }

        private static void createZMOptionPanel()
        {
            try
            {
                // We're now visible - create our gameobject, and give it a unique name for easy finding with ModTools.
                optionsGameObject = new GameObject("ZoningMultiToolOptionsPanel");

                // Attach to game options panel.
                optionsGameObject.transform.parent = optionsPanel.transform;

                // Create a base panel attached to our game object, perfectly overlaying the game options panel.
                UIPanel basePanel = optionsGameObject.AddComponent<UIPanel>();
                basePanel.width = optionsPanel.width - 10f;
                basePanel.height = 725f;
                basePanel.clipChildren = false;

                // Needed to ensure position is consistent if we regenerate after initial opening (e.g. on language change).
                basePanel.relativePosition = new Vector2(10f, 10f);

                UITextComponent textComponent = basePanel.AddUIComponent<UITextComponent>();
                textComponent.text = "Zoning Multitool Options Test";
                textComponent.height = 10f;
                textComponent.width = optionsPanel.width - 10f;
                textComponent.relativePosition = new Vector2(10f, 10f);

            } catch (Exception ex)
            {
                Debug.Log("Unable to create options panel" + ex.Message);
            }
        }

        private static void destroyZMOptionPanel() 
        {
            // Save settings first.
            //XMLSettingsFile.Save();

            // We're no longer visible - destroy our game object.
            if (optionsGameObject != null)
            {
                GameObject.Destroy(optionsGameObject);
                optionsGameObject = null;
            }
        }
    }
}
