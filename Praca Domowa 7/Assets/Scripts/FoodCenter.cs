using UnityEngine;

public class FoodCenter : MonoBehaviour
{
    [SerializeField] int minFood;
    [SerializeField] int maxFood;

    [SerializeField] public int currentFood;

    private void Start()
    {
        currentFood = Random.Range(minFood, maxFood);
    }

    private void Update()
    {
        if (currentFood == 0)
        {
            foreach (Player player in MapGenerator.Instance.players)
            {
                player.foodCenterList.Remove(this);
            }
            MapGenerator.Instance.foodCenters.Remove(this);
            Destroy(gameObject);
        }
    }
}
