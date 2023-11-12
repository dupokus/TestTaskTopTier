using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndgameDisplay : MonoBehaviour
{
    public TextMeshProUGUI usernameText;
    public Image profileImage;
    public TextMeshProUGUI newBestText;
    void Start()
    {
        // Load the username from PlayerPrefs
        string username = PlayerPrefs.GetString("username");
        usernameText.text = username;

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
        // Load the score from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score");

        // Load the high score from PlayerPrefs
        int highScore = PlayerPrefs.GetInt(username + "_HighScore", 0);

        // If the score is higher than the high score, update the high score and display the "New best" message
        if (score > highScore || (score > 0 && highScore == 0))
        {
            PlayerPrefs.SetInt(username + "_HighScore", score);
            newBestText.text = "New best!";
        }
        else
        {
            newBestText.text = "";
        }
    }
}
