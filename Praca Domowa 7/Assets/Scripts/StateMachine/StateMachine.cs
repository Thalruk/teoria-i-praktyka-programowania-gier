using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] StateBase currentState;







    public void SetState(StateBase state)
    {
        currentState?.Exit();

        currentState = state;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
