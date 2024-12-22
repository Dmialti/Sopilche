using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private StateNode CurrentState;
    Dictionary<Type, StateNode> StateNodes;
    HashSet<ITransition> AnyTransitions;

    public void SetState(IState State)
    {
        CurrentState = GetOrAddNode(State);
        CurrentState.State.OnEnter();
    }
    private void ChangeState(IState newState)
    {
        if(CurrentState == newState) return;
        
        CurrentState.State?.OnExit();
        newState?.OnEnter();

        CurrentState = GetOrAddNode(newState);
    }
    private ITransition GetTransition()
    {
        foreach (var transition in AnyTransitions)
        {
            if (transition.Condition.Evaluate()) return transition;
        }
        foreach (var transition in CurrentState.Transitions)
        {
            if (transition.Condition.Evaluate()) return transition;
        }
        return null;
    }

    private StateNode GetOrAddNode(IState State)
    {
        StateNode node = StateNodes.GetValueOrDefault(State.GetType());
        if (node == null)
        {
            node = new StateNode(State);
            StateNodes.Add(State.GetType(), node);
        }
        return node;
    }
    public void AddTransition(IState from, IState to, IPredicate condition)
    {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
    }

    public void AddTransitions(List<Tuple<IState, IState, IPredicate>> transitions)
    {
        foreach (var transition in transitions)
            GetOrAddNode(transition.Item1).AddTransition(GetOrAddNode(transition.Item2).State, transition.Item3);
    }

    public void AddAnyTransition(IState to, IPredicate condition)
    {
        AnyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
    }
    public void AddAnyTransitions(List<Tuple<IState, IPredicate>> transitions)
    {
        foreach (var transition in transitions)
            AnyTransitions.Add(new Transition(GetOrAddNode(transition.Item1).State, transition.Item2));
    }

    public void Update()
    {
        ITransition transition = GetTransition();
        if (transition != null)
            ChangeState(transition.To);
        CurrentState?.State.Update();
    }

    public void FixedUpdate()
    {
        CurrentState.State?.FixedUpdate();
    }
}
