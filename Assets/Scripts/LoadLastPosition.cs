using UnityEngine;

public class LoadLastPosition : MonoBehaviour
{
    [SerializeField] bool loadOnStart = true;
    [SerializeField] Vector3Variable lastPos;

    // Start is called before the first frame update
    void Start()
    {
        if (loadOnStart) 
        {
            LoadPosition();
        }

    }

    public void LoadPosition()
    {
        lastPos.LoadData();
        transform.position = new Vector3(lastPos.Value.x, lastPos.Value.y, lastPos.Value.z);
    }
}
