using CryingOnionTools.ScriptableVariables;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector3 Variable", menuName = "Crying Onion Tools/ Scriptable Variables/ Vector3 Variable")]
public class Vector3Variable : ScriptableVariable<Vecto3Struct>
{
    public override void EraseData()
    {
        base.EraseData();
        value = new Vecto3Struct();
    }

    public void SetValue(Vector3 value)
    {
        this.value.x = value.x;
        this.value.y = value.y;
        this.value.z = value.z;
    }
}

[System.Serializable]
public struct Vecto3Struct
{
    public float x;
    public float y;
    public float z;
}