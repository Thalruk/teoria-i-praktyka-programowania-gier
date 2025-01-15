using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] int minStartFood;
    [SerializeField] int maxStartFood;

    [SerializeField] int maxFood;
    [SerializeField] int currentFood;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
        maxFood = Random.Range(minStartFood, maxStartFood);
    }
}
