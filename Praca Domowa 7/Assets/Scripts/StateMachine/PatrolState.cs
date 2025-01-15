using UnityEngine;

[CreateAssetMenu]
public class PatrolState : StateBase
{
    Player player;
    [SerializeField] float timer = 0;

    public override void Enter()
    {
        player = Player.Instance;
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            RandomMove();
            timer = 0;
        }
    }

    public override void Exit()
    {
        Debug.Log("stop patroling");
    }

    private void RandomMove()
    {
        Vector2[] directions = { new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1) };
        Vector2 movement = directions[Random.Range(0, directions.Length)];

        if (player.transform.position.x + movement.x > MapGenerator.Instance.width)
        {
            movement = -movement;
        }

        if (player.transform.position.x + movement.x > MapGenerator.Instance.width)
        {
            movement = -movement;
        }

        if (player.transform.position.x + movement.x > MapGenerator.Instance.width)
        {
            movement = -movement;
        }

        if (player.transform.position.x + movement.x > MapGenerator.Instance.width)
        {
            movement = -movement;
        }
    }
}
