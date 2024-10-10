using TMPro;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Color baseColor;

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        baseColor = color;
    }
    public void Select(Color selectedColor)
    {
        GetComponent<SpriteRenderer>().color = selectedColor;
    }
    public void Deselect()
    {
        GetComponent<SpriteRenderer>().color = baseColor;
    }
}
