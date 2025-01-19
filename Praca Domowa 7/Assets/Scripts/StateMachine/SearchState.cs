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

        if (stateMachine.player.foodCenterList.Count == 0 || stateMachine.player.currentFood == stateMachine.player.maxFood)
        {
            stateMachine.SetState(stateMachine.patrolState);
        }
        else
        {

            FoodCenter bestCenter = null;
            float bestCount = 0;
            //idz do najlepszego punktu z jedzeniem
            //jak juz jest w punkcie to przejdz do EatState
            foreach (KeyValuePair<FoodCenter, int> keyValuePair in stateMachine.player.foodCenterList)
            {
                if (keyValuePair.Value / Vector3.Distance(keyValuePair.Key.transform.position, stateMachine.player.transform.position) > bestCount)
                {
                    bestCount = keyValuePair.Value / Vector3.Distance(keyValuePair.Key.transform.position, stateMachine.player.transform.position);
                    bestCenter = keyValuePair.Key;
                }
            }
            if (bestCenter != null)
            {
                if (stateMachine.player.transform.position.x > bestCenter.transform.position.x)
                {
                    stateMachine.player.transform.position += Vector3.left;
                }
                else if (stateMachine.player.transform.position.x < bestCenter.transform.position.x)
                {
                    stateMachine.player.transform.position += Vector3.right;
                }

                if (stateMachine.player.transform.position.y < bestCenter.transform.position.y)
                {
                    stateMachine.player.transform.position += Vector3.up;
                }
                else if (stateMachine.player.transform.position.y > bestCenter.transform.position.y)
                {
                    stateMachine.player.transform.position += Vector3.down;
                }

                if (Vector3.Distance(stateMachine.player.transform.position, bestCenter.transform.position) < 0.1f)
                {
                    stateMachine.SetState(stateMachine.eatState);
                }
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
