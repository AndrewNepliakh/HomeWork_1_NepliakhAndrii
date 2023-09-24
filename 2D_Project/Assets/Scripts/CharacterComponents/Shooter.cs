using UnityEngine;

public class Shooter : MonoBehaviour
{
	public bool emitterCorrection;

	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private Projectile _projectile;
	[SerializeField] private Transform _projectileEmitterLeft;
	[SerializeField] private Transform _projectileEmitterRight;

	public void Shoot()
	{
		Transform projectileEmitter;
		Vector2 direction;

		if (!emitterCorrection)
		{
			projectileEmitter = _spriteRenderer.flipX ? _projectileEmitterRight : _projectileEmitterLeft;
			direction = _spriteRenderer.flipX ? Vector2.right : Vector2.left;
		}
		else
		{
			projectileEmitter = !_spriteRenderer.flipX ? _projectileEmitterRight : _projectileEmitterLeft;
			direction = _spriteRenderer.flipX ? Vector2.left : Vector2.right;
		}

		Projectile projectile = Instantiate(_projectile, projectileEmitter.position, Quaternion.identity);
		projectile.Move(direction);
	}
}