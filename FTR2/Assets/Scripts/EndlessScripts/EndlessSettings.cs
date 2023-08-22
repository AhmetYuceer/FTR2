using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessSettings : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private bool isActiveSettingsPanel;


    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    private float sfxValue;
    private float musicValue;

    private void Start() 
    {
        sfxValue = Endless_Menu.sfxValue;
        musicValue = Endless_Menu.musicValue;
        sfxSlider.value = sfxValue;
        musicSlider.value = musicValue;
    }

    private void Update() 
    {
        SoundControl();
        SettingsPanelControl();  
    }

    private void SoundControl()
    {
        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;
    }

    public void ReturnGame()
    {
        isActiveSettingsPanel = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }


    private void SettingsPanelControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActiveSettingsPanel)
            {
                isActiveSettingsPanel = false;
            }
            else
            {
                isActiveSettingsPanel = true;
            }
        }    
        if (isActiveSettingsPanel)
        {
            Time.timeScale = 0;
            SettingsPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            SettingsPanel.SetActive(false);
        }
    }



}
