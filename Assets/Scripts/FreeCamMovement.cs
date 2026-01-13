using UnityEngine;

public class FreeCamMovement : MonoBehaviour
{

    private Camera Camera;

    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    void Update()
    {
        GetInput();
        CameraZoom();
    }

    private void CameraZoom()
    {
        float zoomSpeed = 10f;
        float fovChange = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Camera.fieldOfView -= fovChange;
        Camera.fieldOfView = Mathf.Clamp(Camera.fieldOfView, 20f, 100f);
    }

    private void GetInput()
    {
        float rotationSpeed = 100f;

        // Rotation
        if (Input.GetKey(KeyCode.E)) transform.Rotate(Vector3.down, (rotationSpeed * Time.deltaTime), Space.Self);
        if (Input.GetKey(KeyCode.Q)) transform.Rotate(Vector3.down, -(rotationSpeed * Time.deltaTime), Space.Self);
        if (Input.GetMouseButton(1)) transform.Rotate(Vector3.down, -(Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime), Space.Self);

        float speed = 10f;

        // Movement 
        if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
}
