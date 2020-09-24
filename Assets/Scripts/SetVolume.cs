using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public enum Caller { MUSIC,EFFECTS};
    public Caller caller;

    public void SetLevel(float sliderValue)
    {
        if (caller == Caller.MUSIC)
            AudioManager.musicSliderValue = sliderValue;
        else if (caller == Caller.EFFECTS)
            AudioManager.effectsSliderValue = sliderValue;
        else
        {
            Debug.Log("Caller Error!");
            return;
        }

        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

}
