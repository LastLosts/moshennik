using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class MenuButtonManager : MonoBehaviour
{
    public void NewGamePressed()
    {
        SaveSystem.LoadScene("MainGame");
        DialogueManager.StartConversation("1episode1action");
        PlayerPrefs.SetString("conversationName", "1episode1action");
        PlayerPrefs.SetInt("dialogueID", 21);
    }
    public void ContinuePressed()
    {
        if (PlayerPrefs.HasKey("conversationName") && PlayerPrefs.HasKey("dialogueID"))
        {
            Debug.Log("Loading convesation: " + PlayerPrefs.GetString("conversationName") + PlayerPrefs.GetInt("dialogueID").ToString());
            SaveSystem.LoadScene("MainGame");
            DialogueManager.StartConversation(PlayerPrefs.GetString("conversationName"), null, null, PlayerPrefs.GetInt("dialogueID"));
        }
        else
        {
            Debug.Log("TODO creating emty save");
        }
    }
    public void SavesPressed()
    {
        // TODO
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
