using UnityEngine;

[CreateAssetMenu]
public class DeathState : StateBase
{
    public override void StateEnter(StateMachine stateMachine)
    {
        Debug.Log($"{stateMachine.player.name} Entered {name}");
        Destroy(stateMachine.gameObject);
    }

    public override void StateUpdate(StateMachine stateMachine)
    {
    }

    public override void StateExit(StateMachine stateMachine)
    {
    }
}
