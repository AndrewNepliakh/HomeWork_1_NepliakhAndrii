using UnityEngine;

public class Battery : MonoBehaviour
{
	[SerializeField] private GameObject _hitVFXPrefab;
	
	public void Collect()
	{
		Instantiate(_hitVFXPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
