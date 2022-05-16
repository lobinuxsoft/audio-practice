using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(GroundDetector))]

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float torqueSpeed = 20;
    [SerializeField] private float jumpSpeed = 6;
    [SerializeField] private float maxAngularVelocity = 180;
    private Rigidbody body;
    private GroundDetector gDetector;
    private Camera cam;

    private Vector3 inputDir = Vector3.zero;

    Vector3 forward;
    Vector3 right;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        
        gDetector = GetComponent<GroundDetector>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        forward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up);
        right = Vector3.ProjectOnPlane(cam.transform.right, Vector3.up);

        inputDir = Vector3.ClampMagnitude(forward * -Input.GetAxis("Horizontal") + right * Input.GetAxis("Vertical"), 1f);
        
        if (gDetector.OnGround && Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        body.angularDrag = maxAngularVelocity * .25f;
        body.maxAngularVelocity = maxAngularVelocity;
        
        body.AddTorque( torqueSpeed * inputDir, ForceMode.VelocityChange);
    }

    private void OnDrawGizmos()
    {
        if(!body) body = GetComponent<Rigidbody>();

        Handles.color = Color.yellow;
        Handles.CircleHandleCap(0, transform.position, Quaternion.LookRotation(Vector3.up), 1f, EventType.Repaint);

        

        Handles.color = Color.blue;
        Handles.SphereHandleCap(0, transform.position + forward, Quaternion.identity, .25f, EventType.Repaint);


        Handles.color = Color.red;
        Handles.SphereHandleCap(0, transform.position + right, Quaternion.identity, .25f, EventType.Repaint);


        Handles.color = Color.cyan;
        Handles.ArrowHandleCap(0, transform.position, Quaternion.LookRotation(body.velocity), Vector3.ClampMagnitude(body.velocity, 1).magnitude, EventType.Repaint);
        Handles.DrawWireArc(transform.position, Vector3.up, forward, Vector3.SignedAngle(forward, body.velocity, Vector3.up), Vector3.ClampMagnitude(body.velocity, 1).magnitude);
        Handles.color = new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, .25f);
        Handles.DrawSolidArc(transform.position, Vector3.up, forward, Vector3.SignedAngle(forward, body.velocity, Vector3.up), Vector3.ClampMagnitude(body.velocity, 1).magnitude);
    }
}
