using UnityEngine;

[CreateAssetMenu]
public class EatState : StateBase
{
    public override void StateEnter(StateMachine stateMachine)
    {
        Debug.Log($"{stateMachine.gameObject.name} Entered {name}");
    }

    public override void StateUpdate(StateMachine stateMachine)
    {
        //JESC

        foreach (FoodCenter foodCenter in MapGenerator.Instance.foodCenters)
        {
            if (stateMachine.player.transform.position == foodCenter.transform.position)
            {
                //jesc do limitu albo do wyczerpania


            }
        }


        if (stateMachine.player.currentFood < stateMachine.player.maxFood * stateMachine.player.smallFoodAmountThreshold)
        {
            stateMachine.SetState(stateMachine.searchState);
        }
        else
        {
            stateMachine.SetState(stateMachine.patrolState);
        }
    }

    public override void StateExit(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }
}
