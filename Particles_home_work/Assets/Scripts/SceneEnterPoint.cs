using System.Collections;
using UnityEngine;

public class SceneEnterPoint : MonoBehaviour
{
	[SerializeField] private GameObject _launchPrefab;
	[SerializeField] private GameObject _ShotPrefab;
	[SerializeField] private AudioSource _audioSource;
    
    private IEnumerator Start()
    {
	    yield return new WaitForSeconds(1);
	    Launch launch = Instantiate(_launchPrefab, Vector3.zero, Quaternion.identity).GetComponent<Launch>();
	    launch.OnAudioPlay += PlayAudio;
	    Instantiate(_ShotPrefab, Vector3.zero, Quaternion.identity);
    }

    private void OnDestroy() =>  _launchPrefab.GetComponent<Launch>().OnAudioPlay -= PlayAudio;

    private void PlayAudio(AudioClip clip) => _audioSource.PlayOneShot(clip);
 
}
