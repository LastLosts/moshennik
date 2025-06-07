using UnityEngine;
using UnityEngine.Audio;
using PixelCrushers.DialogueSystem;
using System.Collections;

public class ConversationManager : MonoBehaviour
{
    public Texture2D prologuetexture;
    public Texture2D episode1action1texture;
    public Texture2D episode1action2texture;
    public Texture2D episode1action3texture;

    public Texture2D ending1texture;
    public Texture2D ending2texture;

    public Animator animator;
    public AudioSource audioSource;
    public AudioResource episode1action1;
    public AudioResource episode1action2;
    public AudioResource episode1action3;

    public AudioResource ending1audio;

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

        if (_currentConversation == "Prologue")
        {
            DialogueUIManager.ChangeBackground(prologuetexture);
        }
        if (_currentConversation == "episode1action1")
        {
            DialogueUIManager.ChangeBackground(episode1action1texture);
            audioSource.resource = episode1action1;
            audioSource.Play();
        }
        if (_currentConversation == "episode1action2")
        {
            DialogueUIManager.ChangeBackground(episode1action2texture);
            audioSource.resource = episode1action2;
            audioSource.Play();
        }
        if (_currentConversation == "episode1action3")
        {
            DialogueUIManager.ChangeBackground(episode1action3texture);
            audioSource.resource = episode1action3;
            audioSource.Play();
        }
        if (_currentConversation == "ending1")
        {
            DialogueUIManager.ChangeBackground(ending1texture);
            audioSource.resource = ending1audio;
            audioSource.Play();
        }
        if (_currentConversation == "ending2")
        {
            DialogueUIManager.ChangeBackground(ending2texture);
            audioSource.resource = ending1audio;
            audioSource.Play();
        }

        // DialogueUIManager.ChangeBackground(episode1action1texture);
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
            // Variable v = DialogueManager.databaseManager.defaultDatabase.GetVariable("FailedTests");
            // for (int i = 0; i < v.fields.Count; i++)
            // {
            //     Debug.Log(v.fields[i].title);
            // }
            //
            //
    
            if (DialogueLua.GetVariable("FailedTests").asInt >= 2)
            {
                DialogueUIManager.ChangeBackground(ending2texture);
                audioSource.resource = ending1audio;
                audioSource.Play();
                _currentConversation = "ending2";
            }
            else
            {
                DialogueUIManager.ChangeBackground(ending1texture);
                audioSource.resource = ending1audio;
                audioSource.Play();
                _currentConversation = "ending1";
            }


            PlayerPrefs.SetInt("p3c3", 1);
            return;
        }
        else if (_currentConversation == "ending1" || _currentConversation == "ending2")
        {
            audioSource.Stop();
            _currentConversation = "NONE";
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
        if (DialogueManager.currentConversationState != null)
        {
            if (DialogueManager.currentConversationState.subtitle.speakerInfo.GetFieldText("Name") == "Максим")
            {
                DialogueManager.standardDialogueUI.conversationUIElements.subtitlePanels[0].portraitName.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); 
            }
            else
            {
                DialogueManager.standardDialogueUI.conversationUIElements.subtitlePanels[0].portraitName.color = new Color(0.6f, 0.4f, 0.8f, 1.0f); 
            }
        }
    }
    private IEnumerator Fade()
    {
        if (_currentConversation == "NONE")
        {
            yield return null;
        }
        else
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
}
