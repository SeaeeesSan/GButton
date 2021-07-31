using UnityEditor;
using UnityEngine;

namespace Seaeees.GButton.Editor
{
    public static class Styling
    {
        /// <summary>
        /// Style for the override checkbox.
        /// </summary>
        public static readonly GUIStyle smallTickbox;

        static readonly Color headerBackgroundDark;
        static readonly Color headerBackgroundLight;

        /// <summary>
        /// Color of effect header backgrounds.
        /// </summary>
        public static Color headerBackground
        {
            get { return EditorGUIUtility.isProSkin ? headerBackgroundDark : headerBackgroundLight; }
        }


        static Styling()
        {
            smallTickbox = new GUIStyle("ShurikenToggle");

            headerBackgroundDark = new Color(0.1f, 0.1f, 0.1f, 0.2f);
            headerBackgroundLight = new Color(1f, 1f, 1f, 0.2f);

        }
    }
}


