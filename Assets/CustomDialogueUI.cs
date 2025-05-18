using UnityEngine;

public class CustomDialogueUI : MonoBehaviour
{
    public delegate void MainMenuButtonClicked();
    public event MainMenuButtonClicked OnMainMenuButtonClicked;

    public void PressMainMenu()
    {
        OnMainMenuButtonClicked?.Invoke();
    }
}
