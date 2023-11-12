using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    void Start()
    {
        // Load the main menu after a delay
        Invoke("LoadMainMenu", 2.0f);  // 2 second delay
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
