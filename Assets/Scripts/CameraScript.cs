using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    WebCamTexture tex;
    public RawImage display;
    public TMP_Text enableDisableText;
    public static Texture2D profilePicture;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void EnableDisableCam_Clicked()
    {
        if (tex != null)
        {
            DisableCam();
            enableDisableText.text = "Enable Camera";
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[0];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
            enableDisableText.text = "Disable Camera"; 
        }
}

    private void DisableCam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }

    public void TakePhoto_Clicked()
    {
        if (tex != null)
        {
            profilePicture = new Texture2D(tex.width, tex.height);
            profilePicture.SetPixels(tex.GetPixels());
            profilePicture.Apply();

            // Convert the photo to a byte array
            //byte[] bytes = photo.EncodeToPNG();

            // You can now use the byte array as you wish
            // For example, you can save it as a PNG image on disk:
            //System.IO.File.WriteAllBytes("photo.png", bytes);
        }
        else
        {
            Debug.Log("Cannot take photo because the camera is not enabled.");
        }
    }
}
