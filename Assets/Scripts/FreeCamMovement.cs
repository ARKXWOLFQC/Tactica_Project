using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class FreeCamMovement : MonoBehaviour
{
    private InputActionMap action;

    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float RotationSpeed = 10f;
    [SerializeField] private float CamMoveSpeed = 10f;


    private void OnEnable()
    {
        action.Enable();
        action = GetComponent<PlayerInput>().currentActionMap;
    }
    private void OnDisable()
    {
        action.Disable();
    }
    void Start()
    {

    }
    

    void Update()
    {

    }

    private void OnZoom(InputValue value)
    {
        Camera cam = GetComponent<Camera>();
        var v = value.Get<float>();
        cam.fieldOfView = v * zoomSpeed * Time.deltaTime;
    }

    private void OnCamMove(InputValue value)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        var v = value.Get<Vector2>();
        rb.MovePosition(new Vector3(v.x, v.y, 0) * CamMoveSpeed * Time.deltaTime);
    }

    private void OnRotate(InputValue value)
    {
        var v = value.Get<KeyCode>();




        switch (v)
        {
            case KeyCode.Q:
                transform.Rotate(Vector3.up, -RotationSpeed * Time.deltaTime);
                break;
            case KeyCode.E:
                transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
                break;
            case KeyCode.Mouse2:
                Vector2 mousepos = Mouse.current.position.ReadValue();
                transform.Rotate(Vector3.up, mousepos.y * Time.deltaTime);
                break;
        }
    }

}
