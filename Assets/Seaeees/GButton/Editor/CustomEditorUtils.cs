using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Seaeees.GButton.Editor{
    public static class CustomEditorUtils
    {
        internal static bool Foldout(string title, bool isActive, ref bool group)
        {
            var backgroundRect = GUILayoutUtility.GetRect(1f, 17f);

            var labelRect = backgroundRect;
            labelRect.xMin += 32f;
            labelRect.xMax -= 20f;

            var foldoutRect = backgroundRect;
            foldoutRect.y += 1f;
            foldoutRect.width = 13f;
            foldoutRect.height = 13f;

            var toggleRect = backgroundRect;
            toggleRect.x += 16f;
            toggleRect.y += 2f;
            toggleRect.width = 13f;
            toggleRect.height = 13f;


            // Background rect should be full-width
            backgroundRect.xMin = 1f;
            backgroundRect.width += 4f;

            // Background
            EditorGUI.DrawRect(backgroundRect, Styling.headerBackground);

            // Title
            EditorGUI.LabelField(labelRect, title, EditorStyles.boldLabel);

            // foldout
            group = GUI.Toggle(foldoutRect, group, GUIContent.none, EditorStyles.foldout);

            // Active checkbox
            isActive = GUI.Toggle(toggleRect, isActive, GUIContent.none, Styling.smallTickbox);


            return isActive;
        }
    }
}