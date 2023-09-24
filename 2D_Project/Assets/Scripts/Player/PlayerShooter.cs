using System.Collections;
using UnityEngine;

namespace Player
{
	public class PlayerShooter : Shooter
	{
		private readonly string _notEnoughEnergyMessage = "Not enough energy for shooting!\nLook for batteries";
		
		[SerializeField] private PlayerAnimation _playerAnimation;
		[SerializeField] private InputController _inputController;
		[SerializeField] private UIManager _uiManager;
		
		private Coroutine _timerRoutine;
		private Coroutine _showRoutine;
		
		private bool _isEnoughEnergy;
		private bool _isShoot;

		private void Update()
		{
			Shoot();
		}

		public void SetEnergy() => _isEnoughEnergy = true;

		private void Shoot()
		{
			if (_isShoot) return;
			if (_inputController.KeyCode == KeyCode.RightShift)
			{

				if (!_isEnoughEnergy)
				{
					if (_showRoutine != null)
					{
						StopCoroutine(_showRoutine);
						_showRoutine = null;
						_showRoutine = StartCoroutine(_uiManager.Show(_notEnoughEnergyMessage, 2.0f));
					}
					else
					{
						_showRoutine = StartCoroutine(_uiManager.Show(_notEnoughEnergyMessage, 2.0f));
					}
					return;
				}

				_isShoot = true;

				if (_timerRoutine != null)
				{
					StopCoroutine(_timerRoutine);
					_timerRoutine = null;
					_timerRoutine = StartCoroutine(TimerRoutine());
				}
				else
				{
					_timerRoutine = StartCoroutine(TimerRoutine());
				}

				_playerAnimation.Shoot();
				base.Shoot();
			}
		}

		private IEnumerator TimerRoutine()
		{
			yield return new WaitForSeconds(0.5f);
			_isShoot = false;
		}
	}
}