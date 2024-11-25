using UnityEngine;

public class MovingShape : MonoBehaviour
{
    Vector2 movementVector;
    float horizontal;
    float vertical;
    [SerializeField] float speed;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movementVector = new Vector2(horizontal, vertical).normalized;
        transform.Translate(movementVector * speed * Time.deltaTime);
    }
}
