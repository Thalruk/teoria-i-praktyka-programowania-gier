using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public static bool CheckCollision(GameObject first, GameObject second)
    {
        Vector2[] firstPoints = GetWorldVertices(first.GetComponent<SpriteRenderer>());
        Vector2[] secondPoints = GetWorldVertices(second.GetComponent<SpriteRenderer>());

        Vector2[] firstAxes = GetAxes(firstPoints);
        Vector2[] secondAxes = GetAxes(secondPoints);

        foreach (Vector2 axis in firstAxes)
        {
            if (!IsOverlapping(axis, firstPoints, secondPoints))
                return false;
        }

        foreach (Vector2 axis in secondAxes)
        {
            if (!IsOverlapping(axis, firstPoints, secondPoints))
                return false;
        }

        return true;
    }

    private static Vector2[] GetAxes(Vector2[] polygon)
    {
        Vector2[] axes = new Vector2[polygon.Length];
        for (int i = 0; i < polygon.Length; i++)
        {
            Vector2 edge = polygon[(i + 1) % polygon.Length] - polygon[i];
            axes[i] = new Vector2(-edge.y, edge.x).normalized;
        }
        return axes;
    }

    private static bool IsOverlapping(Vector2 axis, Vector2[] polygonA, Vector2[] polygonB)
    {
        (float minA, float maxA) = ProjectPolygon(axis, polygonA);
        (float minB, float maxB) = ProjectPolygon(axis, polygonB);

        return maxA >= minB && maxB >= minA;
    }

    private static (float min, float max) ProjectPolygon(Vector2 axis, Vector2[] polygon)
    {
        float min = Vector2.Dot(axis, polygon[0]);
        float max = min;

        for (int i = 1; i < polygon.Length; i++)
        {
            float projection = Vector2.Dot(axis, polygon[i]);
            if (projection < min) min = projection;
            if (projection > max) max = projection;
        }

        return (min, max);
    }

    private static Vector2[] GetWorldVertices(SpriteRenderer spriteRenderer)
    {
        Vector2[] localPoints = spriteRenderer.sprite.vertices;
        Vector2[] worldPoints = new Vector2[localPoints.Length];
        for (int i = 0; i < localPoints.Length; i++)
        {
            worldPoints[i] = spriteRenderer.transform.TransformPoint(localPoints[i]);
        }
        return worldPoints;
    }
}
