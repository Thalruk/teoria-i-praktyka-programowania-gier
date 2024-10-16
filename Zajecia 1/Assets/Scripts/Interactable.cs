using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    [SerializeField] private Sprite image;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Interact();
            InfoShower.Instance.ShowImage(image, 1f);
            Destroy(gameObject);
        }

    }
}
