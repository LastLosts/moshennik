using UnityEngine;
using UnityEngine.UI;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class DialogueUIManager : MonoBehaviour
{
    public static RawImage backgroundImage;
    private CustomDialogueUI _ui;

    public static void ChangeBackground(Texture2D texture)
    {
        backgroundImage.texture = texture;
    }

    private void GoMainMenu()
    {
        PlayerPrefs.SetInt("dialogueID", DialogueManager.currentConversationState.subtitle.dialogueEntry.id);
        PlayerPrefs.SetString("conversationName", ConversationManager.GetCurrentConversation());
        SaveSystem.LoadScene("MainMenu");
    }

    private void Start()
    {
        backgroundImage = GameObject.Find("BG").GetComponent<RawImage>();
        _ui = FindFirstObjectByType<CustomDialogueUI>();
        if (_ui == null)
        {
            Debug.Log("WHAT");
        }
        _ui.OnMainMenuButtonClicked += GoMainMenu;
    }
}
