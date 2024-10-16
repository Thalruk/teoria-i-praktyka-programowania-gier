public class Pistol : Interactable
{
    public override void Interact()
    {
        InfoShower.Instance.ShowText("You have more ammo!", 2f);
    }
}
