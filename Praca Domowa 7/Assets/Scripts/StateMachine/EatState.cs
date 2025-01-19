using UnityEngine;

[CreateAssetMenu]
public class EatState : StateBase
{
    public override void StateEnter(StateMachine stateMachine)
    {
        Debug.Log($"{stateMachine.player.name} Entered {name}");
    }

    public override void StateUpdate(StateMachine stateMachine)
    {
        //JESC

        if (stateMachine.player.foodCenterList.Count > 0)
        {
            foreach (FoodCenter foodCenter in MapGenerator.Instance.foodCenters)
            {
                if (stateMachine.player.transform.position == foodCenter.transform.position)
                {

                    if (foodCenter.currentFood > 0 && stateMachine.player.currentFood < stateMachine.player.maxFood)
                    {
                        Debug.Log($"{stateMachine.player.name} EATS FROM  {foodCenter.name}");

                        stateMachine.player.currentFood += 1;
                        foodCenter.currentFood -= 1;
                        break;
                    }
                    else
                    {
                        if (stateMachine.player.currentFood < stateMachine.player.maxFood * stateMachine.player.smallFoodAmountThreshold)
                        {
                            Debug.Log($"{stateMachine.player.name} STILL HUNGRY");

                            stateMachine.SetState(stateMachine.searchState);
                        }
                        else
                        {
                            Debug.Log($"{stateMachine.player.name} NO HUNGRY");

                            stateMachine.SetState(stateMachine.patrolState);
                        }
                    }
                }
                else
                {
                    stateMachine.SetState(stateMachine.searchState);
                }
            }
        }
    }


    public override void StateExit(StateMachine stateMachine)
    {
    }
}
