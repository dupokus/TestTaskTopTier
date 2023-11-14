using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayUsername : MonoBehaviour
{
    public TMP_Text objectText;
    public TMP_InputField display;
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI bestScoreText;
    public Image profileImage;
    // Start is called before the first frame update
    void Start()
    {
        objectText.text = PlayerPrefs.GetString("username");

        // Load the last score from PlayerPrefs
        int lastScore = PlayerPrefs.GetInt("Score", 0);
        lastScoreText.text = "Last Score: " + lastScore.ToString();

        // Load the username from PlayerPrefs
        string username = PlayerPrefs.GetString("username", "Default Username");

        // Load the best score from PlayerPrefs for the current username
        int bestScore = PlayerPrefs.GetInt(username + "_HighScore", 0);
        bestScoreText.text = "Best Score: " + bestScore.ToString();

        // Load the profile picture from PlayerPrefs
        string base64 = PlayerPrefs.GetString("ProfilePicture");
        if (!string.IsNullOrEmpty(base64))
        {
            byte[] bytes = System.Convert.FromBase64String(base64);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            profileImage.sprite = Sprite.Create(texture, new Rect(0, 0,
                texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
    public void Create()
    {
        objectText.text = display.text;
        PlayerPrefs.SetString("username", objectText.text);
        PlayerPrefs.Save();
        string username = PlayerPrefs.GetString("username");
        int bestScore = PlayerPrefs.GetInt(username + "_HighScore", 0);
        bestScoreText.text = "Best Score: " + bestScore.ToString();

        int lastScore = PlayerPrefs.GetInt("Score", 0);
        lastScoreText.text = "Last Score: " + lastScore.ToString();

    }
}
