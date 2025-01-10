using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    MapGenerator m_MapGenerator;
    private void Start()
    {
        m_MapGenerator = MapGenerator.Instance;
    }
    public List<GameObject> FindPath(GameObject start, GameObject goal)
    {
        List<GameObject> openList = new List<GameObject> { start };
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
                return ReconstructPath(current);

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
            int nx = (int)(tile.transform.position.x + offset.x);
            int ny = (int)(tile.transform.position.y + offset.y);

            if (nx >= 0 && nx < m_MapGenerator.width && ny >= 0 && ny < m_MapGenerator.height)
                neighbors.Add(m_MapGenerator.mapData[nx, ny]);
        }

        return neighbors;
    }

    private List<GameObject> ReconstructPath(GameObject current)
    {
        List<GameObject> path = new List<GameObject>();

        while (current != null)
        {
            path.Add(current);
        }

        path.Reverse();
        return path;
    }

}
