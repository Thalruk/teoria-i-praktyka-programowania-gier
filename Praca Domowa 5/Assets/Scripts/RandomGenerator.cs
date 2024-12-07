using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    const int m = 8388608;
    const int a = 33;
    const int c = 17724701;
    const int seed = 8388608 / 3;

    static int lastValue = -1;

    public static int GenerateNextNumber()
    {
        if (lastValue == -1)
        {
            lastValue = (a * seed + c) % m;
            return lastValue;
        }
        else
        {
            lastValue = (a * lastValue + c) % m;
            return lastValue;
        }
    }
}
