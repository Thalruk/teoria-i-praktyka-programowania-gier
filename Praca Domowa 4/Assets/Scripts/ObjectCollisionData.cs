using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionData : MonoBehaviour
{
    [SerializeField] List<GameObject> possibleCollisions;
    [SerializeField] int checkRadius = 1;
    [SerializeField] bool checkEveryFrame = false;

    private void Start()
    {
        CheckForPossibleCollisions();
    }

    private void Update()
    {
        CheckForPossibleCollisions();
    }

    public void CheckForPossibleCollisions()
    {
        possibleCollisions.Clear();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);

        foreach (Collider2D coll in colliders)
        {
            possibleCollisions.Add(coll.gameObject);
        }

        possibleCollisions.Remove(gameObject);

        if (possibleCollisions.Count > 0)
        {
            foreach (GameObject obj in possibleCollisions)
            {
                CollisionCheck.CheckForCollisions(gameObject, obj);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (GetComponent<SpriteRenderer>().sprite.vertices.Length == 4)
        {
            Sprite spr = GetComponent<SpriteRenderer>().sprite;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + (Vector3)spr.vertices[0], 0.1f);
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position + (Vector3)spr.vertices[1], 0.1f);
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position + (Vector3)spr.vertices[2], 0.1f);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position + (Vector3)spr.vertices[3], 0.1f);
        }
        else if (GetComponent<SpriteRenderer>().sprite.vertices.Length == 3)
        {
            Sprite spr = GetComponent<SpriteRenderer>().sprite;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + (Vector3)spr.vertices[0], 0.1f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + (Vector3)spr.vertices[1], 0.1f);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position + (Vector3)spr.vertices[2], 0.1f);
        }
    }
}
