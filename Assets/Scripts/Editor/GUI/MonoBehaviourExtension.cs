using UnityEngine;
using UnityEditor;

namespace EditorExtension.GUI
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class MonoBehaviourExtension : Editor
    {
        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspectorWithoutScriptField();
        }
    }
}