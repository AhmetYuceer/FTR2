using UnityEngine;
public class ButterflyController : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private bool kasilma;
    [SerializeField] private bool gevseme;

    //Score
    private bool stage_1;
    private bool stage_2;

    //Alert
    private byte alertNumber;
    
    private void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
        kasilma = false;
        gevseme = false;
    }
    void Update()
    {
        float normalizedValue = Mathf.InverseLerp(0f, 100f, Values.value);
        float value = Mathf.Lerp(0,1, normalizedValue);
        animator.SetFloat("valueY",value);
        animControl(value);
    }
    private void animControl(float value)
    {
        if (value > 0 && value < 1)
        {
            gameManager.isAlertPanelOn = false;
            kasilma = true;
            stage_1 = true;
        }
        else
        {
            kasilma = false;
        }
        if (value == 1)
        {
            alertNumber = 1;
            AlertControl(alertNumber);
            gameManager.isAlertPanelOn = true;
            gevseme = true;
            stage_2 = true;
        }
        else if(value == 0)
        {
            ScoreControl(stage_1 , stage_2);
            alertNumber = 2;
            AlertControl(alertNumber);
            gameManager.isAlertPanelOn = true;
            gevseme = false;
            stage_1 = false;
            stage_2 = false;
        }
        animator.SetBool("kasılma" , kasilma);
        animator.SetBool("gevşeme" , gevseme);
    }
    private void AlertControl(byte alertNumber)
    {
        AlertsControl.alertNumber = alertNumber;
    }
    private void ScoreControl(bool stage_1 , bool stage_2)
    {
       if (stage_1 && stage_2)
       {
            gameManager.animatorScore.SetTrigger("add");
       }
    }
}