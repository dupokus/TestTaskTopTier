using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;  // player's score
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fpsText;
    public float deltaTime;
    void Start()
    {
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = ("FPS: " + Mathf.Ceil (fps).ToString ());
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PointParticle"))
        {
            score++;  // increment score
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);  // destroy the point particle
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("Endgame");
        }

    }
}
