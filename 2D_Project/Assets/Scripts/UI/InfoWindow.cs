using TMPro;
using UI;
using UnityEngine;

public class InfoWindow : Window
{
    [SerializeField] private TMP_Text _message;

    public void SetMessage(string message)
    {
        _message.text = message;
    }
}
