using Player;
using UnityEngine;

public class PlayerController : Character
{
	private readonly string _isFirstStartKey = "IsFirstStart";
	private readonly string _winMessage = "You win!\nPress Esc to restart";
	
	[SerializeField] private AudioManager _audioManager;
	[SerializeField] private GameManager _gameManager;
	[SerializeField] private CameraMover _cameraMover;
	[SerializeField] private PlayerShooter _shooter;
	[SerializeField] private UIManager _uiManager;

	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private Collider2D _collider2D;

	private Vector2 _deathForce = new Vector2(-1.0f, 2.0f);

	private int _platformLayer = 6;
	
	private void Death()
	{
		IsDead = true;
		_rigidbody2D.AddForce(_deathForce, ForceMode2D.Impulse);
		_collider2D.enabled = false;
		_uiManager.Show("GAME OVER");
		_audioManager.Play(AudioType.Fall);
		_gameManager.Restart();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent<Computar>(out var computar))
		{
			_uiManager.Show(computar.Message);
			_audioManager.Play(AudioType.Beep);
		}

		if (other.TryGetComponent<DeathZone>(out var deathZone))
		{
			IsDead = true;
			_uiManager.Show("GAME OVER");
			_audioManager.Play(AudioType.Fall);
			_gameManager.Restart();
		}

		if (other.TryGetComponent<InteractableButton>(out var button))
		{
			button.Interact();
			_audioManager.Play(AudioType.Interact);
		}
		
		if (other.TryGetComponent<FinalArea>(out var finalArea))
		{
			finalArea.Interact();
		}

		if (other.TryGetComponent<Projectile>(out var projectile))
		{
			projectile.Hit();
			Death();
		}
		
		if (other.TryGetComponent<Battery>(out var battery))
		{
			battery.Collect();
			_shooter.SetEnergy();
			_audioManager.Play(AudioType.Interact);
		}
		
		if (other.TryGetComponent<Portal>(out var portal))
		{
			_uiManager.Show(_winMessage);
			_audioManager.Play(AudioType.Portal);
			gameObject.SetActive(false);
			_gameManager.AllowRestart();
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.TryGetComponent<LadderThrough>(out var ladder))
		{
			IsOnLadder = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.TryGetComponent<Ladder>(out var ladder))
		{
			IsOnLadder = false;
			ladder.OnExit();
		}

		if (other.TryGetComponent<LadderThrough>(out var ladderThrough))
		{
			IsOnLadder = false;
		}

		if (other.TryGetComponent<Computar>(out var computar))
		{
			_uiManager.Close();
		}
		
		if (other.TryGetComponent<InteractableButton>(out var button))
		{
			button.Release();
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == _platformLayer)
		{
			if (_gameManager.IsFirstStart)
			{
				_uiManager.Show(WindowType.Tutorial);
				_gameManager.IsFirstStart = false;
				PlayerPrefs.SetInt(_isFirstStartKey, 1);
			}

			_cameraMover.IsAllowFollow = true;
		}
	}
}