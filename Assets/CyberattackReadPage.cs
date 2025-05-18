using UnityEngine;
using UnityEngine.UIElements;

public class CyberattackReadPage : MonoBehaviour
{
    public UnityEngine.UI.Image image;

    public Sprite p1c1Sprite;
    public Sprite p1c2Sprite;
    public Sprite p1c3Sprite;
    public Sprite p2c1Sprite;
    public Sprite p2c2Sprite;
    public Sprite p2c3Sprite;
    public Sprite p3c1Sprite;
    public Sprite p3c2Sprite;
    public Sprite p3c3Sprite;

    public void Show(string key)
    {
        if (key == "p1c1")
        {
            image.sprite = p1c1Sprite;
        }
        if (key == "p1c2")
        {
            image.sprite = p1c2Sprite;
        }
        if (key == "p1c3")
        {
            image.sprite = p1c3Sprite;
        }
        if (key == "p2c1")
        {
            image.sprite = p2c1Sprite;
        }
        if (key == "p2c2")
        {
            image.sprite = p2c2Sprite;
        }
        if (key == "p2c3")
        {
            image.sprite = p2c3Sprite;
        }
        if (key == "p3c1")
        {
            image.sprite = p3c1Sprite;
        }
        if (key == "p3c2")
        {
            image.sprite = p3c2Sprite;
        }
        if (key == "p3c3")
        {
            image.sprite = p3c3Sprite;
        }
    }
}
