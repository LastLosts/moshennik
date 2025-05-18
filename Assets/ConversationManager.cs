using UnityEngine;
using UnityEngine.Audio;
using PixelCrushers.DialogueSystem;
using System.Collections;

public class ConversationManager : MonoBehaviour
{
    public Texture2D episode1action1texture;
    public Texture2D episode1action2texture;
    public Texture2D episode1action3texture;

    public Animator animator;
    public AudioSource audioSource;
    public AudioResource episode1action1;
    public AudioResource episode1action2;
    public AudioResource episode1action3;

    private static string _currentConversation;
    private bool _fading = false;

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
            DialogueUIManager.ChangeBackground(episode1action1texture);
            _currentConversation = "episode1action1";
            audioSource.resource = episode1action1;
            audioSource.Play();
        }
        else if (_currentConversation == "episode1action1")
        {
            DialogueUIManager.ChangeBackground(episode1action2texture);
            _currentConversation = "episode1action2";
            audioSource.resource = episode1action2;
            audioSource.Play();
            PlayerPrefs.SetInt("p2c1", 1);
        }
        else if (_currentConversation == "episode1action2")
        {
            DialogueUIManager.ChangeBackground(episode1action3texture);
            _currentConversation = "episode1action3";
            audioSource.resource = episode1action3;
            audioSource.Play();
            PlayerPrefs.SetInt("p1c2", 1);
        }
        else if (_currentConversation == "episode1action3")
        {
            audioSource.Stop();
            _currentConversation = "NONE";
            PlayerPrefs.SetInt("p3c3", 1);
            return;
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
        if (DialogueManager.currentConversationState == null && !_fading)
        {
            _fading = true;
            StartCoroutine(Fade());
        }
    }
    private IEnumerator Fade()
    {
        animator.SetTrigger("Show");
        yield return new WaitForSeconds(0.5f);
        GetNextConversation();
        DialogueManager.StartConversation(_currentConversation);
        yield return new WaitForSeconds(0.8f);
        animator.SetTrigger("Hide");
        _fading = false;
    }
}
