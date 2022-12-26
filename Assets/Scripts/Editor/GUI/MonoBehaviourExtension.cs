#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
#endif

namespace EditorExtension.GUI
{
#if UNITY_EDITOR
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class MonoBehaviourExtension : Editor
    {
        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspectorWithoutScriptField();
        }
    }
#endif
}