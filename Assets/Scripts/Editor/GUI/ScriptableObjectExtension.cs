using UnityEngine;
using UnityEditor;

namespace EditorExtension.GUI
{
    [CustomEditor(typeof(ScriptableObject), true)]
    public class ScriptableObjectExtension : Editor
    {
        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspectorWithoutScriptField();
        }
    }
}