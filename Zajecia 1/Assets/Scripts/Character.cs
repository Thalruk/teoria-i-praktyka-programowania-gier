using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    [SerializeField] float MaxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] float MaxStamina;
    [SerializeField] float currentStamina;

    [SerializeField] AudioClip gunShootSound;


    [SerializeField] int ammo = 0;
    [SerializeField] bool hasKey = false;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject bulletHole;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        Cursor.lockState = CursorLockMode.Locked;

        currentHealth = MaxHealth / 2;
        currentStamina = MaxStamina / 2;
    }



    private void Start()
    {
        CharacterUIManager.Instance.UpdateHealthBar(currentHealth);
        CharacterUIManager.Instance.UpdateStaminaBar(currentStamina);
        CharacterUIManager.Instance.UpdateAmmoCounter(0);
    }


    private void Update()
    {
        if (currentHealth == 0)
        {
            Application.Quit();
        }

        if (ammo != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2)), out hit, 100))
                {
                    UseAmmo(1);
                    ParticleSystem explosionInstance = Instantiate(explosion, hit.point, Quaternion.identity);
                    Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    Destroy(explosionInstance, 2);
                    PlaySound(gunShootSound);
                }
            }
        }


    }
    public bool GetKey()
    {
        return hasKey;
    }
    public void PickUpKey()
    {
        hasKey = true;
    }

    public void AddAmmo(int value)
    {
        ammo += value;
        CharacterUIManager.Instance.UpdateAmmoCounter(ammo);
    }

    public void UseAmmo(int value)
    {
        ammo -= value;
        CharacterUIManager.Instance.UpdateAmmoCounter(ammo);
    }


    public void Heal(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, MaxHealth);
        CharacterUIManager.Instance.UpdateHealthBar(currentHealth);
    }

    public void Damage(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth - value, 0, MaxHealth);
        CharacterUIManager.Instance.UpdateHealthBar(currentHealth);
    }

    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    public void UseStamina(float value)
    {
        currentStamina = Mathf.Clamp(currentStamina - value, 0, MaxStamina);
        CharacterUIManager.Instance.UpdateStaminaBar(currentStamina);
    }

    public void RegenStamina(float value)
    {
        currentStamina = Mathf.Clamp(currentStamina + value, 0, MaxStamina);
        CharacterUIManager.Instance.UpdateStaminaBar(currentStamina);
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public float GetMaxStamina()
    {
        return MaxStamina;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
