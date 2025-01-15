using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionData : MonoBehaviour
{
    [SerializeField] List<GameObject> possibleCollisions;
    [SerializeField] int checkRadius = 1;
    [SerializeField] Color baseColor;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = baseColor;
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

        foreach (GameObject obj in possibleCollisions)
        {
            if (CollisionCheck.CheckCollision(gameObject, obj))
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = baseColor;
            }
        }
    }
}
