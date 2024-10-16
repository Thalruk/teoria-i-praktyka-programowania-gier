using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoShower : MonoBehaviour
{
    public static InfoShower Instance;

    [SerializeField] private static GameObject infoText;
    [SerializeField] private static float showTime;

    static GameObject imageShower;

    private void Start()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
        infoText = GameObject.Find("TextShowInfo");
        imageShower = GameObject.Find("PickaupImage");

    }

    public void ShowText(string text, float time)
    {
        infoText.GetComponent<TextMeshProUGUI>().text = text;
        showTime += time;
    }

    public void StopShowingText()
    {
        infoText.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }

    public void ShowImage(Sprite sprite, float time)
    {
        imageShower.GetComponent<Image>().sprite = sprite;
        imageShower.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Invoke(nameof(StopShowingImage), time);
    }

    public void StopShowingImage()
    {
        imageShower.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    private void Update()
    {
        if (showTime > -1)
        {
            showTime -= Time.deltaTime;
        }
        if (showTime <= 0)
        {
            StopShowingText();
        }
    }
}
