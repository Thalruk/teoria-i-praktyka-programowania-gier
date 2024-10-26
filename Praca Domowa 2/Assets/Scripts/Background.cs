using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float speed;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    private void Update()
    {
        rend.material.mainTextureOffset += new Vector2(0, speed / 10 * Time.deltaTime);
    }
}
