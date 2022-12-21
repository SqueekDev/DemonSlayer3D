using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    
    private Player _target;
    private NavMeshAgent _navMeshAgent;
    private Coroutine _burnCorutine;
    private Coroutine _freezeCorutine;
    private float _startSpeed;

    public Player Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _startSpeed = _navMeshAgent.speed;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void Burn(int damage, float burningTime)
    {
        if (_burnCorutine != null)
        {
            StopCoroutine(Burning(damage, burningTime));
        }

        _burnCorutine = StartCoroutine(Burning(damage, burningTime));
    }

    public void Freeze(float freezingTime, float freezingModifier)
    {
        if (_freezeCorutine != null)
        {
            StopCoroutine(Freezing(freezingTime, freezingModifier));
        }

        _burnCorutine = StartCoroutine(Freezing(freezingTime, freezingModifier));
    }

    private IEnumerator Burning(int damage, float burningTime)
    {
        float delayStep = 0.2f;
        WaitForSeconds delay = new WaitForSeconds(delayStep);

        for (float i = 0; i < burningTime; i += delayStep)
        {
            ApplyDamage(damage);
            yield return delay;
        }
    }

    private IEnumerator Freezing(float freezingTime, float freezingModifier)
    {
        _navMeshAgent.speed = _startSpeed / freezingModifier;
        yield return new WaitForSeconds(freezingTime);
        _navMeshAgent.speed = _startSpeed;
    }
}
