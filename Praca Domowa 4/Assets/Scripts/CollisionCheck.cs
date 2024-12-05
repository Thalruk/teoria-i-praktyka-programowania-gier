using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    /// <summary>
    /// find bounding shape, edges will be projecting axis of shape,
    /// for square, bigger square,
    /// for triangle, bigger triangle with right rotation
    /// this will allow to skip complicated math
    /// then project each wall, with right comparison
    /// check each edge projected on shape
    /// if there is gap return false
    /// if there is no gap, keep going
    /// if all edges had been checked return true
    /// </summary>
    /// <returns></returns>
    public static bool CheckForCollisions(GameObject first, GameObject second)
    {
        int firstVerticeCount = first.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.vertices.Length;
        int secondVerticeCount = second.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.vertices.Length;

        print($"FIRST   {first.GetComponent<SpriteRenderer>().sprite.vertices.Length}");
        print($"SECOND   {second.GetComponent<SpriteRenderer>().sprite.vertices.Length}");

        print($"FIRST   {first.GetComponent<SpriteRenderer>().sprite.vertices.Length}");
        return false;
    }

    public List<Vector2> GetVertices(GameObject obj)
    {
        return obj.GetComponent<SpriteRenderer>().sprite.vertices.ToList<Vector2>();
    }



    //private void OnDrawGizmos()
    //{
    //    if (possibleCollisions.Count != 0)
    //    {
    //        Vector2[] vertices = gameObject.GetComponent<SpriteRenderer>().sprite.vertices;
    //        Vector2[] axis = new Vector2[vertices.Length];

    //        foreach (GameObject otherOb in possibleCollisions)
    //        {
    //            //print($"{i} --- {(i + 1) % vertices.Length}");
    //            //axis[i] = new Vector2(vertices[i].x - vertices[(i + 1) % vertices.Length].x, vertices[i].y - vertices[(i + 1) % vertices.Length].y);

    //            //axis[0] = Vector2.Perpendicular(otherVertices[0] - otherVertices[2]);
    //            //axis[1] = Vector2.Perpendicular(otherVertices[2] - otherVertices[1]);
    //            //axis[2] = Vector2.Perpendicular(otherVertices[1] - otherVertices[3]);
    //            //axis[3] = Vector2.Perpendicular(otherVertices[3] - otherVertices[0]);

    //            for (int i = 0; i < axis.Length; i++)
    //            {
    //                foreach (Vector2 vertice in vertices)
    //                {
    //                    Gizmos.DrawWireSphere(transform.position + Vector3.Project(vertice, axis[i]), 0.1f);

    //                }

    //                DrawLine(gameObject, axis[i]);
    //            }
    //        }
    //    }
    //}

    private void DrawLine(GameObject ob, Vector2 pos)
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine((Vector2)ob.transform.position + pos, (Vector2)ob.transform.position - pos);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, 0.5f);
    }
}
