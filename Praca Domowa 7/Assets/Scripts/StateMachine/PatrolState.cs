using UnityEngine;

[CreateAssetMenu]
public class PatrolState : StateBase
{
    public override void StateEnter(StateMachine stateMachine)
    {
        Debug.Log($"{stateMachine.player.name} Entered {name}");
    }

    public override void StateUpdate(StateMachine stateMachine)
    {
        Vector2[] directions = { Vector2.left, Vector2.up, Vector2.right, Vector2.down };
        Vector2 movement = directions[Random.Range(0, directions.Length)];

        int newX = (int)Mathf.Clamp(stateMachine.player.transform.position.x + movement.x, 0, MapGenerator.Instance.width - 1);
        int newY = (int)Mathf.Clamp(stateMachine.player.transform.position.y + movement.y, 0, MapGenerator.Instance.height - 1);

        stateMachine.player.transform.position = new Vector2(newX, newY);

        stateMachine.player.currentFood = Mathf.Clamp(stateMachine.player.currentFood - 1, 0, stateMachine.player.maxFood);
        stateMachine.player.UpdateFoodSLider();


        if (stateMachine.player.currentFood < stateMachine.player.maxFood * stateMachine.player.smallFoodAmountThreshold)
        {
            Debug.Log($"{stateMachine.player.name} AAAAAAAAAAAAAAAAAAAAAAAA {stateMachine.player.currentFood}/ {stateMachine.player.maxFood * stateMachine.player.smallFoodAmountThreshold}");

            stateMachine.SetState(stateMachine.searchState);
        }

        foreach (FoodCenter foodCenter in MapGenerator.Instance.foodCenters)
        {
            if (stateMachine.player.transform.position == foodCenter.transform.position)
            {
                if (stateMachine.player.foodCenterList.ContainsKey(foodCenter))
                {
                    stateMachine.player.foodCenterList[foodCenter] = foodCenter.currentFood;
                }
                else
                {
                    stateMachine.player.foodCenterList.Add(foodCenter, foodCenter.currentFood);
                }

            }
        }


        foreach (Player player in stateMachine.player.GetAllPlayersButThisOne())
        {
            if (stateMachine.player.transform.position == player.transform.position)
            {
                stateMachine.SetState(stateMachine.talkState);
            }
        }

        if (stateMachine.player.currentFood == 0)
        {
            stateMachine.SetState(stateMachine.deathState);
        }
    }

    public override void StateExit(StateMachine stateMachine)
    {
    }
}
