using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticleSystem;
    private BoxCollider2D boxCollider;
    private SpriteRenderer rbSpriteRenderer;

    private Rigidbody2D rb2d;

    [SerializeField] float speed;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rbSpriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.up * speed);
    }

    private void FixedUpdate()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        if (pos.y >= Screen.height - 20)
        {
            explosionParticleSystem.Play();
            rbSpriteRenderer.enabled = false;
            boxCollider.enabled = false;
            Destroy(gameObject, 1);
        }
    }
}
