using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Chase, Attack
}
public class FSM : MonoBehaviour
{
    private IState currentState;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    void Awake()
    {
        
    }

    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));

        TransitionState(StateType.Idle);
    }

    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType type)
    {
        if(currentState != null)
            currentState.OnExit();
        
        currentState = states[type];
        currentState.OnEnter();
    }
}
