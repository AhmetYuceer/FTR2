using UnityEngine;
using TMPro;
public class TimeControl : MonoBehaviour
{
    public bool isTime;
    [SerializeField] private TextMeshProUGUI timeText;
    static public float time = 0;
    private void Start() 
    {
        isTime = true;
    }
    void Update()
    {
        if (isTime)
        {
            time += Time.deltaTime;
            TimeText(time);
        }
    }
    void TimeText(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60); 
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
