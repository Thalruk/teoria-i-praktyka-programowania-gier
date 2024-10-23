using UnityEngine;

public class Medpack : Interactable
{
    void LateUpdate()
    {
        transform.Rotate(new Vector3(0, 1, 0), 90 * Time.deltaTime);
    }

    public override void Interact()
    {
        Character.Instance.Heal(20);
    }
}
