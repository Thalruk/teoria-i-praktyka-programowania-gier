using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int minStartFood;
    [SerializeField] int maxStartFood;

    [SerializeField] public int maxFood;
    [SerializeField] public int currentFood;

    public float smallFoodAmountThreshold = 0.5f;

    [SerializeField] Slider foodSlider;
    [SerializeField] int foodCenterAmount;

    public Dictionary<FoodCenter, int> foodCenterList;

    private void Awake()
    {
        foodCenterList = new Dictionary<FoodCenter, int>();
        maxFood = Random.Range(minStartFood, maxStartFood);
        currentFood = maxFood;
        foodSlider.maxValue = maxFood;
        foodSlider.value = currentFood;
    }

    private void Update()
    {
        foodCenterAmount = foodCenterList.Count;
    }
    public void UpdateFoodSLider()
    {
        foodSlider.value = currentFood;
    }

    public List<Player> GetAllPlayersButThisOne()
    {
        List<Player> players = FindObjectsOfType<Player>().ToList();
        players.Remove(this);

        return players;
    }
}
