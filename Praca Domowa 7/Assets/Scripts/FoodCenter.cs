using UnityEngine;

public class FoodCenter : MonoBehaviour
{
    [SerializeField] int minFood;
    [SerializeField] int maxFood;

    [SerializeField] int food;

    private void Start()
    {
        food = Random.Range(minFood, maxFood);
    }
}
