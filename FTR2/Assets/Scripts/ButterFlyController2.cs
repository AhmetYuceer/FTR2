using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterFlyController2 : MonoBehaviour
{
    /*
    Özge Hoca'dan gelecek olan bilgiye göre konumlanacak 3 farklı hareket var 
    bir tanesi 0 noktasında Kanatlar Tamamen açık dümdüz durması gerekiyor diye anlamıştım ben 
    ikincisinde içeriye doğru bükülme 
    üçüncüsünde dışa doğru bükülme olması lazım kanatlarda 
    */
    [SerializeField] private Animator animator;
    [SerializeField] private bool içeBükül;
    [SerializeField] private bool dışaBükül;

    //////////////////
    void Update()
    {
        float normalizedValue = normalizedValue = Mathf.InverseLerp(0f, 100f, Values.value);
        float value = Mathf.Lerp(0,1, normalizedValue);
       // AnimControl(value);
    }
/*
    private void AnimControl(float value)
    {   
        if (value == 0)
        {
            içeBükül = false;
            dışaBükül = false;
        }
        else if(value >= Values.içeBükülmeDeğeri / 100)
        {
            içeBükül = true;
            dışaBükül = false;
        }
        else if(value >= Values.dışaBükülmeDeğeri / 100)
        {
            dışaBükül = true;
            içeBükül = false;
        }
        animator.SetBool("iç",içeBükül);
        animator.SetBool("dış",dışaBükül);
    }
    */
}
