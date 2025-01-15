using System;
using UnityEngine;

[Serializable]
public abstract class StateBase : ScriptableObject
{
    public abstract void StateEnter(StateMachine stateMachine);
    public abstract void StateUpdate(StateMachine stateMachine);
    public abstract void StateExit(StateMachine stateMachine);
}
