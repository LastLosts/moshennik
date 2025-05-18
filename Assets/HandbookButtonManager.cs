using UnityEngine;

public class HandbookButtonManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject handbookUI;

    public void QuitPress()
    {
        mainMenuUI.SetActive(true);
        handbookUI.SetActive(false);
    }
}
