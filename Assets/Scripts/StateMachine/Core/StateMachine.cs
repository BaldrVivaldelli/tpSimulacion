using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StateMachine {

    private State _currentState;
    private List<State> _states = new List<State>();

    public void Update()
    {
        if (_currentState != null)
            _currentState.Execute();
    }

    public void AddState(State s)
    {
        _states.Add(s);
        if (_currentState == null)
            _currentState = s;
    }

    public void SetState<T>() where T : State
    {
        for (int i = 0; i < _states.Count; i++)
        {
            if (_states[i].GetType() == typeof(T))
            {
                if(_currentState != null)
                _currentState.Sleep();
                _currentState = _states[i];
                _currentState.Awake();
            }
        }
    }

    public bool IsActualState<T>() where T : State
    {
        return _currentState.GetType() == typeof(T);
    }

    private int getStateByType(Type m)
    {
        int stateTotal = _states.Count;
        for (int i = 0; i < stateTotal; i++)
            if (_states[i].GetType() == m)
                return i;
        return -1;
    }
}