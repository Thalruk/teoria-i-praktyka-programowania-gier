using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] StateBase currentState;
    public Player player;
    private float time = 0.0f;
    [SerializeField] float interpolationPeriod = 0.5f;

    public PatrolState patrolState;
    public TalkState talkState;
    public SearchState searchState;
    public EatState eatState;
    public DeathState deathState;


    /// <summary>
    /// Alfabet wejściowy będzie zbiorem komunikatów postaci:
    ///  k1 - wyczerpany zasób punktów życia(0)
    ///  k2 - mała liczba punktów życia(1 − 499)
    ///  k3 - duża liczba punktów życia(500 − 999)
    ///  k4 - maksymalna liczba punktów życia(1000)
    ///  k5 - rozmowa
    ///  k6 - koniec rozmowy
    ///  k7 - odnaleziono punkt z pożywieniem
    ///  k8 - wyczerpanie zasobów pożywienia
    /// </summary>

    private void Awake()
    {
        currentState.StateEnter(this);
    }

    public void SetState(StateBase state)
    {
        currentState.StateExit(this);

        currentState = state;
        currentState.StateEnter(this);
    }

    public void Update()
    {
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            currentState.StateUpdate(this);
            time = 0;
        }
    }
}
