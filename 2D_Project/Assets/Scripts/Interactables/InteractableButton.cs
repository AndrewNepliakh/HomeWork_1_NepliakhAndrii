using System;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    public Action OnInteract { get; set; }
    
    [SerializeField] private Sprite _releasedSprite;
    [SerializeField] private Sprite _pressedSprite;
    
    public void Release()
    {
        GetComponent<SpriteRenderer>().sprite = _releasedSprite;
    }
    
    public void Interact()
    {
        GetComponent<SpriteRenderer>().sprite = _pressedSprite; 
        OnInteract?.Invoke();
    }
}


