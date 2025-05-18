using UnityEngine;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class DialogueUIManager : MonoBehaviour
{
    private CustomDialogueUI _ui;

    private void GoMainMenu()
    {
        PlayerPrefs.SetInt("dialogueID", DialogueManager.currentConversationState.subtitle.dialogueEntry.id);
        PlayerPrefs.SetString("conversationName", ConversationManager.GetCurrentConversation());
        SaveSystem.LoadScene("MainMenu");
    }

    private void Start()
    {
        _ui = FindFirstObjectByType<CustomDialogueUI>();
        if (_ui == null)
        {
            Debug.Log("WHAT");
        }
        _ui.OnMainMenuButtonClicked += GoMainMenu;
    }
}
