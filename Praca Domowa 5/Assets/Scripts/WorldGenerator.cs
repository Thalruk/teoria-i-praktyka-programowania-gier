using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] int sizeX;
    [SerializeField] int sizeY;


    [SerializeField] GameObject grass;
    [SerializeField] GameObject water;
    [SerializeField] GameObject mountains;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                int rand = RandomGenerator.GenerateNextNumber() % 100;
                GameObject objectToSpawn = grass;
                if (rand <= 33)
                {
                    objectToSpawn = grass;
                }
                else if (rand > 33 && rand <= 66)
                {
                    objectToSpawn = water;
                }
                else if (rand > 66 && rand <= 100)
                {
                    objectToSpawn = mountains;
                }

                Instantiate(objectToSpawn, new Vector3(i, j), Quaternion.identity, transform);
            }
        }
    }
}
