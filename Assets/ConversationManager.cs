using UnityEngine;
using UnityEngine.Audio;
using PixelCrushers.DialogueSystem;

public class ConversationManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioResource episode1action1;
    public AudioResource episode1action2;
    public AudioResource episode1action3;

    private static string _currentConversation;

    static public string GetCurrentConversation()
    {
        return _currentConversation;
    }

    void Start()
    {
        DialogueManager.StopAllConversations();
        if (PlayerPrefs.HasKey("conversationName"))
        {
            _currentConversation = PlayerPrefs.GetString("conversationName");
        }
        else 
        {
            Debug.Log("Assert false");
        }
        DialogueManager.StartConversation(_currentConversation, null, null, PlayerPrefs.GetInt("dialogueID"));
    }

    private void GetNextConversation()
    {
        if (_currentConversation == "Prologue")
        {
            _currentConversation = "episode1action1";
            audioSource.resource = episode1action1;
            audioSource.Play();
        }
        else if (_currentConversation == "episode1action1")
        {
            _currentConversation = "episode1action2";
            audioSource.resource = episode1action2;
            audioSource.Play();
            PlayerPrefs.SetInt("p2c1", 1);
        }
        else if (_currentConversation == "episode1action2")
        {
            _currentConversation = "episode1action3";
            audioSource.resource = episode1action3;
            audioSource.Play();
            PlayerPrefs.SetInt("p1c2", 1);
        }
        else if (_currentConversation == "episode1action3")
        {
            audioSource.Stop();
            PlayerPrefs.SetInt("p3c3", 1);
        }
        else
        {
            Debug.Log("CANT HAPPEN");
            return;
        }
        PlayerPrefs.SetString("conversationName", _currentConversation);
        PlayerPrefs.SetInt("dialogueID", -1);
    }

    void Update()
    {
        if (DialogueManager.currentConversationState == null)
        {
            GetNextConversation();
            DialogueManager.StartConversation(_currentConversation);
        }
    }
}
