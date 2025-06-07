using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Casino : MonoBehaviour
{
    public void OpenCasinoUI()
    {
        gameObject.SetActive(true);
    }
    private void Start()
    {
        DialogueManager.databaseManager.defaultDatabase.GetConversation("episode1action2").GetDialogueEntry(53).onExecute.AddListener(OpenCasinoUI);
        gameObject.SetActive(false);
    }
}
