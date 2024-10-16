using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private GameObject hex;

    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private Color selectionColor;

    [SerializeField] private List<Collider2D> selectedHexes;
    void Awake()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 hexPosition = Vector3.zero;
                if (y % 2 == 0)
                {
                    hexPosition = new Vector3(x + (0.5f * x), (y * 0.8828125f) / 2, 0);
                }
                else
                {
                    hexPosition = new Vector3(0.75f + x + (0.5f * x), (y * 0.8828125f) / 2, 0);
                }
                GameObject newHex = Instantiate(hex, hexPosition, Quaternion.identity);
                newHex.name = $"hex {x}:{y}";
                newHex.GetComponent<Hex>().SetText($"{x},{y}");
                newHex.GetComponent<Hex>().SetColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            }

        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                foreach (Collider2D obj in selectedHexes)
                {
                    obj.GetComponent<Hex>().Deselect();
                }
                selectedHexes.Clear();

                List<Collider2D> objects = Physics2D.OverlapCircleAll(hit.transform.position, 0.75f).ToList<Collider2D>();

                objects.Remove(hit.collider);

                selectedHexes.AddRange(objects);

                foreach (Collider2D obj in selectedHexes)
                {
                    obj.GetComponent<Hex>().Select(selectionColor);
                }
            }
        }
    }
}
