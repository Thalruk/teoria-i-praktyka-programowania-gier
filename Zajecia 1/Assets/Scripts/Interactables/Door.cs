using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(1);
        }
        else
        {
            message = noKeyMessage;
        }
        CharacterUIManager.Instance.UpdateHelpingText(message);
    }
}
