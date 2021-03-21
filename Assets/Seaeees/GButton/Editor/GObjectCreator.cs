using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Seaeees.GButton.Editor
{
    static class GObjectCreator
    {
        private static DefaultControls.Resources _uiResource;
    
        private const string SpritePath = "UI/Skin/UISprite.psd";
        
        private static DefaultControls.Resources GetResource()
        {
            if (_uiResource.standard == null)
            {
                _uiResource.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>(SpritePath);
            }
            return _uiResource;
        }

        
        //Licensed under the Unity Companion License for Unity-dependent projects--see Unity Companion License.
        //© 2014 - 2018 Unity Technologies ApS 
        [MenuItem("GameObject/UI/GButton", false, 0)]
        private static void CreateGButton(MenuCommand menuCommand)
        {
            GameObject element = DefaultControls.CreateButton(GetResource());
            var parent = menuCommand.context as GameObject;
            if (parent == null)
            {
                parent = GetOrCreateCanvasGameObject();

                PrefabStage prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
                if (prefabStage != null && !prefabStage.IsPartOfPrefabContents(parent))
                    parent = prefabStage.prefabContentsRoot;
            }
            if (parent.GetComponentsInParent<Canvas>(true).Length == 0)
            {
                GameObject canvas = CreateNewUI();
                canvas.transform.SetParent(parent.transform, false);
                parent = canvas;
            }

            SceneManager.MoveGameObjectToScene(element, parent.scene);

            Undo.RegisterCreatedObjectUndo(element, "Create " + element.name);

            if (element.transform.parent == null)
            {
                Undo.SetTransformParent(element.transform, parent.transform, "Parent " + element.name);
            }

            GameObjectUtility.EnsureUniqueNameForSibling(element);

            Undo.SetCurrentGroupName("Create " + element.name);

            GameObjectUtility.SetParentAndAlign(element, parent);

            Selection.activeGameObject = element;

            element.AddComponent<GButton>();

            element.GetComponent<Button>().transition = Selectable.Transition.None;
        }
        
        static public GameObject CreateNewUI()
        {
            var root = new GameObject("Canvas");
            root.layer = LayerMask.NameToLayer("UI");
            Canvas canvas = root.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            root.AddComponent<CanvasScaler>();
            root.AddComponent<GraphicRaycaster>();

            Undo.RegisterCreatedObjectUndo(root, "Create " + root.name);

            return root;
        }

        private static GameObject GetOrCreateCanvasGameObject()
        {
            GameObject selectedGo = Selection.activeGameObject;

            Canvas canvas = (selectedGo != null) ? selectedGo.GetComponentInParent<Canvas>() : null;
            if (IsValidCanvas(canvas))
                return canvas.gameObject;

            Canvas[] canvasArray = StageUtility.GetCurrentStageHandle().FindComponentsOfType<Canvas>();
            for (int i = 0; i < canvasArray.Length; i++)
                if (IsValidCanvas(canvasArray[i]))
                    return canvasArray[i].gameObject;

            return CreateNewUI();
        }
        
        static bool IsValidCanvas(Canvas canvas)
        {
            if (canvas == null || !canvas.gameObject.activeInHierarchy)
                return false;

            if (EditorUtility.IsPersistent(canvas) || (canvas.hideFlags & HideFlags.HideInHierarchy) != 0)
                return false;

            if (StageUtility.GetStageHandle(canvas.gameObject) != StageUtility.GetCurrentStageHandle())
                return false;

            return true;
        }
    }
}
