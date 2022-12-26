#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EditorExtension
{
    public static class EditorExtension
    {
#if UNITY_EDITOR
        public static bool DrawDefaultInspectorWithoutScriptField(this Editor Inspector)
        {
            EditorGUI.BeginChangeCheck();

            Inspector.serializedObject.Update();

            SerializedProperty Iterator = Inspector.serializedObject.GetIterator();

            Iterator.NextVisible(true);

            while (Iterator.NextVisible(false))
            {
                EditorGUILayout.PropertyField(Iterator, true);
            }

            Inspector.serializedObject.ApplyModifiedProperties();

            return (EditorGUI.EndChangeCheck());
        }
#endif
    }
}