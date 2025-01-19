using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalkState : StateBase
{
    public override void StateEnter(StateMachine stateMachine)
    {
        Debug.Log($"{stateMachine.gameObject.name} Entered {name}");
    }

    public override void StateUpdate(StateMachine stateMachine)
    {
        //wymienic informacje z innym Player em na tym samym miejscu
        foreach (Player player in stateMachine.player.GetAllPlayersButThisOne())
        {
            if (stateMachine.player.transform.position == player.transform.position)
            {
                Dictionary<FoodCenter, int> allKnownFoodCenters = null;

                foreach (KeyValuePair<FoodCenter, int> item in stateMachine.player.foodCenterList)
                {
                    allKnownFoodCenters.Add(item.Key, item.Value);
                }

                foreach (KeyValuePair<FoodCenter, int> item in player.foodCenterList)
                {
                    if (allKnownFoodCenters.ContainsKey(item.Key) && allKnownFoodCenters[item.Key] > item.Value)
                    {
                        allKnownFoodCenters[item.Key] = item.Value;
                    }
                    else
                    {
                        allKnownFoodCenters.Add(item.Key, item.Value);
                    }
                }

                //po tych 2 foreach mamy liste wszystjkich foodCenter ktore znaja, biorac pod uwage mniejsza ilosc jedzenia jezeli oba znaja naraz
                foreach (KeyValuePair<FoodCenter, int> item in allKnownFoodCenters)
                {
                    if (stateMachine.player.foodCenterList.ContainsKey(item.Key))
                    {
                        if (stateMachine.player.foodCenterList[item.Key] > item.Value)
                        {
                            stateMachine.player.foodCenterList[item.Key] = item.Value;
                        }
                    }

                    if (player.foodCenterList.ContainsKey(item.Key))
                    {
                        if (stateMachine.player.foodCenterList[item.Key] > item.Value)
                        {
                            stateMachine.player.foodCenterList[item.Key] = item.Value;
                        }
                    }
                }
            }
        }
        //po wymianie

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
    }
}
