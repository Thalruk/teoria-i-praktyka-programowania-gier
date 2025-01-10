using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    MapGenerator m_MapGenerator;
    [SerializeField] LayerMask m_LayerMask;
    [SerializeField] float movesPerSecond;


    [SerializeField] List<GameObject> openList;
    [SerializeField] List<GameObject> closedList;
    Dictionary<GameObject, float> gScore;
    Dictionary<GameObject, float> fScore;
    Dictionary<GameObject, GameObject> cameFrom = new Dictionary<GameObject, GameObject>();

    [Space]
    [SerializeField] List<GameObject> path;


    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;

    private void Start()
    {
        m_MapGenerator = MapGenerator.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                path = FindPath(m_MapGenerator.mapData[(int)transform.position.x, (int)transform.position.y], hit.collider.gameObject);

                if (path.Count > 0)
                {
                    foreach (GameObject item in path)
                    {
                        print($"{item.transform.position}");
                    }
                }
                else
                {
                    print("Path DONT exists");
                }
            }
        }

        time += Time.deltaTime;

        if (path.Count > 0)
        {
            if (time >= interpolationPeriod)
            {
                time = 0.0f;

                MoveOnPathOnce(path);
            }
        }
    }

    private void MoveOnPathOnce(List<GameObject> path)
    {
        transform.position = path[0].transform.position;
        path.Remove(path[0]);
    }

    public List<GameObject> FindPath(GameObject start, GameObject goal)
    {
        cameFrom.Clear();
        openList = new List<GameObject> { start };
        List<GameObject> closedList = new List<GameObject>();
        Dictionary<GameObject, float> gScore = new Dictionary<GameObject, float>();
        Dictionary<GameObject, float> fScore = new Dictionary<GameObject, float>();

        for (int x = 0; x < m_MapGenerator.width; x++)
        {
            for (int y = 0; y < m_MapGenerator.height; y++)
            {
                gScore[m_MapGenerator.mapData[x, y]] = float.MaxValue;
                fScore[m_MapGenerator.mapData[x, y]] = float.MaxValue;
            }
        }

        gScore[start] = 0;
        fScore[start] = Heuristic(start, goal);

        while (openList.Count > 0)
        {
            GameObject current = GetTileWithLowestF(openList, fScore);

            if (current == goal)
                return ReconstructPath(cameFrom, current);

            openList.Remove(current);
            closedList.Add(current);

            foreach (GameObject neighbor in GetNeighbors(current))
            {
                if (closedList.Contains(neighbor)) continue;

                float tentativeGScore = gScore[current] + neighbor.GetComponent<Tile>().data.moveCost;

                if (!openList.Contains(neighbor))
                    openList.Add(neighbor);
                else if (tentativeGScore >= gScore[neighbor])
                    continue;

                cameFrom[neighbor] = current;
                gScore[neighbor] = tentativeGScore;
                fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor, goal);
            }
        }

        return null;
    }

    private float Heuristic(GameObject first, GameObject second)
    {
        return Mathf.Abs(first.transform.position.x - second.transform.position.x) + Mathf.Abs(first.transform.position.y - second.transform.position.y);
    }

    private GameObject GetTileWithLowestF(List<GameObject> openList, Dictionary<GameObject, float> fScore)
    {
        GameObject bestTile = openList[0];
        float bestFScore = fScore[bestTile];

        foreach (var tile in openList)
        {
            if (fScore[tile] < bestFScore)
            {
                bestTile = tile;
                bestFScore = fScore[tile];
            }
        }

        return bestTile;
    }

    private List<GameObject> GetNeighbors(GameObject tile)
    {
        List<GameObject> neighbors = new List<GameObject>();

        foreach (Vector2 offset in new Vector2[] { new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(-1, 0) })
        {
            int neighborX = (int)(tile.transform.position.x + offset.x);
            int neighborY = (int)(tile.transform.position.y + offset.y);

            if (neighborX >= 0 && neighborX < m_MapGenerator.width && neighborY >= 0 && neighborY < m_MapGenerator.height)
                neighbors.Add(m_MapGenerator.mapData[neighborX, neighborY]);
        }

        return neighbors;
    }

    private List<GameObject> ReconstructPath(Dictionary<GameObject, GameObject> cameFrom, GameObject current)
    {
        List<GameObject> path = new List<GameObject>();

        while (current != null && cameFrom.ContainsKey(current))
        {
            path.Add(current);
            current = cameFrom[current];
        }

        path.Reverse();
        return path;
    }
}
