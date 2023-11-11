using UnityEngine;
using UnityEngine.UI;

public class ProfileButtonScript : MonoBehaviour
{
    public Button profileButton;
    public Sprite defaultSprite;

    void Start()
    {
        if (CameraScript.profilePicture != null)
        {
            // If a profile picture was taken with the camera, use it
            profileButton.image.sprite = Sprite.Create(CameraScript.profilePicture, new Rect(0, 0, CameraScript.profilePicture.width, CameraScript.profilePicture.height), new Vector2(0.5f, 0.5f));
        }
        else
        {
            // Otherwise, use the default picture
            profileButton.image.sprite = defaultSprite;
        }
    }
}
