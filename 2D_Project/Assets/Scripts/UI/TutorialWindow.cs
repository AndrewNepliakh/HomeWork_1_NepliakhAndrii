using UI;
using UnityEngine;
using UnityEngine.UI;


public class TutorialWindow : Window
{
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(Close);
    }
    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Close);
    }

    private void Close()
    {
        _uiManager.Close();
    }
}
