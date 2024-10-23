public class Key : Interactable
{
    public override void Interact()
    {
        Character.Instance.PickUpKey();
    }
}
