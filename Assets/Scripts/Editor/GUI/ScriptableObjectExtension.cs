#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
#endif

namespace EditorExtension.GUI
{
#if UNITY_EDITOR
    [CustomEditor(typeof(ScriptableObject), true)]
    public class ScriptableObjectExtension : Editor
    {
        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspectorWithoutScriptField();
        }
    }
#endif
}