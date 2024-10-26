using UnityEngine;

public class RepeatingObject : MonoBehaviour
{
    [SerializeField] float StartY;
    [SerializeField] float EndY;
    [SerializeField] float speed;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, StartY, transform.position.z);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= EndY)
        {
            transform.position = new Vector3(transform.position.x, StartY, transform.position.z);
        }
    }
}
