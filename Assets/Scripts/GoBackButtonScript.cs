using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackButtonScript : MonoBehaviour
{
    public string sceneName;

    public void GoBack_Clicked()
    {
        SceneManager.LoadScene(sceneName);
    }
}
