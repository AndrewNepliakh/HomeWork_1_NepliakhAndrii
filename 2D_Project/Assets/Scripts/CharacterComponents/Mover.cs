using UnityEngine;
using System;

public class Mover : MonoBehaviour
{
	public Action OnGroundCollide;
	
	[SerializeField] private PlayerController _playerController;
	[SerializeField] private InputController _inputController;
	[SerializeField] private Rigidbody2D _rigidbody;
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
	[Space(10)] [SerializeField] private float _minVelocityValue = 0.0f;
	[SerializeField] private float _maxVelocityValue = 5.0f;

	private bool _isCollide;
	private bool _isJump;

	private int _platformLayer = 6;
	private int _wallLayer = 7;
	

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		if(_playerController.IsDead) return;
		
		Vector2 velocity;

		if (_playerController.IsOnLadder)
		{
			if (_inputController.KeyCode == KeyCode.W)
			{
				velocity = new Vector2(_rigidbody.velocity.x, _speed);
				_rigidbody.velocity = new Vector2(Mathf.Clamp(velocity.x, -_maxVelocityValue, _minVelocityValue),
					velocity.y);
				return;
			}
		}

		if (_inputController.KeyCode == KeyCode.A)
		{
			if (_isCollide)
			{
				_rigidbody.velocity = new Vector2(0.0f, _rigidbody.velocity.y);
				return;
			}

			velocity = new Vector2(-_speed, _rigidbody.velocity.y);
			_rigidbody.velocity = new Vector2(Mathf.Clamp(velocity.x, -_maxVelocityValue, _minVelocityValue),
				velocity.y);
		}
		else if (_inputController.KeyCode == KeyCode.D)
		{
			if (_isCollide)
			{
				_rigidbody.velocity = new Vector2(0.0f, _rigidbody.velocity.y);
				return;
			}
			
			velocity = new Vector2(_speed, _rigidbody.velocity.y);
			_rigidbody.velocity = new Vector2(Mathf.Clamp(velocity.x, _minVelocityValue, _maxVelocityValue),
				velocity.y);
		}
		if (_inputController.KeyCode == KeyCode.Space)
		{
			if (_isJump) return;
			_isJump = true;
			_rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == _platformLayer)
		{
			_isJump = false;
			_isCollide = false;
			OnGroundCollide?.Invoke();
		}
		
		if (other.gameObject.layer == _wallLayer)
		{
			_isCollide = true;
		}
	}
}