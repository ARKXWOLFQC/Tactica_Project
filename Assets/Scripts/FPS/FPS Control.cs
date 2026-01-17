using UnityEngine;
using UnityEngine.InputSystem;

public class FPSControl : MonoBehaviour
{
    private InputActionMap action;

    void OnEnable()
    {
        action = GetComponent<PlayerInput>().currentActionMap;
        if (action != null) action.Disable();
        action.Enable();
    }
    void OnDisable()
    {
        action.Disable();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnMove(InputValue value)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        var v = value.Get<Vector2>();
        rb.MovePosition(transform.position + transform.forward * v.y * Time.deltaTime + transform.right * v.x * Time.deltaTime);
    }

    public void OnLook(InputValue value)
    {
        var v = value.Get<Vector2>();
        transform.Rotate(Vector3.up, v.x, Space.World);
        Camera cam = GetComponentInChildren<Camera>();
        cam.transform.Rotate(Vector3.right, -v.y);
    }
}
