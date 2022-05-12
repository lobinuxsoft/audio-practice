using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CheckPointTrigger : MonoBehaviour
{
    private const string keyName = "CheckPoint";
    [SerializeField] private int checkPointID;
    
    private BoxCollider box;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        box.isTrigger = true;

        if (PlayerPrefs.HasKey(keyName))
        {
            if (PlayerPrefs.GetInt(keyName) == checkPointID)
            {
                GameObject.FindWithTag("Player").transform.position = transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(keyName, checkPointID);
        }
    }

#if UNITY_EDITOR
    public Color gizmoColor = Color.green;
    private GUIStyle labelStyle;
    private void OnDrawGizmos()
    {
        if (labelStyle == null)
        {
            labelStyle = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Game).label;
            labelStyle.richText = true;
            labelStyle.alignment = TextAnchor.MiddleCenter;
        }

        if (!box) box = GetComponent<BoxCollider>();
        
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(box.center, box.size);
        Gizmos.color = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b, .25f);
        Gizmos.DrawCube(box.center, box.size);
        string text = $"<color=#{ColorUtility.ToHtmlStringRGB(gizmoColor)}><b>{keyName} {checkPointID}</b></color>";
        Handles.matrix = transform.localToWorldMatrix;
        Handles.Label(box.center, text, labelStyle);
    }
#endif
}
