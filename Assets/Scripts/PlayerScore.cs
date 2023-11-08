using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;  // player's score
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = score.ToString();
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
            Destroy(gameObject);
    }
}
