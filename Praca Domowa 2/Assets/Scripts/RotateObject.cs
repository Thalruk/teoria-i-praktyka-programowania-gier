using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    void LateUpdate()
    {
        float rotAmount = rotateSpeed * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }
}
