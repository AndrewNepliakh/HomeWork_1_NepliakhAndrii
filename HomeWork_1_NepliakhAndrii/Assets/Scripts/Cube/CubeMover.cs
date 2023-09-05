using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    private KeyCode _keyCode;
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        ReadKey();
    }
    
    private void ReadKey()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _keyCode = KeyCode.W;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _keyCode = KeyCode.S;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _keyCode = KeyCode.A;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _keyCode = KeyCode.D;
        }
    }

    private void Move()
    {
        if (_keyCode == KeyCode.W)
        {
            _rigidbody.velocity += Vector3.forward * _speed;
        }
        if (_keyCode == KeyCode.S)
        {
            _rigidbody.velocity += Vector3.back * _speed;
        }
        if (_keyCode == KeyCode.A)
        {
            _rigidbody.velocity += Vector3.left * _speed;
        }
        if (_keyCode == KeyCode.D)
        {
            _rigidbody.velocity += Vector3.right * _speed;
        }
    }
}
