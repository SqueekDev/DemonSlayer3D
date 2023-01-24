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
    [SerializeField] private int _startDamage;
    [SerializeField] private float _startAttackDelay;
    
    private Player _target;
    private WorldBuilder _worldBuilder;
    private NavMeshAgent _navMeshAgent;
    private Coroutine _burnCorutine;
    private Coroutine _freezeCorutine;
    
    protected float CurrentSpeed;

    public int Reward => _reward;
    public int CurrentHealth => _health;
    public Player Target => _target;
    public int CurrentDamage { get; protected set; }
    public float CurrentAttackDelay { get; protected set; }
    public int MaxHealth { get; private set; }

    public event UnityAction<Enemy> Dying;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        CurrentAttackDelay = _startAttackDelay;
        CurrentSpeed = _navMeshAgent.speed;
    }

    public void Init(Player target, WorldBuilder worldBuilder)
    {
        _target = target;
        _worldBuilder = worldBuilder;
        CurrentDamage = _startDamage * _worldBuilder.StatsModifier;
        _health *= _worldBuilder.StatsModifier;
        MaxHealth = _health;
    }

    public virtual void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Dying?.Invoke(this);
    }

    public void Burn(int damage, float burningTime)
    {
        if (_burnCorutine != null)
            StopCoroutine(Burning(damage, burningTime));

        _burnCorutine = StartCoroutine(Burning(damage, burningTime));
    }

    public void Freeze(float freezingTime, float freezingModifier)
    {
        if (_freezeCorutine != null)
            StopCoroutine(Freezing(freezingTime, freezingModifier));

        _burnCorutine = StartCoroutine(Freezing(freezingTime, freezingModifier));
    }

    protected void ChangeSpeed()
    {
        _navMeshAgent.speed = CurrentSpeed;
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
        _navMeshAgent.speed = CurrentSpeed / freezingModifier;
        yield return new WaitForSeconds(freezingTime);
        _navMeshAgent.speed = CurrentSpeed;
    }
}
