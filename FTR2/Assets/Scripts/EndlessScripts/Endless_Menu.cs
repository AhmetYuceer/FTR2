using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Endless_Menu : MonoBehaviour
{
    public static Endless_Menu Instance;

    [Header("Sound Settings")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    public static float musicValue = 0.5f;
    public static float sfxValue = 0.5f;

    [Header("Panel Settings")]
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject menuPanel;
    [Header("Countdown Settings")]
    [SerializeField] private Toggle toggle;
    public static bool countdown = false;
    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private TMP_InputField minutetext;
    [SerializeField] private TMP_InputField secondtext;

    static public float time;
    static public float minute;
    static public float second;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start() 
    {
        countdown = false;
        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    private void ToggleValueChanged(Toggle chance)
    {
        if (countdown == false)
        {
            countdown = true;    
            countdownPanel.SetActive(true);
        }
        else
        {
            countdown = false; 
            countdownPanel.SetActive(false);
        }
    }

    public void StartButton()
    {
        musicValue = musicSlider.value;
        sfxValue = sfxSlider.value;
        countdownSettings();
        SceneManager.LoadScene(2);
    }
    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void BackButton()
    {
        menuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    private void countdownSettings()
    {
        if (countdown)
        {
            time = 0;
            if (minutetext.text != "" && secondtext.text == "")
            {
                minute = float.Parse(minutetext.text);
                time += minute * 60; 
            }             
            else if(secondtext.text != "" && minutetext.text == "")
            {
                second = float.Parse(secondtext.text);
                time +=  second;
            }        
            else if(secondtext.text != "" && minutetext.text != "")
            {
                minute = float.Parse(minutetext.text);
                second = float.Parse(secondtext.text);
                time += minute * 60;
                time +=  second;
            }
            else if(secondtext.text == "" && minutetext.text == "")
            {
                countdown = false;
            }
        }
    }
}
