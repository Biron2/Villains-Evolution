using UnityEngine;
using YG;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Text musicPercentageText;
    [SerializeField] private Slider soundsSlider;
    [SerializeField] private Text soundsPercentageText;

    [SerializeField] private GameObject ru, en, tr;
    private void Start()
    {
        Time.timeScale = 1;
		AudioListener.pause = false;
        if (YandexGame.savesData.is_sounds_changed == true)
        {
            LoadData();
        }
        else
        {
            SetMusicVolume();
            SetSoundsVolume();
            YandexGame.savesData.is_sounds_changed = true;
        }

        if(YandexGame.lang == "ru")
        {
            ru.SetActive(false);
            en.SetActive(true);
            tr.SetActive(false);
        }
        else if (YandexGame.lang == "en")
        {
            ru.SetActive(false);
            en.SetActive(false);
            tr.SetActive(true);
        }
        else if (YandexGame.lang == "tr")
        {
            ru.SetActive(true);
            en.SetActive(false);
            tr.SetActive(false);
        }
    }
    public void ru_choose()
    {
        ru.SetActive(false);
        en.SetActive(true);
        tr.SetActive(false);
    }
    public void en_choose()
    {
        en.SetActive(false);
        tr.SetActive(true);
        ru.SetActive(false);
    }
    public void tr_choose()
    {
        tr.SetActive(false);
        ru.SetActive(true);
        tr.SetActive(false);
    }
    public void SetMusicVolume()
    {
        float volume_music = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume_music) * 20);
        YandexGame.savesData.music = volume_music;
        musicPercentageText.text = Mathf.RoundToInt(volume_music * 100) + "%";
        
        YandexGame.savesData.music = volume_music;
        YandexGame.SaveProgress();
    }
    public void SetSoundsVolume()
    {
        float volume_sfx = soundsSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume_sfx) * 20);
        YandexGame.savesData.sfx = volume_sfx;
        soundsPercentageText.text = Mathf.RoundToInt(volume_sfx * 100) + "%";
        
        YandexGame.savesData.sfx = volume_sfx;
        YandexGame.SaveProgress();
    }
    private void LoadData()
    {
        musicSlider.value = YandexGame.savesData.music;
        soundsSlider.value = YandexGame.savesData.sfx;

        SetMusicVolume();
        SetSoundsVolume();
    }
}