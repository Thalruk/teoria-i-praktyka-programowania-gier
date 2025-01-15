using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SearchState : StateBase
{
    public override void StateEnter(StateMachine stateMachine)
    {
        Debug.Log($"{stateMachine.gameObject.name} Entered {name}");
    }

    public override void StateUpdate(StateMachine stateMachine)
    {
        if (stateMachine.player.foodCenterList.Count == 0)
        {
            stateMachine.SetState(stateMachine.patrolState);
        }
        else
        {
            //idz do najlepszego punktu z jedzeniem
            //jak juz jest w punkcie to przejdz do EatState
            stateMachine.SetState(stateMachine.patrolState);
            foreach (KeyValuePair<FoodCenter, int> foodCenter in stateMachine.player.foodCenterList)
            {
                Debug.Log($"{stateMachine.player.name}--{foodCenter.Key.name}--{foodCenter.Value}");
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
