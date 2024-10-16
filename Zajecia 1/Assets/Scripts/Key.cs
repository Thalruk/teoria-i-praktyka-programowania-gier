public class Key : Interactable
{
    public override void Interact()
    {
        InfoShower.Instance.ShowText("You can open one more door!", 2f);
    }
}
