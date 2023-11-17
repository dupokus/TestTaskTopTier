using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    WebCamTexture tex;
    public RawImage display;
    public TMP_Text enableDisableText;
    public static Texture2D profilePicture;
    public UnityEngine.UI.Button goBackButton;
    public Image profileImage;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        profilePicture = LoadProfilePicture();
        if (profilePicture != null)
        {
            // If a profile picture was saved in PlayerPrefs, use it
            display.texture = profilePicture;
        }
        // Hide the ProfileImage at the beginning
        Color c = profileImage.color;
        c.a = 0f;
        profileImage.color = c;
    }

    public void EnableDisableCam_Clicked()
    {
        if (tex != null)
        {
            DisableCam();
            enableDisableText.text = "Enable Camera";
            goBackButton.gameObject.SetActive(true);
        }
        else
        {
            if (WebCamTexture.devices.Length > 0)
            {
                WebCamDevice device = WebCamTexture.devices[0];
                tex = new WebCamTexture(device.name);
                display.texture = tex;

                tex.Play();
                enableDisableText.text = "Disable Camera";
                goBackButton.gameObject.SetActive(false);
                Color c = profileImage.color;
                c.a = 0f;
                profileImage.color = c;
            }
        }
    }

    private void DisableCam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
        // Load the profile picture from PlayerPrefs
        string base64 = PlayerPrefs.GetString("ProfilePicture");
        if (!string.IsNullOrEmpty(base64))
        {
            byte[] bytes = System.Convert.FromBase64String(base64);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            profileImage.sprite = Sprite.Create(texture, new Rect(0, 0,
                texture.width, texture.height), new Vector2(0.5f, 0.5f));
            // Show the ProfileImage with the photo you took
            Color c = profileImage.color;
            c.a = 1f;
            profileImage.color = c;
            Debug.Log("Texture width: " + texture.width + ", height: " + texture.height);  // Add this line
        }
    }

    public void SaveProfilePicture(Texture2D texture)
    {
        // Convert the Texture2D to a byte array
        byte[] bytes = texture.EncodeToPNG();

        // Convert the byte array to a string
        string base64 = System.Convert.ToBase64String(bytes);

        // Save the string in PlayerPrefs
        PlayerPrefs.SetString("ProfilePicture", base64);
    }

    public Texture2D LoadProfilePicture()
    {
        // Load the string from PlayerPrefs
        string base64 = PlayerPrefs.GetString("ProfilePicture");

        // If the string is empty, return null
        if (string.IsNullOrEmpty(base64))
            return null;

        // Convert the string to a byte array
        byte[] bytes = System.Convert.FromBase64String(base64);

        // Create a new Texture2D and load the byte array into it
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);

        Debug.Log("Loaded texture width: " + texture.width + ", height: " + texture.height);  // Add this line

        return texture;
    }

    public void TakePhoto_Clicked()
    {
        if (tex != null)
        {
            profilePicture = new Texture2D(tex.width, tex.height, TextureFormat.RGB24, false);
            profilePicture.SetPixels(tex.GetPixels());
            profilePicture.Apply();
            // Convert the Texture2D to a byte array
            byte[] bytes = profilePicture.EncodeToPNG();

            // Convert the byte array to a string
            string base64 = System.Convert.ToBase64String(bytes);

            Debug.Log("Saved texture width: " + profilePicture.width + ", height: " + profilePicture.height);
            // Call the JavaScript function to save the file
            // Define the JavaScript function
            string jsFunction = @"
            window.SaveFile = function(base64, fileName) {
                var link = document.createElement('a');
                link.download = fileName;
                link.href = 'data:application/octet-stream;base64,' + base64;
                link.click();
            };
        ";

            // Run the JavaScript function
            Application.ExternalEval(jsFunction);

            // Call the JavaScript function to save the file
            Application.ExternalEval("SaveFile('" + base64 + "', 'taken_photo.png');");

            // You can now use the byte array as you wish
            // For example, you can save it as a PNG image on disk:
            //System.IO.File.WriteAllBytes("taken_photo.png", bytes);
        }
        else
        {
            Debug.Log("Cannot take photo because the camera is not enabled.");
        }
    }
}