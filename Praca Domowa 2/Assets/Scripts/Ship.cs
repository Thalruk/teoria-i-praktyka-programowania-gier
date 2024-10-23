using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private GameObject missleSpawnersHolder;
    [SerializeField] private List<GameObject> missleSpawners;

    [SerializeField] private GameObject missles;

    [SerializeField] private GameObject misslePrefab;

    private void Awake()
    {
        foreach (Transform child in missleSpawnersHolder.transform)
        {
            missleSpawners.Add(child.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject spawner in missleSpawners)
            {
                GameObject missle = Instantiate(misslePrefab, spawner.transform.position, Quaternion.identity, missles.transform);
            }
        }
    }
}
