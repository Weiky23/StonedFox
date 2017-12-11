using UnityEngine;
using UnityEditor;

namespace StonedFox.Configurations
{
    [CustomEditor(typeof(ScenesConfiguration))]
    public class ScenesConfigurationEditor : Editor
    {
        SerializedProperty scenesProperty;

        private void OnEnable()
        {
            scenesProperty = serializedObject.FindProperty(ScenesConfiguration.Scenes);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Scenes number", EditorStyles.boldLabel);
            EditorGUI.BeginChangeCheck();
            int count = EditorGUILayout.IntField(scenesProperty.arraySize);

            if (EditorGUI.EndChangeCheck())
            {
                scenesProperty.arraySize = count;
            }

            EditorGUILayout.LabelField("Scenes order", EditorStyles.boldLabel);

            

            for (int i = 0; i < count; i++)
            {
                SerializedProperty prop = scenesProperty.GetArrayElementAtIndex(i);
                EditorGUI.BeginChangeCheck();
                SerializedProperty sceneProp = prop.FindPropertyRelative(ScenePicker.ScenePath);
                SceneAsset oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(sceneProp.stringValue);
                SceneAsset newScene = EditorGUILayout.ObjectField(oldScene, typeof(SceneAsset), false) as SceneAsset;

                if (EditorGUI.EndChangeCheck())
                {
                    string newPath = AssetDatabase.GetAssetPath(newScene);
                    sceneProp.stringValue = newPath;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

    }
}
