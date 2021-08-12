using UnityEditor;
using UnityEngine;

namespace Seaeees.GButton.Editor
{
    [CustomEditor(typeof(GButton))]
    public class GButtonEditor : UnityEditor.Editor
    {
        private int _tabIndex;
        private bool _useTemplate;

        private SerializedProperty _useScaleAnimationOnHover;
        private SerializedProperty _useScaleAnimationOnClick;
        private SerializedProperty _useColorAnimationOnHover;
        private SerializedProperty _useColorAnimationOnClick;
        private SerializedProperty _useAudioPlayer;
        private SerializedProperty _useFillAmountAnimation;
        private SerializedProperty _useImageChangerOnHover;
        private SerializedProperty _useImageChangerOnClick;

        //TODO:テンプレート
        //private SerializedProperty _template;

        private SerializedProperty _scaleOnHover;
        private SerializedProperty _scaleDurationOnHover;
        private SerializedProperty _scaleEaseTypeOnHover;
        private SerializedProperty _scaleOnClick;
        private SerializedProperty _scaleDurationOnClick;
        private SerializedProperty _scaleEaseTypeOnClick;

        private SerializedProperty _colorOnHover;
        private SerializedProperty _colorDurationOnHover;
        private SerializedProperty _colorEaseTypeOnHover;
        private SerializedProperty _colorSpaceTypeOnHover;
        private SerializedProperty _colorOnClick;
        private SerializedProperty _colorDurationOnClick;
        private SerializedProperty _colorEaseTypeOnClick;
        private SerializedProperty _colorSpaceTypeOnClick;

        private SerializedProperty _audioSource;
        private SerializedProperty _hoverEnterAudioClip;
        private SerializedProperty _hoverExitAudioClip;
        private SerializedProperty _downAudioClip;
        private SerializedProperty _upAudioClip;

        private SerializedProperty _fillAmountEaseType;
        private SerializedProperty _fillImage;
        private SerializedProperty _fillImageDuration;
        private SerializedProperty _hoverImage;
        private SerializedProperty _clickImage;

