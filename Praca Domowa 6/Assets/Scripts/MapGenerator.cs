using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Tiles))]
public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance;

    private Tiles tiles;
    [SerializeField] GameObject tileObject;
    [SerializeField] GameObject playerObject;

    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] int treeAmount;
    [SerializeField] int scale;

    public GameObject[,] mapData;
    int riverStart;
    int riverWidth;


    void Start()
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
        tiles = GetComponent<Tiles>();
        GenerateMap();
    }

    private void GenerateMap()
    {
        GenerateGrass();
        GenerateRiver();
        GenerateRoad();
        GenerateTrees();
        PlacePlayer();
    }

    private IEnumerator GenerateGrass()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tileObject, new Vector2(x, y), Quaternion.identity, transform);
                mapData[x, y] = tile;
                tile.name = tiles.tiles[0].name;
                tile.GetComponent<Tile>().data = tiles.tiles[0];
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private IEnumerator GenerateRiver()
    {
        riverWidth = Random.Range(0, width / 5);
        riverStart = Random.Range(width * 2 / 10, width * 8 / 10);

        for (int x = riverStart; x < riverStart + riverWidth; x++)
        {
            for (int y = 0; y < height; y++)
            {
                mapData[x, y].GetComponent<Tile>().UpdateData(tiles.tiles[1]);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private IEnumerator GenerateRoad()
    {
        int roadStart = Random.Range(0, riverStart - riverWidth);

        int roadEnd = Random.Range(riverStart + riverWidth, width - 1);

        int roadMiddle = Random.Range(0, height);

        for (int y = height - 1; y > roadMiddle; y--)
        {
            mapData[roadStart, y].GetComponent<Tile>().UpdateData(tiles.tiles[2]);
            yield return new WaitForSeconds(0.1f);
        }

        for (int x = roadStart; x <= roadEnd; x++)
        {
            mapData[x, roadMiddle].GetComponent<Tile>().UpdateData(tiles.tiles[2]);
            yield return new WaitForSeconds(0.1f);
        }

        for (int y = 0; y < roadMiddle; y++)
        {
            mapData[roadEnd, y].GetComponent<Tile>().UpdateData(tiles.tiles[2]);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void GenerateTrees()
    {
        int createdTrees = 0;

        while (createdTrees < treeAmount)
        {
            int x = Random.Range(0, width - 1);
            int y = Random.Range(0, height - 1);

            Tile tile = mapData[x, y].GetComponent<Tile>();

            if (tile.data.name == "Grass")
            {
                tile.UpdateData(tiles.tiles[3]);
                createdTrees++;
            }
        }
    }


    private void PlacePlayer()
    {
        bool playerPlaced = false;
        while (playerPlaced == false)
        {
            int x = Random.Range(0, width - 1);
            int y = Random.Range(0, height - 1);

            Tile tile = mapData[x, y].GetComponent<Tile>();

            if (tile.data.name != "Water")
            {
                Instantiate(playerObject, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
