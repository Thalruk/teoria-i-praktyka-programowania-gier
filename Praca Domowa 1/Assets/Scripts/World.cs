using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private HexSettings hexSettings;
    [SerializeField] private uint width;
    [SerializeField] private uint height;

    [SerializeField] private Hex hex;
    [SerializeField] private Hex[] world;
    private void Awake()
    {
        InitializeWorld();
    }

    private void InitializeWorld()
    {
        world = new Hex[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i);
            }
        }
    }
    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = x * 10f;
        position.y = 0f;
        position.z = z * 10f;

        Hex createdHex = Instantiate(hex);
        world[i] = createdHex;
        createdHex.transform.SetParent(transform, false);
        createdHex.transform.localPosition = position;
    }
}