        private static bool _foldout1;
        private static bool _foldout2;
        private static bool _foldout3;
        private static bool _foldout4;
        private static bool _foldout5;
        private static bool _foldout6;
        private static bool _foldout7;
        private static bool _foldout8;
        private void OnEnable()
        {
            _useScaleAnimationOnHover = serializedObject.FindProperty("useScaleAnimationOnHover");
            _useScaleAnimationOnClick = serializedObject.FindProperty("useScaleAnimationOnClick");
            _useColorAnimationOnHover = serializedObject.FindProperty("useColorAnimationOnHover");
            _useColorAnimationOnClick = serializedObject.FindProperty("useColorAnimationOnClick");
            _useAudioPlayer = serializedObject.FindProperty("useAudioPlayer");
            _useFillAmountAnimation = serializedObject.FindProperty("useFillAmountAnimation");
            _useImageChangerOnHover = serializedObject.FindProperty("useImageChangerOnHover");
            _useImageChangerOnClick = serializedObject.FindProperty("useImageChangerOnClick");

            _scaleOnHover = serializedObject.FindProperty("scaleOnHover");
            _scaleDurationOnHover = serializedObject.FindProperty("scaleDurationOnHover");
            _scaleEaseTypeOnHover = serializedObject.FindProperty("scaleEaseTypeOnHover");
            _scaleOnClick = serializedObject.FindProperty("scaleOnClick");
            _scaleDurationOnClick = serializedObject.FindProperty("scaleDurationOnClick");
            _scaleEaseTypeOnClick = serializedObject.FindProperty("scaleEaseTypeOnClick");

            _colorOnHover = serializedObject.FindProperty("colorOnHover");
            _colorDurationOnHover = serializedObject.FindProperty("colorDurationOnHover");
            _colorEaseTypeOnHover = serializedObject.FindProperty("colorEaseTypeOnHover");
            _colorSpaceTypeOnHover = serializedObject.FindProperty("colorSpaceTypeOnHover");
            _colorOnClick = serializedObject.FindProperty("colorOnClick");
            _colorDurationOnClick = serializedObject.FindProperty("colorDurationOnClick");
            _colorEaseTypeOnClick = serializedObject.FindProperty("colorEaseTypeOnClick");
            _colorSpaceTypeOnClick = serializedObject.FindProperty("colorSpaceTypeOnClick");

            _audioSource = serializedObject.FindProperty("audioSource");
            _hoverEnterAudioClip = serializedObject.FindProperty("hoverEnterAudioClip");
            _hoverExitAudioClip = serializedObject.FindProperty("hoverExitAudioClip");
            _downAudioClip = serializedObject.FindProperty("downAudioClip");
            _upAudioClip = serializedObject.FindProperty("upAudioClip");
            _fillAmountEaseType = serializedObject.FindProperty("fillImageEaseType");
            _fillImage = serializedObject.FindProperty("fillImage");
            _fillImageDuration = serializedObject.FindProperty("fillImageDuration");
            _hoverImage = serializedObject.FindProperty("hoverImage");
            _clickImage = serializedObject.FindProperty("clickImage");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Effects", EditorStyles.boldLabel);

            _useColorAnimationOnHover.boolValue = CustomEditorUtils.Foldout("Hover Color", _useColorAnimationOnHover.boolValue, ref _foldout1);
            if(_foldout1)
            {
                GUI.enabled = _useColorAnimationOnHover.boolValue;
                {
                    EditorGUILayout.PropertyField(_colorEaseTypeOnHover,new GUIContent("Easing"));
                    EditorGUILayout.PropertyField(_colorSpaceTypeOnHover,new GUIContent("Color Space"));
                    EditorGUILayout.PropertyField(_colorOnHover,new GUIContent("Color"));
                    EditorGUILayout.PropertyField(_colorDurationOnHover,new GUIContent("Duration"));

                }
                GUI.enabled = true;
            }

            _useColorAnimationOnClick.boolValue = CustomEditorUtils.Foldout("Click Color", _useColorAnimationOnClick.boolValue,ref _foldout2);
            if(_foldout2)
            {
                GUI.enabled = _useColorAnimationOnClick.boolValue;
                {
                    EditorGUILayout.PropertyField(_colorEaseTypeOnClick,new GUIContent("Easing"));
                    EditorGUILayout.PropertyField(_colorSpaceTypeOnClick,new GUIContent("Color Space"));
                    EditorGUILayout.PropertyField(_colorOnClick,new GUIContent("Coloer"));
                    EditorGUILayout.PropertyField(_colorDurationOnClick,new GUIContent("Duration"));
                }
                GUI.enabled = true;
            }

            _useScaleAnimationOnHover.boolValue = CustomEditorUtils.Foldout("Hover Scale", _useScaleAnimationOnHover.boolValue,ref _foldout3);
            if(_foldout3)
            {
                GUI.enabled = _useScaleAnimationOnHover.boolValue;
                {
                    EditorGUILayout.PropertyField(_scaleEaseTypeOnHover,new GUIContent("Easing"));
                    EditorGUILayout.PropertyField(_scaleOnHover,new GUIContent("Scale"));
                    EditorGUILayout.PropertyField(_scaleDurationOnHover,new GUIContent("Duration"));
                }
                GUI.enabled = true;
            }

            _useScaleAnimationOnClick.boolValue = CustomEditorUtils.Foldout("Click Scale", _useScaleAnimationOnClick.boolValue,ref _foldout4);
            if(_foldout4)
            {
                GUI.enabled = _useScaleAnimationOnClick.boolValue;
                {
                    EditorGUILayout.PropertyField(_scaleEaseTypeOnClick,new GUIContent("Easing"));
                    EditorGUILayout.PropertyField(_scaleOnClick,new GUIContent("Scale"));
                    EditorGUILayout.PropertyField(_scaleDurationOnClick,new GUIContent("Duration"));
                }
                GUI.enabled = true;
            }

            _useAudioPlayer.boolValue = CustomEditorUtils.Foldout("Audio", _useAudioPlayer.boolValue,ref _foldout5);
            if(_foldout5)
            {
                GUI.enabled = _useAudioPlayer.boolValue;
                {
                    EditorGUILayout.PropertyField(_audioSource,new GUIContent("Audio Source"));

                    GUILayout.Label("Audio Clips");
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(_hoverEnterAudioClip,new GUIContent("Pointer Enter"));
                    EditorGUILayout.PropertyField(_hoverExitAudioClip,new GUIContent("Pointer Exit"));
                    EditorGUILayout.PropertyField(_downAudioClip,new GUIContent("Pointer Down"));
                    EditorGUILayout.PropertyField(_upAudioClip,new GUIContent("Pointer Up"));
                    EditorGUI.indentLevel--;

                }
                GUI.enabled = true;
            }

            _useImageChangerOnHover.boolValue = CustomEditorUtils.Foldout("Hover Sprite", _useImageChangerOnHover.boolValue,ref _foldout6);
            if(_foldout6)
            {
                GUI.enabled = _useImageChangerOnHover.boolValue;
                {
                        EditorGUILayout.PropertyField(_hoverImage,new GUIContent("Sprite"));
                }
                GUI.enabled = true;
            }

            _useImageChangerOnClick.boolValue = CustomEditorUtils.Foldout("Click Sprite", _useImageChangerOnClick.boolValue,ref _foldout7);
            if (_foldout7)
            {
                GUI.enabled = _useImageChangerOnClick.boolValue;
                {

                    EditorGUILayout.PropertyField(_clickImage,new GUIContent("Sprite"));
                }
                GUI.enabled = true;
            }

            _useFillAmountAnimation.boolValue = CustomEditorUtils.Foldout("FillAmount", _useFillAmountAnimation.boolValue,ref _foldout8);
            if (_foldout8)
            {
                GUI.enabled = _useFillAmountAnimation.boolValue;
                {
                    EditorGUILayout.PropertyField(_fillAmountEaseType,new GUIContent("Easing"));
                    EditorGUILayout.PropertyField(_fillImage,new GUIContent("Sprite"));
                    EditorGUILayout.PropertyField(_fillImageDuration,new GUIContent("Duration"));
                }
                GUI.enabled = true;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
