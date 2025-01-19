using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance;

    [SerializeField] GameObject tileObject;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject foodCenterObject;

    [SerializeField] int minFoodCenters;
    [SerializeField] int maxFoodCenters;

    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] int waitTime = 1;

    public GameObject[,] mapData;
    public List<FoodCenter> foodCenters;
    public List<Player> players;
    int riverStart;
    int riverWidth;


    async void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        mapData = new GameObject[width, height];
        await GenerateMap();
    }

    private async Task GenerateMap()
    {
        await GenerateGrass();
        await GenerateRiver();
        await GenerateRoad();

        PlacePlayers();

        await PlaceFoodCenters();
    }

    private async Task GenerateGrass()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tileObject, new Vector2(x, y), Quaternion.identity, transform);
                mapData[x, y] = tile;
                tile.name = "Grass";
                tile.GetComponent<SpriteRenderer>().color = Color.green;
                await Task.Delay(waitTime);
            }
        }
    }

    private async Task GenerateRiver()
    {
        riverWidth = Random.Range(0, width / 5);
        riverStart = Random.Range(width * 2 / 10, width * 8 / 10);

        for (int x = riverStart; x < riverStart + riverWidth; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = mapData[x, y];
                tile.name = "Water";
                tile.GetComponent<SpriteRenderer>().color = Color.cyan;
                await Task.Delay(waitTime);
            }
        }
    }

    private async Task GenerateRoad()
    {
        int roadStart = Random.Range(0, riverStart - riverWidth);

        int roadEnd = Random.Range(riverStart + riverWidth, width - 1);

        int roadMiddle = Random.Range(0, height);

        for (int y = height - 1; y > roadMiddle; y--)
        {
            GameObject tile = mapData[roadStart, y];
            tile.name = "Road";
            tile.GetComponent<SpriteRenderer>().color = Color.yellow;
            await Task.Delay(waitTime);
        }

        for (int x = roadStart; x <= roadEnd; x++)
        {
            GameObject tile = mapData[x, roadMiddle];
            tile.name = "Road";
            tile.GetComponent<SpriteRenderer>().color = Color.yellow;
            await Task.Delay(waitTime);
        }

        for (int y = 0; y < roadMiddle; y++)
        {
            GameObject tile = mapData[roadEnd, y];
            tile.name = "Road";
            tile.GetComponent<SpriteRenderer>().color = Color.yellow;
            await Task.Delay(waitTime);
        }
    }
    private void PlacePlayers()
    {
        GameObject player1 = Instantiate(playerObject, new Vector2(0, 0), Quaternion.identity);
        player1.name = "Player 1";
        GameObject player2 = Instantiate(playerObject, new Vector2(width - 1, 0), Quaternion.identity);
        player2.name = "Player 2";
        GameObject player3 = Instantiate(playerObject, new Vector2(0, height - 1), Quaternion.identity);
        player3.name = "Player 3";
        GameObject player4 = Instantiate(playerObject, new Vector2(width - 1, height - 1), Quaternion.identity);
        player4.name = "Player 4";

        players.Add(player1.GetComponent<Player>());
        players.Add(player2.GetComponent<Player>());
        players.Add(player3.GetComponent<Player>());
        players.Add(player4.GetComponent<Player>());
    }

    private async Task PlaceFoodCenters()
    {
        int foodCentersGenerated = 0;
        int foodCentersAmount = Random.Range(minFoodCenters, maxFoodCenters);

        while (foodCentersGenerated < foodCentersAmount)
        {
            int x = Random.Range(0, width - 1);
            int y = Random.Range(0, height - 1);

            if (mapData[x, y].name != "Water")
            {
                GameObject foodCenter = Instantiate(foodCenterObject, new Vector2(x, y), Quaternion.identity);
                foodCenter.name = $"FoodCenter {foodCentersGenerated}";
                foodCentersGenerated++;
                foodCenters.Add(foodCenter.GetComponent<FoodCenter>());
                await Task.Delay(waitTime);
            }
        }
    }
}
