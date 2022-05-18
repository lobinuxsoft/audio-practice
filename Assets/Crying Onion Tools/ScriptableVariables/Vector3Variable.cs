using CryingOnionTools.ScriptableVariables;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector3 Variable", menuName = "Crying Onion Tools/ Scriptable Variables/ Vector3 Variable")]
public class Vector3Variable : ScriptableVariable<Vector3Struct>
{
    public new Vector3 Value
    {
        get => base.Value;
        set => base.Value = value;
    }

    public override void EraseData()
    {
        base.EraseData();
        value = Vector3.zero;
    }
}

[System.Serializable]
public struct Vector3Struct
{
    public float x;
    public float y;
    public float z;

    public static implicit operator Vector3(Vector3Struct vector3Struct)
    {
        return new Vector3(vector3Struct.x, vector3Struct.y, vector3Struct.z);
    }

    public static implicit operator Vector3Struct(Vector3 vector3)
    {
        return new Vector3Struct { x = vector3.x, y = vector3.y, z = vector3.z };
    }
}