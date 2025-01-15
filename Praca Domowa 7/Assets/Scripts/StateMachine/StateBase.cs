using System;
using UnityEngine;

[Serializable]
public abstract class StateBase : ScriptableObject
{
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
