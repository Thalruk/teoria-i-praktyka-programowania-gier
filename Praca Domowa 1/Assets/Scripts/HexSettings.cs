using UnityEngine;

[CreateAssetMenu(fileName = "New Hex Settings", menuName = "Create new hex settings")]
public class HexSettings : ScriptableObject
{
    public const float outerRadius = 10f;
    public const float innerRadius = outerRadius * 0.866025404f;

}
