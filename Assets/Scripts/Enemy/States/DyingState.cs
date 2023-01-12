using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DyingState : EnemyState
{
    [SerializeField] private Collider _collider;

    private Animator _animator;
    private readonly string _dieTriggetName = "Die";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(DyingCorutine());
    }

    private IEnumerator DyingCorutine()
    {
        _animator.SetTrigger(_dieTriggetName);
        _collider.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
