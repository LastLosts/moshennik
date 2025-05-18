using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    private int currentSceneID;

    public AudioResource mainMenu;
    public AudioResource episode1action1;
    public AudioResource episode1action2;
    public AudioResource episode1action3;

    private void Start()
    {
        currentSceneID = 0;
    }

    private void Update()
    {
        int sceneID = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneID == 1 && sceneID == 0)
        {
            audioSource.resource = mainMenu;
        }
        if (currentSceneID == 0 && sceneID == 1)
        {
            audioSource.Stop();
            audioSource.resource = null;
        }
    }
}
