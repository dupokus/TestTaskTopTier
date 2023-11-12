using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");  // Load the score
        scoreText.text = "Score: " + score.ToString();
    }

    
}
