using UnityEngine;
using UnityEngine.UIElements;

public class HandbookButton : MonoBehaviour
{
    public string playerPrefsKey;
    public Sprite defaultImage;
    public Sprite cyberattackImage;
    public GameObject cyberattackReadUI;
    public GameObject handbookUI;

    public void Start()
    {
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            int unlocked = PlayerPrefs.GetInt(playerPrefsKey);

            UnityEngine.UI.Image image = GetComponent<UnityEngine.UI.Image>();

            if (unlocked == 0)
            {
                image.sprite = defaultImage;
            }
            else
            {
                image.sprite = cyberattackImage;
            }
        }
        else
        {
            Debug.Log("No key found");
        }
    }

    public void OnClicked()
    {
        if (PlayerPrefs.GetInt(playerPrefsKey) != 0)
        {
            CyberattackReadPage cyberattackReadPage = cyberattackReadUI.GetComponent<CyberattackReadPage>();
            cyberattackReadUI.SetActive(true);
            cyberattackReadPage.Show(playerPrefsKey);
        }
    }
}
