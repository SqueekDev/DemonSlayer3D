using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DyingState : EnemyState
{
    [SerializeField] private Collider _collider;
    [SerializeField] private AudioSource _audio;

    private readonly string _dieTriggetName = "Die";
    private Animator _animator;

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
        _audio.Play();
        _collider.enabled = false;
        float timeToDestroy = 2f;
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
