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

    public GameObject[,] mapData;
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
                await Task.Delay(1);
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
                await Task.Delay(1);
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
            await Task.Delay(1);
        }

        for (int x = roadStart; x <= roadEnd; x++)
        {
            GameObject tile = mapData[x, roadMiddle];
            tile.name = "Road";
            tile.GetComponent<SpriteRenderer>().color = Color.yellow;
            await Task.Delay(1);
        }

        for (int y = 0; y < roadMiddle; y++)
        {
            GameObject tile = mapData[roadEnd, y];
            tile.name = "Road";
            tile.GetComponent<SpriteRenderer>().color = Color.yellow;
            await Task.Delay(1);
        }
    }
    private void PlacePlayers()
    {
        Instantiate(playerObject, new Vector2(0, 0), Quaternion.identity);
        Instantiate(playerObject, new Vector2(width - 1, 0), Quaternion.identity);
        Instantiate(playerObject, new Vector2(0, height - 1), Quaternion.identity);
        Instantiate(playerObject, new Vector2(width - 1, height - 1), Quaternion.identity);
    }

    private async Task PlaceFoodCenters()
    {
        int foodCentersGenerated = 0;
        int foodCenters = Random.Range(minFoodCenters, maxFoodCenters);

        while (foodCentersGenerated < foodCenters)
        {
            int x = Random.Range(0, width - 1);
            int y = Random.Range(0, height - 1);

            if (mapData[x, y].name != "Water")
            {
                Instantiate(foodCenterObject, new Vector2(0, 0), Quaternion.identity);
                foodCentersGenerated++;
                await Task.Delay(1);
            }
        }

    }
}
