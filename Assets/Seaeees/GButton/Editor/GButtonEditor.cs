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

        private SerializedProperty _scaleEaseType;
        private SerializedProperty _scaleOnHover;
        private SerializedProperty _scaleDurationOnHover;
        private SerializedProperty _scaleOnClick;
        private SerializedProperty _scaleDurationOnClick;

        private SerializedProperty _colorOnHover;
        private SerializedProperty _colorDurationOnHover;
        private SerializedProperty _colorOnClick;
        private SerializedProperty _colorDurationOnClick;

        private SerializedProperty _audioSource;
        private SerializedProperty _hoverEnterAudioClip;
        private SerializedProperty _hoverExitAudioClip;
        private SerializedProperty _downAudioClip;
        private SerializedProperty _upAudioClip;

        private SerializedProperty _fillImageEaseType;
        private SerializedProperty _fillImage;
        private SerializedProperty _fillImageDuration;
        private SerializedProperty _hoverImage;
        private SerializedProperty _clickImage;

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
            //_template = serializedObject.FindProperty("template");
            _scaleEaseType = serializedObject.FindProperty("scaleEaseType");
            _scaleOnHover = serializedObject.FindProperty("scaleOnHover");
            _scaleDurationOnHover = serializedObject.FindProperty("scaleDurationOnHover");
            _scaleOnClick = serializedObject.FindProperty("scaleOnClick");
            _scaleDurationOnClick = serializedObject.FindProperty("scaleDurationOnClick");
            _colorOnHover = serializedObject.FindProperty("colorOnHover");
            _colorDurationOnHover = serializedObject.FindProperty("colorDurationOnHover");
            _colorOnClick = serializedObject.FindProperty("colorOnClick");
            _colorDurationOnClick = serializedObject.FindProperty("colorDurationOnClick");
            _audioSource = serializedObject.FindProperty("audioSource");
            _hoverEnterAudioClip = serializedObject.FindProperty("hoverEnterAudioClip");
            _hoverExitAudioClip = serializedObject.FindProperty("hoverExitAudioClip");
            _downAudioClip = serializedObject.FindProperty("downAudioClip");
            _upAudioClip = serializedObject.FindProperty("upAudioClip");
            _fillImageEaseType = serializedObject.FindProperty("fillImageEaseType");
            _fillImage = serializedObject.FindProperty("fillImage");
            _fillImageDuration = serializedObject.FindProperty("fillImageDuration");
            _hoverImage = serializedObject.FindProperty("hoverImage");
            _clickImage = serializedObject.FindProperty("clickImage");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            //EditorGUILayout.BeginHorizontal();
            //_useTemplate = EditorGUILayout.Toggle("UseTemplate", _useTemplate);
            //EditorGUI.BeginDisabledGroup(!_useTemplate);
            //EditorGUILayout.PropertyField(_template, new GUIContent(""));
            //EditorGUI.EndDisabledGroup();
            //EditorGUILayout.EndHorizontal();
            _useTemplate = false;
            EditorGUI.BeginDisabledGroup(_useTemplate);
            _tabIndex = GUILayout.Toolbar(_tabIndex, new[] {"Color", "Scale", "Audio", "Sprite", "Others"});
            switch (_tabIndex)
            {
                case 0:
                    EditorGUILayout.PropertyField(_useColorAnimationOnHover);
                    if (_useColorAnimationOnHover.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_colorOnHover);
                        EditorGUILayout.PropertyField(_colorDurationOnHover);
                        EditorGUILayout.EndVertical();
                        EditorGUI.indentLevel--;
                    }
                    EditorGUILayout.PropertyField(_useColorAnimationOnClick);
                    if (_useColorAnimationOnClick.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.Space(4);
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_colorOnClick);
                        EditorGUILayout.PropertyField(_colorDurationOnClick);
                        EditorGUILayout.EndVertical();
                        EditorGUI.indentLevel--;
                    }
                    break;
                case 1:
                    EditorGUILayout.PropertyField(_useScaleAnimationOnHover);
                    if (_useScaleAnimationOnHover.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_scaleEaseType);
                        EditorGUILayout.PropertyField(_scaleOnHover);
                        EditorGUILayout.PropertyField(_scaleDurationOnHover);
                        EditorGUILayout.EndVertical();
                        EditorGUI.indentLevel--;
                    }
                    EditorGUILayout.PropertyField(_useScaleAnimationOnClick);
                    if (_useScaleAnimationOnClick.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.Space(4);
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_scaleOnClick);
                        EditorGUILayout.PropertyField(_scaleDurationOnClick);
                        EditorGUILayout.EndVertical();
                        EditorGUI.indentLevel--;
                    }
                    break;
                case 2:
                    EditorGUILayout.PropertyField(_useAudioPlayer);
                    if (_useAudioPlayer.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_audioSource);
                        EditorGUILayout.Space(4);
                        EditorGUILayout.PropertyField(_hoverEnterAudioClip);
                        EditorGUILayout.PropertyField(_hoverExitAudioClip);
                        EditorGUILayout.PropertyField(_downAudioClip);
                        EditorGUILayout.PropertyField(_upAudioClip);
                        EditorGUILayout.EndVertical();
                        EditorGUI.indentLevel--;
                    }
                    break;
                case 3:
                    EditorGUILayout.PropertyField(_useImageChangerOnHover);
                    if (_useImageChangerOnHover.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_hoverImage);
                        EditorGUI.indentLevel--;
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.PropertyField(_useImageChangerOnClick);
                    if (_useImageChangerOnClick.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_clickImage);
                        EditorGUILayout.EndVertical();
                        EditorGUI.indentLevel--;
                    }
                    break;
                case 4:
                    EditorGUILayout.PropertyField(
                        _useFillAmountAnimation);
                    if (_useFillAmountAnimation.boolValue)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.BeginVertical(GUI.skin.box);
                        EditorGUILayout.PropertyField(_fillImageEaseType);
                        EditorGUILayout.PropertyField(_fillImage);
                        EditorGUILayout.PropertyField(_fillImageDuration);
                        EditorGUILayout.EndVertical();
                        EditorGUI.indentLevel--;
                    }
                    break;
            }
            EditorGUI.EndDisabledGroup();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}