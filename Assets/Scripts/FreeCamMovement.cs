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
    }
    private void OnDisable()
    {
        action.Disable();
    }
    void Start()
    {
        InputActionMap playerInput = GetComponent<PlayerInput>().currentActionMap;
        action = playerInput;

    }

    void Update()
    {
         switch (action.actions.ToString())
         {
            case "Zoom":
                Zoom(action.);
                break;
            case "Move Around":
                MoveCamera(action.ReadValue<Vector2>());
                break;
            case "Rotate":
                RotateCamera(action.ReadValue<KeyCode>());
                break;
            }
        }
    private void Zoom(int value)
    {
        Camera cam = GetComponent<Camera>();
        cam.fieldOfView = value * zoomSpeed * Time.deltaTime;
    }

    private void MoveCamera(Vector2 value)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(new Vector3(value.x, value.y, 0) * CamMoveSpeed * Time.deltaTime);
    }

    private void RotateCamera(KeyCode value)
    {
        switch (value)
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
