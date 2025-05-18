using UnityEngine;
using PixelCrushers.DialogueSystem;

public class TestScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerPrefs.SetInt("p1c1", 1);
            PlayerPrefs.SetInt("p1c3", 1);
        }
    }
}
