//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(Song))]
//public class SongGUI : Editor
//{
//    SerializedProperty rings2;
//    private void OnEnable()
//    {
//        rings2 = serializedObject.FindProperty("rings2");
//    }
//    public override void OnInspectorGUI()
//    {
//        EditorGUILayout.LabelField("Custom editor:");
//        var serializedObject = new SerializedObject(target);
        
//        serializedObject.Update();
//        EditorGUILayout.PropertyField(rings2, true);
//        serializedObject.ApplyModifiedProperties();
//    }
//}