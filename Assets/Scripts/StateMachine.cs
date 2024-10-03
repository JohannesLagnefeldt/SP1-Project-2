using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    [SerializeField] private State initialState;

    private State currentState;

    private void Start()
    {
        currentState = initialState;
        currentState.OnEnter();
    }

    private void Update()
    {
        State new_state = currentState.StateUpdate();
        if(new_state)
        {
            ChangeState(new_state);
        }
    }

    private void FixedUpdate()
    {
        State new_state = currentState.StateFixedUpdate();
        if (new_state)
        {
            ChangeState(new_state);
        }
    }

    private void LateUpdate()
    {
        State new_state = currentState.StateLateUpdate();
        if (new_state)
        {
            ChangeState(new_state);
        }
    }

    public void ChangeState(State newState)
    {
        // Exit the current state
        currentState.OnExit();

        // Assign the new state and enter it
        currentState = newState;
        currentState.OnEnter();
    }
}
