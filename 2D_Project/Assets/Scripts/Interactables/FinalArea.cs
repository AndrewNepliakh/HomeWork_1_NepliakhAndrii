using System;
using UnityEngine;

public class FinalArea : MonoBehaviour
{
    public Action OnInteract;
    
    public void Interact()
    {
        OnInteract?.Invoke();
    }
}
