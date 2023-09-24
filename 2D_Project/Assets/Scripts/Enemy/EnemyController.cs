using UnityEngine;

public class EnemyController : Character
{
	[SerializeField] private EnemyAnimation _enemyAnimation;
	[SerializeField] private Shooter _shooter;
	[SerializeField] private FinalArea _finalArea;
	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private Collider2D _collider2D;
	[SerializeField] private Portal _portal;
	private Vector2 _deathForce = new Vector2(-1.0f, 2.0f);

	private void Start()
	{
		_finalArea.OnInteract += OnActivate;
	}

	public void OnActivate()
	{
		_enemyAnimation.PlaySoot();
	}

	public void Shoot_AnimationEventMethod()
	{
		_shooter.Shoot();
	}

	private void OnDestroy()
	{
		_finalArea.OnInteract -= OnActivate;
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent<Projectile>(out var projectile))
		{
			projectile.Hit();
			Death();
		}
	}

	private void Death()
	{
		IsDead = true;
		_rigidbody2D.AddForce(_deathForce, ForceMode2D.Impulse);
		_collider2D.enabled = false;
		Destroy(gameObject, 1.0f);
		_portal.Enable();
	}
}