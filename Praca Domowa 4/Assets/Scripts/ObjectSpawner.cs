using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject triangle;
    [SerializeField] int triangleCount;
    [SerializeField] GameObject square;
    [SerializeField] int squareCount;
    void Start()
    {
        SpawnObjects(triangle, triangleCount);
        SpawnObjects(square, squareCount);
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObjects(GameObject gameObject, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(gameObject, spawnPosition, Quaternion.identity, transform);
        }
    }
}
