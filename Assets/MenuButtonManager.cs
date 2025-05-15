using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public void NewGamePressed()
    {
        Debug.Log("SCENE");
        SceneManager.LoadScene("MainGame");
    }
    public void ContinuePressed()
    {
        SceneManager.LoadScene(1);
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
