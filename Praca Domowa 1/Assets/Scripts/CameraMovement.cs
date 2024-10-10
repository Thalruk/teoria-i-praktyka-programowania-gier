using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float panBorderThicnkess = 10f;

    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThicnkess)
        {
            pos.y += panSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThicnkess)
        {
            pos.y -= panSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThicnkess)
        {
            pos.x += panSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThicnkess)
        {
            pos.x -= panSpeed * Time.fixedDeltaTime;
        }

        transform.position = pos;
    }
}
