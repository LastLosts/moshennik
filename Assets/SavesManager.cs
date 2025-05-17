using UnityEngine;
using PixelCrushers.DialogueSystem;

public class SavesManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Saving dialogue and conversation");
            PlayerPrefs.SetInt("dialogueID", DialogueManager.currentConversationState.subtitle.dialogueEntry.id);
            PlayerPrefs.SetString("conversationName", "1episode1action");
        }
    }
}
