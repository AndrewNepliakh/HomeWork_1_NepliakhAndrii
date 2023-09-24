using System;
using Unity.Mathematics;
using UnityEngine;

public enum ProjectileType
{
	Player,
	Enemy
}

public class Projectile : MonoBehaviour
{
	public ProjectileType type;

	[SerializeField] private GameObject _hitVFXPrefab;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private float _speed;
	private Vector3 _direction;
	private float _lifeDuration = 1.5f;

	private void Start()
	{
		Destroy(gameObject, _lifeDuration);
	}

	private void Update()
	{
		transform.Translate(_direction * Time.deltaTime);
	}

	public void Move(Vector3 direction)
	{
		_spriteRenderer.flipX = direction.x < 0;
		_direction = direction;
	}

	public void Hit()
	{
		Instantiate(_hitVFXPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}