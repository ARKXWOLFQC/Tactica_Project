using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamPivot : MonoBehaviour
{

    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float RotationSpeed = 10f;
    [SerializeField] private float CamMoveSpeed = 10f;
    [SerializeField] private FreeCamMovement Cam;

    private InputActionMap action;
    private Vector2 RotationInput;
    private Vector2 XMovement;

    private void OnEnable()
    {
        action = GetComponent<PlayerInput>().currentActionMap;
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }
    public void UpdatePos(Vector3 _position)
    {
        transform.position = _position;
    }

    private void Update()
    {
        transform.Translate(XMovement.x * CamMoveSpeed * Time.deltaTime, transform.position.y, XMovement.y * CamMoveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up, (RotationInput.y - RotationInput.x)*RotationSpeed*Time.deltaTime);
    }

    private void OnZoom(InputValue value)
    {
        var v = value.Get<Vector2>();
        Cam.Zoom(v);
        
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
