using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float timer;
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = $"{Mathf.Round(timer / 60f)} min::{Mathf.Round(timer % 60f)} sec";
    }
}
