using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsSlider : MonoBehaviour
{
    //MUSIC SLIDER//
    public Slider musicVolume_S;
    public TMPro.TMP_Text musicVolText;

    [SerializeField] private GameObject musicManager;

    // Start is called before the first frame update
    private void Awake()
    {
        musicVolume_S.value = Settings.musicVolume;
        UpdateMusicVol();
    }

    public void UpdateMusicVol()
    {
        Settings.ChangeMusicVol((int)musicVolume_S.value);
        musicVolume_S.value = Settings.musicVolume;
        musicVolText.text = musicVolume_S.value.ToString();
        musicManager.GetComponent<AudioSource>().volume = ((float)Settings.musicVolume / 100);
    }
}
