using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private readonly string _isFirstStartKey = "IsFirstStart";
    
    public bool IsFirstStart
    {
        get => _isFirstStat;
        set => _isFirstStat = value;
    }

    [SerializeField] private InputController _inputController;
    [SerializeField] private AudioManager _audioManager;
    private bool _isAllowRestart;
    private bool _isFirstStat;

    private void Awake()
    {
        _isFirstStat = PlayerPrefs.GetInt(_isFirstStartKey) == 0;
    }

    private void Update()
    {
        if(!_isAllowRestart) return;
        if (_inputController.KeyCode == KeyCode.Escape)
        {
            SceneManager.LoadScene("Game");
            _audioManager.Restart();
        }
    }

    public void Restart()
    {
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Game");
        _audioManager.Restart();
    }

    public void AllowRestart()
    {
        _isAllowRestart = true;
    }
}
