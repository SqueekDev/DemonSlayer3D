using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private List<EnemyTransition> _transitions;

    protected Player Target { get; set; }

    public void Enter(Player target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    protected void CheckCorutine(Coroutine coroutine)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }
}
