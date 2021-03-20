using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Seaeees.GUGUI.Editor
{
    static class GObjectCreator
    {
        private static DefaultControls.Resources _uiResource;
    
        [MenuItem("GameObject/UI/GUGUI/GButton", false, 0)]
        private static void CreateGButton(MenuCommand menuCommand)
        {
            var parent = menuCommand.context as GameObject;
            GameObject btn = DefaultControls.CreateButton(_uiResource);
            btn.transform.SetParent(parent.transform);
            btn.AddComponent<GButton>();
            btn.GetComponent<Button>().transition = Selectable.Transition.None;

            btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
    }
}
