using System.Collections;
using UnityEngine;

public delegate void OnAudioPlay(AudioClip audioClip);

public class Launch : MonoBehaviour
{
	public event OnAudioPlay OnAudioPlay;
	
	[SerializeField] private GameObject _explosionPrefab;
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _lifeDuration;
	[SerializeField] private float _force;
	[SerializeField] private AudioClip _launchClip;
	[SerializeField] private AudioClip _explosionClip;
	[SerializeField] private AudioClip _postClip;
	
	private ParticleSystem _particleSystem;
    
    private IEnumerator Start()
    {
	    OnAudioPlay?.Invoke(_launchClip);
	    _particleSystem = GetComponent<ParticleSystem>();
	    _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
	    yield return new WaitForSeconds(_lifeDuration);
	    _particleSystem.Stop();
	    OnAudioPlay?.Invoke(_explosionClip);
	    OnAudioPlay?.Invoke(_postClip);
	    Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }
    
}
