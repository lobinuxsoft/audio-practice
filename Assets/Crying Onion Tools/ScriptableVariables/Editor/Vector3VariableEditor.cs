using CryingOnionTools.ScriptableVariables.Editor;
using UnityEditor;

[CustomEditor(typeof(Vector3Variable))]
public class Vector3VariableEditor : ScriptableVariableEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawInspector((Vector3Variable)target);
    }
}
