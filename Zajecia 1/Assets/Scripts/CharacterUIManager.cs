using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    public static CharacterUIManager Instance;

    [SerializeField] Slider healthSlider;
    [SerializeField] Image HealthSliderFill;
    [SerializeField] Slider staminaSlider;

    [SerializeField] TextMeshProUGUI ammoCounter;
    [SerializeField] Image crosshair;

    [SerializeField] TextMeshProUGUI infoText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        healthSlider.maxValue = Character.Instance.GetMaxHealth();
        staminaSlider.maxValue = Character.Instance.GetMaxStamina();
    }

    public void UpdateHealthBar(float value)
    {
        healthSlider.value = value;

        if (value > Character.Instance.GetMaxHealth() / 2)
        {
            HealthSliderFill.color = Color.red;
        }
        if (value <= Character.Instance.GetMaxHealth() / 2 && value >= Character.Instance.GetMaxHealth() / 4)
        {
            HealthSliderFill.color = new Color(255, 70, 0);
        }
        if (value < Character.Instance.GetMaxHealth() / 4)
        {
            HealthSliderFill.color = Color.yellow;
        }
    }
    public void UpdateStaminaBar(float value)
    {
        staminaSlider.value = value;
    }

    public void UpdateAmmoCounter(int value)
    {
        if (value == 0)
        {
            crosshair.enabled = false;
            ammoCounter.enabled = false;
        }
        else
        {
            crosshair.enabled = true;
            ammoCounter.enabled = true;
        }
        ammoCounter.text = value.ToString();
    }

    public void UpdateHelpingText(string text)
    {
        infoText.text = text;
        Invoke(nameof(StopHelpingText), 5);
    }

    private void StopHelpingText()
    {
        infoText.text = string.Empty;
    }
}
