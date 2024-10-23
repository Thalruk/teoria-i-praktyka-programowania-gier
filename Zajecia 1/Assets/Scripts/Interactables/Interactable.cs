using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    [SerializeField] private AudioClip useSound;
    [SerializeField] private bool destroyObject = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Character.Instance.PlaySound(useSound);

            Interact();
            if (destroyObject)
            {
                Destroy(gameObject);
            }
        }
    }
}
