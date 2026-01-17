using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FreeCamMovement : MonoBehaviour
{
    private InputActionMap action;
    private Vector2 RotationInput;
    private Vector2 XMovement;

    private float yaw;
    private float pitch;

    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float RotationSpeed = 10f;
    [SerializeField] private float CamMoveSpeed = 10f;


    private void OnEnable()
    {
        action = GetComponent<PlayerInput>().currentActionMap;
        action.Enable();
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
        Vector3 point = Vector3.zero;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit result))
        {
            point = result.point;
        }

        yaw += RotationInput.x * RotationSpeed * Time.deltaTime;
        pitch -= RotationInput.y * RotationSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        UpdateCamera(point, Vector3.Distance(transform.position, point));

        transform.position = new Vector3(transform.position.x + XMovement.x * CamMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z + XMovement.y * CamMoveSpeed * Time.deltaTime);

    }

    private void UpdateCamera(Vector3 point, float distance)
    {
        Quaternion rotation = Quaternion.Euler(pitch, 0f, yaw);
        Vector3 offset = rotation * Vector3.back * distance;

        transform.position = point + offset;
        transform.rotation = rotation;
    }

    private void OnZoom(InputValue value)
    {
        Camera cam = GetComponent<Camera>();
        var v = value.Get<float>();
        cam.fieldOfView = v * zoomSpeed * Time.deltaTime;
    }

    private void OnCamMove(InputValue value)
    {
        XMovement = value.Get<Vector2>();
    }

    private void OnRotate(InputValue value)
    {
        print(value);
        RotationInput = value.Get<Vector2>();

    }

}
