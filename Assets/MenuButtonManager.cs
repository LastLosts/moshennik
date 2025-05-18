using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class MenuButtonManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject handbookUI;

    private void ResetCyberattacks()
    {
        PlayerPrefs.SetInt("p1c1", 0);
        PlayerPrefs.SetInt("p1c2", 0);
        PlayerPrefs.SetInt("p1c3", 0);
        PlayerPrefs.SetInt("p2c1", 0);
        PlayerPrefs.SetInt("p2c2", 0);
        PlayerPrefs.SetInt("p2c3", 0);
        PlayerPrefs.SetInt("p3c1", 0);
        PlayerPrefs.SetInt("p3c2", 0);
        PlayerPrefs.SetInt("p3c3", 0);
    }

    public void NewGamePressed()
    {
        PlayerPrefs.SetString("conversationName", "Prologue");
        PlayerPrefs.SetInt("dialogueID", -1);
        ResetCyberattacks();
        SaveSystem.LoadScene("MainGame");
    }
    public void ContinuePressed()
    {
        if (PlayerPrefs.HasKey("conversationName") && PlayerPrefs.HasKey("dialogueID"))
        {
            Debug.Log("Loading convesation: " + PlayerPrefs.GetString("conversationName") + " ID:" + PlayerPrefs.GetInt("dialogueID").ToString());
            SaveSystem.LoadScene("MainGame");
        }
        else
        {
            Debug.Log("TODO hide the button");
        }
    }
    public void HandbookPressed()
    {
        handbookUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }
    public void SettingsPressed()
    {
        // TODO
    }
    public void QuitPressed()
    {
        Application.Quit();
    }
}
