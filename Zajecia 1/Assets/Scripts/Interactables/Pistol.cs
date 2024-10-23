using UnityEngine;

public class Pistol : Interactable
{
    [SerializeField] int ammo;
    public override void Interact()
    {
        Character.Instance.AddAmmo(ammo);
    }
}
