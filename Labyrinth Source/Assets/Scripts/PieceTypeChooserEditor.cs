#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace Labyrinth
{
    [CustomEditor(typeof(PieceTypeChooser))]
    [CanEditMultipleObjects]
    public class PieceTypeChooserEditor : Editor
    {
        private SerializedProperty _typePlaceholderProperty;
        private SerializedProperty _typeObjectiveProperty;
        private SerializedProperty _previousTypeProperty;
        private SerializedProperty _clearProperty;

        private Boolean _boolCheck = new Boolean();

        private void OnEnable()
        {
            _typePlaceholderProperty = serializedObject.FindProperty("_typePlaceholder");
            _typeObjectiveProperty = serializedObject.FindProperty("_typeObjective");
            _previousTypeProperty = serializedObject.FindProperty("_previousType");
            _clearProperty = serializedObject.FindProperty("_clear");
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            if (_boolCheck.AnyIsTrue(_typeObjectiveProperty.boolValue, _typePlaceholderProperty.boolValue))
            {
                if (_clearProperty.boolValue = GUILayout.Button("Clear"))
                {
                    Clear();
                }
                return;
            }

            if (_typePlaceholderProperty.boolValue = EditorGUILayout.Toggle("Set As Placeholder", _typePlaceholderProperty.boolValue))
            {
                SetType(typeof(TypePlaceHolder));
            }

            if (_typeObjectiveProperty.boolValue = EditorGUILayout.Toggle("Set As Objective", _typeObjectiveProperty.boolValue))
            {
                SetType(typeof(TypeObjective));
            }

            void Clear()
            {
                _clearProperty.boolValue = false;
                _typePlaceholderProperty.boolValue = false;
                _typeObjectiveProperty.boolValue = false;

                serializedObject.ApplyModifiedProperties();

                DestroyComponent();
            }

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        private void SetType(Type type)
        {
            if (_previousTypeProperty.objectReferenceValue?.GetType() == type) return;

            var ptc = (PieceTypeChooser)target;
            _previousTypeProperty.objectReferenceValue = ptc.gameObject.AddComponent(type);
        }

        public void DestroyComponent()
        {
            if (_previousTypeProperty.objectReferenceValue != null)
                DestroyImmediate(_previousTypeProperty.objectReferenceValue);
        }
    }
}
#endif