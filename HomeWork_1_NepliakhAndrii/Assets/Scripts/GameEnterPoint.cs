using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnterPoint : MonoBehaviour
{
    private const string MAIN_SCENE = "MainScene";
    void Start()
    {
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
