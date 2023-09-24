using UnityEngine;

public class CameraMover : MonoBehaviour
{
	public bool IsAllowFollow
	{
		get => _isAllowFollow;
		set => _isAllowFollow = value;
	}

	[SerializeField] private PlayerController _playerController;
	[SerializeField] private float _cameraMinRestrict;
	[SerializeField] private float _cameraMaxRestrict;
	private float _minY = 0.307f;
	private bool _isAllowFollow;

	private void LateUpdate()
	{
		if(!_isAllowFollow) return;
		if(_playerController.IsDead) return;
		
		Vector3 playerPosition = _playerController.transform.position;

		if (playerPosition.x >= _cameraMinRestrict && playerPosition.x <= _cameraMaxRestrict)
		{
			if (transform.position.x > _cameraMinRestrict && transform.position.x < _cameraMaxRestrict)
			{
				float y = Mathf.Clamp(playerPosition.y, _minY, float.MaxValue);
				transform.position = new Vector3(playerPosition.x, y, transform.position.z);
			}
		}
	}
}