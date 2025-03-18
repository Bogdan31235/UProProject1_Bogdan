using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateMachine 
{
    private Dictionary<Type, ILevelState> _levelStates = new Dictionary<Type, ILevelState>();
    private ILevelState _currentState;

    public ILevelState CurrentState {get => _currentState; }
     public void AddState(ILevelState state)
    {
        Type type = state.GetType();
        if (!_levelStates.ContainsKey(type))
            _levelStates.Add(type, state);
    }
    public void SetState(ILevelState state)
    {
        Type type = state.GetType();

        if(_currentState != null && _currentState.GetType() == type)
        {
            return;
        }
        if(_levelStates.TryGetValue(type,out ILevelState newState))
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
           
        }
    }

    public void Fixed()
    {
        _currentState.FixedDo();
    }
    public void Update()
    {
        _currentState.Do();
    }


}
