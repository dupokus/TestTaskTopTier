using UnityEngine;
using UnityEngine.UI;
public class ProfilePictureScript : MonoBehaviour
{
    public Image profileImage;
    public Sprite defaultSprite;

    void Start()
    {
        if (CameraScript.profilePicture != null)
        {
            // If a profile picture was taken with the camera, use it
            profileImage.sprite = Sprite.Create(CameraScript.profilePicture,
                new Rect(0, 0, CameraScript.profilePicture.width, 
                CameraScript.profilePicture.height), new Vector2(0.5f, 0.5f));
        }
        else if (defaultSprite != null)
        {
            
            if (defaultSprite != null)
            {
                profileImage.sprite = defaultSprite;
            }
            else
            {
                Debug.LogError("Default profile picture not found");
            }
        }
        else
        {
            Debug.LogError("Profile image not assigned");
        }
    }
    public void FromFile_Clicked()
    {
        // Call a JavaScript function to open the file dialog
        Application.ExternalEval(
            @"
            window.UnityOpenFileDialog = function() {
                var input = document.createElement('input');
                input.type = 'file';
                input.accept = 'image/png,image/jpeg';
                input.onchange = function(event) {
                    var file = event.target.files[0];
                    var reader = new FileReader();
                    reader.onload = function(event) {
                        var base64 = event.target.result.split(',')[1];
                        SendMessage('ProfilePictureScript', 'OnFileSelected', base64);
                    };
                    reader.readAsDataURL(file);
                };
                input.click();
            };
            window.UnityOpenFileDialog();
            "
        );
    }
    public void OnFileSelected(string base64)
    {
        // Convert the base64 string to a Texture2D
        var bytes = System.Convert.FromBase64String(base64);
        var texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);

        // Set the profile picture
        profileImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
    }
    public void Default_Clicked()
    {

        profileImage.sprite = defaultSprite;
        Texture2D texture = new Texture2D(defaultSprite.texture.width, defaultSprite.texture.height);
        texture.SetPixels(defaultSprite.texture.GetPixels());
        texture.Apply();
        CameraScript.profilePicture = texture;
        // Convert the Texture2D to a byte array
        byte[] bytes = texture.EncodeToPNG();

        // Convert the byte array to a string
        string base64 = System.Convert.ToBase64String(bytes);

        // Save the string in PlayerPrefs
        PlayerPrefs.SetString("ProfilePicture", base64);
        base64 = PlayerPrefs.GetString("ProfilePicture");
        if (!string.IsNullOrEmpty(base64))
        {
            bytes = System.Convert.FromBase64String(base64);
            texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            profileImage.sprite = Sprite.Create(texture, new Rect(0, 0,
                texture.width, texture.height), new Vector2(0.5f, 0.5f));
            // Show the ProfileImage with the photo you took
            Color c = profileImage.color;
            c.a = 1f;
            profileImage.color = c;
        }
    }
}
