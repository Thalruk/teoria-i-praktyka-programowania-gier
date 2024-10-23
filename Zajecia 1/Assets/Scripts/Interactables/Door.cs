using UnityEngine;

public class Door : Interactable
{
    [SerializeField] string noKeyMessage;
    [SerializeField] string hasKeyMessage;

    public override void Interact()
    {
        string message = string.Empty;
        if (Character.Instance.GetKey())
        {
            message = hasKeyMessage;
        }
        else
        {
            message = noKeyMessage;
        }
        CharacterUIManager.Instance.UpdateHelpingText(message);
    }
}
