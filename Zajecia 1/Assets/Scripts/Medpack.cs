using UnityEngine;

public class Medpack : Interactable
{
    void LateUpdate()
    {
        transform.Rotate(new Vector3(0, 1, 0), 90 * Time.deltaTime);
    }

    public override void Interact()
    {
        InfoShower.Instance.ShowText("Heal 50 hp!", 2f);
    }
}
