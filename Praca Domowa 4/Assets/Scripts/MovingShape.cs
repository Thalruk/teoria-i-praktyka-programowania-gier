using UnityEngine;

public class MovingShape : MonoBehaviour
{
    Vector2 movementVector;
    [SerializeField] float speed;

    void Update()
    {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(speed * Time.deltaTime * movementVector);
    }
}
