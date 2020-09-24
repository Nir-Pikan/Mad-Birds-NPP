using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public  AudioMixer musicMixer;
    public  AudioMixer effectsMixer;

    public  Slider musicSlider;
    public  Slider effectsSlider;

    public TextMeshProUGUI musicPercentageText;
    public TextMeshProUGUI effectsPercentageText;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void OptionsGame()
    {
        musicSlider.value = AudioManager.musicSliderValue;
        musicPercentageText.text = Mathf.RoundToInt(AudioManager.musicSliderValue * 100) + "%";
        effectsSlider.value = AudioManager.effectsSliderValue;
        effectsPercentageText.text = Mathf.RoundToInt(AudioManager.effectsSliderValue * 100) + "%";
    }
}
