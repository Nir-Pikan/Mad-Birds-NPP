using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void BackToMainMenu()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Victory");
        FindObjectOfType<AudioManager>().Play("Theme");
        SceneManager.LoadScene("Menu");
    }
}
