using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _shootAnimation;

    public void PlaySoot()
    {
        _animator.Play(_shootAnimation);
    }
}
