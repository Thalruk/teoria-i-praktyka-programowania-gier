using UnityEngine;

public class RotateObjectAround : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject pivot;

    void Update()
    {
        RotateZ(rotationSpeed * Time.deltaTime * Mathf.Deg2Rad);
    }
    private void RotateZ(float rad)
    {
        Vector3 offset = transform.position - pivot.transform.position;

        float[,] zRotationMatrix = new float[2, 2];
        zRotationMatrix[0, 0] = Mathf.Cos(rad);
        zRotationMatrix[0, 1] = -Mathf.Sin(rad);

        zRotationMatrix[1, 0] = Mathf.Sin(rad);
        zRotationMatrix[1, 1] = Mathf.Cos(rad);

        float newX = offset.x * zRotationMatrix[0, 0] + offset.y * zRotationMatrix[0, 1];
        float newY = offset.x * zRotationMatrix[1, 0] + offset.y * zRotationMatrix[1, 1];

        transform.position = new Vector2(newX, newY) + (Vector2)pivot.transform.position;
        transform.Rotate(0, 0, rad * Mathf.Rad2Deg);
    }
}
