using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool isAlertPanelOn {get;set;}
    
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    public Animator animatorScore; 

    [Header("Alert")]
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private TextMeshProUGUI alertText;
     
    private void Update() 
    {
        ScoreControl();
        AlertControl(AlertsControl.alertNumber);
    }
    private void AlertControl(byte alertNumber)
    {
        if (isAlertPanelOn)
        {
            switch (alertNumber)
            {
                case 0:
                     alertText.text = AlertsControl.alert_0;
                break;
                case 1:
                    alertText.text = AlertsControl.alert_1;
                break;
                case 2:
                    alertText.text = AlertsControl.alert_2;
                break;
            }
            alertPanel.SetActive(true);
        }
        else
        {
            alertPanel.SetActive(false);
        }
    }
    public void ScoreControl()
    {
        scoreText.text = Score.score.ToString();
    }
}