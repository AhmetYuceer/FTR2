using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndlessGameManager : MonoBehaviour
{
    //Score
    static public int score;
    static private int addScoreValue = 1;

    //Score UI
    [SerializeField] private TextMeshProUGUI scoreText;
    
    //Area Spawnner
    static public int thisAreaValue;
    [SerializeField] private List<GameObject> areaList = new List<GameObject>();
    
    //Time
    [SerializeField] private TextMeshProUGUI timeText;
    public bool countdown;
    static public bool startTime;
    private float setaTime;
    private float time = 0;

    //End
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI endTimeText;
    public static bool isDead;
    

    private void Start() 
    {
        isDead = false;
        countdown = Endless_Menu.countdown;
        setaTime = Endless_Menu.time;
        thisAreaValue = 0;
        score = 0;
        startTime = false;
        ChancedTimeSettings();
    }
    private void Update() 
    {
        EndGame();
        ScoreTextUpdate ();
        StartTime();
    }

    private void EndGame()
    {
        if (isDead)
        {
            Time.timeScale = 0f;
            endPanel.SetActive(true);
        }
        else
        {
            endPanel.SetActive(false);
        }
    }

    public void spawnNewArea()
    {
        var spawnPos = areaList[thisAreaValue].transform.position;
        spawnPos.z += 300;
        GameObject area = Instantiate(areaList[thisAreaValue],spawnPos,Quaternion.identity);
        areaList.Add(area);
        RemoveArea(); 
        thisAreaValue++;
    }

    private void RemoveArea()
    {
        if (areaList.Count > 2)
        {
            Destroy(areaList[thisAreaValue - 1]);
            areaList.RemoveAt(thisAreaValue - 1);
            thisAreaValue = 0;
        }
    }

    static public void AddScore()
    {
        score += addScoreValue;
    } 

    private void ScoreTextUpdate ()
    {
        scoreText.text = score.ToString();
        endScoreText.text = score.ToString();
    }

    //Time Settings 

    private void ChancedTimeSettings()
    {
        if (!startTime)
        {
            if (countdown)
            {
                time = setaTime;
                startTime = true;
            }
            else
            {
                time = 0;
                startTime = true;;
            }
        }
    }

    private void StartTime()
    {
        if (startTime && countdown)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                isDead = true;
            }
            else
            {         
                TimeConvertText(time);   
            }
        }
        else if(startTime && !countdown)
        {
            time += Time.deltaTime;
            TimeConvertText(time);
        }
    }
    private void TimeConvertText(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60); 
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        endTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}