using UnityEngine;

public class Missle : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] float speed;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector2.up * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
