using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayUsername : MonoBehaviour
{
    public TMP_Text objectText;
    public TMP_InputField display;
    // Start is called before the first frame update
    void Start()
    {
        objectText.text = PlayerPrefs.GetString("username");
    }
    public void Create()
    {
        objectText.text = display.text;
        PlayerPrefs.SetString("username", objectText.text);
        PlayerPrefs.Save();
    }
}
