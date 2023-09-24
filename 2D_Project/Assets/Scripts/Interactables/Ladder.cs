using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private void Start()
    {
        _mover.OnGroundCollide += OnGroundCollideHandler;
    }

    private void OnGroundCollideHandler()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void OnExit()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
