using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData data;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = data.color;
    }

    public void UpdateData(TileData newData)
    {
        data = newData;
        spriteRenderer.color = newData.color;
    }
}
